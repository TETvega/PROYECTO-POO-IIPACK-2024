import { useParams } from "react-router-dom";
import { getEventById, updateEvent } from "../../../../shared/actions/events";
import { Pagination } from "../../../../shared/components";
import { useEvent, useProducts } from "../../hooks/data";
import { FormButtons } from "../events/FormButtons";
import { ProductGrid } from "../events/ProductGrid";
import { ProductsSelectGrid } from "../events/ProductsSelectGrid";
import { SelecOptions } from "../events/SelecOptions";
import { Alert, AlertPopUp2 } from "../utils";
import { AlertPopUp } from "../utils/AlertPopUp";
import { useEffect, useState } from "react";
import { convertToISO, formatDateShort, validateFormCreateEvent } from "../../../../shared/utils";


export const EditEventForm = () => {
  // Declaración de Objetos
  const { products, loadProducts, isLoading } = useProducts();
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState('');
  const [selectedCategory, setSelectedCategory] = useState('');
  const [fetching, setFetching] = useState(true);
  const [selectedProducts, setSelectedProducts] = useState([]);
  const [alert, setAlert] = useState({ message: "", isVisible: false});
  const [errors, setErrors] = useState({});
  const [formData, setFormData] = useState({
    name: "",
    location: "",
    startDate: "",
    endDate: "",
    productos: [{}],
  });
  const { id } = useParams();
  const { event, isLoadingEvent, loadEvent } = useEvent();
  const [ fetchingEV, setFetchingEV ] = useState(true)


  // Declaración de Funciones
  useEffect(()=>{
    if(fetchingEV)
    {
      loadEvent(id)
      setFetchingEV(false)
    }
  },[])
  useEffect(() => {
    if (event && event.data) {
      console.log('Event Data:', event.data); // Verifica que `event.data` tenga los datos correctos
  
      // Actualiza el estado del formulario con los datos del evento
      setFormData({
        name: event.data.name,
        location: event.data.location,
        startDate:formatDateShort( event.data.startDate),
        endDate: formatDateShort(event.data.endDate),
        productos: event.data.eventDetails.map( detail => ({
          id: detail.product.id,
          name: detail.product.name,
          quantity: detail.quantity,
          cost: detail.unitPrice,
        })),
      });
  
      // Actualiza el estado de selectedProducts
     setSelectedProducts(event.data.eventDetails.map( detail => ({
      id: detail.product.id,
      name: detail.product.name,
      quantity: detail.quantity,
      cost: detail.unitPrice
    })))
      console.log(formData);
      
      console.log('Selected Products:', selectedProducts); // Verifica si selectedProducts se está actualizando correctamente
    }
  }, [event]);
  
  const [successAlert, setSuccessAlert] = useState({
    isVisible: false,
    data: {},
  });

  //Respeta el Formulario 
  const resetForm = () => {
    setFormData({
      name: "",
      location: "",
      startDate: "",
      endDate: "",
      productos: [],
    });
    setSelectedProducts([]);
    setErrors({});
    setAlert({ message: "", isVisible: false });
  };


  // Cargar productos cuando sea necesario
  useEffect(() => {
    if (!fetching) return;
    console.log(selectedCategory);
    
    loadProducts(searchTerm, currentPage, selectedCategory);
    setFetching(false);
  }, [fetching, searchTerm, currentPage, loadProducts]);


//DECLARACIÓN DE HANDLES
  const handlePreviousPage = () => {
    if (products?.data?.hasPreviousPage) {
      setCurrentPage((prevPage) => prevPage - 1);
      setFetching(true);
    }
  };

  const handleNextPage = () => {
    if (products?.data?.hasNextPage) {
      setCurrentPage((prevPage) => prevPage + 1);
      setFetching(true);
    }
  };

  // cuando se presiona enviar evento
  const handleSubmit = async (e) => {
    e.preventDefault();

    // arreglando el Data que manda al backend
    const formDataToSubmit = {
      name: formData.name,
      location: formData.location,
      startDate: convertToISO(formData.startDate),
      endDate: convertToISO(formData.endDate),
      // mapeo correcto de los productos según lo que espera el backend
      productos: selectedProducts.map((product) => ({
        productId: product.id,
        quantity: product.quantity || 1,
      })),
    };
    //console.log(selectedProducts);

    console.log(formDataToSubmit);

    const validationErrors = validateFormCreateEvent(formDataToSubmit);
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    try {
      // se manda al operador del api
      const response = await updateEvent( id,formDataToSubmit);
      if (response.status) {
        resetForm();
        const updatedata = await getEventById(id) 
        setSuccessAlert({
          ...updatedata.data, // Aquí pasas todos los detalles del evento
          isVisible: true, // Añadimos isVisible para controlar la visibilidad del pop-up
        });
      } else {
        setAlert({
          message: "Error al crear el evento: " + response.message,
          isVisible: true,
        });
      }
    } catch (error) {
      setAlert({
        message: "Error en la solicitud: " + error.message,
        isVisible: true,
      });
    }

    setFetching(true);
  };
  // para cuando se escribe sobre el campo realizar la validación de los errores de nuevo
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevFormData) => {
      const newFormData = { ...prevFormData, [name]: value };
      const validationErrors = validateFormCreateEvent(newFormData);
      setErrors(validationErrors);
      return newFormData;
    });
  };
