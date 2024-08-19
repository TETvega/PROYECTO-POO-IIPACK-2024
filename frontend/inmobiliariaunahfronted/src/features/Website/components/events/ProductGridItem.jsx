export const ProductGridItem = ({ products = [], handleDoubleClick = () => {} }) => {
  return (
    <tbody className="bg-white divide-y divide-gray-200">
      {products.map((product) => (
        <tr
          key={product.id}
          onDoubleClick={() => handleDoubleClick(product)}
          className="hover:bg-gray-100 cursor-pointer"
        >
          <a href={product.urlImage} target="_blank" className="py-2 px-4 flex justify-center transform transition-transform duration-300 hover:scale-110"><img src={product.urlImage} width={50} alt="img-product" className="rounded-md shadow-md"  /></a>
          {/* <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
            {product.name}
          </td> */}
          <td className="px-6 py-4 whitespace-nowrap text-sm font-medium text-gray-900">
            {product.name}
          </td>
          <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
            {product.category.name}
          </td>
          <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
            {product.cost}
          </td>
          <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
            {product.stock}
          </td>
        </tr>
      ))}
    </tbody>
  );
};