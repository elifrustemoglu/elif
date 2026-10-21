const etkinlikAdi = "Yapay Zeka";
const kategori = "Teknoloji";
const yer = "Konferans Salonu A";

let kontenjan = 200;
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

//  En az 8 etkinlik 
const etkinlikler = [
  "Yazılıma Giriş Semineri",
  "Tailwind CSS Workshop",
  "Yapay Zeka ve Gelecek Konferansı",
  "JavaScript ile Web Geliştirme",
  "Siber Güvenlik Webinarı",
  "Mobil Uygulama Geliştirme",
  "Git & GitHub Eğitimi",
  "UX/UI Tasarım Atölyesi"
]
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


// js/main.js

document.addEventListener("DOMContentLoaded", () => {
  // HTML'deki ana kapsayıcıyı seçiyoruz
  const container = document.getElementById("events-container");

  // Eğer sayfada bu ID yoksa hata vermemesi için kontrol koyuyoruz
  if (!container) return;

  // Konteynerin içini sıfırlıyoruz
  container.innerHTML = "";

  // eventsData dizisindeki her bir etkinlik için dönüyoruz
  eventsData.forEach(event => {
    // Yeni bir div (kart) oluşturuyoruz
    const card = document.createElement("div");
    
    // Tailwind sınıflarını ekleyerek şık bir kart tasarımı yapıyoruz
    card.className = "bg-white p-5 rounded-xl shadow-sm border border-gray-100 flex flex-col justify-between hover:shadow-md transition";

    // Kartın içine gelecek HTML yapısı
    card.innerHTML = `
      <div>
        <span class="text-xs font-bold text-purple-600 uppercase tracking-wider bg-purple-50 px-2 py-1 rounded">
          ${event.category}
        </span>
        <h3 class="text-lg font-bold text-gray-800 mt-3">${event.title}</h3>
        <p class="text-sm text-gray-600 mt-2 line-clamp-2">${event.description}</p>
      </div>

      <div class="mt-4 pt-3 border-t border-gray-100 text-xs text-gray-500 space-y-1">
        <p>📅 <strong>Tarih:</strong> ${event.date} - ${event.time}</p>
        <p>📍 <strong>Yer:</strong> ${event.location}</p>
        <p>🏢 <strong>Birim:</strong> ${event.unit}</p>
      </div>

      <button onclick="alert('${event.title} etkinliğine tıklandı!')" 
              class="mt-5 w-full bg-purple-600 text-white py-2 rounded-lg text-sm font-medium hover:bg-purple-700 transition">
        Detayları Gör
      </button>
    `;

    // Oluşturduğumuz kartı sayfadaki ana kutunun içine ekliyoruz
    container.appendChild(card);
  });
});

// 1. Elemanları Seçme (document.getElementById ve querySelector kullanımı)
const title = document.getElementById('main-title');
const changeBtn = document.querySelector('#change-btn');

const descText = document.querySelector('#desc-text');
const descBtn = document.querySelector('#desc-btn');

const counterValue = document.querySelector('#counter-value');
const incrementBtn = document.querySelector('#increment-btn');

// Console üzerinden elementleri inceleme (Gereksinim kontrolü)
console.log('Seçilen Başlık Elementi:', title);
console.log('Başlık Metni:', title.textContent);

// 2. Başlık Metnini ve Stilini Değiştirme
changeBtn.addEventListener('click', () => {
  title.textContent = "Güncellenmiş Etkinlik Portalı (DOM Çalışması)";
  title.style.color = "#2563eb"; // Renk değiştirme
});

// 3. Açıklama Metnini Değiştirme
descBtn.addEventListener('click', () => {
  descText.innerHTML = "<strong>Harika!</strong> DOM üzerinden HTML yapısı başarıyla değiştirildi.";
});

// 4. Sayaç Mantığı
let count = 0;
incrementBtn.addEventListener('click', () => {
  count++;
  counterValue.textContent = count;
});