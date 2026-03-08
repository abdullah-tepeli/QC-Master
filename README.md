# QC-Master: Endüstriyel Üretim Fire, Kalite Kontrol ve Personel Yönetim Sistemi

QC-Master, üretim hatlarındaki kalite kontrol süreçlerini, makine bazlı arıza kayıtlarını, vardiya planlamalarını ve personel yetkilendirmelerini merkezi bir veritabanı üzerinden yönetmek amacıyla geliştirilmiş C# (WinForms) tabanlı bir masaüstü otomasyon projesidir.

## Proje Özellikleri

* **Rol Tabanlı Erişim Kontrolü (RBAC):** Sistem Yöneticisi, Kalite Mühendisi ve Bant Operatörü gibi farklı yetki seviyeleri ile veri güvenliği sağlanır.
* **Dinamik Vardiya Yönetimi:** Personel girişleri sunucu saati baz alınarak vardiya saatlerine göre denetlenir (Sistem Yöneticileri bu kısıtlamadan muaftır).
* **Makine ve Hata Senkronizasyonu:** Hata tipleri makine tiplerine göre filtrelenerek yanlış veri girişinin önüne geçilir.
* **Kriptografik Güvenlik:** Kullanıcı parolaları veritabanında SHA-256 algoritması ile tek yönlü olarak şifrelenir.

## Kurulum ve Sistem Gereksinimleri

Projeyi bilgisayarınızda derleyip çalıştırabilmeniz için aşağıdaki adımları sırasıyla uygulamanız gerekmektedir.

### 1. Veritabanı Kurulumu (SQL Server)
Sistem, verilerini Microsoft SQL Server üzerinde tutmaktadır. 
* Proje dizininde bulunan `QC_Master_Init.sql` dosyasını tercih ettiğiniz bir SQL aracı ile (SQL Server Management Studio, Azure Data Studio, Visual Studio Server Explorer vb.) çalıştırın.
* Bu betik, `QC-MasterDB` adında yeni bir veritabanı oluşturur ve gerekli tüm tablo mimarisini varsayılan verilerle birlikte ayağa kaldırır.

### 2. Veritabanı Bağlantı Ayarları
Projenin veritabanı ile haberleşebilmesi için bağlantı dizesinin (Connection String) güncellenmesi gerekmektedir.
* Proje kök dizinindeki `App.config` dosyasını açın.
* `connectionString` parametresi içerisindeki sunucu adı, kullanıcı adı ve şifre bilgilerini kendi SQL Server yapılandırmanıza göre düzenleyin.

### 3. Bağımlılıkların Geri Yüklenmesi
Proje, veritabanı işlemleri için `System.Data.SqlClient` paketini kullanmaktadır. 
* Projeyi Visual Studio ile açtıktan sonra, Solution Explorer (Çözüm Gezgini) penceresinde Solution'a sağ tıklayıp **Restore NuGet Packages** (NuGet Paketlerini Geri Yükle) seçeneğine tıklayın.

### 4. Sistemin İlk Kez Çalıştırılması
Gerekli yapılandırmaları tamamladıktan sonra projeyi derleyip çalıştırın (F5).
* Sistem başlangıçta veritabanını kontrol edecek ve kayıtlı hiçbir kullanıcı bulamadığı için otomatik olarak **Sistem Kurulum Modu**'na geçecektir.
* Karşınıza çıkan ekranda, kendinize ait bir Sicil Numarası ve Şifre belirleyerek **SİSTEM YÖNETİCİSİ OLUŞTUR** butonuna tıklayın.
* Bu işlem, sizi "Sistem Yöneticisi" rolü ile veritabanına kaydedecektir. Ardından standart giriş moduna dönen ekrandan kendi bilgilerinizle sisteme giriş yapabilirsiniz.
