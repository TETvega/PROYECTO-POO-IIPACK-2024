import { useState } from "react";
import { Link } from "react-scroll";

export const NavBar = () => {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const handleMenuToggle = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  return (
    <nav className="px-6 py-4 bg-white shadow-md z-50 font-helvetica-new">
      <div className="container flex flex-col mx-auto md:flex-row md:items-center md:justify-between">
        <div className="flex items-center justify-between">
          <div>
            <Link
              to="init"
              smooth={true}
              duration={500}
              className="flex items-center space-x-2"
            >
              <img
                src="./../../../../public/siidni-logo.png"
                alt="Siidni Rentals Logo"
                className="object-cover w-14 h-14"
              />
              <p className="text-lg font-bold">Siidni Rentals</p>
            </Link>
          </div>
          <div>
            <button
              type="button"
              onClick={handleMenuToggle}
              className="block text-black hover:text-siidni-blueLight md:hidden"
            >
              <svg viewBox="0 0 24 24" className="w-6 h-6 fill-current">
                <path d="M4 5h16a1 1 0 0 1 0 2H4a1 1 0 1 1 0-2zm0 6h16a1 1 0 0 1 0 2H4a1 1 0 0 1 0-2zm0 6h16a1 1 0 0 1 0 2H4a1 1 0 1 1 0-2z"></path>
              </svg>
            </button>
          </div>
        </div>
        <div
          className={`${
            isMenuOpen ? "flex" : "hidden"
          } md:flex md:gap-6 flex-col md:flex-row bg-white`}
        >
          <Link
            to="/home"
            smooth={true}
            duration={500}
            className="my-2 text-lg font-medium text-gray-700 hover:underline underline-offset-4"
          >
            Home
          </Link>
          <Link
            to="servicesSec"
            smooth={true}
            duration={500}
            className="my-2 text-lg font-medium text-gray-700 hover:underline underline-offset-4"
          >
            Services
          </Link>
          <Link
            to="/home"
            smooth={true}
            duration={500}
            className="my-2 text-lg font-medium text-gray-700 hover:underline underline-offset-4"
          >
            Sobre nosotros
          </Link>
        </div>
      </div>
    </nav>
  );
};
