import { useState } from "react";
import { deleteEvent, getAllEvents } from "../../../../shared/actions/events";

export const useEvents = () => {
  const [events, setEvents] = useState({});
  const [isLoading, setIsLoading] = useState(false);


  const loadEvents = async () => {
    setIsLoading(true);
    const result = await getAllEvents();
    setEvents(result);
    setIsLoading(false);
  };

  const removeEvent = async (id) => {
    setIsLoading(true);
      await deleteEvent(id);
      console.log('Mensaje desde removeEvent HOOK');
      
      const result = await getAllEvents();
       setEvents(result);
      setIsLoading(false);
  };
  

  return {
    // Properties
    events,
    isLoading,

        //Methods
        loadEvents,
        removeEvent,
  };
};