export const AlertPopUp = ({ message, onClose }) => {
  // cortar el mensaje por el .
  const messages = message.split('. ').filter(msg => msg.length > 0);
  
  return (
    <div className="fixed z-50 inset-0 flex items-center justify-center p-4 bg-red-500 bg-opacity-75 text-white text-center">
      <div className="relative bg-red-600 rounded-lg shadow-lg p-4">
        {/* Muestra el mensaje con los saltos de línea */}
        {messages.map((msg, index) => (
          <div key={index}>
            <p>{msg}.</p>
            <br />
          </div>
        ))}
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