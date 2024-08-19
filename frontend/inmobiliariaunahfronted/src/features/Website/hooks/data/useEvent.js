import { useEffect, useState } from "react";
import { getEventById } from "../../../../shared/actions/events";

export const useEvent = (id) => {
  const [event, setEvent] = useState({});
  const [isLoading, setIsLoading] = useState(false);

  const loadEvent = async (id) => {
    setIsLoading(true);
    try {
      const result = await getEventById(id);
      setEvent(result);
    } catch (error) {
      console.error(error);
    } finally {
      setIsLoading(false);
    }
  };
  useEffect(() => {
    if (id) {
      loadEvent(id);
    }
  }, [id]);

  return {
    event,
    isLoading,
    loadEvent,
  };
};