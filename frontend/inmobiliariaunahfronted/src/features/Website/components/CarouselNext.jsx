import { FaArrowLeft } from "react-icons/fa";

export const CarouselNext = ({ onClick }) => {
  return (
    <button
      onClick={onClick}
      className="bg-gray-800 text-white rounded-full p-2 shadow-md hover:bg-siidni-goldLight h-8"
      aria-label="Next"
    >
      <FaArrowLeft className="rotate-180" />
    </button>
  );
};
