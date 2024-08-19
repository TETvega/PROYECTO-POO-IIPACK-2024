import { useEffect, useState } from "react";
import { useEvents } from "../hooks/data";
import { EventItem } from "./EventItem";
import { EventsListSkeleton } from "../components/events/EventsListSkeleton";
import { Link } from "react-router-dom";

export const MyEvents = () =>  {

  const {events, loadEvents} = useEvents();
  const [fetching, setFetching] = useState(true); 

  useEffect(() => {
    if(fetching) {
      loadEvents();
      setFetching(false);
    }
  }, [fetching]);

  const handleAfterDelete = () => {
    setFetching(true); // Esto hará que se vuelva a ejecutar el useEffect y recargue los eventos
    alert('Evento Cancelado');
    
  };

  return (
    <section className="py-28  mx-auto px-4 md:px-6 bg-gray-100 ">
      <header className="flex items-center justify-between mb-8">
        <h1 className="text-3xl font-semibold">Mis Eventos</h1>
        
      </header>

      <section className="bg-white p-6 rounded-md">
        <div className="grid gap-6">
          {
            fetching ? (
              <EventsListSkeleton size={6}/>
            ) : (
            events?.data?.length ? (
              events.data.map((event) => (
                <EventItem key={event.id} event={event} onDelete={handleAfterDelete} />
                                        ))
                                   ) 
            : (
              <section className="w-full justify-center">
              <span className="flex justify-center mb-4 text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl">Parece que no tienes evento...</span>
              <span className="flex justify-center">
              <Link
                      to='/reservation'
                      className="md:text-xl lg:text-base xl:text-xl inline-flex items-center justify-center rounded-md bg-siidni-gold px-6 py-3 text-base font-medium text-primary-foreground shadow-sm transition-colors hover:bg-primary/90 focus:outline-none focus:ring-2 focus:ring-primary focus:ring-offset-2 cursor-pointer"
                    >
                      Reserva Ahora
                    </Link>
              </span>
            </section>
            )
          )
          }
        </div>
      </section>

    </section>
  );
}
