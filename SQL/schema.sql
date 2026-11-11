USE etkinlik;

-- 1. Categories Tablosu (Ana Tablo)
CREATE TABLE IF NOT EXISTS Categories (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Slug VARCHAR(150) NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- 2. Events Tablosu (Categories'e Bağlı Tablo)
CREATE TABLE IF NOT EXISTS Events (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Slug VARCHAR(150) NOT NULL,
    Description TEXT,
    StartDate DATETIME NOT NULL,
    LocationType VARCHAR(50),
    CategoryId INT NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT FK_Events_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);