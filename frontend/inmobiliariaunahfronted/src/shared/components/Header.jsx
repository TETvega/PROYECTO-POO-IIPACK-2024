import { Link } from "react-router-dom"
import './../../index.css'

export const Header = () => {
  return (
    <header className="header">
      <div className="header-content">
        <Link to="#" className="flex items-center space-x-4 cursor-pointer">
          <div className="flex items-center space-x-2">
            <img
              src="https://i.postimg.cc/Y02vKjST/siidni-logo.png" // Verifica que la ruta sea correcta
              alt="Furniture Icon"
              className="object-cover object-center"
            />
          </div>
          <p>Siidni Rentals</p>
        </Link>
      </div>
    </header>
  );
};
