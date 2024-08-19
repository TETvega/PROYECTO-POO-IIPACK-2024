import { useProducts } from "../../hooks/data/useProducts"
import { useEffect, useState } from "react"
import { CatalagoProductSkeleton } from "./CatalagoProductSkeleton"
import { ProductCard } from "./ProductCard"
import { Pagination } from "../../../../shared/components"
import { IoIosSearch } from "react-icons/io"

export const CatalagoProductsList = () => {
  const { products, loadProducts, isLoading } = useProducts();
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState('');
  const [fetching, setFetching] = useState(true); 

  useEffect(() => {
    if (fetching) {
      loadProducts(searchTerm, currentPage);
      setFetching(false); 
    }
  }, [fetching]);

  const handlePreviousPage = () => {
    if (products.data.hasPreviousPage) {
      setCurrentPage((prevPage) => prevPage - 1);
      setFetching(true); 
    }
  };

  const handleNextPage = () => {
    if (products.data.hasNextPage) {
      setCurrentPage((prevPage) => prevPage + 1);
      setFetching(true); 
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log('Pedrito, me electrocutaste');
    setFetching(true); 
  };

  const handleCurrentPage = (index = 1) => {
    setCurrentPage(index);
    setFetching(true); 
  };

  // if (isLoading) {
  //   return <Loading />;
  // }

  return (
    <div className="w-full mt-8">
      <div className="flex items-center justify-between">
        <h2 className="text-3xl font-bold text-gray-700 md:text-2xl">
          Productos
        </h2>
        {/* Formulario de Busqueda  */}
        <form onSubmit={handleSubmit} className="flex items-center bg-white rounded-lg  border-2 ">
          <div className="w-full">
            <input type="search"
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              className="w-full px-4 py-1 text-gray-800 rounded-full focus:outline-none"
              placeholder="Buscar"
            />
          </div>
          <div>
            <button type="submit"
            className="flex items-center bg-slate-800 justify-center w-12 h-12 text-white rounded-r-lg" >
              <IoIosSearch className="h-6 w-6" />
            </button>
          </div>
        </form>
        {/* Fin del Formulario de Busqueda  */}
      </div>
      {isLoading ? (
         
          <CatalagoProductSkeleton size={4} />
      
      ) : (
        <div className="mt-8 grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6 md:gap-8 lg:gap-10">
          {products?.data?.items?.length ? (
            products.data.items.map((product) => (
              <ProductCard key={product.id} product={product} />
            ))
          ) : (
            <p>Lo siento. No hay productos disponibles :(</p>
          )}
        </div>
      )}
      {/* Inicio de Paginación */}
      <div className="mt-8">
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
      </div>
      {/* Fin de Paginación */}
    </div>
  )
}
