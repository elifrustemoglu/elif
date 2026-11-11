USE etkinlik;

SELECT title AS 'Duyuru Başlığı', content AS 'İçerik', publish_date AS 'Yayın Tarihi'
FROM announcements 
WHERE is_deleted = FALSE AND priority_level = 'Acil'
ORDER BY publish_date DESC;

SELECT sender_name AS 'Gönderen', subject AS 'Konu', message AS 'Mesaj', created_at AS 'Tarih'
FROM contact_messages
WHERE subject LIKE '%Sorun%' OR message LIKE '%Sorun%';

SELECT 
is_read AS 'Okunma Durumu (0: Okunmadı, 1: Okundu)', 
COUNT(id) AS 'Toplam Mesaj Sayısı'
FROM contact_messages
GROUP BY is_read;