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
    public partial class UC_UretimGirisi : UserControl
    {
        public UC_UretimGirisi()
        {
            InitializeComponent();
        }
        // Combobox'lar doldurulurken olayların birbirini tetiklemesini engelleyen güvenlik kilidi
        private bool isUpdating = false;
        // Sistemde aktif olan makineleri veritabanından çeker ve Makine seçim kutusuna doldurur.
        // Hafıza mantığı ile çalışır; eğer bir makine ID'si verilirse seçimi o makinede tutmaya çalışır.
        private void MakineleriDoldur(int? seciliMakineID = null)
        {
            isUpdating = true; // Motoru kilitliyoruz ki SelectedIndexChanged olayı boş yere tetiklenmesin
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                string sorgu = "SELECT Makine_ID, Makine_Adi, Makine_Tip_ID FROM Makineler WHERE IsActive = 1";
                SqlDataAdapter adaptor = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                adaptor.Fill(dt);
                cmbMakine.DisplayMember = "Makine_Adi";
                cmbMakine.ValueMember = "Makine_ID";
                cmbMakine.DataSource = dt;
                // Eğer cebimizde eski bir seçim varsa ve makine hala aktifse, seçimi geri yükle
                if (seciliMakineID.HasValue)
                {
                    cmbMakine.SelectedValue = seciliMakineID.Value;
                }
                else
                {
                    cmbMakine.SelectedIndex = -1; // Yoksa kutuyu boş bırak
                }
            }
            isUpdating = false; // Kilidi açıyoruz
            // Makine listesi güncellendikten sonra, alt kutuları da o anki duruma göre tetikleyelim
            MakineyeGoreAltKutulariDoldur(null, null);
        }

        // Seçilen makinenin tipine bağlı olarak üretilebilecek ürünleri ve olası hata tiplerini getirir.
        private void MakineyeGoreAltKutulariDoldur(int? seciliUrunID = null, int? seciliHataID = null)
        {
            // Eğer makine seçilmemişse alt kutuları temizle ve çık
            if (cmbMakine.SelectedIndex == -1 || cmbMakine.SelectedItem == null)
            {
                cmbUrun.DataSource = null;
                cmbDurum.DataSource = null;
                return;
            }
            // Seçili makinenin DataRow'una ulaşıp Makine_Tip_ID değerini alıyoruz
            DataRowView seciliMakineRow = (DataRowView)cmbMakine.SelectedItem;
            int makineTipID = Convert.ToInt32(seciliMakineRow["Makine_Tip_ID"]);
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                // 1. ÜRÜNLERİ DOLDUR
                string urunSorgu = "SELECT Urun_ID, Urun_Adi FROM Urunler WHERE IsActive = 1 AND Makine_Tip_ID = @tipID";
                SqlDataAdapter urunAdaptor = new SqlDataAdapter(urunSorgu, baglanti);
                urunAdaptor.SelectCommand.Parameters.AddWithValue("@tipID", makineTipID);
                DataTable dtUrun = new DataTable();
                urunAdaptor.Fill(dtUrun);
                cmbUrun.DisplayMember = "Urun_Adi";
                cmbUrun.ValueMember = "Urun_ID";
                cmbUrun.DataSource = dtUrun;
                if (seciliUrunID.HasValue) cmbUrun.SelectedValue = seciliUrunID.Value;
                // 2. HATA TİPLERİNİ (DURUM) DOLDUR
                string hataSorgu = "SELECT Hata_ID, Hata_Adi FROM HataTipleri WHERE IsActive = 1 AND Makine_Tip_ID = @tipID";
                SqlDataAdapter hataAdaptor = new SqlDataAdapter(hataSorgu, baglanti);
                hataAdaptor.SelectCommand.Parameters.AddWithValue("@tipID", makineTipID);
                DataTable dtHata = new DataTable();
                hataAdaptor.Fill(dtHata);
                // "Sağlam" kaydını suni olarak listenin en tepesine ekliyoruz
                DataRow saglamRow = dtHata.NewRow();
                saglamRow["Hata_ID"] = -1;
                saglamRow["Hata_Adi"] = "Sağlam (Fire Yok)";
                dtHata.Rows.InsertAt(saglamRow, 0);
                cmbDurum.DisplayMember = "Hata_Adi";
                cmbDurum.ValueMember = "Hata_ID";
                cmbDurum.DataSource = dtHata;
                if (seciliHataID.HasValue) cmbDurum.SelectedValue = seciliHataID.Value;
                else cmbDurum.SelectedValue = -1; // Varsayılan olarak hep "Sağlam" gelsin ki operatör yorulmasın
            }
        }

        private void UC_UretimGirisi_Load(object sender, EventArgs e)
        {
            MakineleriDoldur();
        }

        private void cmbMakine_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eğer kod kendisi dolduruyorsa boşuna çalışma
            if (isUpdating) return;
            MakineyeGoreAltKutulariDoldur();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Eksik giriş kontrolü
            if (cmbMakine.SelectedIndex == -1 || cmbUrun.SelectedIndex == -1 || cmbDurum.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik bilgi girdiniz. Makine, ürün ve durum tam olmalı!", "Eksik Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int seciliMakineID = Convert.ToInt32(cmbMakine.SelectedValue);
            int seciliUrunID = Convert.ToInt32(cmbUrun.SelectedValue);
            int seciliHataID = Convert.ToInt32(cmbDurum.SelectedValue);
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                // UretimLoglari tablosuna kaydı gönderiyoruz
                string insertSorgu = "INSERT INTO UretimLoglari (Kullanici_ID, Makine_ID, Urun_ID, Hata_ID, Islem_Tarihi) VALUES (@kulID, @makID, @urunID, @hataID, GETDATE())";
                using (SqlCommand komut = new SqlCommand(insertSorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kulID", AnaForm.aktifKullaniciID);
                    komut.Parameters.AddWithValue("@makID", seciliMakineID);
                    komut.Parameters.AddWithValue("@urunID", seciliUrunID);
                    // Eğer -1 geldiyse operatör "Sağlam" seçeneğini seçmiştir, SQL'e boş olarak atıyoruz ki şema bozulmasın
                    if (seciliHataID == -1)
                        komut.Parameters.AddWithValue("@hataID", DBNull.Value);
                    else
                        komut.Parameters.AddWithValue("@hataID", seciliHataID);
                    try
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kayıt sırasında bir sorun oluştu: " + ex.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            // Hafızalı Yenileme: İş bitince makine listesini SQL'den tazeliyoruz ama operatörün seçimini unutmuyoruz.
            MakineleriDoldur(seciliMakineID);
            // Alt kutuları da eski seçime göre tazele
            MakineyeGoreAltKutulariDoldur(seciliUrunID, seciliHataID);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Eğer operatör klavyeden F12 tuşuna bastıysa
            if (keyData == Keys.F12)
            {
                btnKaydet.PerformClick();
                return true;
            }
            // Eğer F12 değil de başka tuşlara basıldıysa devam et
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
