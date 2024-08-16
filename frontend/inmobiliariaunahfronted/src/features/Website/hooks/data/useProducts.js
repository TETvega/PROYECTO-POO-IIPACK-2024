import { useState } from "react"
import { getProductsList } from "../../../../shared/actions/products";

export const useProducts = () => {
  const [product, setProducts] = useState({});
  const [isLoading, setIsLoading] = useState(false);

  const loadProducts = async (searchTerm, page) => {
    setIsLoading(true);
    const result = await getProductsList(searchTerm, page);
    setProducts(result);
    setIsLoading(false);
  } 



  return {
    // Properties
    product,
    isLoading,
    // Methods
    loadProducts,
  }
}