CREATE DATABASE IF NOT EXISTS etkinlik;

USE etkinlik;

CREATE TABLE announcements (
    id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    content TEXT NOT NULL,
    publish_date DATETIME DEFAULT CURRENT_TIMESTAMP,
    priority_level ENUM('Normal', 'Acil') DEFAULT 'Normal',
    is_deleted BOOLEAN DEFAULT FALSE
);

CREATE TABLE contact_messages (
    id INT AUTO_INCREMENT PRIMARY KEY,
    sender_name VARCHAR(150) NOT NULL,
    sender_email VARCHAR(150) NOT NULL,
    subject VARCHAR(200),
    message TEXT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    is_read BOOLEAN DEFAULT FALSE,
    is_deleted BOOLEAN DEFAULT FALSE
);