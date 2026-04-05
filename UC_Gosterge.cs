using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC_Master
{
    public partial class UC_Gosterge : UserControl
    {
        // Veri yenileme işlemleri için arka plan zamanlayıcısı
        private Timer motorTimer = new Timer();

        public UC_Gosterge()
        {
            InitializeComponent();
        }

        private void UC_Gosterge_Load(object sender, EventArgs e)
        {
            // Zamanlayıcı yapılandırması
            motorTimer.Interval = 5000;
            motorTimer.Tick += MotorTimer_Tick;
            if (this.Visible)
            {
                VitriniGuncelle();
                motorTimer.Start();
            }
            }

        private void MotorTimer_Tick(object sender, EventArgs e)
        {
            // Belirlenen aralıklarla gösterge panelini günceller
            VitriniGuncelle();
        }

        // Veritabanından anlık üretim istatistiklerini ve son işlemleri çeker.
        private void VitriniGuncelle()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                try
                {
                    baglanti.Open();
                    // 1. ÜST PANEL İSTATİSTİKLERİ
                    // Hata_ID IS NULL durumu 'Sağlam' üretimi temsil eder.
                    string istatistikSorgu = @"
                        SELECT COUNT(Log_ID) FROM UretimLoglari WHERE Hata_ID IS NULL AND CAST(Islem_Tarihi AS DATE) = CAST(GETDATE() AS DATE);
                        SELECT COUNT(Log_ID) FROM UretimLoglari WHERE Hata_ID IS NOT NULL AND CAST(Islem_Tarihi AS DATE) = CAST(GETDATE() AS DATE);
                        SELECT COUNT(Makine_ID) FROM Makineler WHERE IsActive = 1;
SELECT COUNT(k.Kullanici_ID) 
FROM Kullanicilar k
LEFT JOIN Vardiyalar v ON k.Vardiya_ID = v.Vardiya_ID
WHERE k.IsActive = 1 
AND (
    k.Vardiya_ID IS NULL
    OR (v.Baslangic_Saati <= v.Bitis_Saati AND CAST(GETDATE() AS TIME) >= v.Baslangic_Saati AND CAST(GETDATE() AS TIME) <= v.Bitis_Saati)
    OR (v.Baslangic_Saati > v.Bitis_Saati AND (CAST(GETDATE() AS TIME) >= v.Baslangic_Saati OR CAST(GETDATE() AS TIME) <= v.Bitis_Saati))
);
                    ";
                    using (SqlCommand komut = new SqlCommand(istatistikSorgu, baglanti))
                    {
                        using (SqlDataReader reader = komut.ExecuteReader())
                        {
                            // Sorgu 1: Bugünkü Sağlam Üretim
                            if (reader.Read()) txtUretim.Text = reader[0].ToString();
                            // Sorgu 2: Bugünkü Toplam Fire
                            reader.NextResult();
                            if (reader.Read()) txtFire.Text = reader[0].ToString();
                            // Sorgu 3: Aktif Makine Sayısı
                            reader.NextResult();
                            if (reader.Read()) txtMakine.Text = reader[0].ToString();
                            // Sorgu 4: Aktif Personel Sayısı
                            reader.NextResult();
                            if (reader.Read()) txtPersonel.Text = reader[0].ToString();
                        }
                    }
                    // Fire Oranı Hesaplaması
                    double saglam = Convert.ToDouble(txtUretim.Text);
                    double fire = Convert.ToDouble(txtFire.Text);
                    double toplam = saglam + fire;
                    if (toplam > 0)
                    {
                        double oran = (fire / toplam) * 100;
                        txtOran.Text = "%" + Math.Round(oran, 2).ToString();
                    }
                    else
                    {
                        txtOran.Text = "%0";
                    }
                    // 2. ALT PANEL VERİ TABLOSU
                    // İlişkisel tablolar birleştirilerek anlamlı veri seti oluşturulur.
                    string tabloSorgu = @"
                        SELECT TOP 15 
                            ul.Log_ID AS 'Kayıt No',
                            k.Ad_Soyad AS 'Operatör',
                            m.Makine_Adi AS 'Makine',
                            ur.Urun_Adi AS 'Ürün',
                            ISNULL(ht.Hata_Adi, 'Sağlam') AS 'Durum',
                            ul.Islem_Tarihi AS 'İşlem Zamanı'
                        FROM UretimLoglari ul
                        INNER JOIN Kullanicilar k ON ul.Kullanici_ID = k.Kullanici_ID
                        INNER JOIN Makineler m ON ul.Makine_ID = m.Makine_ID
                        INNER JOIN Urunler ur ON ul.Urun_ID = ur.Urun_ID
                        LEFT JOIN HataTipleri ht ON ul.Hata_ID = ht.Hata_ID
                        WHERE CAST(Islem_Tarihi AS DATE) = CAST(GETDATE() AS DATE)
                        ORDER BY ul.Islem_Tarihi DESC;";
                    SqlDataAdapter adapt = new SqlDataAdapter(tabloSorgu, baglanti);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    gridSonIslemler.DataSource = dt;
                }
                catch (Exception)
                {
                    // Hata durumunda uygulamanın kilitlenmemesi için zamanlayıcı durdurulur.
                    motorTimer.Stop();
                }
            }
        }

        private void UC_Gosterge_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                VitriniGuncelle();
                motorTimer.Start();
            }
            else
            {
                motorTimer.Stop();
            }
        }
    }
}