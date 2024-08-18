import { useEffect, useState } from "react";
import { useCategories, useProducts } from "../../hooks/data";
import { ProductGrid } from "./ProductGrid";
import { ProductsSelectGrid } from "./ProductsSelectGrid";
import { Pagination } from "../../../../shared/components";
import {
  convertToISO,
  validateFormCreateEvent,
} from "../../../../shared/utils";
import { Alert } from "../utils";
import { FormButtons } from "./FormButtons";
import { createEvent } from "../../../../shared/actions/events";
import { AlertPopUp } from "../utils/AlertPopUp";
import { AlertPopUp2 } from "../utils/AlertPopUp2";

export const ReservationForm = () => {
  const { products, loadProducts, isLoading } = useProducts();
  const { categories, loadCategories, isLoadingCategories } = useCategories();
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [selectedCategory, setSelectedCategory] = useState("");
  const [fetching, setFetching] = useState(true);
  const [selectedProducts, setSelectedProducts] = useState([]);
  const [alert, setAlert] = useState({ message: "", isVisible: false }); // la que salta por errores del backend
  const [errors, setErrors] = useState({});
  const [formData, setFormData] = useState({
    name: "",
    location: "",
    email: "",
    startDate: "",
    endDate: "",
    productos: [{}],
  });
  const [successAlert, setSuccessAlert] = useState({
    isVisible: false,
    data: {},
  });
  const resetForm = () => {
    setFormData({
      name: "",
      location: "",
      email: "",
      startDate: "",
      endDate: "",
      productos: [],
    });
    setSelectedProducts([]);
    setErrors({});
    setAlert({ message: "", isVisible: false });
  };
  useEffect(() => {
    loadCategories();
  }, [loadCategories]);

  useEffect(() => {
    if (fetching) {
      loadProducts(searchTerm, currentPage);
      setFetching(false);
    }
  }, [fetching, searchTerm, currentPage, loadProducts]);

  const handleCategoryChange = (e) => {
    setSelectedCategory(e.target.value);
    setFetching(true);
  };

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

  const handleSubmit = async (e) => {
    e.preventDefault();

    // arreglando el Data que manda al backend
    const formDataToSubmit = {
      name: formData.name,
      location: formData.location,
      startDate: convertToISO(formData.startDate),
      endDate: convertToISO(formData.endDate),
      // mapeo correcto de los productos segun lo que espera el backend
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
      const response = await createEvent(formDataToSubmit);
      if (response.status) {
        resetForm();
        setSuccessAlert({
          ...response.data, // Aquí pasas todos los detalles del evento
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

  const handleSearch = (e) => {
    setSearchTerm(e.target.value);
    setFetching(true);
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
  const handleCloseAlert = () => {
    setAlert({ ...alert, isVisible: false });
  };
  const handleCreateAnotherEvent = () => {
    setSuccessAlert((prevState) => ({
      ...prevState,
      isVisible: false,
    }));
  };

  return (
    <div className="py-12 container ml-auto mr-auto flex items-center justify-center bg-gray-100 ">
      <div className="w-full p-4 ">
        <form
          className="bg-white shadow-md px-8 pb-4 pt-6 mb-4 rounded-md"
          onSubmit={handleSubmit}
        >
          {successAlert.isVisible && (
            <AlertPopUp2
              eventDetails={successAlert}
              onCreateAnotherEvent={handleCreateAnotherEvent}
            />
          )}
          {alert.isVisible && (
            <AlertPopUp message={alert.message} onClose={handleCloseAlert} />
          )}
          <div className="mb-4 mt-4">
            <div className="grid grid-flow-row sm:grid-flow-col gap-3">
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
                  <select
                    className="shadow border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    value={selectedCategory}
                    onChange={handleCategoryChange}
                  >
                    <option value="">Todas las Categorías</option>
                    {/* el doble verificador si existe ejecuta el otro */}
                    {categories?.data?.length > 0 &&
                      categories.data.map((category) => (
                        <option key={category.id} value={category.id}>
                          {category.name}
                        </option>
                      ))}
                  </select>

                  <input
                    type="text"
                    placeholder="Buscar productos..."
                    className="ml-4 shadow border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    value={searchTerm}
                    onChange={handleInputChange}
                  />

                  <button
                    type="button"
                    className="ml-4 bg-blue-500 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                    onClick={handleSearch}
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
            <div className="grid grid-flow-row lg:grid-flow-col gap-3 mt-1">
              <FormButtons onSubmit={handleSubmit} onCancel={handleCancel} />
            </div>
          </div>
        </form>
      </div>
    </div>
  );
};
