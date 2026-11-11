const etkinlikAdi = "Yapay Zeka";
const kategori = "Bilişim & Teknoloji";
const yer = "Salon 1";

const etkinlikVerileri = [
  {
    title: "Yazılıma Giriş",
    category: "technology",
    categoryLabel: "Bilişim & Teknoloji",
    type: "seminar",
    typeLabel: "Seminer",
    image: "software",
    imageAlt: "Yazılıma giriş semineri görseli",
    startsAt: "2026-12-05T10:00",
    location: "Amfi 1",
    capacity: 120,
    participants: null,
  },
  {
    title: "JavaScript ile Web Geliştirme",
    category: "web",
    categoryLabel: "Web & Yazılım",
    type: "education",
    typeLabel: "Eğitim",
    image: "javascript",
    imageAlt: "JavaScript ile web geliştirme görseli",
    startsAt: "2026-12-12T13:30",
    location: "Laboratuvar C",
    capacity: 300,
    participants: null,
  },
  {
    title: "Mobil Uygulama Geliştirme",
    category: "mobile",
    categoryLabel: "Mobil Teknolojiler",
    type: "education",
    typeLabel: "Eğitim",
    image: "mobile",
    imageAlt: "Mobil uygulama geliştirme görseli",
    startsAt: "2026-12-19T11:00",
    location: "Konferans Salonu B",
    capacity: 100,
    participants: null,
  },
  {
    title: "Git & GitHub Eğitimi",
    category: "developer",
    categoryLabel: "Geliştirici Araçları",
    type: "education",
    typeLabel: "Eğitim",
    image: "git",
    imageAlt: "Git ve GitHub eğitimi görseli",
    startsAt: "2027-01-09T14:00",
    location: "Laboratuvar A",
    capacity: 60,
    participants: null,
  },
  {
    title: "Tailwind CSS",
    category: "web",
    categoryLabel: "Web & Yazılım",
    type: "education",
    typeLabel: "Eğitim",
    image: "tailwind",
    imageAlt: "Tailwind CSS workshop görseli",
    startsAt: null,
    location: "Yakında duyurulacak",
    capacity: null,
    participants: null,
  },
  {
    title: "Yapay Zeka",
    category: "technology",
    categoryLabel: "Bilişim & Teknoloji",
    type: "conference",
    typeLabel: "Konferans",
    image: "ai",
    imageAlt: "Yapay zeka konferansı görseli",
    startsAt: "2027-01-23T13:00",
    location: "Salon 1",
    capacity: 300,
    participants: null,
  },
  {
    title: "Siber Güvenlik",
    category: "security",
    categoryLabel: "Siber Güvenlik",
    type: "seminar",
    typeLabel: "Seminer",
    image: "cybersecurity",
    imageAlt: "Siber güvenlik görseli",
    startsAt: "2026-11-28T14:00",
    location: "Konferans Salonu C",
    capacity: 125,
    participants: null,
  },
  {
    title: "Mühendislik ve Yazılım Kariyer",
    category: "engineering",
    categoryLabel: "Mühendislik & Gelecek",
    type: "conference",
    typeLabel: "Konferans",
    image: "engineering",
    imageAlt: "Mühendislik ve yazılım kariyer etkinliği görseli",
    startsAt: "2027-01-16T10:00",
    location: "Konferans Salonu A",
    capacity: 150,
    participants: null,
  },
];

let kontenjan = 300;
let kayitDurumuAcik = true;
let katilimciListesi = null; 
let egitmenPuani; 

console.log(" PORTAL ETKİNLİK BİLGİLERİ");
console.log("Etkinlik Adı:", etkinlikAdi);
console.log("Kategori:", kategori);
console.log("Yer:", yer);
console.log("Kontenjan:", kontenjan);
console.log("Kayıt Durumu Açık mı?:", kayitDurumuAcik);
console.log("Katılımcı Listesi:", katilimciListesi);
console.log("Eğitmen Puanı (Atanmadı):", egitmenPuani);

function etiketOlustur(kategori) {
  return "#" + kategori.toUpperCase();
}

function kontenjanKontrol(kalan) {
  if (kalan === 0) {
    return "Kontenjan doldu!";
  }
  return "Kalan yer: " + kalan;
}

function tarihYaz(gun, ay, yil) {
  return gun + "/" + ay + "/" + yil;
}

