import { generateId } from "../utils";

export const Pagination = ({
    totalPages,
    handlePreviousPage = () => {},
    hasPreviousPage,
    handleCurrentPage,
    currentPage,
    handleNextPage = () => {},
    hasNextPage
}) => {
  return (
    <div className="flex">
      <button
        onClick={handlePreviousPage}
        disabled={!hasPreviousPage}
        className={`px-3 py-2 mx-1 font-medium bg-cyan-800 text-white rounded-md ${
          !hasPreviousPage
            ? "cursor-not-allowed"
            : "hover:bg-siidni-blue hover:text-white"
        }`}
      >
        Anterior
      </button>

      {[...Array(totalPages)].map((value, index) => (
        <button
          key={generateId()}
          onClick={() => handleCurrentPage(index + 1)}
          className={`px-3 py-2 mx-1 font-medium rounded-md text-gray-700 ${
            currentPage === index + 1
              ? "bg-siidni-blue text-white"
              : "hover:bg-siidni-blue hover:text-white"
          }`}
        >
          {index + 1}
        </button>
      ))}

      <button
        onClick={handleNextPage}
        disabled={!hasNextPage}
        className={`px-3 py-2 mx-1 font-medium bg-cyan-800 text-white rounded-md ${
          !hasNextPage
            ? "cursor-not-allowed"
            : "hover:bg-siidni-blue hover:text-white"
        }`}
      >
        Siguiente
      </button>
    </div>
  );
};