import { Link } from "react-router-dom"

export const Header = () => {
  return (
    <div className="h-10">
        <header className="mt-2 ml-[100px]">
          <h2 className="text-2xl">
        <Link to="#" className="flex items-center space-x-4 cursor-pointer">
          <div className="flex items-center space-x-2 ">
            <img
              src="./../../../../public/siidni-logo.png"
              alt="Furniture Icon"
              className="object-cover object-center  w-14 h-14"
            />
          </div>
          <p>Siidni Rentals</p>
        </Link>
          </h2>
        </header>
    </div>
  )
}
