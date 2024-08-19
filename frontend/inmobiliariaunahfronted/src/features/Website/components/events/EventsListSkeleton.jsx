import { generateId } from "../../../../shared/utils"

const EventItemSkeleton = () => {
    return(
        <div className="bg-gray-200 animate-pulse rounded-lg shadow-md p-4 mb-4">
      <div className="mb-4 flex items-center">
        <div className="bg-gray-300 rounded-full w-96 h-6 mr-1"></div>
        {/* <div className="bg-gray-300 rounded w-32 h-6"></div> */}
      </div>
      <div className="flex items-center mb-2">
        <div className="bg-gray-300 rounded-full w-4 h-4 mr-1"></div>
        <div className="bg-gray-300 rounded w-24 h-4"></div>
      </div>
      <div className="flex items-center mb-2">
        <div className="bg-gray-300 rounded-full w-6 h-6 mr-1"></div>
        <div className="bg-gray-300 rounded w-20 h-4"></div>
      </div>
      <div className="flex items-center mb-4">
        <div className="bg-gray-300 rounded-full w-6 h-6 mr-1"></div>
        <div className="bg-gray-300 rounded w-20 h-4"></div>
      </div>
        <div className="flex justify-between">
        <div className="bg-gray-300 rounded w-20 h-5"></div>
        <div className="bg-gray-300 rounded w-20 h-5"></div>
        <div className="bg-gray-300 rounded w-20 h-5"></div>
        </div>
    </div>
    )
}

export const EventsListSkeleton = ({ size = 10 }) => {
  return (
    <div className="">
      {[...Array(size)].map(() => (
        <EventItemSkeleton key={generateId()} />
      ))}
    </div>
  )
}
