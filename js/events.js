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
    location: "Amfi 1",
    capacity: "120 Kişi",
  },
  {
    title: "JavaScript ile Web Geliştirme",
    category: "web",
    categoryLabel: "Web & Yazılım",
    type: "education",
    typeLabel: "Eğitim",
    image: "javascript",
    imageAlt: "JavaScript ile web geliştirme görseli",
    location: "Laboratuvar C",
    capacity: "300 Kişi",
  },
  {
    title: "Mobil Uygulama Geliştirme",
    category: "mobile",
    categoryLabel: "Mobil Teknolojiler",
    type: "education",
    typeLabel: "Eğitim",
    image: "mobile",
    imageAlt: "Mobil uygulama geliştirme görseli",
    location: "Konferans Salonu B",
    capacity: "100 Kişi",
  },
  {
    title: "Git & GitHub Eğitimi",
    category: "developer",
    categoryLabel: "Geliştirici Araçları",
    type: "education",
    typeLabel: "Eğitim",
    image: "git",
    imageAlt: "Git ve GitHub eğitimi görseli",
    location: "Laboratuvar A",
    capacity: "60 Kişi",
  },
  {
    title: "Tailwind CSS",
    category: "web",
    categoryLabel: "Web & Yazılım",
    type: "education",
    typeLabel: "Eğitim",
    image: "tailwind",
    imageAlt: "Tailwind CSS workshop görseli",
    location: "Yakında duyurulacak",
    capacity: "Yakında duyurulacak",
  },
  {
    title: "Yapay Zeka",
    category: "technology",
    categoryLabel: "Bilişim & Teknoloji",
    type: "conference",
    typeLabel: "Konferans",
    image: "ai",
    imageAlt: "Yapay zeka konferansı görseli",
    location: "Salon 1",
    capacity: "1000 Kişi",
  },
  {
    title: "Siber Güvenlik",
    category: "security",
    categoryLabel: "Siber Güvenlik",
    type: "seminar",
    typeLabel: "Seminer",
    image: "cybersecurity",
    imageAlt: "Siber güvenlik görseli",
    location: "Konferans Salonu C",
    capacity: "125 Kişi",
  },
  {
    title: "Mühendislik ve Yazılım Kariyer",
    category: "engineering",
    categoryLabel: "Mühendislik & Gelecek",
    type: "conference",
    typeLabel: "Konferans",
    image: "engineering",
    imageAlt: "Mühendislik ve yazılım kariyer etkinliği görseli",
    location: "Konferans Salonu A",
    capacity: "150 Kişi",
  },
];

let kontenjan = 1000;
let isOnline = false;
let kayitDurumuAcik = true;
let katilimciListesi = null; 
let egitmenPuani; 

console.log(" PORTAL ETKİNLİK BİLGİLERİ");
console.log("Etkinlik Adı:", etkinlikAdi);
console.log("Kategori:", kategori);
console.log("Yer:", yer);
console.log("Kontenjan:", kontenjan);
console.log("Çevrim İçi mi?:", isOnline);
console.log("Kayıt Durumu Açık mı?:", kayitDurumuAcik);
console.log("Katılımcı Listesi:", katilimciListesi);
console.log("Eğitmen Puanı (Atanmadı):", egitmenPuani);


function etiketOlustur(kategori) 
{
  return "#" + kategori.toUpperCase();
}

function kontenjanKontrol(kalan) 
{
  if (kalan === 0) {
    return "Kontenjan doldu!";
  }
  return "Kalan yer: " + kalan;
}

function tarihYaz(gun, ay, yil) 
{
  return gun + "/" + ay + "/" + yil;
}

console.log(etiketOlustur("yazilim")); 
console.log(kontenjanKontrol(5));      
console.log(tarihYaz(19, 10, 2026));   

const etkinlikler = etkinlikVerileri.map((etkinlik) => etkinlik.title);
console.log(" BÜTÜN ETKİNLİK LİSTESİ ");

