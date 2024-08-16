import { webApi } from "../../../config/api/WebApi";



// Obtener todos los eventos ABSOLUTAMENTE TODOS
//TODO MODIFICAR EL BACKEND PARA EL EVENTOS DE TODOS Y DE PAGINATION
//TODO REVISAR SI HAY PAGINACION POR PARTE DEL BACKEND
export const getAllEvents = async (searchTerm = "", page = 1) => {
    try {
      const { data } = await webApi.get(`/eventos?searchTerm=${searchTerm}&page=${page}`);
  
      return data;
    } catch (error) {
      console.error(error);
      return error.response;
    }
  };
  
  // Obtener un evento por ID
  export const getEventById = async (id = 0) => {
    try {
      const { data } = await webApi.get(`/eventos/${id}`);
  
      return data;
    } catch (error) {
      console.error(error);
      return error.response;
    }
  };

// Crear un evento
export const createEvent = async (eventData) => {
  try {
    const { data } = await webApi.post('/eventos', eventData);

    return data;
  } catch (error) {
    console.error(error);
    return error.response;
  }
};

// Editar un evento
export const updateEvent = async (id, updatedData) => {
  try {
    const { data } = await webApi.put(`/eventos/${id}`, updatedData);

    return data;
  } catch (error) {
    console.error(error);
    return error.response;
  }
};

// Eliminar un evento
export const deleteEvent = async (id) => {
  try {
    const { data } = await webApi.delete(`/eventos/${id}`);

    return data;
  } catch (error) {
    console.error(error);
    return error.response;
  }
};
