USE etkinlik;


INSERT INTO announcements (title, content, priority_level) 
VALUES ('Stajyer Oryantasyon Eğitimi', 'Tüm yeni stajyerlerin katılımı zorunludur.', 'Acil');

SELECT * FROM announcements 
WHERE is_deleted = FALSE 
ORDER BY publish_date DESC;

UPDATE announcements 
SET title = 'Ertelenen Oryantasyon Eğitimi', priority_level = 'Normal' 
WHERE id = 1;

UPDATE announcements 
SET is_deleted = TRUE 
WHERE id = 1;



INSERT INTO contact_messages (sender_name, sender_email, subject, message) 
VALUES ('Efe özdemir', 'efeözdemir@gmail.com', 'Sisteme Giriş Sorunu', 'Şifremi unuttum, yardımcı olabilir misiniz?');

SELECT * FROM contact_messages 
WHERE is_read = FALSE;

UPDATE contact_messages 
SET is_read = TRUE 
WHERE id = 1;


