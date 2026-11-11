# Egitim Portali API Sözleşmesi (Endpoint Tasarımı)

Bu doküman, sistemdeki kaynaklar (resources) için tasarlanan RESTful uç noktalarını (endpoints) içerir.

## 1. Event (Etkinlik) Uç Noktaları

| HTTP Metodu | Endpoint URL | Açıklama |
| :--- | :--- | :--- |
| **GET** | `/api/events` | Sistemdeki tüm etkinlikleri listeler. |
| **GET** | `/api/events/{id}` | Belirtilen ID'ye sahip tek bir etkinliğin detaylarını getirir. |
| **POST** | `/api/events` | Gelen JSON verisiyle sisteme yeni bir etkinlik ekler. |

## 2. Category (Kategori) Uç Noktaları

| HTTP Metodu | Endpoint URL | Açıklama |
| :--- | :--- | :--- |
| **GET** | `/api/categories` | Sistemdeki tüm kategorileri listeler. |
| **GET** | `/api/categories/{id}` | Belirtilen ID'ye sahip kategorinin detaylarını getirir. |
| **POST** | `/api/categories` | Gelen JSON verisiyle sisteme yeni bir kategori ekler. |

## 3. Announcement (Duyuru) Uç Noktaları

| HTTP Metodu | Endpoint URL | Açıklama |
| :--- | :--- | :--- |
| **GET** | `/api/announcements` | Sistemdeki tüm duyuruları listeler. |
| **GET** | `/api/announcements/{id}` | Belirtilen ID'ye sahip tek bir duyurunun detaylarını getirir. |
| **POST** | `/api/announcements` | Gelen JSON verisiyle sisteme yeni bir duyuru ekler. |
| **PUT** | `/api/announcements/{id}` | Belirtilen ID'ye sahip duyuruyu günceller. |
| **DELETE** | `/api/announcements/{id}` | Belirtilen ID'ye sahip duyuruyu siler. |

## 4. Contact (İletişim Mesajları) Uç Noktaları

| HTTP Metodu | Endpoint URL | Açıklama |
| :--- | :--- | :--- |
| **GET** | `/api/contact-messages` | Sistemdeki tüm iletişim mesajlarını listeler. |
| **GET** | `/api/contact-messages/{id}` | Belirtilen ID'ye sahip tek bir iletişim mesajının detaylarını getirir. |
| **POST** | `/api/contact-messages` | Gelen JSON verisiyle yeni bir iletişim mesajı kaydeder. |
