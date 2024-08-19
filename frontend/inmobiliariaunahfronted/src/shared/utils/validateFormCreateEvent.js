  // función para validar los errores del Formulario
 export const validateFormCreateEvent = (data) => {
    const errors = {};

    if (!data.name) errors.name = "El nombre del evento es obligatorio.";
    if (!data.location) errors.location = "La ubicación es obligatoria.";
    if (!data.startDate) errors.startDate = "La fecha de inicio es obligatoria.";
    if (!data.endDate) errors.endDate = "La fecha de finalización es obligatoria.";
    if (data.startDate && data.endDate) {
        const startDate = new Date(data.startDate);
        const endDate = new Date(data.endDate);
    
        // Validar si endDate es menor que startDate
        if (endDate < startDate) {
          errors.startDate = "La Fecha de Inicio tiene que ser antes de la Fecha de Finalización";
        }
      }
    if (data.productos.length === 0)
      errors.selectedProducts = "Debe seleccionar al menos un producto.";

    return errors;
  };