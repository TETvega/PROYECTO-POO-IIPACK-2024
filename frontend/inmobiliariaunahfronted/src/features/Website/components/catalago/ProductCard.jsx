import { Link } from "react-router-dom";

export const ProductCard = ({ product }) => {
  return (
    <div
      key={product.id}
      className="max-w-sm px-2 py-4 mx-auto bg-white rounded-lg shadow-md mb-5 "
    >
      <img
        src={product.name}
        alt={product.name}
        className="w-full h-48 object-cover rounded-md"
      />
      <div className="mt-4">
        <h2 className="text-lg font-semibold text-gray-800">
          {product.name}
        </h2>
        <p className="mt-2 text-gray-600">
          <span className="font-medium">Categoría:</span> {product.category.name}
        </p>
        <p className="mt-1 text-gray-600">
          <span className="font-medium">Costo por unidad:</span> ${product.cost}
        </p>
        <p className="mt-1 text-gray-600">
          <span className="font-medium">Stock disponible:</span> {product.stock}
        </p>
      </div>
      <div className="flex items-center justify-between mt-4">
        <Link
          to={`/products/${product.id}`}
          className="text-unah-blue hover:underline"
        >
          Ver detalles
        </Link>
      </div>
    </div>
  );
};
