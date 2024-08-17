import { Navigate, Route, Routes } from "react-router-dom";
import { Footer, Header, SideBar2 } from "../../../shared/components";
import { useEffect, useRef, useState } from 'react';
import { CatalagoProducts, FormEventPage, HomePage } from "../pages";
export const WebRouter = () => {

  const sideBar = useRef(null); // se usa useRef para referenciar el componente (SideBar2).
  const [isOpen, setIsOpen] = useState(false); // para controlar si el 'SideBar2' está abierto o cerrado.

  const toggleSidebar = () => { //  invierte el valor de 'isOpen' cuando se llama
    setIsOpen(!isOpen);
  };

  useEffect(() => { // para agregar un event-listener al documento que escucha eventos de clic.
    
    const handleClickOutside = (event) => { // verifica si el clic ocurrió fuera del componente. Se ejecutará cada vez que ocurra un evento mousedown (cuando se hace clic en cualquier parte del documento).
      if (sideBar.current && !sideBar.current.contains(event.target)) {
  /* sideBar.current: Asegura que el componente SideBar esté montado
    '!componentRef.current.contains(event.target)': Verifica si el elemento clicado (event.target) NO está dentro del SideBar. Si es así, significa que se hizo clic fuera del sidebar.  */
        setIsOpen(false); // Cierra el sidebar (ya se validó que se hizo clic fuera del componente)
      }
    };

    document.addEventListener('mousedown', handleClickOutside); // Agrega el event-listener 'mousedown' al documento. Osea, cada vez que se haga clic en cualquier lugar de la página, la función 'handleClickOutside' se ejecutará.

    return () => { // se elimina el listener para evitar comportamientos inesperados cuando el componente se desmonte
      document.removeEventListener('mousedown', handleClickOutside);
    };
  }, []);

    return (
      <div>
        <SideBar2 ref={sideBar} isOpen={isOpen} toggleSidebar={toggleSidebar} />
          <div>
            <main className="flex-row">
              <Header />
                <div className="w-full">
                  <Routes>
                    <Route path="/reservation" element={<FormEventPage/>} />
                    <Route path="/products" element={<CatalagoProducts/>} />
                    <Route path="/home" element={<HomePage />} />
                    <Route path="/*" element={<Navigate to={"/home"} />} />
                  </Routes>
                </div>
            </main>
            <Footer />
          </div>
      </div>
    );
};
