export const FormButtons = ({ onSubmit, onCancel }) => {
    return (
      <div className="flex justify-end space-x-4 mt-4 w-full">
        <button
          type="button"
          onClick={onCancel}
          className="px-4 py-2 w-full bg-gray-500 text-white rounded hover:bg-gray-600 focus:outline-none focus:ring-2 focus:ring-gray-500 focus:ring-opacity-50"
        >
          Cancelar
        </button>
        <button
          type="submit"
          onClick={onSubmit}
          className="px-4 py-2 w-full bg-blue-500 text-white rounded hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-opacity-50"
        >
          Enviar
        </button>
      </div>
    );
  };