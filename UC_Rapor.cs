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
    public partial class UC_Rapor : UserControl
    {
        // Sayfalama ayarları
        private int sayfaBasinaKayit = 50;
        private int toplamKayitSayisi = 0;
        private int toplamSayfaSayisi = 1;
        // Filtreleme işlemlerinde sayfa değiştiğinde hatalı veri gelmesini önlemek için, 
        // en son "Sorgula" butonuna basıldığındaki değerleri tutan değişkenler (Snapshot).
        private int aktifFiltreKullanici = -1;
        private int aktifFiltreMakine = -1;
        private int aktifFiltreUrun = -1;
        private int aktifFiltreHata = -1;
        private DateTime? aktifFiltreBaslangic = null;
        private DateTime? aktifFiltreBitis = null;
        private string aktifSiralamaSutunu = "L.Log_ID";
        private string aktifSiralamaYonu = "DESC";
        // Arayüzdeki sıralama seçeneklerinin SQL sütun karşılıkları
        private readonly Dictionary<string, string> siralamaEslestirme = new Dictionary<string, string>
    {
        { "Varsayılan", "L.Log_ID" },
        { "Operatör", "K.Ad_Soyad" },
        { "Makine", "M.Makine_Adi" },
        { "Hata", "H.Hata_Adi" },
        { "Tarih", "L.Islem_Tarihi" }
    };
        // UI güncellemeleri sırasında olayların sonsuz döngüye girmesini engelleyen kilit.
        private bool isUpdating = false;
        public UC_Rapor()
        {
            InitializeComponent();
        }

        // Personel ve Makine listelerini veritabanından, aktif/pasif durumuna bakılmaksızın tüm geçmiş kayıtları kapsayacak şekilde çeker.
        private void AnaFiltreleriDoldur()
        {
            isUpdating = true;
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                baglanti.Open();
                // 1. Kullanıcılar
                SqlDataAdapter daKul = new SqlDataAdapter("SELECT Kullanici_ID, Ad_Soyad FROM Kullanicilar", baglanti);
                DataTable dtKul = new DataTable();
                daKul.Fill(dtKul);
                DataRow drK = dtKul.NewRow(); drK["Kullanici_ID"] = -1; drK["Ad_Soyad"] = "<Tümü>";
                dtKul.Rows.InsertAt(drK, 0);
                cmbFiltreKullanici.DataSource = dtKul;
                cmbFiltreKullanici.DisplayMember = "Ad_Soyad";
                cmbFiltreKullanici.ValueMember = "Kullanici_ID";
                // 2. Makineler
                SqlDataAdapter daMakine = new SqlDataAdapter("SELECT Makine_ID, Makine_Adi, Makine_Tip_ID FROM Makineler", baglanti);
                DataTable dtMakine = new DataTable();
                daMakine.Fill(dtMakine);
                DataRow drM = dtMakine.NewRow(); drM["Makine_ID"] = -1; drM["Makine_Adi"] = "<Tümü>"; drM["Makine_Tip_ID"] = -1;
                dtMakine.Rows.InsertAt(drM, 0);
                cmbFiltreMakine.DataSource = dtMakine;
                cmbFiltreMakine.DisplayMember = "Makine_Adi";
                cmbFiltreMakine.ValueMember = "Makine_ID";
            }
            isUpdating = false;
            // Makineler dolduğunda alt menüleri dinamik olarak yükle
            MakineyeGoreAltFiltreleriDoldur();
        }

        // Seçilen makinenin tipine göre, ilgili ürünleri ve hata tiplerini getirir.
        // Eğer belirli bir makine seçilmemişse, sistemdeki tüm kayıtları listeler.
        private void MakineyeGoreAltFiltreleriDoldur()
        {
            if (cmbFiltreMakine.SelectedIndex == -1) return;
            int makineTipID = Convert.ToInt32(((DataRowView)cmbFiltreMakine.SelectedItem)["Makine_Tip_ID"]);
            string tipSart = makineTipID == -1 ? "" : "WHERE Makine_Tip_ID = @tipID";
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                baglanti.Open();
                // Ürünler
                string urunSorgu = $"SELECT Urun_ID, Urun_Adi FROM Urunler {tipSart}";
                SqlDataAdapter daUrun = new SqlDataAdapter(urunSorgu, baglanti);
                if (makineTipID != -1) daUrun.SelectCommand.Parameters.AddWithValue("@tipID", makineTipID);
                DataTable dtUrun = new DataTable();
                daUrun.Fill(dtUrun);
                DataRow drU = dtUrun.NewRow(); drU["Urun_ID"] = -1; drU["Urun_Adi"] = "<Tümü>";
                dtUrun.Rows.InsertAt(drU, 0);
                cmbFiltreUrun.DataSource = dtUrun;
                cmbFiltreUrun.DisplayMember = "Urun_Adi";
                cmbFiltreUrun.ValueMember = "Urun_ID";
                // Hata Tipleri ve "Sağlam" Seçeneği
                string hataSorgu = $"SELECT Hata_ID, Hata_Adi FROM HataTipleri {tipSart}";
                SqlDataAdapter daHata = new SqlDataAdapter(hataSorgu, baglanti);
                if (makineTipID != -1) daHata.SelectCommand.Parameters.AddWithValue("@tipID", makineTipID);
                DataTable dtHata = new DataTable();
                daHata.Fill(dtHata);
                // Veritabanı bütünlüğü için özel yapılar: Tümü (-1) ve Sağlam (-2)
                DataRow drHTumu = dtHata.NewRow(); drHTumu["Hata_ID"] = -1; drHTumu["Hata_Adi"] = "<Tümü>";
                dtHata.Rows.InsertAt(drHTumu, 0);
                DataRow drHSaglam = dtHata.NewRow(); drHSaglam["Hata_ID"] = -2; drHSaglam["Hata_Adi"] = "Sağlam (Fire Yok)";
                dtHata.Rows.InsertAt(drHSaglam, 1);
                cmbFiltreHata.DataSource = dtHata;
                cmbFiltreHata.DisplayMember = "Hata_Adi";
                cmbFiltreHata.ValueMember = "Hata_ID";
            }
        }

        // Kullanıcının arayüzdeki mevcut seçimlerini belleğe alır ve ilk sayfadan itibaren verileri getirir.
        private void SorguyuTetikle()
        {
            // UI değerlerini değişkenlere kaydet
            aktifFiltreKullanici = Convert.ToInt32(cmbFiltreKullanici.SelectedValue);
            aktifFiltreMakine = Convert.ToInt32(cmbFiltreMakine.SelectedValue);
            aktifFiltreUrun = Convert.ToInt32(cmbFiltreUrun.SelectedValue);
            aktifFiltreHata = Convert.ToInt32(cmbFiltreHata.SelectedValue);
            aktifFiltreBaslangic = dtpBaslangic.Checked ? dtpBaslangic.Value.Date : (DateTime?)null;
            aktifFiltreBitis = dtpBitis.Checked ? dtpBitis.Value.Date.AddDays(1).AddSeconds(-1) : (DateTime?)null;
            aktifSiralamaSutunu = siralamaEslestirme[cmbSirala.Text];
            aktifSiralamaYonu = cmbYon.Text == "Artan" ? "ASC" : "DESC";
            nudSayfaNo.Value = 1; // Yeni sorgularda her zaman ilk sayfaya dönülür
            RaporVerileriniGetir();
        }

        // Bellekteki filtre kriterlerine göre veritabanından belirtilen sayfa indeksine ait logları getirir.
        private void RaporVerileriniGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                string whereClause = " WHERE 1=1 ";
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                // Kriterleri dinamik olarak oluştur
                if (aktifFiltreKullanici != -1)
                {
                    whereClause += " AND L.Kullanici_ID = @kulID";
                    komut.Parameters.AddWithValue("@kulID", aktifFiltreKullanici);
                }
                if (aktifFiltreMakine != -1)
                {
                    whereClause += " AND L.Makine_ID = @makID";
                    komut.Parameters.AddWithValue("@makID", aktifFiltreMakine);
                }
                if (aktifFiltreUrun != -1)
                {
                    whereClause += " AND L.Urun_ID = @urunID";
                    komut.Parameters.AddWithValue("@urunID", aktifFiltreUrun);
                }
                // Hata ID kontrolü
                if (aktifFiltreHata == -2)
                {
                    whereClause += " AND L.Hata_ID IS NULL";
                }
                else if (aktifFiltreHata != -1)
                {
                    whereClause += " AND L.Hata_ID = @hataID";
                    komut.Parameters.AddWithValue("@hataID", aktifFiltreHata);
                }
                if (aktifFiltreBaslangic.HasValue)
                {
                    whereClause += " AND L.Islem_Tarihi >= @basTar";
                    komut.Parameters.AddWithValue("@basTar", aktifFiltreBaslangic.Value);
                }
                if (aktifFiltreBitis.HasValue)
                {
                    whereClause += " AND L.Islem_Tarihi <= @bitTar";
                    komut.Parameters.AddWithValue("@bitTar", aktifFiltreBitis.Value);
                }
                // Toplam sayfa hesaplaması
                komut.CommandText = "SELECT COUNT(*) FROM UretimLoglari L " + whereClause;
                baglanti.Open();
                toplamKayitSayisi = (int)komut.ExecuteScalar();
                toplamSayfaSayisi = (int)Math.Ceiling((double)toplamKayitSayisi / sayfaBasinaKayit);
                if (toplamSayfaSayisi == 0) toplamSayfaSayisi = 1;
                lblToplamSayfa.Text = "/ " + toplamSayfaSayisi.ToString();
                lblToplamKayit.Text = "Toplam: " + toplamKayitSayisi + " Kayıt";
                nudSayfaNo.Maximum = toplamSayfaSayisi;
                // Sayfalama işlemi ve asıl verinin getirilmesi
                int offset = ((int)nudSayfaNo.Value - 1) * sayfaBasinaKayit;
                string anaSorgu = $@"
                SELECT L.Log_ID, K.Ad_Soyad as [Operatör], M.Makine_Adi as [Makine], 
                       U.Urun_Adi as [Ürün], ISNULL(H.Hata_Adi, 'Sağlam') as [Durum], L.Islem_Tarihi as [Tarih]
                FROM UretimLoglari L
                JOIN Kullanicilar K ON L.Kullanici_ID = K.Kullanici_ID
                JOIN Makineler M ON L.Makine_ID = M.Makine_ID
                JOIN Urunler U ON L.Urun_ID = U.Urun_ID
                LEFT JOIN HataTipleri H ON L.Hata_ID = H.Hata_ID
                {whereClause}
                ORDER BY {aktifSiralamaSutunu} {aktifSiralamaYonu}
                OFFSET {offset} ROWS FETCH NEXT {sayfaBasinaKayit} ROWS ONLY";
                komut.CommandText = anaSorgu;
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dtSonuc = new DataTable();
                da.Fill(dtSonuc);
                dgvRapor.DataSource = dtSonuc;
            }
        }

        private void UC_Rapor_Load(object sender, EventArgs e)
        {
            // Tarih başlangıç ayarlarını oluştur
            dtpBaslangic.Value = DateTime.Now.AddMonths(-1);
            dtpBitis.Value = DateTime.Now;
            dtpBaslangic.Checked = false;
            dtpBitis.Checked = false;
            AnaFiltreleriDoldur();
            // Tasarım tarafından ayarlanamayan varsayılan sıralama seçimleri
            cmbSirala.SelectedIndex = 4; // Tarih
            cmbYon.SelectedIndex = 1;    // Azalan
            SorguyuTetikle(); // Form açılışında verileri getir
        }

        private void cmbFiltreMakine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            MakineyeGoreAltFiltreleriDoldur();
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            // Kullanıcı sorgula dediğinde kutuların veritabanı yansımalarını günceller
            object seciliKullanici = cmbFiltreKullanici.SelectedValue;
            object seciliMakine = cmbFiltreMakine.SelectedValue;
            object seciliUrun = cmbFiltreUrun.SelectedValue;
            object seciliHata = cmbFiltreHata.SelectedValue;
            AnaFiltreleriDoldur();
            if (seciliKullanici != null) cmbFiltreKullanici.SelectedValue = seciliKullanici;
            if (seciliMakine != null) cmbFiltreMakine.SelectedValue = seciliMakine;
            if (seciliUrun != null) cmbFiltreUrun.SelectedValue = seciliUrun;
            if (seciliHata != null) cmbFiltreHata.SelectedValue = seciliHata;
            SorguyuTetikle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // Arayüz elemanlarını fabrika ayarlarına döndürür
            AnaFiltreleriDoldur();
            cmbFiltreKullanici.SelectedIndex = 0;
            cmbFiltreMakine.SelectedIndex = 0;
            cmbFiltreUrun.SelectedIndex = 0;
            cmbFiltreHata.SelectedIndex = 0;
            dtpBaslangic.Checked = false;
            dtpBitis.Checked = false;
            cmbSirala.SelectedIndex = 4;
            cmbYon.SelectedIndex = 1;
            SorguyuTetikle();
        }

        private void btnGit_Click(object sender, EventArgs e)
        {
            RaporVerileriniGetir();
        }

        private void btnOnceki_Click(object sender, EventArgs e)
        {
            if (nudSayfaNo.Value > 1)
            {
                nudSayfaNo.Value--;
                RaporVerileriniGetir();
            }
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            if (nudSayfaNo.Value < toplamSayfaSayisi)
            {
                nudSayfaNo.Value++;
                RaporVerileriniGetir();
            }
        }
    }
}
