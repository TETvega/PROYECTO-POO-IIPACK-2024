import { useState } from "react";
import { CiFacebook } from "react-icons/ci";
import { FaGithub, FaInstagram } from "react-icons/fa";
import { FaXTwitter } from "react-icons/fa6";
import { GiLynxHead } from "react-icons/gi";

export const Footer = () => {
  const [year] = useState(new Date().getFullYear()); 
  //Secciones que tendrá el footer se pueden a;adir mas en este arreglo
  const sections = [
    {
      title: "Soluciones",
      items: ["Borrar el Código", "Cambiar de Carrera", "Tener Fe"],
    },
    {
      title: "Desarrollo",
      items: ["Archivo de Word", "Diagrama"],
    },
  ];
  // las redes sociales se pueden añadir mas siguiendo la nomenclatura
  const items = [
    {
      name: "Facebook",
      icon: CiFacebook,
      link: "./home",
    },
    {
      name: "Instagram",
      icon: FaInstagram,
      link: "https://www.instagram.com/iscuroc/",
    },
    {
      name: "GitHub",
      icon: FaGithub,
      link: "https://github.com/TETvega/PROYECTO-POO-IIPACK-2024",
    },
    {
      name: "X",
      icon : FaXTwitter,
      link: "./home",
    },
    {
      name : "Pumagram",
      icon : GiLynxHead,
      link : "https://curoc.unah.edu.hn/"
    }

  ];

  return (
    // Inicio de lo que es el Footer
    <footer className=" w-full  bg-slate-900 text-gray-300 py-2 px-2">
      {/* Inicio de las secciones */}
      <div className="max-w-[1240px] mx-auto grid grid-cols-2 md:grid-cols-6 border-b-2 border-gray-300 py-8">
        {/* Mapeo y renderizado de las secciones definidas */}
        {sections.map((section, index) => (
          <div key={index}>
            {/* Nombre de la sección */}
            <h6 className=" font-bold uppercase pt-2 ">{section.title}</h6>
            {/* Lista de Elementos de la Sección */}
            <ul>
              {section.items.map((item, i) => (
                // Items de cada sección
                <li
                  key={i}
                  className="py-1 text-gray-500 hover:text-white cursor-pointer"
                   href = {'google.com'}
                >
                  {item}
                </li>
              ))}
            </ul>
          </div>
        ))}
        {/* section de la Empresa y su refrán */}
        <div className="col-span-2 pt-8 md:pt-2">
          <p className=" font-bold uppercase">Siidni Reservations Hn</p>
          <p className="py-4 ">
            Lo mejor en artículos, mobiliario decoraciones y eventos
          </p>
        </div>
      </div>
      {/* Fin de las Secciones */}
      {/* Inicio de la Row final de derechos y redes sociales */}
      <div className=" flex flex-col max-w-[1240px] px-2 py-4 mx-auto justify-between sm:flex-row text-center text-gray-500">
        {/* Para las gracias de los autores de la web */}
        <p className="py-4">
        © {year} Héctor & Anner, LLC. All Rights Reserved
        </p>
        {/* Para el renderizado de los items de la lista */}
        <div className="flex justify-between sm:w-[300px] pt-4 text-2xl">
          {items.map((i, index) => {
            return (
              <a key={index} href={i.link} target="_blank">
                <i.icon  className="hover:text-white cursor-pointer" />
              </a>
            );
          })}
        </div>
      </div>
      {/* Fin de la Row */}
    </footer>
  );
};
