# Veritabanı Kurulum ve Taslak Dokümanı

## 1. Ortam Bilgileri
* **RDBMS:** MySQL 8.0
* **Veritabanı Adı:** `EgitimPortaliDb`
* **Bağlantı İstemcisi:** DBeaver
* **Port:** 3306 (localhost)

## 2. `Events` Tablosu Mantıksal Taslağı (Stajyer A)

| Alan Adı (Field) | Veri Tipi | Zorunlu mu? | Açıklama / Kısıt |
| :--- | :--- | :--- | :--- |
| **Id** | INT | Evet | Birincil Anahtar (Primary Key), Otomatik Artan (AUTO_INCREMENT) |
| **Title** | VARCHAR(100) | Evet | Etkinlik başlığı |
| **Slug** | VARCHAR(150) | Evet | URL dostu metin formatı |
| **Description** | TEXT | Hayır | Etkinliğin detaylı açıklaması |
| **StartDate** | DATETIME | Evet | Etkinlik başlangıç tarihi ve saati |
| **LocationType** | VARCHAR(50) | Hayır | Etkinlik türü (Online / Yüz Yüze) |
| **CategoryId** | INT | Evet | Bağlı olduğu kategori kimliği (Foreign Key -> Categories.Id) |
| **CreatedAt** | DATETIME | Evet | Kaydın oluşturulma tarihi (Varsayılan: CURRENT_TIMESTAMP) |