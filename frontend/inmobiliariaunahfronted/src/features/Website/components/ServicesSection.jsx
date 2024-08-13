import { Element } from "react-scroll";

export const ServicesSection = () => {
  return (
    <Element name="services" id="servicesSec" className="section py-12 md:py-16 lg:py-20">
      <div className="container px-4 sm:px-6 md:px-8 lg:px-10">
        <div className="grid grid-cols-1 md:grid-cols-2 gap-8 md:gap-12 lg:gap-16">
          <div>
            <h2 className="text-3xl sm:text-4xl md:text-5xl font-bold tracking-tight mb-4">
              Nuestros servicios
            </h2>
            <p className="text-muted-foreground text-lg sm:text-xl md:text-2xl mb-8">
              Descúbre cómo podemos transformar el espacio de su evento.
            </p>
            <ul className="space-y-4 text-lg">
              <li className="flex items-start">
                <div className="w-6 h-6 text-primary mr-4" />
                <div>
                  <h3 className="text-xl font-semibold mb-2">
                    Alquiler de mobiliario para eventos
                  </h3>
                  <p className="text-muted-foreground">
                    Explora nuestra amplia colección de muebles, decoración y
                    accesorios para crear el ambiente perfecto para tu evento.
                  </p>
                </div>
              </li>
              <li className="flex items-start">
                <div className="w-6 h-6 text-primary mr-4" />
                <div>
                  <h3 className="text-xl font-semibold mb-2">
                    Entrega e instalación
                  </h3>
                  <p className="text-muted-foreground">
                    Nuestro equipo entregará e instalará tus artículos de
                    alquiler, lo que garantizará una experiencia perfecta.
                  </p>
                </div>
              </li>
              <li className="flex items-start">
                <div className="w-6 h-6 text-primary mr-4" />
                <div>
                  <h3 className="text-xl font-semibold mb-2">
                    Personalización
                  </h3>
                  <p className="text-muted-foreground">
                    Trabaja con nuestros expertos en diseño para
                    personalizar tus artículos de alquiler y crear una
                    apariencia única para tu evento.
                  </p>
                </div>
              </li>
            </ul>
          </div>
          <div className="flex items-center justify-center">
            <img
              src="https://scontent-gua1-1.xx.fbcdn.net/v/t39.30808-6/326532091_715938200113663_3386244716034004616_n.jpg?_nc_cat=103&ccb=1-7&_nc_sid=6ee11a&_nc_eui2=AeFDHAIYQ_qLUBvbbE4lJdOp_Xed-Onxjvr9d5346fGO-joW47flS4nNtsySV2Ja4jdp0AKYGLDPsMqMGeO3m-sX&_nc_ohc=5NcuknW77jAQ7kNvgHosY5O&_nc_ht=scontent-gua1-1.xx&oh=00_AYDvvfCr6k7zCOVxrcMO8Y269RPwTKQbR2bEhgdASr7FQw&oe=66BEF4E9"
              alt="Furniture rental"
              width={500}
              height={500}
              className="rounded-lg shadow-lg"
              style={{ aspectRatio: "500/500", objectFit: "cover" }}
            />
          </div>
        </div>
      </div>
    </Element>
  );
};
