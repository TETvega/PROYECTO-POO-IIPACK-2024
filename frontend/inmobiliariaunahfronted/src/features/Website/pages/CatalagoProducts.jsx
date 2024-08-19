import { CatalagoProductsList } from "../components/catalago/CatalagoProductsList"

export const CatalagoProducts = () => {
  return (
    <div className="w-full p-6 bg-gray-100">
        {/* <div className=" justify-center items-center font-bold ">
            <h1 className=" text-4xl text-center">Mobiliario en Alquiler</h1>
        </div> */}
        {/* INICIO SECCIÓN PRODUCTOS DESTACADOS*/}
        <section className="py-12 md:py-16 lg:py-20 bg-muted">
          <div className="container px-4 sm:px-6 md:px-8 lg:px-10">
            <div className="text-center mb-8 md:mb-12 lg:mb-16">
              <h2 className="text-3xl mb-2 sm:text-4xl md:text-5xl font-bold tracking-tight">
                Muebles destacados
              </h2>
              <p className="text-muted-foreground text-lg sm:text-xl md:text-2xl">
                Explora nuestra cuidada selección de muebles de alquiler.
              </p>
            </div>
            {/* Lista de los Productos */}
            <CatalagoProductsList className="z-0"/>
          </div>
          {/*  */}
        </section>
        {/* FIN SECCIÓN PRODUCTOS DESTACADOS*/}
    </div>
  )
}
