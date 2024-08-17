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
      className={`px-3 py-2 mx-1 font-medium rounded-md ${
        !hasPreviousPage
          ? "bg-gray-400 text-white cursor-not-allowed"
          : "bg-cyan-800 text-white hover:bg-cyan-700"
      }`}
    >
      Anterior
    </button>

    {[...Array(totalPages)].map((value, index) => (
      <button
        key={generateId()}
        onClick={() => handleCurrentPage(index + 1)}
        className={`px-3 py-2 mx-1 font-medium rounded-md ${
          currentPage === index + 1
            ? "bg-cyan-800 text-white"
            : "bg-white text-gray-700 hover:bg-cyan-100"
        }`}
      >
        {index + 1}
      </button>
    ))}

    <button
      onClick={handleNextPage}
      disabled={!hasNextPage}
      className={`px-3 py-2 mx-1 font-medium rounded-md ${
        !hasNextPage
          ? "bg-gray-400 text-white cursor-not-allowed"
          : "bg-cyan-800 text-white hover:bg-cyan-700"
      }`}
    >
      Siguiente
    </button>
  </div>
);
};
