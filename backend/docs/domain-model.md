# Domain Model ve Veri Sözleşmesi

## 1. Event (Etkinlik) Modeli
* **Id**: int (Primary Key)
* **Title**: string (Max: 200, Zorunlu)
* **Slug**: string (Max: 160, Unique, Zorunlu)
* **Description**: string (Opsiyonel)
* **StartDate**: DateTime (Zorunlu)
* **EndDate**: DateTime (Zorunlu)
* **LocationType**: string ("Fiziksel" / "Online")
* **PhysicalAddress**: string (Opsiyonel - Fiziksel ise)
* **OnlineMeetingUrl**: string (Opsiyonel - Online ise)
* **Quota**: int? (Opsiyonel Kontenjan)
* **CategoryId**: int (Foreign Key - Category)
* **OrganizerUnitId**: int (Foreign Key - OrganizerUnit)
* **IsDeleted**: bool (Soft Delete için)

## 2. OrganizerUnit (Düzenleyen Birim) Modeli
* **Id**: int (Primary Key)
* **Name**: string (Max: 100, Zorunlu - Örn: "Bilgi İşlem Daire Başkanlığı")
* **Code**: string (Max: 20, Opsiyonel Birim Kodu)
* **IsActive**: bool (Varsayılan: true)

## 3. İlişki Kuralları
* Bir **OrganizerUnit** birden fazla **Event** düzenleyebilir (One-to-Many).
* Her **Event** bir **OrganizerUnit**'e bağlı olmak zorundadır.