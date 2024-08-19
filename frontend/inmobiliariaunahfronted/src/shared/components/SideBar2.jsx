import { CiSearch } from "react-icons/ci";
import { FaHome } from "react-icons/fa";
import { IoExitOutline, IoHomeOutline } from "react-icons/io5";
import { MdExpandCircleDown, MdOutlineProductionQuantityLimits } from "react-icons/md";
import { IoIosArrowDown } from "react-icons/io";
import React, { useState } from "react";
import { Link } from "react-router-dom";
import { LuCalendarPlus } from "react-icons/lu";
import { RiCalendarScheduleLine } from "react-icons/ri";

//Este es el sidebar ajustado y responsivo en cierta manera
export const SideBar2 = React.forwardRef(({ isOpen, toggleSidebar }, ref) => {
  // se usa 'React.forwardRef' para permitir recibir la referencia (ref) junto con las demás propiedades
  // Se debe colocar las iguientes declaraciones dentro del componente SideBar para manejar el comportamiento
  const [isOpenMenu, setIsOpenMenu] = useState(false);

  const toggleDropdown = () => {
    setIsOpenMenu(!isOpenMenu);
  };
  return (
    <div className="items-center">
      {/* Inicio del Aside  */}
      <div
        ref={ref}
        className={`sidebar fixed top-0 bottom-0 p-2 w-[300px] overflow-y-auto text-center bg-gray-900 ${
          isOpen ? "left-0" : "left-[-300px]"
        } transition-all duration-300
        
        `}
      >
        {/* PARTE DE LA IDENTIDAD  */}
        <div className="text-gray-100 text-xl">
          {/* Nombre Principal e Icono */}
          <div className="p-2 mt-1 flex items-center justify-between">
            <div className="flex items-center">
              <FaHome className="py-0.3 cursor-pointer" />
              <span className="font-bold text-gray-200 ml-3 text-3xl">
                Siidni{" "}
              </span>
            </div>

            <div className="mr-3">
              <IoExitOutline
                className=" cursor-pointer text-white rotate-180"
                onClick={toggleSidebar}
              />
            </div>
          </div>
          {/* Fin del Nombre Principal e Icono */}
          <hr className="my-2 text-gray-600" />
        </div>
        {/* PARTE DE LA BÚSQUEDA  */}
        <div className=" flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer bg-gray-700">
          <CiSearch />
          <input
            type="text"
            placeholder="Search"
            className="text-sm ml-4 w-full bg-transparent focus:outline-none"
          />
        </div>
        {/* PARTE DE LOS MENU  */}
        {/* Item de Menu  */}
        <Link to="/home">
          <div className=" flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer hover:bg-blue-500">
            <IoHomeOutline className="text-white" />
            <span className=" text-sm ml-4 text-gray-200">Home</span>
          </div>
        </Link>

        {/* Fin de Item de Menu  */}
        {/* Item de Menu  */}
        <Link to="/products">
          <div className=" flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer hover:bg-blue-500">
            <MdOutlineProductionQuantityLimits className="text-white" />
            <span className=" text-sm ml-4 text-gray-200">Productos</span>
          </div>
        </Link>

        {/* Fin de Item de Menu  */}
        {/* Item de Menu  */}
        <Link to="/reservation">
          <div className=" flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer hover:bg-blue-500">
          <LuCalendarPlus  className="text-white" />
            <span className=" text-sm ml-4 text-gray-200">Crear Reservación</span>
          </div>
        </Link>

        {/* Item de Menu  */}
        <Link to="/my-events">
          <div className=" flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer hover:bg-blue-500">
          <RiCalendarScheduleLine  className="text-white" />
            <span className=" text-sm ml-4 text-gray-200">Mis Eventos</span>
          </div>
        </Link>

        {/* Fin de Item de Menu  */}
        {/* Item de Menu Desplegable  */}
        <div
          className="flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer hover:bg-blue-500 text-white"
          onClick={toggleDropdown}
        >
          <MdExpandCircleDown className="text-white" size={20} />
          <div className="flex ml-4 justify-between w-full items-center">
            <span>ChatBox</span>
            <span
              className={`text-sm ${isOpenMenu ? "rotate-180" : ""}`}
              id="arrow"
            >
              <IoIosArrowDown />
            </span>
          </div>
        </div>

        {isOpenMenu && (
          <div
            className="flex flex-col text-left text-sm font-thin mt-2 w-4/5 mx-auto"
            id="submenu"
          >
            <span className="cursor-pointer p-2 hover:bg-blue-500 rounded-md mt-1 text-white">
              Opción 1
            </span>
            <span className="cursor-pointer p-2 hover:bg-blue-500 rounded-md mt-1 text-white">
              Opción 2
            </span>
            <span className="cursor-pointer p-2 hover:bg-blue-500 rounded-md mt-1 text-white">
              Opción 3
            </span>
          </div>
        )}
        {/* Fin de Item de Menu  Desplegable*/}

        <hr className="my-2 text-gray-600" />

        {/* Item de Menu  */}
        <div className=" flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer hover:bg-blue-500">
          <IoHomeOutline className="text-white" />
          <span className=" text-sm ml-4 text-gray-200">Bookmark</span>
        </div>
        {/* Fin del Item de MENU  */}
      </div>
      {/* Fin del Aside  */}
    </div>
  );
});
// Asigna un displayName al componente
SideBar2.displayName = "SideBar2";
