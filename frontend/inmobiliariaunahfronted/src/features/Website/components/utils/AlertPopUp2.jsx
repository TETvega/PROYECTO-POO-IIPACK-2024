import { Link } from "react-router-dom";
import { formatDate } from "../../../../shared/utils";

//Este se muestra cuando se crea o edita un evento y muestra los detalles del mismo ,
// recibe los datos de mapeo del objeto evento
export const AlertPopUp2 = ({ eventDetails, onCreateAnotherEvent  , isUpdate}) => {
  return (
    <div className="fixed z-50 inset-0 mt-8 flex items-center justify-center bg-black bg-opacity-50">
      <div className="max-w-2xl border rounded-lg bg-white shadow-lg">
        <div className="flex flex-col p-5 rounded-lg">
          <div className="flex">
            {/* Inicio del Icono de Alerta */}
            <div>
              <svg
                className="w-6 h-6 fill-current text-blue-500"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
              >
                <path d="M0 0h24v24H0V0z" fill="none" />
                <path d="M11 7h2v2h-2zm0 4h2v6h-2zm1-9C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 18c-4.41 0-8-3.59-8-8s3.59-8 8-8 8 3.59 8 8-3.59 8-8 8z" />
              </svg>
            </div>
            {/* Fin del Inicio de Icono de Alerta */}
            <div className="ml-3">
              {/*   Operación de llamada editado o creado */}
            <h2 className="font-semibold text-gray-800">
                {isUpdate ? "Evento Editado" : "Evento Creado"}
              </h2>
              <p className="mt-2 text-sm text-gray-600 leading-relaxed">
                {isUpdate
                  ? "¡El evento se ha editado con éxito! Aquí tienes los detalles:"
                  : "¡El evento se ha creado con éxito! Aquí tienes los detalles:"}
              </p>
              {/* Desglose del evento en cuestión */}
              <div className="mt-4">
                <h3 className="font-semibold text-gray-800">Detalles del Evento:</h3>
                <ul className="mt-2 text-sm text-gray-600">
                  <li><strong>Nombre:</strong> {eventDetails.name}</li>
                  <li><strong>Ubicación:</strong> {eventDetails.location}</li>
                  <li><strong>Fecha de Inicio:</strong> {formatDate(eventDetails.startDate)}</li>
                  <li><strong>Fecha de Fin:</strong> {formatDate(eventDetails.endDate)}</li>
                </ul>
                <h4 className="mt-4 font-semibold text-gray-800">Productos:</h4>
                <ul className="mt-2 text-sm text-gray-600">
                  {eventDetails.eventDetails.map((product, index) => (
                    <li key={index}>
                      <strong>Producto :</strong> {product.product.name} | 
                      <strong> Cantidad:</strong> {product.quantity} unidades | 
                      <strong> Costo Total:</strong> ${product.totalPrice}
                    </li>
                  ))}
                </ul>
                <h4 className="mt-4 font-semibold text-gray-800">Totales</h4>
                <ul className="mt-2 text-sm text-gray-600">
                  <li>
                    <strong>Subtotal: </strong> {eventDetails.eventCost}
                  </li>
                  <li>
                  <strong>Descuento: </strong> {eventDetails.discount}
                  </li>
                  <li>
                  <strong>Total: </strong> {eventDetails.total}
                  </li>
                </ul>
              </div>
            </div>
          </div>
          {/* CONTROL DE BOTONES DEL POP UP */}
          <div className="flex justify-end items-center mt-3">
          {!isUpdate && (
              <button
                className="px-4 py-2 bg-gray-100 hover:bg-gray-200 text-gray-800 text-sm font-medium rounded-md"
                onClick={onCreateAnotherEvent}
              >
                Crear Otro Evento
              </button>
            )}

            <Link to="/my-events" className="px-4 py-2 ml-2 bg-blue-500 hover:bg-blue-600 text-white text-sm font-medium rounded-md">
              Ir a Lista de Eventos
            </Link>
          </div>
          {/* Fin de Control de Botones de Pop Up */}
        </div>
      </div>
    </div>
  );
};