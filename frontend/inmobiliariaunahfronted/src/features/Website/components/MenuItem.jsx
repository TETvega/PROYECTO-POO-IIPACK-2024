// eslint-disable-next-line react/prop-types
export const MenuItem = ({ menu , open, isFirst }) => {
    return (
      <li
        className={`flex rounded-md p-2 cursor-pointer hover:bg-light-white text-gray-300 text-sm items-center gap-x-4 ${
          menu.gap ? "mt-9" : "mt-2"
        } ${isFirst && "bg-light-white"}`}
      >
        <img src={`./src/assets/${menu.src}.png`} alt={`${menu.title} icon`} />
        <span className={`${!open && "hidden"} origin-left duration-200`}>
          {menu.title}
        </span>
      </li>
    );
  };
  
  