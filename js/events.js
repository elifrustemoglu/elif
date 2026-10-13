// --- JavaScript'e Giriş ve Değişkenler ---

const etkinlikAdi = "Yapay Zeka ve Gelecek Konferansı";
const kategori = "Teknoloji";
const yer = "Konferans Salonu A";


let kontenjan = 50;
const etkinlikUcreti = 0; // Ücretsiz etkinlik


let isOnline = false;
let kayitDurumuAcik = true;

// 4. Null ve Undefined örnekleri
let katilimciListesi = null; // Henüz liste boş/tanımlı değil
let egitmenPuani; // Değer atanmadığı için "undefined" olacak

// --- Bilgileri Konsola Yazdırma ---
console.log("=== PORTAL ETKİNLİK BİLGİLERİ ===");
console.log("Etkinlik Adı:", etkinlikAdi);
console.log("Kategori:", kategori);
console.log("Yer:", yer);
console.log("Kontenjan:", kontenjan);
console.log("Çevrim İçi mi?:", isOnline);
console.log("Kayıt Durumu Açık mı?:", kayitDurumuAcik);
console.log("Katılımcı Listesi:", katilimciListesi);
console.log("Eğitmen Puanı (Atanmadı):", egitmenPuani);