etkinlikler.forEach((etkinlik, indeks) =>
 {
  console.log(`${indeks + 1}. Etkinlik: ${etkinlik}`);
});
console.log(" FİLTRELENMİŞ ETKİNLİKLER");

etkinlikler.forEach((etkinlik) => 
  {
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
      card.className = 'event-card bg-white rounded-2xl shadow-lg hover:shadow-xl transition-shadow duration-300 overflow-hidden flex flex-col justify-between p-4';
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
      typeIcons[etkinlik.type].forEach((pathData) => {
        const path = document.createElementNS('http://www.w3.org/2000/svg', 'path');
        path.setAttribute('stroke-linecap', 'round');
        path.setAttribute('stroke-linejoin', 'round');
        path.setAttribute('stroke-width', '2');
        path.setAttribute('d', pathData);
        typeIcon.append(path);
      });
      typeLabel.textContent = etkinlik.typeLabel;
      typeLabel.prepend(typeIcon);

      const title = document.createElement('h3');
      title.className = 'text-xl font-bold text-slate-800 mt-1 mb-3';
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

      const capacity = document.createElement('div');
      capacity.className = 'flex items-center gap-2';
      const capacityLabel = document.createElement('span');
      capacityLabel.textContent = `Kontenjan: ${etkinlik.capacity}`;
      capacity.append(
        createDetailIcon([
          'M17 20h5v-2a3 3 0 00-5.356-1.857M17 20H7m10 0v-2c0-.656-.126-1.283-.356-1.857M7 20H2v-2a3 3 0 015.356-1.857M7 20v-2c0-.656.126-1.283.356-1.857m0 0a5.002 5.002 0 019.288 0M15 7a3 3 0 11-6 0 3 3 0 016 0zm6 3a2 2 0 11-4 0 2 2 0 014 0zM7 10a2 2 0 11-4 0 2 2 0 014 0z',
        ]),
        capacityLabel,
      );

      details.append(location, capacity);
      content.append(image, categoryLabel, typeLabel, title, details);

      const joinButton = document.createElement('button');
      joinButton.type = 'button';
      joinButton.className = 'w-fit bg-gradient-to-r from-[#8E9AAF] via-[#34495E] to-[#2C3E50] text-[#F4F7F6] text-xs font-semibold px-5 py-2.5 rounded-full shadow-md shadow-[#8E9AAF]/30 hover:from-[#A8B1C0] hover:to-[#34495E] transition-all';
      joinButton.textContent = 'Etkinliğe Katıl';

      card.append(content, joinButton);
      eventCardsContainer.append(card);
    });
  }

  // 1. Elemanları Seçme (document.getElementById ve querySelector kullanımı)
  const title = document.getElementById('main-title');
  const changeBtn = document.querySelector('#change-btn');
  const descText = document.querySelector('#desc-text');
  const descBtn = document.querySelector('#desc-btn');
  const counterValue = document.querySelector('#counter-value');
  const incrementBtn = document.querySelector('#increment-btn');

  if (title && changeBtn) {
    console.log('Seçilen Başlık Elementi:', title);
    console.log('Başlık Metni:', title.textContent);
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

  // DOM alıştırma elemanları yalnızca ilgili alıştırma sayfasında bulunur.
  const baslik = document.getElementById('portalBasligi');
  const sayac = document.querySelector('#sayacMiktari');
  const metinKutusu = document.querySelector('#kullaniciGirdisi');

  if (baslik && sayac && metinKutusu) {
    console.log('Seçilen Başlık Elementi:', baslik);
    console.log('Mevcut Başlık Metni:', baslik.textContent);
    console.log('Mevcut Input Değeri:', metinKutusu.value);

    baslik.textContent = 'Eğitim ve Etkinlik Duyuru Portalı';
    sayac.textContent = '15';
    console.log('Eski Input Value:', metinKutusu.value);
    metinKutusu.value = 'Yeni Duyuru Başlığı';
    baslik.classList.add('vurgulu');
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
        const title = card.querySelector('h3')?.textContent ?? '';
        const queryMatches = title.toLocaleLowerCase('tr').includes(query);
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
});
