USE etkinlik;

-- 1. CREATE (INSERT): Yeni Bir Etkinlik Ekleme
-- (Not: Foreign Key kısıtı nedeniyle CategoryId alanına var olan bir Id girmelisin, örneğin 1)
INSERT INTO Events (Title, Slug, Description, StartDate, LocationType, CategoryId)
VALUES (
    'MySQL ile CRUD Pratiği', 
    'mysql-ile-crud-pratigi', 
    '28 Ekim Yarım Gün SQL Çalışması', 
    '2026-11-15 10:00:00', 
    'Online', 
    1
);

-- 2. READ (SELECT): Etkinlikleri Listeleme
-- Tüm sütunları getirme:
SELECT * FROM Events;

-- Sadece başlık ve başlangıç tarihini getirme:
SELECT Title, StartDate, LocationType FROM Events WHERE CategoryId = 1;

-- 3. UPDATE: Etkinlik Bilgisi Güncelleme
-- (DİKKAT: WHERE şartı koymazsan tüm tablonun mekan türü değişir!)
UPDATE Events 
SET LocationType = 'Yüz Yüze', Description = 'Güncellenmiş 28 Ekim çalışması'
WHERE Id = 1;

-- 4. DELETE: Etkinlik Silme
DELETE FROM Events 
WHERE Id = 1;