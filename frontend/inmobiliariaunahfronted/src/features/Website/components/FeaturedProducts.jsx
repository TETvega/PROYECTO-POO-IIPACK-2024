export const FeaturedProducts = () => {
  return (
    <div className="container px-4 md:px-6 mt-8 mb-8 lg:mb-16">
      <h3 className="text-2xl font-bold mb-6 leading-none tracking-tight text-center">
        Productos destacados
      </h3>
      <div className="px-4 md:px-6">
        <div className="grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-4">
          {/* Producto 1 */}
          <div className="relative flex-shrink-0">
            <img
              className="w-full h-[250px] rounded-lg object-cover shadow-lg"
              src="https://areadesign.com.py/wp-content/uploads/2022/11/ER_4693-3.jpg"
              alt="chair"
            />
            <span className="text-xl font-bold absolute inset-0 flex items-end justify-center text-center text-white pb-2 bg-gradient-to-t from-black to-transparent">
              Sillas Victoria
            </span>
          </div>
          {/* Producto 2 */}
          <div className="relative flex-shrink-0">
            <img
              className="w-full h-[250px] rounded-lg object-cover shadow-lg"
              src="https://www.idfdesign.es/imagenes/sofas-clasicos-de-lujo/sinfonia-sofa-de-2-plazas-sofa-clasico-de-lujo.jpg"
              alt="sofa"
            />
            <span className="text-xl font-bold absolute inset-0 flex items-end justify-center text-center text-white pb-2 bg-gradient-to-t from-black to-transparent">
              Sofás Elegantes
            </span>
          </div>
          {/* Producto 3 */}
          <div className="relative flex-shrink-0">
            <img
              className="w-full h-[250px] rounded-lg object-cover shadow-lg"
              src="https://i.pinimg.com/736x/00/3d/1b/003d1beb18fca7630cdbdba495bc151b.jpg"
              alt="Carpas Blancas"
            />
            <span className="text-xl font-bold absolute inset-0 flex items-end justify-center text-center text-white pb-2 bg-gradient-to-t from-black to-transparent">
              Carpas Blancas
            </span>
          </div>
          {/* Producto 4 */}
          <div className="relative flex-shrink-0">
            <img
              className="w-full h-[250px] rounded-lg object-cover shadow-lg"
              src="https://www.boqnews.com/wp-content/uploads/2019/02/cortina-varao-2.jpg"
              alt="Cortinas Elegantes"
            />
            <span className="text-xl font-bold absolute inset-0 flex items-end justify-center text-center text-white pb-2 bg-gradient-to-t from-black to-transparent">
              Cortinas Elegantes
            </span>
          </div>
        </div>
      </div>
    </div>
  );
};

  