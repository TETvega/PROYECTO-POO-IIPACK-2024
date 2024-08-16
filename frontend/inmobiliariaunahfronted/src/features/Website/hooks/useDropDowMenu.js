import { useState } from "react";

export const useDropDowMenu = () => {
    const [isOpenMenu, setIsOpen] = useState(false);

    const toggleDropdown = () => {
      setIsOpen(!isOpenMenu);
    };
  
    return { isOpenMenu, toggleDropdown };
}
