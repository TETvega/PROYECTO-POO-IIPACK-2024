// convertir de local a iso date 
export const convertToISO = (localDateString) => {
    // Crear un objeto Date con la fecha local
    const date = new Date(localDateString + 'T00:00:00'); 
    
    return date.toISOString();
  };