import { generateId } from "../../../../shared/utils";

const CatalagoItemSkeleton = () => {
  return (
  
  <section >
    <div className="bg-background rounded-lg shadow-lg overflow-hidden max-w-sm mx-auto flex flex-col w-full mb-2 justify-evenly animate-pulse p-4">
    <div className="w-50 h-40 bg-gray-300 rounded mb-2"></div>
    <div className="p-4 flex flex-col flex-grow">
      <div className="h-6 bg-gray-300 rounded mb-2 w-3/4"></div>
      <div className="h-4 bg-gray-300 rounded mb-2 w-full"></div>
      <div className="h-4 bg-gray-300 rounded mb-2 w-1/2"></div>
      <div className="flex justify-start items-center space-x-4 mb-4">
        <div className="h-4 bg-gray-300 rounded w-1/4"></div>
        <div className="h-4 bg-gray-300 rounded w-1/4 ml-4"></div>
      </div>
    </div>
  </div>
  </section>


  );
};

export const CatalagoProductSkeleton = ({ size = 10 }) => {
  return (
    <div className="mt-6 grid grid-cols-4 max-w-screen-2xl">
      {[...Array(size)].map(() => (
        <CatalagoItemSkeleton key={generateId()} />
      ))}
    </div>
  );
};
