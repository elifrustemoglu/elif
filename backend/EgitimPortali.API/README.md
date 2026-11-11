# Etkinlik Kataloğu (Console App)

## Özellikler
- **Tüm Etkinlikleri Listeleme:** Sistemde kayıtlı tüm etkinlikleri ID, Başlık, Tarih ve Kontenjan bilgileriyle listeler.
- **Yaklaşan Etkinlikler:** Tarihi bugünden (UTC) daha ileri olan etkinlikleri kronolojik sıraya göre listeler (LINQ `Where` ve `OrderBy` kullanılmıştır).
- **ID ile Arama:** Kullanıcının girdiği ID numarasına göre nokta atışı etkinlik araması yapar.
- **İsimle Arama:** Girilen anahtar kelimeyi başlığında içeren tüm etkinlikleri filtreler.

## Kullanılan Teknolojiler
- C# 10.0 / .NET
- Nesne Tabanlı Programlama (Encapsulation, Sınıf Modelleri)
- Generic Koleksiyonlar (`List<T>`, `Dictionary<TKey, TValue>`)
- LINQ (`Where`, `OrderBy`, `FirstOrDefault`, `Select`, `Any`)

## Nasıl Çalıştırılır?
1. Repoyu bilgisayarınıza klonlayın.
2. Terminal veya Geliştirici PowerShell üzerinden proje dizinine gidin.
3. `dotnet run` komutunu çalıştırarak ana menüye erişin.




## Veri Modelleri ve Zorunluluk (Nullable) Kararları

Frontend ve veritabanı tarafında uyumsuzluk yaşamamak için temel modellerimizin yapılarını ve hangi alanların boş geçilebileceğini (nullable) aşağıda netleştirdik.

### 1. Event (Etkinlik)
Etkinlik modelinde adres ve kontenjan gibi durumlar etkinliğin tipine göre değişebildiği için bazı alanları esnek bıraktık.

* **Zorunlu Alanlar:** `Id`, `Title`, `Slug` (URL için), `Description`, `StartDate`, `EndDate`, `LocationType` (Online/Fiziksel), `CategoryId`, `OrganizerUnitId`
* **Opsiyonel (Nullable) Alanlar:**
  * `PhysicalAddress`: Sadece fiziksel etkinliklerde dolacak, online ise `null`.
  * `OnlineMeetingUrl`: Sadece online etkinliklerde dolacak.
  * `Quota`: Kontenjan. Eğer etkinlik herkese açıksa ve kontenjan sınırı yoksa `null` bırakıyoruz (0 yazmıyoruz).

### 2. Announcement (Duyuru)
Duyurularda genelde bir bitiş tarihi olur ama bazen kalıcı duyurular da atmamız gerekebilir.

* **Zorunlu Alanlar:** `Id`, `Title`, `Content`, `PublishedDate`, `IsPinned` (Sabitlenmiş mi?)
* **Opsiyonel (Nullable) Alanlar:**
  * `ExpirationDate`: Duyurunun yayından kalkacağı tarih. Kalıcı bir duyuruysa `null` bırakılacak.

### 3. ContactMessage (İletişim Mesajı)
Kullanıcıdan gelen mesajlarda eksik bilgi istemediğimiz için tüm alanlar zorunlu.

* **Zorunlu Alanlar:** `Id`, `SenderName`, `SenderEmail`, `Subject`, `Message`, `SentDate`, `IsRead` (Okundu mu bilgisi, varsayılan: false)
