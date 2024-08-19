import { useState } from "react";
import { getAllCategoryProducts } from "../../../../shared/actions/categoryProducts/categoryProduct";

export const useCategoryProduct = () => {

    const [categoriesProd, setCategoriesProd] = useState({});
    const [isLoading, setIsLoading] = useState(false);
  
    const loadCategoriesProd = async () => {
      setIsLoading(true);
      const result = await getAllCategoryProducts();
      setCategoriesProd(result);
      setIsLoading(false);
    } 
  
    return {
      //Properties
      categoriesProd,
      isLoading,
          //Methods
          loadCategoriesProd,
    }
  
}
