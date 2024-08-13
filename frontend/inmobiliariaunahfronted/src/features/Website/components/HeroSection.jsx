import { Link } from "react-scroll";

export const HeroSection = () => {
  return (
    <header
      name="init"
      className="relative w-full h-screen bg-hero-pattern bg-no-repeat bg-cover"
    >
      <div className="absolute inset-0 bg-black/50 flex items-center justify-center">
        <div className="text-center text-white space-y-6 px-4 sm:px-6 md:px-8 lg:px-10">
          <h1 className="text-4xl sm:text-5xl md:text-6xl font-bold tracking-tight">
            Eleva tu evento con nuestro alquiler de mobiliario
          </h1>
          <p className="text-lg sm:text-xl md:text-2xl">
            Descubre las piezas perfectas para transformar tu espacio y crear
            una experiencia inolvidable.
          </p>
          <div className="flex flex-col gap-2 min-[400px]:flex-row justify-center font-bold">
            <Link
              href="#"
              className="inline-flex items-center justify-center rounded-md bg-siidni-gold px-6 py-3 
              text-base font-medium text-primary-foreground shadow-sm transition-colors hover:bg-primary/90 
              focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-2 cursor-pointer font-bold hover:bg-orange-600"
            >
              Reserva Ahora
            </Link>
            <Link
              href="#"
              className="inline-flex items-center justify-center rounded-md  text-unah-black px-6 py-3 border border-input 
              text-base font-medium text-primary-foreground shadow-sm transition-colors hover:bg-primary/90 focus:outline-none 
              focus:ring-2 focus:ring-primary focus:ring-offset-2  hover:bg-white hover:text-black "
            >
              Iniciar Sesión
            </Link>
          </div>
        </div>
      </div>
    </header>
  );
};
