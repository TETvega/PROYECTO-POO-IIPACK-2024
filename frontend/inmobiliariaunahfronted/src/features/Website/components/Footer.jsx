import { Link } from "react-router-dom";
import { FaGithub } from "react-icons/fa"; // Asegúrate de tener instalada la librería react-icons

export const Footer = () => {
  const year = new Date().getFullYear();

  return (
    <footer className="bg-gray-100 py-6 md:py-8 lg:py-10">
      <div className="container px-4 sm:px-6 md:px-8 lg:px-10 flex flex-col md:flex-row items-center justify-between">
        <div className="flex items-center space-x-2">
          <a
            href="https://github.com/TETvega/PROYECTO-POO-IIPACK-2024"
            target="_blank"
            rel="noopener noreferrer"
            className="mx-2"
          >
            <FaGithub />
          </a>
          <p className="text-gray-600 text-sm md:text-base mt-0">
            &copy; {year} Siidni Rentals. Todos los derechos reservados.
          </p>
        </div>
        <nav className="flex items-center space-x-4 md:space-x-6 lg:space-x-8">
          <Link
            to="/privacy-policy"
            className="text-gray-600 hover:text-gray-800 transition-colors text-sm md:text-base"
          >
            Privacy Policy
          </Link>
          <Link
            to="/terms-of-service"
            className="text-gray-600 hover:text-gray-800 transition-colors text-sm md:text-base"
          >
            Terms of Service
          </Link>
        </nav>
      </div>
    </footer>
  );
};