console.log(etiketOlustur("yazilim")); 
console.log(kontenjanKontrol(5));      
console.log(tarihYaz(28, 11, 2026));

const etkinlikler = etkinlikVerileri.map((etkinlik) => etkinlik.title);
console.log(" BÜTÜN ETKİNLİK LİSTESİ ");

etkinlikler.forEach((etkinlik, indeks) => {
  console.log(`${indeks + 1}. Etkinlik: ${etkinlik}`);
});

console.log(" FİLTRELENMİŞ ETKİNLİKLER");
etkinlikler.forEach((etkinlik) => {
  if (etkinlik.includes("Workshop") || etkinlik.includes("Eğitimi")) {
    console.log("Seçilen Önemli Etkinlik:", etkinlik);
  }
});

document.addEventListener('DOMContentLoaded', () => {
  const eventCardsContainer = document.getElementById('event-cards');

  if (eventCardsContainer) {
    eventCardsContainer.replaceChildren();

    etkinlikVerileri.forEach((etkinlik) => {
      const card = document.createElement('article');
      card.className = 'event-card rounded-2xl shadow-lg hover:shadow-xl transition-shadow duration-300 overflow-hidden flex flex-col justify-between p-4';
      card.dataset.category = etkinlik.category;
      card.dataset.eventType = etkinlik.type;

      const content = document.createElement('div');
      const image = document.createElement('div');
      image.className = `event-image event-image--${etkinlik.image} bg-slate-100 rounded-xl h-48 flex items-center justify-center text-slate-400 gap-2 mb-4`;
      image.setAttribute('role', 'img');
      image.setAttribute('aria-label', etkinlik.imageAlt);

      const categoryLabel = document.createElement('span');
      categoryLabel.className = 'text-[11px] font-bold text-gray-700 tracking-wider uppercase';
      categoryLabel.textContent = etkinlik.categoryLabel;

      const typeIcons = {
        education: ['M12 6.253v13m0-13C10.832 5.477 9.246 5 7.5 5S4.168 5.477 3 6.253v13C4.168 18.477 5.754 18 7.5 18s3.332.477 4.5 1.253m0-13C13.168 5.477 14.754 5 16.5 5c1.746 0 3.332.477 4.5 1.253v13C19.832 18.477 18.246 18 16.5 18c-1.746 0-3.332.477-4.5 1.253'],
        seminar: ['M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z'],
        conference: ['M8 5a4 4 0 108 0 4 4 0 00-8 0z', 'M4 21v-2a7 7 0 0114 0v2', 'M19 8v6', 'M22 10v2'],
      };
      
      const typeColors = {
        education: 'border-blue-200 bg-blue-50 text-blue-700',
        seminar: 'border-pink-200 bg-pink-50 text-pink-700',
        conference: 'border-violet-200 bg-violet-50 text-violet-700',
      };

      const typeLabel = document.createElement('span');
      typeLabel.className = `ml-2 inline-flex items-center gap-1 rounded-full border px-2.5 py-1 text-[11px] font-semibold ${typeColors[etkinlik.type]}`;
      
      const typeIcon = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
      typeIcon.setAttribute('class', 'h-3 w-3');
      typeIcon.setAttribute('fill', 'none');
      typeIcon.setAttribute('stroke', 'currentColor');
      typeIcon.setAttribute('viewBox', '0 0 24 24');
      typeIcon.setAttribute('aria-hidden', 'true');
      
      if (typeIcons[etkinlik.type]) {
        typeIcons[etkinlik.type].forEach((pathData) => {
          const path = document.createElementNS('http://www.w3.org/2000/svg', 'path');
          path.setAttribute('stroke-linecap', 'round');
          path.setAttribute('stroke-linejoin', 'round');
          path.setAttribute('stroke-width', '2');
          path.setAttribute('d', pathData);
          typeIcon.append(path);
        });
      }
      
      typeLabel.textContent = etkinlik.typeLabel;
      typeLabel.prepend(typeIcon);

      const title = document.createElement('h3');
      title.className = 'mt-1 mb-3 bg-gradient-to-r from-[#0F172A] to-[#1E3A8A] bg-clip-text text-xl font-bold text-transparent';
      title.textContent = etkinlik.title;

      const details = document.createElement('div');
      details.className = 'space-y-1.5 text-xs text-slate-500 font-medium mb-6';

      const createDetailIcon = (pathData) => {
        const icon = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
        icon.setAttribute('class', 'h-4 w-4 shrink-0 text-slate-400');
        icon.setAttribute('fill', 'none');
        icon.setAttribute('stroke', 'currentColor');
        icon.setAttribute('viewBox', '0 0 24 24');
        icon.setAttribute('aria-hidden', 'true');

        pathData.forEach((data) => {
          const path = document.createElementNS('http://www.w3.org/2000/svg', 'path');
          path.setAttribute('stroke-linecap', 'round');
          path.setAttribute('stroke-linejoin', 'round');
          path.setAttribute('stroke-width', '2');
          path.setAttribute('d', data);
          icon.append(path);
        });

        return icon;
      };

      const date = document.createElement('div');
      date.className = etkinlik.startsAt
        ? 'flex items-center gap-2'
        : 'flex items-center gap-2 rounded-lg border border-orange-200 bg-gradient-to-r from-orange-50 to-amber-100 px-2 py-1.5 font-semibold text-orange-800';
      
      const dateLabel = document.createElement('span');
      if (etkinlik.startsAt) {
        const [datePart, timePart] = etkinlik.startsAt.split('T');
        const [year, month, day] = datePart.split('-').map(Number);
        const [hours, minutes] = timePart.split(':').map(Number);
        const startsAt = new Date(year, month - 1, day, hours, minutes);
        const formattedDate = new Intl.DateTimeFormat('tr-TR', {
          weekday: 'long',
          day: 'numeric',
          month: 'long',
          year: 'numeric',
        }).format(startsAt);
        const formattedTime = new Intl.DateTimeFormat('tr-TR', {
          hour: '2-digit',
          minute: '2-digit',
        }).format(startsAt);
        const time = document.createElement('time');
        time.dateTime = etkinlik.startsAt;
        time.textContent = `${formattedDate} · ${formattedTime}`;
        dateLabel.append(time);
      } else {
        dateLabel.textContent = 'Tarih ve saat yakında duyurulacak';
      }
      
      date.append(
        createDetailIcon([
          'M8 7V3m8 4V3M4 11h16M5 5h14a1 1 0 011 1v14H4V6a1 1 0 011-1z',
        ]),
        dateLabel,
      );

      const location = document.createElement('div');
      location.className = 'flex items-center gap-2';
      const locationLabel = document.createElement('span');
      locationLabel.textContent = etkinlik.location;
      location.append(
        createDetailIcon([
          'M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z',
          'M15 11a3 3 0 11-6 0 3 3 0 016 0z',
        ]),
        locationLabel,
      );

      const attendance = document.createElement('div');
      attendance.className = 'flex items-center gap-2';
      const attendanceLabel = document.createElement('span');
      attendanceLabel.textContent = etkinlik.capacity === null
        ? 'Kontenjan bilgisi yakında duyurulacak'
        : `Kontenjan: ${etkinlik.capacity} kişi`;
      
      attendance.append(
        createDetailIcon([
          'M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z',
        ]),
        attendanceLabel,
      );

      details.append(date, location, attendance);
      content.append(image, categoryLabel, typeLabel, title, details);

      const joinButton = document.createElement('button');
      joinButton.type = 'button';
      joinButton.className = 'w-fit bg-gradient-to-r from-[#1E293B] to-[#1E3A8A] text-white text-xs font-semibold px-5 py-2.5 rounded-full shadow-md shadow-slate-900/20 hover:from-[#27364B] hover:to-[#1E40AF] transition-all';
      joinButton.dataset.action = 'join';
      joinButton.textContent = 'Etkinliğe Katıl';

      card.append(content, joinButton);
      eventCardsContainer.append(card);
    });
  }

  const authDialog = document.getElementById('auth-dialog');
  const closeAuthDialog = document.getElementById('close-auth-dialog');

  if (eventCardsContainer && authDialog instanceof HTMLDialogElement && closeAuthDialog instanceof HTMLButtonElement) {
    eventCardsContainer.addEventListener('click', (event) => {
      if (!(event.target instanceof Element)) return;

      const joinButton = event.target.closest('button[data-action="join"]');
      if (!joinButton || !eventCardsContainer.contains(joinButton)) return;

      authDialog.showModal();
    });

    closeAuthDialog.addEventListener('click', () => {
      authDialog.close();
    });

    authDialog.addEventListener('click', (event) => {
      if (event.target === authDialog) authDialog.close();
    });
  }

  const title = document.getElementById('main-title');
  const changeBtn = document.querySelector('#change-btn');
  const descText = document.querySelector('#desc-text');
  const descBtn = document.querySelector('#desc-btn');
  const counterValue = document.querySelector('#counter-value');
  const incrementBtn = document.querySelector('#increment-btn');

  if (title && changeBtn) {
    changeBtn.addEventListener('click', () => {
      title.textContent = 'Güncellenmiş Etkinlik Portalı (DOM Çalışması)';
      title.style.color = '#2563eb';
    });
  }

  if (descText && descBtn) {
    descBtn.addEventListener('click', () => {
      descText.innerHTML = '<strong>Harika!</strong> DOM üzerinden HTML yapısı başarıyla değiştirildi.';
    });
  }

  if (counterValue && incrementBtn) {
    let count = 0;
    incrementBtn.addEventListener('click', () => {
      count++;
      counterValue.textContent = count;
    });
  }

  const typeFilters = document.getElementById('type-filters');
  const search = document.getElementById('event-search');
  const results = document.getElementById('event-results');
  const cards = document.querySelectorAll('.event-card');

  if (typeFilters && search instanceof HTMLInputElement && results && cards.length > 0) {
    const typeButtons = Array.from(typeFilters.querySelectorAll('button[data-type]'));
    const requestedType = new URLSearchParams(window.location.search).get('type');
    const initialTypeButton = typeButtons.find((button) => button.dataset.type === requestedType)
      ?? typeButtons.find((button) => button.dataset.type === 'all');
    let activeType = initialTypeButton?.dataset.type ?? 'all';

    typeButtons.forEach((button) => {
      button.setAttribute('aria-pressed', String(button === initialTypeButton));
    });

    const filterEvents = () => {
      const query = search.value.trim().toLocaleLowerCase('tr');
      let visibleCount = 0;

      cards.forEach((card) => {
        const typeMatches = activeType === 'all' || card.dataset.eventType === activeType;
        const cardTitle = card.querySelector('h3')?.textContent ?? '';
        const queryMatches = cardTitle.toLocaleLowerCase('tr').includes(query);
        card.hidden = !typeMatches || !queryMatches;

        if (!card.hidden) visibleCount++;
      });

      results.textContent = visibleCount
        ? `${visibleCount} etkinlik gösteriliyor.`
        : 'Aramanızla eşleşen etkinlik bulunamadı.';
      results.dataset.empty = String(visibleCount === 0);
    };

    typeFilters.addEventListener('click', (event) => {
      if (!(event.target instanceof Element)) return;

      const button = event.target.closest('button[data-type]');
      if (!button || !typeFilters.contains(button)) return;

      activeType = button.dataset.type;
      typeButtons.forEach((filterButton) => {
        filterButton.setAttribute('aria-pressed', String(filterButton === button));
      });
      filterEvents();
    });

    search.addEventListener('input', filterEvents);
    filterEvents();
  }

  const backendEventList = document.getElementById('backend-event-list');
  const backendEventsStatus = document.getElementById('backend-events-status');

  if (backendEventList && backendEventsStatus) {
    fetch('https://10.100.42.74:7217/api/events')
      .then((response) => {
        if (!response.ok) {
          throw new Error(`Sunucu HTTP ${response.status} yanıtı verdi.`);
        }
        return response.json();
      })
      .then((result) => {
        console.log("Backend'den gelen tam yanıt:", result);
        
        const eventsArray = result.data || result; 

        if (!Array.isArray(eventsArray)) {
          throw new Error('API yanıtı etkinlik listesi biçiminde değil.');
        }

        backendEventList.replaceChildren();
        eventsArray.forEach((event) => {
          if (!event || typeof event.title !== 'string') {
            return;
          }

          const item = document.createElement('li');
          item.textContent = event.title;
          backendEventList.append(item);
        });

        backendEventsStatus.textContent = backendEventList.childElementCount
          ? `Backend'den ${backendEventList.childElementCount} etkinlik yüklendi.`
          : 'Backend bağlantısı başarılı; henüz etkinlik bulunmuyor.';
      })
      .catch((error) => {
        console.error('Backend etkinlikleri yüklenemedi:', error);
        backendEventsStatus.textContent =
          'Backend API’ye ulaşılamadı. Backend’in çalıştığını, adres/portu ve CORS ayarlarını kontrol edin.';
        backendEventsStatus.setAttribute('role', 'alert');
      });
  }
});