## 10. Hafta Sürüm Notları (23-27 Kasım 2026)

## Neler Yapıldı?
* **ContactMessage Modülü:** Validasyon (doğrulama) kuralları yazıldı. Boşluk temizleme (Trim) ve e-postaları küçük harfe çevirme (ToLower) standartları eklendi.
* **Announcement Modülü:** Duyuru ekleme ve getirme uç noktaları (endpoint) test edildi.
* **Test Altyapısı:** Projeye uçtan uca testleri barındıran `api-test.http` dosyası başarıyla entegre edildi.

## Çözülen Hatalar (Bugfix)
* Duyuru eklerken boş başlıkların kabul edilmesi engellendi (`400 Bad Request`).
* Bulunamayan ID'ler çağrıldığında sistemin çökmesi önlendi (`404 Not Found`).