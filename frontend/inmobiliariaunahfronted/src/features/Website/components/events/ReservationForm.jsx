import { useEffect, useState } from "react";
import { useProducts } from "../../hooks/data";
import { ProductGrid } from "./ProductGrid";
import { ProductsSelectGrid } from "./ProductsSelectGrid";
import { Pagination } from "../../../../shared/components";

export const ReservationForm = () => {
  const { products, loadProducts, isLoading } = useProducts();
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState("");
  const [selectedCategory, setSelectedCategory] = useState("");
  const [fetching, setFetching] = useState(true);
  const [selectedProducts, setSelectedProducts] = useState([]);

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

  const handleSubmit = (e) => {
    e.preventDefault();
    setFetching(true);
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
  const handleUpdateQuantity = (id, quantity) => {
    return {id,quantity}
  };


  return (
    <div className="py-12 container ml-auto mr-auto flex items-center justify-center bg-gray-100 ">
      <div className="w-full p-4 ">
        <form
          className="bg-white shadow-md px-8 pb-4 pt-6 mb-4 rounded-md"
          onSubmit={handleSubmit}
        >
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
                  placeholder="Presentación UNAH"
                />
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
                  name="ubication"
                  placeholder="Santa Rosa, Copán, Honduras"
                />
              </div>
            </div>
            <div className="grid grid-flow-row lg:grid-flow-col gap-3 mt-4 py-2">
              <div className="sm:col-span-4 justify-center">
                <label
                  className="block text-gray-700 text-sm font-bold mb-2"
                  htmlFor="email"
                >
                  Email
                </label>
                <input
                  type="email"
                  className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-md"
                  id="email"
                  name="email"
                  placeholder="albondigastostadas1@gmail.com"
                />
              </div>
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
                    name="startdate"
                  />
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
                    name="enddate"
                  />
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

                    <option value="Decoración">Decoración</option>
                    <option value="Ropa de Mesa">Ropa de Mesa</option>
                    <option value="Muebles">Muebles</option>
                  </select>

                  <input
                    type="text"
                    placeholder="Buscar productos..."
                    className="ml-4 shadow border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
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
          </div>
        </form>
      </div>
    </div>
  );
};
