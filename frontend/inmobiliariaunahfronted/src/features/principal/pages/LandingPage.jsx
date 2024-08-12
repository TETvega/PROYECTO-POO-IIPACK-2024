import { useState } from "react";
import { Link, Element } from "react-scroll";
import { FaGithub } from "react-icons/fa";

export const LandingPage = () => {
  const [year] = useState(new Date().getFullYear());
  return (
    <div className="flex flex-col min-h-[100dvh]">
      {/* INICIO NAV BAR */}
      <div className="fixed top-0 left-0 w-full px-4 lg:px-6 h-14 flex items-center bg-white shadow-md z-50 font-pluto-light font-bold">
        <Link to="init" className="flex items-center space-x-4 cursor-pointer">
          <Link to="init" className="flex items-center space-x-2 ">
            <img
              src="./../../../../public/siidni-logo.png"
              alt="Furniture Icon"
              className="object-cover object-center  w-14 h-14"
            />
          </Link>
          <p>Siidni Rentals</p>
        </Link>
        <nav className="ml-auto flex gap-4 sm:gap-6 font-extrabold">
          <Link
            to="services"
            smooth={true}
            duration={500}
            className="text-sm font-medium text-gray-700 hover:underline underline-offset-4 cursor-pointer"
          >
            Servicios
          </Link>
          <Link
            to="about"
            smooth={true}
            duration={500}
            className="text-sm font-medium text-gray-700 hover:underline underline-offset-4 cursor-pointer"
          >
            Sobre Nosotros
          </Link>

          <Link
            to="contact"
            smooth={true}
            duration={500}
            className="text-sm font-medium text-gray-700 hover:underline underline-offset-4 cursor-pointer"
          >
            Contacto
          </Link>
        </nav>
      </div>
      {/* FIN NAV BAR */}

      {/* INICIO HERO SECTION */}
      <header
        name="init"
        className="relative w-full h-[70vh] md:h-[80vh] lg:h-[90vh] bg-hero-pattern bg-no-repeat bg-cover"
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
            <div className="flex flex-col gap-2 min-[400px]:flex-row justify-center font-pluto-light font-bold">
              <Link
                href="#"
                className="inline-flex items-center justify-center rounded-md bg-siidni-gold px-6 py-3 text-base font-medium text-primary-foreground shadow-sm transition-colors hover:bg-primary/90 focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-2 cursor-pointer font-bold"
              >
                Reserva Ahora
              </Link>
              <Link
                href="#"
                className="inline-flex items-center justify-center rounded-md  text-unah-black px-6 py-3 border border-input text-base font-medium text-primary-foreground shadow-sm transition-colors hover:bg-primary/90 focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-2"
              >
                Iniciar Sesión
              </Link>
            </div>
          </div>
        </div>
      </header>
      {/* FIN HERO SECTION */}

      {/* INICIO CONTENIDO VARIADO*/}
      <main className="flex-1 justify-center">
        {/* INICIO SECCIÓN NUESTROS SERVICIOS */}
        <Element name="services" className="section py-12 md:py-16 lg:py-20">
          <div className="container px-4 sm:px-6 md:px-8 lg:px-10">
            <div className="grid grid-cols-1 md:grid-cols-2 gap-8 md:gap-12 lg:gap-16">
              <div>
                <h2 className="text-3xl sm:text-4xl md:text-5xl font-bold tracking-tight mb-4">
                  Nuestros servicios
                </h2>
                <p className="text-muted-foreground text-lg sm:text-xl md:text-2xl mb-8">
                  Descúbre cómo podemos transformar el espacio de su evento.
                </p>
                <ul className="space-y-4  text-lg">
                  <li className="flex items-start">
                    <div className="w-6 h-6 text-primary mr-4" />
                    <div>
                      <h3 className="text-xl font-semibold mb-2">
                        Alquiler de mobiliario para eventos
                      </h3>
                      <p className="text-muted-foreground">
                        Explora nuestra amplia colección de muebles, decoración
                        y accesorios para crear el ambiente perfecto para tu
                        evento.
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
        {/* FIN SECCIÓN NUESTROS SERVICIOS */}

        {/* INICIO SECCIÓN NUESTROS PRODUCTOS*/}
        <section className="w-full py-7 md:py-24 lg:py-9">
          <div className="container px-4 md:px-6">
            <div className="flex  items-center justify-center space-y-4 text-center">
              <div className="space-y-2 items-center">
                <div className="inline-block rounded-lg bg-muted px-3 py-1 text-sm">
                  Nuestros Muebles
                </div>
                <h2 className="text-3xl font-bold tracking-tighter sm:text-5xl">
                  Muebles seleccionados para cualquier evento
                </h2>
                <div className="flex justify-center">
                  <p className="max-w-[600px] text-muted-foreground md:text-xl/relaxed lg:text-base/relaxed xl:text-xl/relaxed">
                    Desde elegantes sillas hasta mesas modernas, nuestra
                    selección de alquiler de muebles tiene todo lo que necesita
                    para crear el ambiente perfecto para tu evento.
                  </p>
                </div>
              </div>
            </div>
            <div className="mx-auto grid max-w-5xl items-center gap-6 py-12 lg:grid-cols-2 lg:gap-12">
              <img
                src="https://scontent-gua1-1.xx.fbcdn.net/v/t1.6435-9/35356753_2072567446364904_8756911062063775744_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=dd6889&_nc_eui2=AeHQsb9OmN9BhkuMhMgcHZsXhW3Pk6RpTJmFbc-TpGlMmdYLuQBU5H_awiIAEPwNiICsD6E9uQEMCG-3PcdHALDG&_nc_ohc=vH1HViJ6M1EQ7kNvgF2J0wo&_nc_ht=scontent-gua1-1.xx&oh=00_AYBdzY0T4soN8V6v98Bbyw0_Lzkvv6V3nrpLfH9n_j6R3w&oe=66E0BB92"
                width="550"
                height="310"
                alt="Furniture"
                className="mx-auto aspect-video overflow-hidden rounded-xl object-cover object-center sm:w-full lg:order-last"
              />
              <div className="flex flex-col justify-center space-y-4">
                <ul className="grid gap-6 text-lg">
                  <li>
                    <div className="grid gap-1">
                      <h3 className="text-xl font-bold">Mantel Blanco</h3>
                      <p className="text-muted-foreground">
                        Mantel blanco de algodón, ideal para mesas de banquete.
                      </p>
                    </div>
                  </li>
                  <li>
                    <div className="grid gap-1">
                      <h3 className="text-xl font-bold">Silla Plegable</h3>
                      <p className="text-muted-foreground">
                        Silla plegable de plástico resistente, fácil de
                        transportar y almacenar.
                      </p>
                    </div>
                  </li>
                  <li>
                    <div className="grid gap-1">
                      <h3 className="text-xl font-bold">Toldo</h3>
                      <p className="text-muted-foreground">
                        Toldo grande para eventos al aire libre, resistente al
                        agua.
                      </p>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </section>
        {/* FIN SECCIÓN NUESTROS PRODUCTOS*/}

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
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6 md:gap-8 lg:gap-10">
              <div className="bg-background rounded-lg shadow-lg overflow-hidden">
                <img
                  src="https://img.freepik.com/fotos-premium/mesa-redonda-plegable-madera-recreacion-al-aire-libre_295088-39.jpg?w=740"
                  alt="Producto 1"
                  width={400}
                  height={300}
                  className="w-full h-[200px] object-cover"
                  style={{ aspectRatio: "400/300", objectFit: "cover" }}
                />
                <div className="p-4">
                  <h3 className="text-xl font-semibold mb-2">Mesa Redonda</h3>
                  <p className="text-muted-foreground">
                    Mesa redonda de madera, ideal para eventos al aire libre.
                  </p>
                  <div className="mt-4">
                    <a
                      href="#"
                      className="inline-flex items-center justify-center rounded-md bg-siidni-gold px-4 py-2 text-sm font-medium text-white shadow-sm transition-colors hover:bg-primary/90 focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-2"
                    >
                      Reserva Ahora
                    </a>
                  </div>
                </div>
              </div>

              <div className="bg-background rounded-lg shadow-lg overflow-hidden">
                <img
                  src="https://cdn0.casamiento.com.uy/article-real-wedding-o/8882/3_2/960/jpg/16_2888.webp"
                  alt="Producto 2"
                  width={400}
                  height={300}
                  className="w-full h-[200px] object-cover"
                  style={{ aspectRatio: "400/300", objectFit: "cover" }}
                />
                <div className="p-4">
                  <h3 className="text-xl font-semibold mb-2">Centro de Mesa</h3>
                  <p className="text-muted-foreground">
                    Elegante centro de mesa con flores artificiales, perfecto
                    para bodas.
                  </p>
                  <div className="mt-4">
                    <a
                      href="#"
                      className="inline-flex items-center justify-center rounded-md bg-siidni-gold px-4 py-2 text-sm font-medium text-white shadow-sm transition-colors hover:bg-primary/90 focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-2"
                    >
                      Reserva Ahora
                    </a>
                  </div>
                </div>
              </div>
              <div className="bg-background rounded-lg shadow-lg overflow-hidden">
                <img
                  src="https://m.media-amazon.com/images/I/6169iONcybL._AC_SL1500_.jpg"
                  alt="Producto 3"
                  width={400}
                  height={300}
                  className="w-full h-[200px] object-cover"
                  style={{ aspectRatio: "400/300", objectFit: "cover" }}
                />
                <div className="p-4">
                  <h3 className="text-xl font-semibold mb-2">Cortinas</h3>
                  <p className="text-muted-foreground">
                    Para escenario en algodón blanco. Con un acabado de costura
                    reforzada.
                  </p>
                  <div className="mt-4">
                    <a
                      href="#"
                      className="inline-flex items-center justify-center rounded-md bg-siidni-gold px-4 py-2 text-sm font-medium text-white shadow-sm transition-colors hover:bg-primary/90 focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-2"
                    >
                      Reserva Ahora
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
        {/* FIN SECCIÓN PRODUCTOS DESTACADOS*/}

        {/* INICIO SECCIÓN NUESTRO EQUIPO*/}
        <section className="py-12 md:py-16 lg:py-20">
          <div className="container px-4 sm:px-6 md:px-8 lg:px-10">
            <h2 className="text-3xl sm:text-4xl md:text-5xl font-bold tracking-tight mb-8 text-center">
              Conoce a nuestro equipo
            </h2>
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-6 md:gap-8 lg:gap-10">
              <a
                href="https://github.com/TETvega"
                target="_blank"
                rel="noopener noreferrer"
                className="bg-background rounded-lg shadow-lg p-6"
              >
                <div className="w-16 h-16 bg-gray-200 rounded-full overflow-hidden">
                  <img
                    src="./../../../../public/hector-profile.jpeg"
                    alt="Team Member 1"
                    className="w-full h-full object-cover"
                  />
                </div>
                <h3 className="text-xl font-semibold mt-4">Héctor Vega</h3>
                <p className="text-muted-foreground">Coordinador de Eventos</p>
              </a>
              <a
                href="https://github.com/annerh3"
                target="_blank"
                rel="noopener noreferrer"
                className="bg-background rounded-lg shadow-lg p-6"
              >
                <div className="w-16 h-16 bg-gray-200 rounded-full overflow-hidden">
                  <img
                    src="./../../../../public/anner-profile.jpg"
                    alt="Team Member 2"
                    className="w-full h-full object-cover"
                  />
                </div>
                <h3 className="text-xl font-semibold mt-4">Anner Henriquez</h3>
                <p className="text-muted-foreground">Servicio al cliente</p>
              </a>
            </div>
          </div>
        </section>
        {/* FIN SECCIÓN NUESTRO EQUIPO */}

        {/* INICIO SECCIÓN SOBRE NOSOTROS*/}
        <Element name="about" className=" section w-full md:py-3 lg:py-20">
          <div className="container px-4 md:px-6">
            <div className="flex flex-col items-center justify-center space-y-4 text-center">
              <div className="space-y-2">
                <div className="inline-block rounded-lg bg-muted px-3 py-1 mb-10 text-3xl font-bold sm:text-5xl">
                  Sobre Nosotros
                </div>
                <h3 className="font-bold tracking-tighter text-2xl ">
                  Quines Somos
                </h3>
                <p className="max-w-[600px] text-muted-foreground md:text-xl/relaxed lg:text-base/relaxed xl:text-xl/relaxed">
                  <span className="font-pluto-light font-bold text-siidni-gold">
                    Siidni Rentals ®
                  </span>{" "}
                  es un proveedor líder de muebles de alta calidad para todas
                  las necesidades de su evento. Con años de experiencia en la
                  industria, nos enorgullecemos de brindar un servicio
                  excepcional y seleccionar los muebles perfectos para realzar
                  cualquier ocasión.
                </p>
              </div>
              <div className="flex flex-col items-center justify-center space-y-4 mt-8">
                <div className="space-y-2">
                  <h3 className="text-2xl font-bold">Nuestra Misión</h3>
                  <p className="max-w-[600px] text-muted-foreground md:text-xl/relaxed lg:text-base/relaxed xl:text-xl/relaxed">
                    Nuestra misión es facilitar la planificación de eventos al
                    ofrecer alquileres de muebles de primer nivel y un servicio
                    al cliente incomparable. Nos esforzamos por superar las
                    expectativas de nuestros clientes y crear experiencias
                    inolvidables.
                  </p>
                </div>
                <div className="space-y-2">
                  <h3 className="text-2xl font-bold">Nuestros Valores</h3>
                  <p className="max-w-[600px] text-muted-foreground md:text-xl/relaxed lg:text-base/relaxed xl:text-xl/relaxed">
                    En el corazón de nuestra empresa se encuentran los valores
                    de calidad, innovación e integridad. Nos comprometemos a
                    proporcionar los mejores productos y servicios posibles,
                    mejorando continuamente nuestra oferta y manteniendo los más
                    altos estándares de profesionalismo.
                  </p>
                </div>
              </div>
            </div>
          </div>
        </Element>
        {/* FIN SECCIÓN SOBRE NOSOTROS*/}

        {/* INICIO HR */}
        <div className="relative my-4">
          <div className="absolute inset-0 flex items-center justify-center">
            <div className="w-full h-0.5 bg-gradient-to-r from-transparent via-siidni-gold to-transparent" />
          </div>
        </div>
        {/* FIN HR */}

        {/* INICIO SECCIÓN CONTACTANOS */}
        <Element name="contact" className="w-full md:py-1 lg:py-20">
          <div className="container px-4 md:px-6 ">
            <div className="flex flex-col items-center justify-center space-y-4 text-center">
              <div className="space-y-2">
                <div className="inline-block rounded-lg bg-gray-200 px-3 py-1 text-sm text-gray-700">
                  Contáctanos
                </div>
                <h2 className="text-3xl font-bold tracking-tighter sm:text-5xl">
                  Ponte en contacto
                </h2>
                <p className="max-w-[600px] text-gray-600 md:text-xl lg:text-base xl:text-xl">
                  ¿Tienes alguna pregunta o deseas obtener más información sobre
                  nuestros servicios de alquiler de muebles? Completa el
                  formulario a continuación y nos comunicaremos contigo lo antes
                  posible.
                </p>
              </div>
              <form className="w-full max-w-md space-y-4">
                <div className="grid grid-cols-2 gap-4">
                  <div className="space-y-2">
                    <label
                      htmlFor="name"
                      className="block text-sm font-medium text-gray-700"
                    >
                      Nombre
                    </label>
                    <input
                      id="name"
                      type="text"
                      placeholder="Ingresa tu nombre"
                      className="mt-1 block w-full rounded-md border-gray-300 shadow-sm border py-1 px-1 focus:border-indigo-500 focus:ring focus:ring-indigo-500 focus:ring-opacity-50"
                    />
                  </div>
                  <div className="space-y-2">
                    <label
                      htmlFor="email"
                      className="block text-sm font-medium text-gray-700"
                    >
                      Email
                    </label>
                    <input
                      id="email"
                      type="email"
                      placeholder="Ingresa tu email"
                      className="mt-1 block w-full rounded-md border-gray-300 shadow-sm border py-1 px-1 focus:border-indigo-500 focus:ring focus:ring-indigo-500 focus:ring-opacity-50"
                    />
                  </div>
                </div>
                <div className="space-y-2">
                  <label
                    htmlFor="message"
                    className="block text-sm font-medium text-gray-700"
                  >
                    Mensaje
                  </label>
                  <textarea
                    id="message"
                    placeholder="Escribe tu mensaje"
                    className="mt-1 block w-full min-h-[100px] rounded-md border-gray-300 shadow-sm border py-1 px-1 focus:border-indigo-500 focus:ring focus:ring-indigo-500 focus:ring-opacity-50"
                  />
                </div>
                <button
                  type="submit"
                  className="w-full px-4 py-2 bg-blue-500 text-white font-medium rounded-md hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2"
                >
                  Enviar
                </button>
              </form>
            </div>
          </div>
        </Element>
        {/* FIN SECCIÓN CONTACTANOS */}
      </main>
      {/* FIN CONTENIDO VARIADO*/}

      {/* INICIO FOOTER*/}
      <footer className="bg-gray-100 py-6 md:py-8 lg:py-10">
        <div className="container px-4 sm:px-6 md:px-8 lg:px-10 flex flex-col md:flex-row items-center justify-between">
          <div className="flex items-center space-x-2 ">
            <a
              href="https://github.com/TETvega/PROYECTO-POO-IIPACK-2024"
              target="_blank"
              className="mx-2"
            >
              <FaGithub />
            </a>
            <p className="text-gray-600 text-sm md:text-base mt-0">
              &copy; {year} Siidni Rentals. Todos los derechos reservados.
            </p>
          </div>
          <nav className="flex items-center space-x-4 md:space-x-6 lg:space-x-8">
            <Link
              to="/privacy-policy"
              className="text-gray-600 hover:text-gray-800 transition-colors text-sm md:text-base"
            >
              Privacy Policy
            </Link>
            <Link
              to=""
              className="text-gray-600 hover:text-gray-800 transition-colors text-sm md:text-base"
            >
              Terms of Service
            </Link>
          </nav>
        </div>
      </footer>
      {/* FIN FOOTER*/}
    </div>
  );
};
