import { IoIosSearch } from "react-icons/io"
import { BlogPostListSkeleton } from "./CatalagoProductSkeleton"
import { ProductCard } from "./ProductCard"
import { Pagination } from "../../../../shared/components"
import { useProducts } from "../../hooks/data"

export const CatalagoProductsList = () => {
  const { products, loadProducts, isLoading } = useProducts();
  const [currentPage, setCurrentPage] = useState(1);
  const [searchTerm, setSearchTerm] = useState('');
  const [fetching, setFetching] = useState(true);

  useEffect(() => {
    if(fetching) {
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
      setFetching(false);
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();    
    console.log('Buscando...');
    setFetching(true);
  }

  const handleCurrentPage = (index = 1) => {
    setCurrentPage(index);
    setFetching(true);
  }


  return (
    <div className="w-full lg:w-8/12">
      <div className="flex items-center justify-between">
        <h1 className="text-xl font-bold text-gray-700 md:text-2xl">
          Publicaciones
        </h1>
        <form onSubmit={handleSubmit} className="flex items-center bg-white rounded-lg">
          <div className="w-full">
            <input 
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
              type="search"
              className="w-full px-4 py-1 text-gray-800 rounded-full focus:outline-none"
              placeholder="Buscar"
            />
          </div>
          <div>
            <button type="submit"
            className="flex items-center bg-unah-yellow justify-center w-12 h-12 text-white rounded-r-lg" >
              <IoIosSearch className="h-6 w-6" />
            </button>
          </div>
        </form>
      </div>
      {isLoading ? (
        <BlogPostListSkeleton size={4} />
      ) : (
        <div className="mt-6">
          {posts?.data?.items?.length ? (
            posts.data.items.map((post) => (
              <ProductCard key={post.id} post={post} />
            ))
          ) : (
            <p>No hay publicaciones disponibles</p>
          )}
        </div>
      )}
      {/* Inicio de Paginación */}
      <div className="mt-8">
        <Pagination
          totalPages={posts?.data?.totalPages}
          hasNextPage={posts?.data?.hasNextPage}
          hasPreviousPage={posts?.data?.hasPreviousPage}
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