// para que al darle al botón de enter no se busque
  const handleEnter = (e) => {
    if (e.key === 'Enter') {
      e.preventDefault(); // Previene el envío del formulario o la acción predeterminada
    }
  }
  //Cancelación del evento y form
  const handleCancel = () => {
    setFormData({
      eventName: "",
      location: "",
      startDate: "",
      endDate: "",
      selectedProducts: [{}],
    });

    setErrors({});
  };
  const handleCurrentPage = (index = 1) => {
    setCurrentPage(index);
    setFetching(true);
  };

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value); // Actualiza el término de búsqueda
    setFetching(true); // Vuelve a cargar productos cuando cambia el término de búsqueda
  };

  // Maneja la selección de productos
  const handleProductSelect = (product) => {
    setSelectedProducts((prevSelected) =>
      prevSelected.find((item) => item.id === product.id)
        ? prevSelected // Si ya está seleccionado, no agregarlo de nuevo
        : [...prevSelected, product]
    );
  };

  // Maneja la eliminación de productos seleccionados
  const handleRemoveProduct = (id) => {
    setSelectedProducts((prevProducts) =>
      prevProducts.filter((product) => product.id !== id)
    );
  };
  // Actualiza la cantidad de un producto
  const handleUpdateQuantity = (id, quantity) => {
    setSelectedProducts((prevProducts) =>
      prevProducts.map((product) =>
        product.id === id ? { ...product, quantity: quantity } : product
      )
    );
  };
  // Actualiza el estado del Pop Up cuando se crea o edita evento
  const handleCreateAnotherEvent = () => {
    setSuccessAlert((prevState) => ({
      ...prevState,
      isVisible: false,
    }));
  };

    return (
      <div className="py-12 container ml-auto mr-auto flex items-center justify-center bg-gray-100 ">
        <div className="w-full p-4 ">
          {/* Formulario */}
          <form
            className="bg-white shadow-md px-8 pb-4 pt-6 mb-4 rounded-md"
            onSubmit={handleSubmit}
          >
            {successAlert.isVisible && (
              <AlertPopUp2
                eventDetails={successAlert}
                isUpdate={true}
                onCreateAnotherEvent={handleCreateAnotherEvent}
              />
            )}
            {alert.isVisible && (
              <AlertPopUp message={alert.message} onClose={handleCloseAlert} />
            )}
            {/* Cuerpo del Formulario */}
            <div className="mb-4 mt-4">
              {/* ROW 1 */}
              <div className="grid grid-flow-row sm:grid-flow-col gap-3">
                {/* row de nombre y lugar del evento */}
                <div className="sm:col-span-4 justify-center">
                  <label
                    className="block text-gray-700 text-sm font-bold mb-2"
                    htmlFor="name"
                  >
                    Nombre del Evento
                  </label>
                  <input
                    type="text"
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-md"
                    id="name"
                    name="name"
                    value={formData.name}
                    placeholder="Presentación UNAH"
                    onChange={handleInputChange}
                  />
                  {errors.name && <Alert errorMessage={errors.name} />}
                </div>
                {/* Row de las fechas del evento */}
                <div className="sm:col-span-4 justify-center">
                  <label
                    className="block text-gray-700 text-sm font-bold mb-2"
                    htmlFor="ubication"
                  >
                    Localización del Evento
                  </label>
                  <input
                    type="text"
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-md"
                    id="ubication"
                    name="location"
                    value={formData.location}
                    placeholder="Santa Rosa, Copán, Honduras"
                    onChange={handleInputChange}
                  />
                  {errors.location && <Alert errorMessage={errors.location} />}
                </div>
              </div>
              {/* ROW 2 */}
              <div className="grid grid-flow-row lg:grid-flow-col gap-3 mt-4 py-2">
                <div className="grid grid-flow-col gap-3">
                  <div className="sm:col-span-4 justify-center">
                    <label
                      className="block text-gray-700 text-sm font-bold mb-2"
                      htmlFor="startdate"
                    >
                      Fecha de Inicio
                    </label>
                    <input
                      type="date"
                      className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-md"
                      id="startdate"
                      name="startDate"
                      value={formData.startDate}
                      onChange={handleInputChange}
                    />
                    {errors.startDate && (
                      <Alert errorMessage={errors.startDate} />
                    )}
                  </div>
                  <div className="sm:col-span-4 justify-center">
                    <label
                      className="block text-gray-700 text-sm font-bold mb-2"
                      htmlFor="enddate"
                    >
                      Fecha de Finalización
                    </label>
                    <input
                      type="date"
                      className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-md"
                      id="enddate"
                      name="endDate"
                      value={formData.endDate}
                      onChange={handleInputChange}
                    />
                    {errors.endDate && <Alert errorMessage={errors.endDate} />}
                  </div>
                </div>
              </div>
              {/* ROW 3 PRODUCTOS seleccionados y listados de productos */}
              <div className="grid grid-flow-row lg:grid-flow-col gap-3 mt-8">
                {/* PARA LOS PRODUCTOS QUE SELECCIONA EL USUARIO  */}
                <div className="border rounded w-full shadow-md mb-4 mt-4 py-2">
                  {/* Encabezados */}
                  <div className="w-full justify-center items-center">
                    <h3 className="text-center font-bold text-gray-800">
                      Productos Seleccionados
                    </h3>
                  </div>
                  {/* Cuerpo  */}
                  <ProductsSelectGrid
                    selectedProducts={selectedProducts}
                    onRemoveProduct={handleRemoveProduct}
                    onUpdateQuantity={handleUpdateQuantity}
                  />
                </div>
                {/* Fin de los Productos que seleeciona el Usuario  */}
                <div className="border rounded w-full shadow-md mb-4 mt-4 px-6 py-2">
                  <div className="w-full justify-center items-center">
                    <h3 className="text-center font-bold text-gray-800">
                      Lista de Productos Existentes
                    </h3>
                  </div>
  
                  {/* Selector de Categoría y Buscador */}
                  <div className="flex items-center mb-4 mt-4">
                    <SelecOptions setSelectedCategory={setSelectedCategory} setFeching={setFetching}/>
  
                    <input
                      type="text"
                      placeholder="Buscar productos..."
                      name="searchTerm"
                      className="ml-4 shadow border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                      value={searchTerm}
                      onChange={(e) => setSearchTerm(e.target.value)}
                      onKeyDown={handleEnter}
                    />
  
                    <button
                      type="button"
                      className="ml-4 bg-blue-500 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                      onClick={handleSearchChange}
                    >
                      Buscar
                    </button>
                  </div>
  
                  {/* Lista de Productos */}
                  <div className="border rounded w-full shadow-md mb-4 mt-4 py-2">
                    <div className="w-full justify-center items-center">
                      <h3 className="text-center font-bold text-gray-800 mb-4">
                        Lista de Productos Existentes
                      </h3>
  
                      <ProductGrid
                        products={products}
                        isLoading={isLoading}
                        onProductSelect={handleProductSelect}
                      />
                      {/* Paginación */}
                      <Pagination
                        totalPages={products?.data?.totalPages}
                        hasNextPage={products?.data?.hasNextPage}
                        hasPreviousPage={products?.data?.hasPreviousPage}
                        currentPage={currentPage}
                        handleNextPage={handleNextPage}
                        handlePreviousPage={handlePreviousPage}
                        setCurrentPage={setCurrentPage}
                        handleCurrentPage={handleCurrentPage}
                      />
                      {/* Fin de Paginacion */}
                    </div>
                  </div>
                </div>
              </div>
              {/* row 4 botones */}
              <div className="grid grid-flow-row lg:grid-flow-col gap-3 mt-1">
                <FormButtons onSubmit={handleSubmit} onCancel={handleCancel} />
              </div>
            </div>
          </form>
          {/* Fin del Formulario */}
        </div>
      </div>
    );
  };
  