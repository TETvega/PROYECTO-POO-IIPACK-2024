import { SelecOptions } from '../events/SelecOptions'
import { ProductGrid } from '../events/ProductGrid'
import { Pagination } from '../../../../shared/components'

export const SelectionProducts = () => {

  return (
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
  )
}
