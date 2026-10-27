document.addEventListener("DOMContentLoaded", () => {
  const countdown = document.getElementById("upcoming-event-countdown");
  if (!countdown) return;

  const events = [
    { title: "Siber Güvenlik", date: "2026-10-22" },
    { title: "Mühendislik ve Yazılım Kariyer", date: "2026-11-28" },
    { title: "Web Geliştirme", date: "2026-12-15" }
  ];
  const title = document.getElementById("countdown-title");
  const dateLabel = document.getElementById("countdown-date");
  const status = document.getElementById("countdown-status");
  const units = {
    days: document.getElementById("countdown-days"),
    hours: document.getElementById("countdown-hours"),
    minutes: document.getElementById("countdown-minutes"),
    seconds: document.getElementById("countdown-seconds")
  };
  const formatDate = new Intl.DateTimeFormat("tr-TR", {
    day: "numeric",
    month: "long",
    year: "numeric"
  });

  const updateCountdown = () => {
    const now = new Date();
    const nextEvent = events
      .map(event => {
        const [year, month, day] = event.date.split("-").map(Number);
        return { ...event, startsAt: new Date(year, month - 1, day) };
      })
      .filter(event => event.startsAt > now)
      .sort((first, second) => first.startsAt - second.startsAt)[0];

    if (!nextEvent) {
      title.textContent = "Yaklaşan etkinlik bulunmuyor";
      dateLabel.textContent = "";
      status.textContent = "";
      document.getElementById("countdown-timer").hidden = true;
      return;
    }

    document.getElementById("countdown-timer").hidden = false;
    title.textContent = nextEvent.title;
    dateLabel.textContent = formatDate.format(nextEvent.startsAt);

    const remainingSeconds = Math.max(
      0,
      Math.floor((nextEvent.startsAt.getTime() - now.getTime()) / 1000)
    );
    const days = Math.floor(remainingSeconds / 86400);
    const hours = Math.floor((remainingSeconds % 86400) / 3600);
    const minutes = Math.floor((remainingSeconds % 3600) / 60);
    const seconds = remainingSeconds % 60;

    units.days.textContent = String(days);
    units.hours.textContent = String(hours).padStart(2, "0");
    units.minutes.textContent = String(minutes).padStart(2, "0");
    units.seconds.textContent = String(seconds).padStart(2, "0");
    status.textContent = days === 0 ? "Etkinlik bugün!" : "";
  };

  updateCountdown();
  window.setInterval(updateCountdown, 1000);
});
