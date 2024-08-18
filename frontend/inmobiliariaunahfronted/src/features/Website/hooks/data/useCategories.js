import { useState } from "react"
import { getAllCategoryProducts } from "../../../../shared/actions/categoryProducts/categoryProduct";

export const useCategories = () => {
  const [categories, setCategories] = useState({});
  const [isLoadingCategories, setIsLoading] = useState(false);

  const loadCategories = async () => {
    setIsLoading(true);
    const result = await getAllCategoryProducts();
    setCategories(result);
    setIsLoading(false);
  } 



  return {
    // Properties
    categories,
    isLoadingCategories,
    // Methods
    loadCategories,
  }
}