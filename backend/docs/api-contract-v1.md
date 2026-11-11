# Frontend - Backend API Sözleşmesi v1 (Announcement & Contact)

1. TESPİT EDİLEN SÖZLEŞME EKSİKLERİ VE ÇÖZÜMLER

* ContactMessage Yanıt (Response) Modeli Eksikliği:
  - Sorun: İletişim formu gönderildiğinde kayıt ID'si ve oluşturulma tarihi (CreatedAt) eksikti.
  - Çözüm: ContactMessageDto eklendi.

* Announcement Filtreleme ve Doğrulama Eksikliği:
  - Sorun: Aktif duyuruları filtreleme parametresi ve duyuru eklerken karakter sınırları net değildi.
  - Çözüm: GET /api/announcements uç noktasına ?isActive=true query parametresi ve CreateAnnouncementDto modeline doğrulama kuralları eklendi.

--------------------------------------------------

2. ANNOUNCEMENT (DUYURU) UÇ NOKTALARI

A) Duyuruları Listele
* Metot ve URL: GET /api/announcements?isActive=true
* Başarılı Yanıt (200 OK - AnnouncementDto[]):
[
  {
    "id": 1,
    "title": "Staj Programı Başladı",
    "content": "2026 Güz dönemi staj programı kapsamında API sözleşmeleri hazırlanıyor.",
    "createdAt": "2026-10-22T10:00:00Z",
    "isActive": true
  }
]

B) Yeni Duyuru Oluştur
* Metot ve URL: POST /api/announcements
* İstek Gövdesi (CreateAnnouncementDto):
{
  "title": "Yeni Etkinlik Duyurusu",
  "content": "Yarın saat 14:00'te toplantı odasında sunum yapılacaktır.",
  "isActive": true
}
* Yanıtlar: 201 Created (AnnouncementDto) | 400 Bad Request

--------------------------------------------------

3. CONTACT MESSAGE (İLETİŞİM) UÇ NOKTALARI

A) İletişim Mesajı Gönder
* Metot ve URL: POST /api/contact-messages
* İstek Gövdesi (CreateContactMessageDto):
{
  "fullName": "Ahmet Yılmaz",
  "email": "ahmet@ornek.com",
  "subject": "Etkinlik Hakkında",
  "message": "Etkinlik katılım şartları hakkında bilgi almak istiyorum."
}
* Yanıtlar: 201 Created (ContactMessageDto) | 400 Bad Request