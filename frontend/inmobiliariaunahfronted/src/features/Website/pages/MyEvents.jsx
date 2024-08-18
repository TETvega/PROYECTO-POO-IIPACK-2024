import { useEffect, useState } from "react";
import { useEvents } from "../hooks/data";
import { Loading } from "../../../shared/components";
import { EventItem } from "./EventItem";

export const MyEvents = () =>  {

  const {events, loadEvents, isLoading} = useEvents();
  const [fetching, setFetching] = useState(true);

  useEffect(() => {
    if(fetching) {
      loadEvents();
      console.log(events)
      setFetching(false);
    }
  }, [fetching]);

  if(isLoading){
      return <Loading />
    }
  return (
    <section className="py-28  mx-auto px-4 md:px-6 bg-gray-100 ">
      <header className="flex items-center justify-between mb-8">
        <h1 className="text-3xl font-semibold">Mis Eventos</h1>
        
      </header>

      <section className="bg-white p-6 rounded-md">
        <div className="grid gap-6">
          {
            events?.data?.length ? (
              events.data.map((event) => (
                <EventItem key={event.id} event={event} />
              ))
            ) 
            : (
              <p>No hay eventos XD</p>
            )
          }
        </div>
      </section>

    </section>
  );
}
