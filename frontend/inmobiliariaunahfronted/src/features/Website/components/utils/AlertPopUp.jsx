export const AlertPopUp = ({ message, onClose }) => {

    

    return (
        <div className="fixed z-50 inset-0 flex items-center justify-center p-4 bg-red-500 bg-opacity-75 text-white text-center">
          <div className="relative bg-red-600 rounded-lg shadow-lg p-4">
            <p>{message}</p>
            <button
              onClick={onClose}
              className="absolute top-2 right-2 p-1 bg-white text-red-500 rounded-full"
            >
              &times;
            </button>
          </div>
        </div>
      );
    };