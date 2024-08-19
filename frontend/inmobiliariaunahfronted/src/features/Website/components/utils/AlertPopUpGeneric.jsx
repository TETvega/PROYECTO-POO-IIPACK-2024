import { Link } from "react-router-dom";

export const AlertPopUpGeneric = ({ message, onDelete}) => {
  const handleOk = () => {
    console.log('Botón OK Presionado');
    onDelete();
  };
  return (
    <div className="fixed inset-0 mt-8 flex items-center justify-center bg-black bg-opacity-50">
      <div className="max-w-2xl border rounded-lg bg-white shadow-lg">
        <div className="flex flex-col p-5 rounded-lg">
          <div className="">
            <div className="flex">
              <svg
                className="w-6 h-max fill-current text-blue-500 mr-2"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
              >
                <path d="M0 0h24v24H0V0z" fill="none" />
                <path d="M11 7h2v2h-2zm0 4h2v6h-2zm1-9C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 18c-4.41 0-8-3.59-8-8s3.59-8 8-8 8 3.59 8 8-3.59 8-8 8z" />
              </svg>
            <h2 className="font-semibold text-gray-800  flex justify-self-center">
                {message}
              </h2>
            </div>

            <div className="ml-3">
              <p className="py-4 text-sm text-gray-600 leading-relaxed">
                ¡El evento se ha cancelado con éxito!
              </p>
             
            </div>
          </div>
            <span className="flex justify-center">
            <Link to="/reservation" className="px-4 py-2 ml-2 bg-siidni-goldLight hover:bg-siidni-gold text-white text-sm font-medium rounded-md flex justify-center">
              Volver a Reservar
            </Link>
            <button onClick={handleOk} className="px-4 py-2 ml-2 bg-blue-500 hover:bg-blue-600 text-white text-sm font-medium rounded-md flex justify-center">
              Okay
            </button>
            </span>
          </div>
        </div>
      </div>

  );
};