import { useEffect, useState } from "react";

const EVENTS_API_URL = "https://10.100.42.74:7217/api/events";
function EventList() {
  const [events, setEvents] = useState([]);
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const controller = new AbortController();

    async function loadEvents() {
      try {
        const response = await fetch(EVENTS_API_URL, {
          signal: controller.signal,
        });

        if (!response.ok) {
          throw new Error(`Etkinlikler yüklenemedi (HTTP ${response.status}).`);
        }

        const data = await response.json();
        if (!Array.isArray(data)) {
          throw new Error("API yanıtı beklenen etkinlik listesi biçiminde değil.");
        }

        setEvents(data);
      } catch (err) {
        if (err.name !== "AbortError") {
          setError(
            err instanceof Error ? err.message : "Etkinlikler yüklenirken bir hata oluştu."
          );
        }
      } finally {
        if (!controller.signal.aborted) {
          setIsLoading(false);
        }
      }
    }

    loadEvents();
    return () => controller.abort();
  }, []);

  return (
    <section aria-labelledby="event-list-title">
      <h2 id="event-list-title">Eğitim Portalı Etkinlikleri</h2>
      {isLoading && <p role="status">Etkinlikler yükleniyor...</p>}
      {error && <p role="alert">Hata: {error}</p>}
      {!isLoading && !error && events.length === 0 && (
        <p>Henüz etkinlik bulunmuyor.</p>
      )}
      {!error && events.length > 0 && (
        <ul>
          {events.map((event, index) => (
            <li key={event.id ?? `${event.title}-${index}`}>
              {event.title}
            </li>
          ))}
        </ul>
      )}
    </section>
  );
}

export default EventList;