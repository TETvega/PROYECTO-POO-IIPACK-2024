import { useEffect, useState } from "react";
import { Pagination } from "../../../../shared/components";

export const ProductsSelectGrid = ({
  selectedProducts,
  onRemoveProduct,
  onUpdateQuantity,
}) => {
  // Inicializa las cantidades con la cantidad en el producto seleccionado
  const [quantities, setQuantities] = useState({});
  useEffect(() => {
    const newQuantities = selectedProducts.reduce((acc, product) => {
      acc[product.id] = product.quantity || 1; 
      return acc;
    }, {});
    setQuantities(newQuantities);
  }, [selectedProducts]);

  const PRODUCTS_PER_PAGE = 10;
  const [currentPage, setCurrentPage] = useState(1);

  // Calcula el número total de páginas
  const totalPages = Math.ceil(selectedProducts.length / PRODUCTS_PER_PAGE);

  // Maneja el cambio en la cantidad
  const handleQuantityChange = (id, value) => {
    const intValue = parseInt(value, 10);
    if (intValue >= 0) {
      setQuantities((prev) => ({
        ...prev,
        [id]: intValue,
      }));
      onUpdateQuantity(id, intValue); // Notifica al componente padre sobre el cambio
    }
  };

  // Maneja la eliminación de un producto específico
  const handleRemoveClick = (id) => {
    onRemoveProduct(id);
  };

  // Cambia la página actual
  const handleCurrentPage = (page) => {
    setCurrentPage(page);
  };

  // Maneja el clic en la página anterior
  const handlePreviousPage = () => {
    setCurrentPage((prev) => Math.max(prev - 1, 1));
  };

  // Maneja el clic en la página siguiente
  const handleNextPage = () => {
    setCurrentPage((prev) => Math.min(prev + 1, totalPages));
  };

  // Calcula los productos a mostrar en la página actual
  const startIndex = (currentPage - 1) * PRODUCTS_PER_PAGE;
  const endIndex = Math.min(startIndex + PRODUCTS_PER_PAGE, selectedProducts.length);
  const currentProducts = selectedProducts.slice(startIndex, endIndex);

  return (
    <div className="mt-6">
      <table className="min-w-full divide-y divide-gray-200">
        <thead className="bg-gray-50">
          <tr>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Nombre
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Costo
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Cantidad
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Acciones
            </th>
          </tr>
        </thead>
        <tbody className="bg-white divide-y divide-gray-200">
          {currentProducts.length ? (
            currentProducts.map((product) => (
              <tr key={product.id} className="hover:bg-gray-100">
                <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
                  {product.name}
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                  {product.cost}
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                  <input
                    type="number"
                    min="0"
                    value={quantities[product.id] || 1}
                    onChange={(e) =>
                      handleQuantityChange(product.id, e.target.value)
                    }
                    className="border rounded px-2 py-1"
                  />
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                  <button
                    onClick={() => handleRemoveClick(product.id)}
                    className="px-4 py-2 bg-red-500 text-white rounded"
                  >
                    Eliminar
                  </button>
                </td>
              </tr>
            ))
          ) : (
            <tr>
              <td
                colSpan="4"
                className="px-6 py-4 whitespace-nowrap text-sm text-gray-500 text-center"
              >
                No hay productos seleccionados.
              </td>
            </tr>
          )}
        </tbody>
      </table>

      {/* Paginación */}
      <div className="mt-4">
        <Pagination
          totalPages={totalPages}
          handlePreviousPage={handlePreviousPage}
          hasPreviousPage={currentPage > 1}
          handleCurrentPage={handleCurrentPage}
          currentPage={currentPage}
          handleNextPage={handleNextPage}
          hasNextPage={currentPage < totalPages}
        />
      </div>
    </div>
  );
};
