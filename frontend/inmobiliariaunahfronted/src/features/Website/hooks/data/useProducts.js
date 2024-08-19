import { useState } from "react"
import {getProductsList} from "../../../../shared/actions/products/products"

export const useProducts = () => {
  const [products, setProducts] = useState({});
  const [prodCats, setProductsCategory] = useState({});
  const [isLoading, setIsLoading] = useState(false);

  const loadProducts = async (searchTerm, page, category) => {
    setIsLoading(true);
    const result = await getProductsList(searchTerm, page,category);
    setProducts(result);
    setIsLoading(false);
  } 

  const loadProductsByCategory = async (id) => {
    setIsLoading(true);
    const result = await getAllByCategory(id);
    setProductsCategory(result);
    setIsLoading(false);
  }

//getProductsList

  return {
    // Properties
    products,
    isLoading,
    prodCats,
    // Methods
    loadProducts,
    loadProductsByCategory,
  }
}