// --- JavaScript'e Giriş ve Değişkenler ---

const etkinlikAdi = "Yapay Zeka ve Gelecek Konferansı";
const kategori = "Teknoloji";
const yer = "Konferans Salonu A";

let kontenjan = 50;
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


