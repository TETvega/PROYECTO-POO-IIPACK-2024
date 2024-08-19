import { ProductGridItem } from "./ProductGridItem";

export const ProductGrid = ({ products, isLoading, onProductSelect }) => {
    const handleDoubleClick = (product) => {
      onProductSelect(product);
    };
  
    return (
      <div className="mt-6">
        {isLoading ? (
          <p className="text-gray-500">Cargando productos...</p> 
        ) : (
          <>
            {products?.data?.items?.length ? (
              <table className="min-w-full divide-y divide-gray-200">
                <thead className="bg-gray-50">
                  <tr>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Imagen</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Nombre</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Categoría</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Costo</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Stock</th>
                  </tr>
                </thead>
                <ProductGridItem products={products.data.items} handleDoubleClick={handleDoubleClick} />
              </table>
            ) : (
              <section className="">
                <span className="flex text-gray-500 justify-center mb-3">
                  <img src="https://i.postimg.cc/15KZsqSC/notfound.jpg" alt="404-Not-Found" className="w-80 rounded-md z-0" />
                </span>
                <span className="flex text-gray-500 justify-center mb-3">Nel, rey. Dele pa' fuera</span>
                </section> 
               
            )}
          </>
        )}
      </div>
    );
  };
  