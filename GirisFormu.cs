using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC_Master
{
    public partial class GirisFormu : Form
    {
        string baglantiCumlesi = ConfigurationManager.ConnectionStrings["QCMasterConn"].ConnectionString;
        bool ilkKurulumMu = false;
        public GirisFormu()
        {
            InitializeComponent();
        }

        private void GirisFormu_Load(object sender, EventArgs e)
        {
            // Veritabanı bağlantısı açılıyor. using bloğu kaynakların doğru yönetilmesi için kullanılmıştır.
            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                try
                {
                    baglanti.Open();

                    // Sistemde kayıtlı herhangi bir kullanıcı olup olmadığı kontrol ediliyor.
                    string sorgu = "SELECT COUNT(*) FROM Kullanicilar";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);

                    int kullaniciSayisi = (int)komut.ExecuteScalar();

                    if (kullaniciSayisi == 0)
                    {
                        // Sistemde kullanıcı bulunamadığı için ilk kurulum modu aktif ediliyor.
                        ilkKurulumMu = true;

                        // Kullanıcı arayüzü ilk yönetici kaydına uygun olarak güncelleniyor.
                        this.Text = "QC-Master - Sistem Kurulumu";
                        btnGiris.Text = "SİSTEM YÖNETİCİSİ OLUŞTUR";

                        MessageBox.Show("Sistemde kayıtlı kullanıcı bulunamadı.\nLütfen ilk sistem yöneticisi hesabını oluşturunuz.", "Sistem Kurulumu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Bağlantı veya sorgu sırasında oluşabilecek hatalar kullanıcıya bildiriliyor.
                    MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu. Lütfen sistem yöneticinizle iletişime geçiniz.\n\nHata Detayı: " + ex.Message, "Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Şifre güvenliği için SHA256 şifreleme metodu
        private string SifreyiHashle(string sifre)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(sifre));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string sicil = txtSicil.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            // Kullanıcı giriş alanlarının geçerliliği kontrol ediliyor.
            if (string.IsNullOrEmpty(sicil) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen sicil numarası ve şifre alanlarını boş bırakmayınız.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Güvenlik amacıyla kullanıcı şifresi SHA256 ile şifreleniyor.
            string hashliSifre = SifreyiHashle(sifre);

            using (SqlConnection baglanti = new SqlConnection(baglantiCumlesi))
            {
                try
                {
                    baglanti.Open();

                    if (ilkKurulumMu)
                    {
                        // İlk kurulum aşaması: Mevcut 'Sistem Yöneticisi' rolü sorgulanarak kurucu kullanıcı kaydediliyor.
                        string kayitSorgu = @"
                            DECLARE @RolId INT;
                            SELECT TOP 1 @RolId = Rol_ID FROM Roller WHERE Rol_Adi = 'Sistem Yöneticisi';
                            
                            IF @RolId IS NOT NULL
                            BEGIN
                                INSERT INTO Kullanicilar (Sicil_No, Ad_Soyad, Sifre_Hash, Rol_ID, IsActive) 
                                VALUES (@sicil, 'Sistem Yöneticisi', @sifre, @RolId, 1);
                            END
                            ELSE
                            BEGIN
                                THROW 50000, 'Veritabanında Sistem Yöneticisi rolü bulunamadı. Lütfen SQL şablonunu kontrol ediniz.', 1;
                            END";

                        SqlCommand cmd = new SqlCommand(kayitSorgu, baglanti);
                        cmd.Parameters.AddWithValue("@sicil", sicil);
                        cmd.Parameters.AddWithValue("@sifre", hashliSifre);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Sistem yöneticisi hesabı başarıyla oluşturuldu. Lütfen oluşturduğunuz bilgilerle giriş yapınız.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Arayüz standart kullanıcı giriş moduna döndürülüyor.
                        ilkKurulumMu = false;
                        this.Text = "QC-Master - Kullanıcı Girişi";
                        btnGiris.Text = "GİRİŞ YAP";
                        txtSicil.Clear();
                        txtSifre.Clear();
                    }
                    else
                    {
                        // Kullanıcı kimliği, rolü ve vardiya saatleri sunucu saatiyle birlikte sorgulanıyor.
                        string girisSorgu = @"
                            SELECT k.Kullanici_ID, k.Ad_Soyad, r.Rol_Adi, v.Baslangic_Saati, v.Bitis_Saati, CAST(GETDATE() AS TIME) as SunucuSaati
                            FROM Kullanicilar k 
                            INNER JOIN Roller r ON k.Rol_ID = r.Rol_ID 
                            LEFT JOIN Vardiyalar v ON k.Vardiya_ID = v.Vardiya_ID
                            WHERE k.Sicil_No = @sicil AND k.Sifre_Hash = @sifre AND k.IsActive = 1";

                        SqlCommand cmd = new SqlCommand(girisSorgu, baglanti);
                        cmd.Parameters.AddWithValue("@sicil", sicil);
                        cmd.Parameters.AddWithValue("@sifre", hashliSifre);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["Kullanici_ID"]);
                                string adSoyad = reader["Ad_Soyad"].ToString();
                                string rolAdi = reader["Rol_Adi"].ToString();

                                // Vardiya saatleri kontrolü (Vardiya atanmamışsa her zaman erişim sağlanır)
                                if (reader["Baslangic_Saati"] != DBNull.Value && reader["Bitis_Saati"] != DBNull.Value)
                                {
                                    TimeSpan baslangic = (TimeSpan)reader["Baslangic_Saati"];
                                    TimeSpan bitis = (TimeSpan)reader["Bitis_Saati"];
                                    TimeSpan suAn = (TimeSpan)reader["SunucuSaati"];

                                    bool vardiyaIci = false;
                                    if (baslangic <= bitis)
                                        vardiyaIci = (suAn >= baslangic && suAn <= bitis); // Aynı gün içindeki vardiya
                                    else
                                        vardiyaIci = (suAn >= baslangic || suAn <= bitis); // Gece vardiyası (ertesi güne sarkan)

                                    // Sistem Yöneticisi vardiya kısıtlamasına tabi değildir.
                                    if (!vardiyaIci && rolAdi != "Sistem Yöneticisi")
                                    {
                                        MessageBox.Show("Sayın " + adSoyad + ", şu anki saatiniz vardiya saatleriniz dışında kalmaktadır.", "Erişim Reddedildi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                AnaForm anaEkran = new AnaForm(id, rolAdi, adSoyad);
                                this.Hide();
                                anaEkran.Show();
                            }
                            else
                            {
                                MessageBox.Show("Girdiğiniz sicil numarası veya şifre hatalı. Lütfen bilgilerinizi kontrol ediniz.", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Olası sistem ve veritabanı hataları kullanıcıya raporlanıyor.
                    MessageBox.Show("Sistemde beklenmeyen bir hata oluştu.\nDetay: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
