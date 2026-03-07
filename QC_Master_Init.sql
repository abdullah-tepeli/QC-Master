/*
    QC-Master Veritabaný Baþlatma Scripti
    Bu script mevcut QC-MasterDB veritabanýný siler ve tüm þemayý sýfýrdan oluþturur.
*/

USE master;
GO

-- 1. Eðer veritabaný varsa, tüm baðlantýlarý kopar ve veritabanýný uçur
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QC-MasterDB')
BEGIN
    ALTER DATABASE [QC-MasterDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [QC-MasterDB];
END
GO

-- 2. Veritabanýný taze taze oluþtur
CREATE DATABASE [QC-MasterDB];
GO

USE [QC-MasterDB];
GO

-- ==========================================
-- TABLO OLUÞTURMA ÝÞLEMLERÝ
-- ==========================================

-- Roller Tablosu
CREATE TABLE Roller (
    Rol_ID INT PRIMARY KEY IDENTITY(1,1),
    Rol_Adi NVARCHAR(50) NOT NULL
);

-- Vardiyalar Tablosu
CREATE TABLE Vardiyalar (
    Vardiya_ID INT PRIMARY KEY IDENTITY(1,1),
    Vardiya_Adi NVARCHAR(50) NOT NULL,
    Baslangic_Saati TIME NOT NULL,
    Bitis_Saati TIME NOT NULL
);

-- Makine Tipleri Tablosu
CREATE TABLE MakineTipleri (
    Tip_ID INT PRIMARY KEY IDENTITY(1,1),
    Tip_Adi NVARCHAR(50) NOT NULL,
    IsActive BIT DEFAULT 1
);

-- Makineler Tablosu
CREATE TABLE Makineler (
    Makine_ID INT PRIMARY KEY IDENTITY(1,1),
    Makine_Kodu NVARCHAR(20) UNIQUE NOT NULL,
    Makine_Adi NVARCHAR(100) NOT NULL,
    Makine_Tip_ID INT FOREIGN KEY REFERENCES MakineTipleri(Tip_ID),
    IsActive BIT DEFAULT 1
);

-- Kullanýcýlar Tablosu
CREATE TABLE Kullanicilar (
    Kullanici_ID INT PRIMARY KEY IDENTITY(1,1),
    Sicil_No NVARCHAR(20) UNIQUE NOT NULL,
    Ad_Soyad NVARCHAR(100) NOT NULL,
    Sifre_Hash NVARCHAR(256) NOT NULL,
    Rol_ID INT FOREIGN KEY REFERENCES Roller(Rol_ID),
    Vardiya_ID INT NULL FOREIGN KEY REFERENCES Vardiyalar(Vardiya_ID),
    IsActive BIT DEFAULT 1
);

-- Ürünler Tablosu
CREATE TABLE Urunler (
    Urun_ID INT PRIMARY KEY IDENTITY(1,1),
    Urun_Adi NVARCHAR(100) NOT NULL,
    Makine_Tip_ID INT FOREIGN KEY REFERENCES MakineTipleri(Tip_ID),
    IsActive BIT DEFAULT 1
);

-- Hata Tipleri Tablosu
CREATE TABLE HataTipleri (
    Hata_ID INT PRIMARY KEY IDENTITY(1,1),
    Hata_Adi NVARCHAR(100) NOT NULL,
    Kritiklik_Seviyesi NVARCHAR(20) NOT NULL,
    Makine_Tip_ID INT FOREIGN KEY REFERENCES MakineTipleri(Tip_ID),
    IsActive BIT DEFAULT 1
);

-- Üretim Loglarý Tablosu
CREATE TABLE UretimLoglari (
    Log_ID INT PRIMARY KEY IDENTITY(1,1),
    Kullanici_ID INT FOREIGN KEY REFERENCES Kullanicilar(Kullanici_ID),
    Makine_ID INT FOREIGN KEY REFERENCES Makineler(Makine_ID),
    Urun_ID INT FOREIGN KEY REFERENCES Urunler(Urun_ID),
    Hata_ID INT NULL FOREIGN KEY REFERENCES HataTipleri(Hata_ID),
    Islem_Tarihi DATETIME DEFAULT GETDATE()
);
GO

-- ==========================================
-- TOHUMLAMA (SEED DATA)
-- ==========================================

INSERT INTO Roller (Rol_Adi) VALUES (N'Sistem Yöneticisi'), (N'Kalite Mühendisi'), (N'Bant Operatörü');

INSERT INTO Vardiyalar (Vardiya_Adi, Baslangic_Saati, Bitis_Saati) VALUES 
(N'Sabah', '08:00', '16:00'), (N'Akþam', '16:00', '00:00'), (N'Gece', '00:00', '08:00');

INSERT INTO MakineTipleri (Tip_Adi) VALUES (N'Boya Hattý'), (N'Kesim Hattý'), (N'Montaj Hattý');

INSERT INTO Makineler (Makine_Kodu, Makine_Adi, Makine_Tip_ID) VALUES 
(N'MKN-01', N'Boya Fýrýný 1', 1), (N'MKN-02', N'CNC Freze', 2), (N'MKN-03', N'Robotik Kol', 3);

INSERT INTO HataTipleri (Hata_Adi, Kritiklik_Seviyesi, Makine_Tip_ID) VALUES 
(N'Kýlcal Çizik', N'Az', 1), (N'Eksik Vida', N'Orta', 3), (N'Kýrýk Parça', N'Kritik', 2);

INSERT INTO Urunler (Urun_Adi, Makine_Tip_ID) VALUES 
(N'Kapak (Ham)', 2), (N'Kapak (Montajlý)', 3), (N'Kapak (Boyalý)', 1);
GO