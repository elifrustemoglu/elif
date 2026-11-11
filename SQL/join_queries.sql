USE etkinlik;

-- 1. INNER JOIN: Etkinliği Kategori Adı İle Birlikte Getirme
-- Sadece CategoryId (1, 2) yerine Kategorinin gerçek adını çekiyoruz.
SELECT 
    e.Id AS EtkinlikId,
    e.Title AS EtkinlikBasligi,
    c.Name AS KategoriAdi,
    e.StartDate AS BaslangicTarihi,
    e.LocationType AS MekanTuru
FROM Events e
INNER JOIN Categories c ON e.CategoryId = c.Id;


-- 2. WHERE & ORDER BY: Yaklaşan Etkinlikleri Tarihe Göre Sıralama
-- 'NOW()' o anki sistem tarihini verir. Tarihi bugünden sonra olanları en yakından uzağa sıralar.
SELECT 
    Title, 
    StartDate, 
    LocationType 
FROM Events
WHERE StartDate >= NOW()
ORDER BY StartDate ASC;


-- 3. BÜTÜNLEŞİK SORGU: Belirli Bir Kategorideki Yaklaşan Etkinlikler
-- JOIN + WHERE + ORDER BY hepsini tek sorguda birleştiriyoruz.
SELECT 
    e.Title AS EtkinlikBasligi,
    c.Name AS Kategori,
    e.StartDate AS Tarih,
    e.LocationType AS Mekan
FROM Events e
INNER JOIN Categories c ON e.CategoryId = c.Id
WHERE c.Name = 'Yazılım Eğitimleri' AND e.StartDate >= NOW()
ORDER BY e.StartDate ASC;