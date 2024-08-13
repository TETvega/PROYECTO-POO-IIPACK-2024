export const ProductsSection = () => {
    return (
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
              src="https://sauderworship.com/wp-content/uploads/2020/11/732-9800_M_T.jpg"
              alt="Sillas"
              width={400}
              height={400}
              className="rounded-lg shadow-lg"
              style={{ aspectRatio: "400/400", objectFit: "cover" }}
            />
            <img
              src="https://i.pinimg.com/originals/b1/ff/68/b1ff6897baf52cf16901fa1d812072a0.jpg"
              alt="Mesas"
              width={400}
              height={400}
              className="rounded-lg shadow-lg"
              style={{ aspectRatio: "400/400", objectFit: "cover" }}
            />
          </div>
        </div>
      </section>
    );
  };
  