import { useEffect, useState } from "react";
import { useCategories } from "../../hooks/data";

export const SelecOptions = ({
  setSelectedCategory = () => {},
   setFetching = () => {},
}) => {
  const { categories, loadCategories, isLoadingCategories } = useCategories();
  const [selectedValue, setSelectedValue] = useState("");
  const [feching, setFechingOptions] = useState(true);

  useEffect(() => {
    if (feching) {
      loadCategories();
      setFechingOptions(false);
    }
  }, [feching]);

  const handleChange = (event) => {
    const value = event.target.value;
    setSelectedValue(value);
    setSelectedCategory(value);
    setFetching(true)

  };

  if (isLoadingCategories) return <p>Cargando categorías...</p>;

  return (
    <div className="flex items-center mb-4 mt-4">
      <select
        className="shadow border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        value={selectedValue}
        onChange={handleChange}
      >
        <option value="">Selecciona una opción</option>
        {categories?.data?.map((category) => (
          <option key={category.id} value={category.name}>
            {category.name}
          </option>
        ))}
      </select>
    </div>
  );
};
