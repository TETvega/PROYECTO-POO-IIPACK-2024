import { useState } from "react";
import { MdOutlineCancel } from "react-icons/md";
import { TbFilePencil } from "react-icons/tb";
import { VscEye } from "react-icons/vsc";
import { formatDate } from "../../../shared/utils";
import { Link } from "react-router-dom";

export const EventItem = ({ event }) => {
  const [showDetails, setShowDetails] = useState(false);

  const toggleDetails = () => {
    setShowDetails(!showDetails);
  };

  return (
    <div className="bg-white rounded-lg shadow-md p-4 hover:bg-slate-100">
      <div className="mb-4 flex justify-between">
        <h2 className="text-lg font-bold">{event.name}</h2>
      </div>

      <div className="mb-4">
        {showDetails && (
          <section>
            <p className="text-sm text-gray-500">
              <strong>Ubicación:</strong> {event.location}
            </p>
            <p className="text-sm text-gray-500">
              <strong>Fecha de Inicio:</strong>{" "}
              {formatDate(event.startDate)}
            </p>
            <p className="text-sm text-gray-500">
              <strong>Fecha de Fin:</strong>{" "}
              {formatDate(event.endDate)}
            </p>
            {/* <p className="text-sm text-gray-500">
              <strong>Costo del Evento:</strong> ${event.eventCost.toFixed(2)}
            </p>
            <p className="text-sm text-gray-500">
              <strong>Descuento:</strong> ${event.discount.toFixed(2)}
            </p> */}
            <p className="text-sm text-gray-500">
              <strong>Total:</strong> ${event.total.toFixed(2)}
            </p>

            <table className="min-w-full bg-white mt-4 border">
              <thead>
                <tr className="bg-gray-100">
                  <th className="py-2 px-4 border">Imagen</th>
                  <th className="py-2 px-4 border">Producto</th>
                  <th className="py-2 px-4 border">Cantidad</th>
                  <th className="py-2 px-4 border">Precio Unitario</th>
                  <th className="py-2 px-4 border">Precio Total</th>
                </tr>
              </thead>
              <tbody>
                {event.eventDetails.map((detail) => (
                  <tr key={detail.id} className="border-b">
                    <td className="py-2 px-4 flex justify-center"><img src={detail.product.urlImage} width={50} alt="img-product" className="rounded-md shadow-md"  /></td>
                    <td className="py-2 px-4 border">{detail.product.name}</td>
                    <td className="py-2 px-4 border">{detail.quantity}</td>
                    <td className="py-2 px-4 border">
                      ${detail.unitPrice.toFixed(2)}
                    </td>
                    <td className="py-2 px-4 border">
                      ${detail.totalPrice.toFixed(2)}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </section>
        )}
      </div>

      <div className="flex justify-between">
        <button
          onClick={toggleDetails}
          className="flex items-center text-sm border border-gray-300 rounded px-3 py-1 hover:bg-blue-200"
        >
          <VscEye className="h-4 w-4 mr-2" />
          {showDetails ? "Ocultar Detalles" : "Ver Detalles"}
        </button>
        <Link
        to={`/my-event/edit/${event.id}`}
        className="flex items-center text-sm border border-gray-300 rounded px-3 py-1 hover:bg-orange-300">
          <TbFilePencil className="h-4 w-4 mr-2" />
          Editar
        </Link>
        <button className="flex items-center text-sm border border-gray-300 rounded px-3 py-1 hover:bg-red-500">
          <MdOutlineCancel className="h-4 w-4 mr-2" />
          Cancelar
        </button>
      </div>
    </div>
  );
};
