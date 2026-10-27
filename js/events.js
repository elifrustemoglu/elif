const etkinlikAdi = "Yapay Zeka";
const kategori = "Bilişim & Teknoloji";
const yer = "Salon 1";

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

//  En az 8 etkinlik 
const etkinlikler = [
  "Yazılıma Giriş",
  "JavaScript ile Web Geliştirme",
  "Mobil Uygulama Geliştirme",
  "Git & GitHub Eğitimi",
  "Tailwind CSS",
  "Yapay Zeka",
  "Siber Güvenlik",
  "Mühendislik ve Yazılım Kariyer"
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

document.addEventListener('DOMContentLoaded', () => {
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
});