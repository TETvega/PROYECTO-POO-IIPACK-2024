import { Link } from "react-router-dom";
import { useRef, useState, useEffect } from "react";

import './../../index.css';
import { SideBar2 } from "./SideBar2";
import { BsFilterLeft } from "react-icons/bs";

export const Header = () => {
  const sideBar = useRef(null); // useRef para referenciar el componente SideBar2.
  const [isOpen, setIsOpen] = useState(false); // para controlar si el SideBar2 está abierto o cerrado.

  const toggleSidebar = () => {
    setIsOpen(!isOpen); // Invierte el valor de 'isOpen' cuando se llama.
  };

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (sideBar.current && !sideBar.current.contains(event.target)) {
        setIsOpen(false); // Cierra el sidebar si se hace clic fuera de él.
      }
    };

    document.addEventListener("mousedown", handleClickOutside);

    return () => {
      document.removeEventListener("mousedown", handleClickOutside);
    };
  }, []);

  return (
    <section className="relative">
        <span className="fixed z-50">
          <SideBar2 ref={sideBar} isOpen={isOpen} toggleSidebar={toggleSidebar} />
        </span>
        <header className="header ">
        <BsFilterLeft
          className="my-5 text-white text-2xl w-10 h-10 top-1 left-4 cursor-pointer fixed z-50 bg-siidni-brown rounded-md hover:border-2 hover:border-siidni-goldLight"
          onClick={toggleSidebar}
        />
          <div className="header-content flex items-center justify-between z-50 ">
            <Link to="/home" className="flex items-center space-x-4 cursor-pointer">
              <div className="flex items-center space-x-2">
                <img
                  src="https://i.postimg.cc/Y02vKjST/siidni-logo.png"
                  alt="Siidni Icon"
                  className="object-cover object-center"
                />
              </div>
              <span className="text-[#d56e18] text-4xl font-semibold  z-50">Siidni Rentals</span>
            </Link>
          </div>
        </header>
    </section>
  );
};
