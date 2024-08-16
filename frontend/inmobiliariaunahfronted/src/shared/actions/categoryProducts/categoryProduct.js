import { webApi } from "../../../config/api/WebApi";

// Obtener todas las categorias de productos
export const getAllCategoryProducts = async (searchTerm = "", page = 1) => {
  try {
    const { data } = await webApi.get(`/categoriesproducts?searchTerm=${searchTerm}&page=${page}`);

    return data;
  } catch (error) {
    console.error(error);
    return error.response;
  }
};

// Obtener una categoría de producto por ID
export const getCategoryProductById = async (id = 0) => {
  try {
    const { data } = await webApi.get(`/categoriesproducts/${id}`);

    return data;
  } catch (error) {
    console.error(error);
    return error.response;
  }
};

// Crear una nueva categoría de producto
export const createCategoryProduct = async (categoryData) => {
  try {
    const { data } = await webApi.post(`/categoriesproducts`, categoryData);

    return data;
  } catch (error) {
    console.error(error);
    return error.response;
  }
};

// Editar una categoría de producto
export const updateCategoryProduct = async (id, updatedData) => {
  try {
    const { data } = await webApi.put(`/categoriesproducts/${id}`, updatedData);

    return data;
  } catch (error) {
    console.error(error);
  }
};