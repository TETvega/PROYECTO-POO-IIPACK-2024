import { BsFilterLeft } from "react-icons/bs";
import { CiSearch } from "react-icons/ci";
import { FaHome } from "react-icons/fa";
import { IoExitOutline, IoHomeOutline } from "react-icons/io5";
import { MdExpandCircleDown } from "react-icons/md";
import { useDropDowMenu, useToggleSidebar} from "../../features/Website/hooks";
import { IoIosArrowDown } from "react-icons/io";

//Este es el sidebar ajustado y responsivo en cierta manera
export const SideBar2 = () => {
  // uso de Hooks
  const { isOpen, toggleSidebar } = useToggleSidebar(); // para poder quitar y expandir el aside
  const {isOpenMenu, toggleDropdown} = useDropDowMenu(); // para poder expandir o contraer el dropdon menu
  return (
    <div>
      {/* Boton que se muestra cuando se contrae el aside  */}
      <span className="absolute text-white text-4xl top-5 left-4 cursor-pointer ">
        <BsFilterLeft className=" px-2 bg-gray-600 rounded-md"
        onClick={toggleSidebar} />
      </span>
      {/* Inicio del Aside  */}
      <div
        className={`sidebar fixed top-0 bottom-0 p-2 w-[300px] overflow-y-auto text-center bg-gray-900 ${
          isOpen ? "left-0" : "left-[-300px]"
        } transition-all duration-300`}
      >
        {/* PARTE DE LA IDENTIDAD  */}
        <div className="text-gray-100 text-xl">
          {/* Nombre Principal e Icono */}
          <div className="p-2 mt-1 flex items-center">
            <FaHome className="py-0.3 cursor-pointer" />
            <span className="font-bold text-gray-200 ml-3 text-3xl">
              Siidni{" "}
            </span>
            <IoExitOutline
              className="ml-20 cursor-pointer text-white"
              onClick={toggleSidebar}
            />
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
        <div className=" flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer hover:bg-blue-500">
          <IoHomeOutline className="text-white" />
          <span className=" text-sm ml-4 text-gray-200">Home</span>
        </div>
        {/* Fin de Item de Menu  */}
        {/* Item de Menu  */}
        <div className=" flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer hover:bg-blue-500">
          <IoHomeOutline className="text-white" />
          <span className=" text-sm ml-4 text-gray-200">Bookmark</span>
        </div>
        {/* Fin de Item de Menu  */}
        {/* Item de Menu Desplegable  */}
        <div
          className="flex mt-3 p-2 items-center rounded-md px-4 duration-300 cursor-pointer hover:bg-blue-500 text-white"
          onClick={toggleDropdown}
        >
          <MdExpandCircleDown className="text-white" size={20} />
          <div className="flex ml-4 justify-between w-full items-center">
            <span>ChatBox</span>
            <span className={`text-sm ${isOpenMenu ? "rotate-180" : ""}`} id="arrow">
            <IoIosArrowDown />
            </span>
          </div>
        </div>

        {isOpenMenu && (
          <div className="flex flex-col text-left text-sm font-thin mt-2 w-4/5 mx-auto" id="submenu">
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
};
