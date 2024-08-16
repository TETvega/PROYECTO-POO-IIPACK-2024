import { generateId } from "../../../../shared/utils";

const CatalagoItemSkeleton = () => {
  return (
    <div className="max-w-24xl px-2 py-2 mx-auto bg-white rounded-lg shadow-md mb-5 animate-pulse">
      <div className="flex items-center justify-between">
        <span className="h-4 bg-gray-200 w-20"></span>
        <div className="flex gap-1">
          <div className="px-2 py-1 bg-gray-200 rounded w-16"></div>
          <div className="px-2 py-1 bg-gray-200 rounded w-16"></div>
        </div>
      </div>
      <div className="mt-2">
        <div className="h-6 bg-gray-200 rounded w-3/4 mb-2"></div>
        <div className="h-4 bg-gray-200 rounded w-full mb-2"></div>
        <div className="h-4 bg-gray-200 rounded w-full mb-2"></div>
        <div className="h-4 bg-gray-200 rounded w-2/3 mb-2"></div>
      </div>
      <div className="flex items-center justify-between mt-4">
        <div className="h-4 bg-gray-200 rounded w-20"></div>
        <div className="flex items-center">
          <div className="w-10 h-10 bg-gray-200 rounded-full mx-4"></div>
          <div className="h-4 bg-gray-200 rounded w-24"></div>
        </div>
      </div>
    </div>
  );
};

export const CatalagoProductSkeleton = ({size = 10}) => {
  return (
    <div className="mt-6">
      {[...Array(size)].map(() => (
        <CatalagoItemSkeleton key={generateId()} />
      ))}
    </div>
  );
};
