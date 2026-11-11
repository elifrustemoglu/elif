document.addEventListener("DOMContentLoaded", () => {
  const countdown = document.getElementById("upcoming-event-countdown");
  if (!countdown) return;

  const events = [
    { title: "Siber Güvenlik", startsAt: "2026-11-28T14:00", capacity: 125, location: "Konferans Salonu C" },
    { title: "Yazılıma Giriş", startsAt: "2026-12-05T10:00", capacity: 120, location: "Amfi 1" },
    { title: "JavaScript ile Web Geliştirme", startsAt: "2026-12-12T13:30", capacity: 300, location: "Laboratuvar C" },
    { title: "Mobil Uygulama Geliştirme", startsAt: "2026-12-19T11:00", capacity: 100, location: "Konferans Salonu B" },
    { title: "Git & GitHub Eğitimi", startsAt: "2027-01-09T14:00", capacity: 60, location: "Laboratuvar A" },
    { title: "Mühendislik ve Yazılım Kariyer", startsAt: "2027-01-16T10:00", capacity: 150, location: "Konferans Salonu A" },
    { title: "Yapay Zeka", startsAt: "2027-01-23T13:00", capacity: 300, location: "Salon 1" }
  ];
  const scheduledEvents = events.map(event => {
    const [date, time] = event.startsAt.split("T");
    const [year, month, day] = date.split("-").map(Number);
    const [hours, minutes] = time.split(":").map(Number);
    return { ...event, eventDate: new Date(year, month - 1, day, hours, minutes) };
  });
  const title = document.getElementById("countdown-title");
  const dateLabel = document.getElementById("countdown-date");
  const status = document.getElementById("countdown-status");
  const attendanceEventTitle = document.getElementById("attendance-event-title");
  const attendanceCount = document.getElementById("attendance-count");
  const units = {
    days: document.getElementById("countdown-days"),
    hours: document.getElementById("countdown-hours"),
    minutes: document.getElementById("countdown-minutes"),
    seconds: document.getElementById("countdown-seconds")
  };
  const formatDate = new Intl.DateTimeFormat("tr-TR", {
    weekday: "long",
    day: "numeric",
    month: "long",
    year: "numeric"
  });
  const formatTime = new Intl.DateTimeFormat("tr-TR", {
    hour: "2-digit",
    minute: "2-digit"
  });
  const featuredEventList = document.getElementById("featured-event-list");
  if (featuredEventList) {
    const upcomingEvents = scheduledEvents
      .filter(event => event.eventDate > new Date())
      .sort((first, second) => first.eventDate - second.eventDate)
      .slice(0, 3);

    if (upcomingEvents.length === 0) {
      const emptyState = document.createElement("p");
      emptyState.className = "text-sm text-slate-600";
      emptyState.textContent = "Şu anda öne çıkan yaklaşan etkinlik bulunmuyor.";
      featuredEventList.append(emptyState);
    } else {
      upcomingEvents.forEach(event => {
        const card = document.createElement("article");
        card.className = "flex flex-col rounded-2xl border border-slate-300 bg-gradient-to-br from-white via-blue-50 to-indigo-100 p-5 shadow-sm";

        const date = document.createElement("p");
        date.className = "text-xs font-semibold uppercase tracking-wide text-blue-800";
        date.textContent = `${formatDate.format(event.eventDate)} · ${formatTime.format(event.eventDate)}`;

        const eventTitle = document.createElement("h3");
        eventTitle.className = "mt-2 text-lg font-bold text-slate-900";
        eventTitle.textContent = event.title;

        const details = document.createElement("p");
        details.className = "mt-3 text-sm text-slate-600";
        details.textContent = `${event.location} · Kontenjan: ${event.capacity} kişi`;

        const link = document.createElement("a");
        link.className = "mt-5 inline-flex w-fit items-center gap-2 text-sm font-semibold text-blue-900 transition hover:text-blue-700";
        link.href = "events.html";
        link.textContent = "Etkinlik detayları";

        card.append(date, eventTitle, details, link);
        featuredEventList.append(card);
      });
    }
  }
  const formatMonth = new Intl.DateTimeFormat("tr-TR", {
    month: "long",
    year: "numeric"
  });
  const formatDay = new Intl.DateTimeFormat("tr-TR", {
    day: "numeric",
    month: "long"
  });
  const dateKey = date => [
    date.getFullYear(),
    String(date.getMonth() + 1).padStart(2, "0"),
    String(date.getDate()).padStart(2, "0")
  ].join("-");

  const updateCountdown = () => {
    const now = new Date();
    const nextEvent = scheduledEvents
      .filter(event => event.eventDate > now)
      .sort((first, second) => first.eventDate - second.eventDate)[0];

    if (!nextEvent) {
      title.textContent = "Yaklaşan etkinlik bulunmuyor";
      dateLabel.textContent = "";
      status.textContent = "";
      attendanceEventTitle.textContent = "Yaklaşan etkinlik bulunmuyor";
      attendanceCount.textContent = "";
      document.getElementById("countdown-timer").hidden = true;
      return;
    }

    document.getElementById("countdown-timer").hidden = false;
    title.textContent = nextEvent.title;
    attendanceEventTitle.textContent = nextEvent.title;
    attendanceCount.textContent = `${nextEvent.capacity} kişi`;
    dateLabel.textContent = `${formatDate.format(nextEvent.eventDate)} · ${formatTime.format(nextEvent.eventDate)}`;

    const remainingSeconds = Math.max(
      0,
      Math.floor((nextEvent.eventDate.getTime() - now.getTime()) / 1000)
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

  const calendarMonth = document.getElementById("calendar-month");
  const calendarDays = document.getElementById("calendar-days");
  const calendarSelection = document.getElementById("calendar-selection");
  const previousMonth = document.getElementById("calendar-previous");
  const nextMonth = document.getElementById("calendar-next");

  if (calendarMonth && calendarDays && calendarSelection && previousMonth && nextMonth) {
    let displayedMonth = new Date();
    let selectedDate = new Date(
      displayedMonth.getFullYear(),
      displayedMonth.getMonth(),
      displayedMonth.getDate()
    );
    const eventsByDate = new Map();

    scheduledEvents.forEach(event => {
      const key = dateKey(event.eventDate);
      eventsByDate.set(key, [...(eventsByDate.get(key) || []), event]);
    });

    const renderCalendar = () => {
      const year = displayedMonth.getFullYear();
      const month = displayedMonth.getMonth();
      const firstWeekday = (new Date(year, month, 1).getDay() + 6) % 7;
      const daysInMonth = new Date(year, month + 1, 0).getDate();
      const cellCount = Math.ceil((firstWeekday + daysInMonth) / 7) * 7;
      const todayKey = dateKey(new Date());
      calendarMonth.textContent = formatMonth.format(displayedMonth);
      calendarDays.replaceChildren();

      for (let index = 0; index < cellCount; index += 1) {
        const dayNumber = index - firstWeekday + 1;
        const date = new Date(year, month, dayNumber);
        const key = dateKey(date);
        const dayEvents = eventsByDate.get(key) || [];
        const inDisplayedMonth = dayNumber >= 1 && dayNumber <= daysInMonth;
        const dayButton = document.createElement("button");
        dayButton.type = "button";
        dayButton.disabled = !inDisplayedMonth;
        dayButton.setAttribute("aria-pressed", String(key === dateKey(selectedDate)));
        dayButton.setAttribute(
          "aria-label",
          `${formatDate.format(date)}${dayEvents.length ? `, ${dayEvents.length} etkinlik` : ""}`
        );
        dayButton.className = inDisplayedMonth
          ? "mx-auto flex h-7 w-7 flex-col items-center justify-center rounded-full text-xs text-slate-700 transition hover:bg-blue-50 hover:text-blue-800 aria-pressed:bg-gradient-to-r aria-pressed:from-[#2563EB] aria-pressed:to-[#1D4ED8] aria-pressed:font-bold aria-pressed:text-white"
          : "mx-auto flex h-7 w-7 items-center justify-center rounded-full text-xs text-slate-500";
        if (key === todayKey && key !== dateKey(selectedDate)) {
          dayButton.classList.add("ring-1", "ring-blue-300");
        }

        const dayLabel = document.createElement("span");
        dayLabel.textContent = String(date.getDate());
        dayButton.append(dayLabel);
        if (dayEvents.length > 0) {
          const eventDot = document.createElement("span");
          eventDot.className = key === dateKey(selectedDate)
            ? "mt-0.5 h-1 w-1 rounded-full bg-white"
            : "mt-0.5 h-1 w-1 rounded-full bg-cyan-500";
          eventDot.setAttribute("aria-hidden", "true");
          dayButton.append(eventDot);
        }

        if (inDisplayedMonth) {
          dayButton.addEventListener("click", () => {
            selectedDate = date;
            renderCalendar();
          });
        }
        calendarDays.append(dayButton);
      }

      const selectedEvents = eventsByDate.get(dateKey(selectedDate)) || [];
      if (selectedEvents.length === 0) {
        calendarSelection.textContent = `${formatDay.format(selectedDate)} için planlanmış etkinlik yok.`;
      } else {
        calendarSelection.textContent = selectedEvents
          .map(event => `${formatTime.format(event.eventDate)} · ${event.title}`)
          .join("  |  ");
      }
    };

    previousMonth.addEventListener("click", () => {
      displayedMonth = new Date(displayedMonth.getFullYear(), displayedMonth.getMonth() - 1, 1);
      selectedDate = new Date(displayedMonth.getFullYear(), displayedMonth.getMonth(), 1);
      renderCalendar();
    });
    nextMonth.addEventListener("click", () => {
      displayedMonth = new Date(displayedMonth.getFullYear(), displayedMonth.getMonth() + 1, 1);
      selectedDate = new Date(displayedMonth.getFullYear(), displayedMonth.getMonth(), 1);
      renderCalendar();
    });

    renderCalendar();
  }

  const motivationTitle = document.getElementById("motivation-title");
  const newMotivation = document.getElementById("new-motivation");
  if (motivationTitle && newMotivation) {
    const messages = [
      "Her büyük başarı, bugün atılan küçük bir adımla başlar.",
      "Öğrenmeye ayırdığın her dakika, geleceğine yaptığın yatırımdır.",
      "Merak et, dene, keşfet; gelişimin en güzel yolu budur."
    ];
    let messageIndex = 0;

    newMotivation.addEventListener("click", () => {
      messageIndex = (messageIndex + 1) % messages.length;
      motivationTitle.textContent = messages[messageIndex];
    });
  }
});
