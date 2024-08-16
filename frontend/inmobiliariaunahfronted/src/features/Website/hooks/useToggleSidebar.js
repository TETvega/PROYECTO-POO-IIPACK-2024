import { useState } from "react";

export const useToggleSidebar = () => {
    const [isOpen, setIsOpen] = useState(false);

    const toggleSidebar = () => {
      setIsOpen(!isOpen);
    };
  
    return { isOpen, toggleSidebar };
}
