Proje Veritabanı Kurulum Notları ve Tablo Taslakları (26.10.2026)

-------- Tablo Taslakları --------

Aşağıda Stajyer B tarafından hazırlanan Category ve Announcement tablolarının veri yapıları metin halinde listelenmiştir.


-------- Category (Kategori) Tablosu --------

Kategorileri (Seminer, Atölye vb.) tutacağımız tablodur.

Id: Benzersiz kimlik (Integer, Primary Key, Auto Increment)

Name: Kategori adı (Varchar, Not Null)

IsActive: Kategorinin aktiflik durumu (Boolean, Default True)

IsDeleted: Çöp kutusu durumu / Soft delete (Boolean, Default False)


-------- Announcement (Duyuru) Tablosu --------

Sistemdeki duyuruları tutacağımız tablodur.

Id: Benzersiz kimlik (Integer, Primary Key, Auto Increment)

Title: Duyuru başlığı (Varchar, Not Null)

Content: Duyuru içeriği (Text, Not Null)

PublishDate: Yayınlanma zamanı (Timestamp, Default Current_Timestamp)

PriorityLevel: Önem derecesi - Düşük / Normal / Acil (Varchar, Default 'Normal')

IsDeleted: Çöp kutusu durumu / Soft delete (Boolean, Default False)