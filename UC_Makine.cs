using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC_Master
{
    public partial class UC_Makine : UserControl
    {
        // Sistemdeki mevcut kayıtları güncellemek için bellekte tutulan referans kimlikleri.
        // Yeni kayıt ekleneceği durumlarda bu değerler -1 olarak korunur.
        private int seciliTipID = -1;
        private int seciliMakineID = -1;
        private int seciliUrunID = -1;
        private int seciliHataID = -1;

        public UC_Makine()
        {
            InitializeComponent();
        }

        // Kullanıcı denetimi yüklendiğinde tüm veri tablolarını ve açılır listeleri eşzamanlı olarak başlatır.
        private void UC_Makine_Load(object sender, EventArgs e)
        {
            OrtakCombolariDoldur();
            TumTablolariYenile();
        }

        // Arayüzdeki 4 farklı veri ızgarasını veritabanından alınan güncel bilgilerle tazeler.
        private void TumTablolariYenile()
        {
            MakineTipleriniGetir();
            MakineleriGetir();
            UrunleriGetir();
            HataTipleriniGetir();
        }

        // Diğer sekmelerde yer alan 'Makine Tipi / Hat' ComboBox nesnelerine ait verileri günceller.
        // Bu işlem, yeni bir hat eklendiğinde diğer sekmelerin anlık olarak haberdar olmasını sağlar.
        private void OrtakCombolariDoldur()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                // IsActive koşulu aranmaz; pasif hatlar da geçmiş veri bütünlüğü için listelenmelidir.
                string sorgu = "SELECT Tip_ID, Tip_Adi FROM MakineTipleri";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMakineTipi.DataSource = new DataView(dt);
                cmbMakineTipi.DisplayMember = "Tip_Adi";
                cmbMakineTipi.ValueMember = "Tip_ID";
                cmbMakineTipi.SelectedIndex = -1;

                cmbUrunMakineTipi.DataSource = new DataView(dt);
                cmbUrunMakineTipi.DisplayMember = "Tip_Adi";
                cmbUrunMakineTipi.ValueMember = "Tip_ID";
                cmbUrunMakineTipi.SelectedIndex = -1;

                cmbHataMakineTipi.DataSource = new DataView(dt);
                cmbHataMakineTipi.DisplayMember = "Tip_Adi";
                cmbHataMakineTipi.ValueMember = "Tip_ID";
                cmbHataMakineTipi.SelectedIndex = -1;
            }
        }

        #region 1. SEKME: MAKİNE TİPLERİ (HAT YÖNETİMİ)

        private void MakineTipleriniGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                // İlişkili tablolardaki (Makine, Ürün, Hata) kullanımların toplamı hesaplanarak gizli bir sütuna aktarılır.
                string sorgu = @"
                    SELECT Tip_ID, Tip_Adi AS [Hat Adı], IsActive AS [Aktif],
                    ((SELECT COUNT(*) FROM Makineler WHERE Makine_Tip_ID = mt.Tip_ID) + 
                     (SELECT COUNT(*) FROM Urunler WHERE Makine_Tip_ID = mt.Tip_ID) + 
                     (SELECT COUNT(*) FROM HataTipleri WHERE Makine_Tip_ID = mt.Tip_ID)) AS [Kullanim]
                    FROM MakineTipleri mt";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMakineTip.DataSource = dt;

                if (dgvMakineTip.Columns["Tip_ID"] != null) dgvMakineTip.Columns["Tip_ID"].Visible = false;
                if (dgvMakineTip.Columns["Kullanim"] != null) dgvMakineTip.Columns["Kullanim"].Visible = false;
            }
        }

        private void dgvMakineTip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dgvMakineTip.Rows[e.RowIndex];
                seciliTipID = Convert.ToInt32(satir.Cells["Tip_ID"].Value);
                txtTipAdi.Text = satir.Cells["Hat Adı"].Value.ToString();
                chkTipAktif.Checked = Convert.ToBoolean(satir.Cells["Aktif"].Value);

                // Silme butonu, yalnızca hiçbir ilişkili kayıt bulunmadığında görünür hale gelir.
                int kullanimSayisi = Convert.ToInt32(satir.Cells["Kullanim"].Value);
                btnTipSil.Visible = (kullanimSayisi == 0);
            }
        }

        private void btnTipEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipAdi.Text)) return;

            if (AnaForm.KayitVarMi("MakineTipleri", "Tip_Adi", txtTipAdi.Text.Trim()))
            {
                MessageBox.Show("Bu hat adı sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO MakineTipleri (Tip_Adi, IsActive) VALUES (@adi, @aktif)", baglanti);
                cmd.Parameters.AddWithValue("@adi", txtTipAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@aktif", chkTipAktif.Checked);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnTipTemizle.PerformClick();
            MakineTipleriniGetir();
            OrtakCombolariDoldur();
        }

        private void btnTipGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliTipID == -1 || string.IsNullOrWhiteSpace(txtTipAdi.Text)) return;

            if (AnaForm.KayitVarMi("MakineTipleri", "Tip_Adi", txtTipAdi.Text.Trim(), "Tip_ID", seciliTipID))
            {
                MessageBox.Show("Bu hat adı sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("UPDATE MakineTipleri SET Tip_Adi = @adi, IsActive = @aktif WHERE Tip_ID = @id", baglanti);
                cmd.Parameters.AddWithValue("@adi", txtTipAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@aktif", chkTipAktif.Checked);
                cmd.Parameters.AddWithValue("@id", seciliTipID);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnTipTemizle.PerformClick();
            MakineTipleriniGetir();
            OrtakCombolariDoldur();
            TumTablolariYenile();
        }

        private void btnTipSil_Click(object sender, EventArgs e)
        {
            if (seciliTipID == -1) return;
            DialogResult cevap = MessageBox.Show("Bu hattı sistemden kalıcı olarak silmek istediğinize emin misiniz?", "Kalıcı Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM MakineTipleri WHERE Tip_ID = @id", baglanti);
                    cmd.Parameters.AddWithValue("@id", seciliTipID);
                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                }
                btnTipTemizle.PerformClick();
                MakineTipleriniGetir();
                OrtakCombolariDoldur();
            }
        }

        private void btnTipTemizle_Click(object sender, EventArgs e)
        {
            seciliTipID = -1;
            txtTipAdi.Clear();
            chkTipAktif.Checked = true;
            dgvMakineTip.ClearSelection();
            btnTipSil.Visible = false;
        }

        #endregion

        #region 2. SEKME: MAKİNELER (TEZGAH YÖNETİMİ)

        private void MakineleriGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                string sorgu = @"
                    SELECT m.Makine_ID, m.Makine_Kodu AS [Kodu], m.Makine_Adi AS [Makine Adı], 
                           mt.Tip_Adi AS [Bağlı Olduğu Hat], m.IsActive AS [Aktif], m.Makine_Tip_ID,
                           (SELECT COUNT(*) FROM UretimLoglari WHERE Makine_ID = m.Makine_ID) AS [Kullanim]
                    FROM Makineler m 
                    INNER JOIN MakineTipleri mt ON m.Makine_Tip_ID = mt.Tip_ID";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMakine.DataSource = dt;

                if (dgvMakine.Columns["Makine_ID"] != null) dgvMakine.Columns["Makine_ID"].Visible = false;
                if (dgvMakine.Columns["Makine_Tip_ID"] != null) dgvMakine.Columns["Makine_Tip_ID"].Visible = false;
                if (dgvMakine.Columns["Kullanim"] != null) dgvMakine.Columns["Kullanim"].Visible = false;
            }
        }

        private void dgvMakine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dgvMakine.Rows[e.RowIndex];
                seciliMakineID = Convert.ToInt32(satir.Cells["Makine_ID"].Value);
                txtMakineKodu.Text = satir.Cells["Kodu"].Value.ToString();
                txtMakineAdi.Text = satir.Cells["Makine Adı"].Value.ToString();
                cmbMakineTipi.SelectedValue = satir.Cells["Makine_Tip_ID"].Value;
                chkMakineAktif.Checked = Convert.ToBoolean(satir.Cells["Aktif"].Value);

                int kullanimSayisi = Convert.ToInt32(satir.Cells["Kullanim"].Value);
                btnMakineSil.Visible = (kullanimSayisi == 0);
            }
        }

        private void btnMakineEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMakineKodu.Text) || string.IsNullOrWhiteSpace(txtMakineAdi.Text) || cmbMakineTipi.SelectedIndex == -1) return;

            if (AnaForm.KayitVarMi("Makineler", "Makine_Kodu", txtMakineKodu.Text.Trim()))
            {
                MessageBox.Show("Bu makine kodu sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Makineler (Makine_Kodu, Makine_Adi, Makine_Tip_ID, IsActive) VALUES (@kod, @adi, @tipId, @aktif)", baglanti);
                cmd.Parameters.AddWithValue("@kod", txtMakineKodu.Text.Trim());
                cmd.Parameters.AddWithValue("@adi", txtMakineAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@tipId", cmbMakineTipi.SelectedValue);
                cmd.Parameters.AddWithValue("@aktif", chkMakineAktif.Checked);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnMakineTemizle.PerformClick();
            MakineleriGetir();
        }

        private void btnMakineGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliMakineID == -1 || string.IsNullOrWhiteSpace(txtMakineKodu.Text) || string.IsNullOrWhiteSpace(txtMakineAdi.Text) || cmbMakineTipi.SelectedIndex == -1) return;

            if (AnaForm.KayitVarMi("Makineler", "Makine_Kodu", txtMakineKodu.Text.Trim(), "Makine_ID", seciliMakineID))
            {
                MessageBox.Show("Bu makine kodu sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Makineler SET Makine_Kodu = @kod, Makine_Adi = @adi, Makine_Tip_ID = @tipId, IsActive = @aktif WHERE Makine_ID = @id", baglanti);
                cmd.Parameters.AddWithValue("@kod", txtMakineKodu.Text.Trim());
                cmd.Parameters.AddWithValue("@adi", txtMakineAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@tipId", cmbMakineTipi.SelectedValue);
                cmd.Parameters.AddWithValue("@aktif", chkMakineAktif.Checked);
                cmd.Parameters.AddWithValue("@id", seciliMakineID);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnMakineTemizle.PerformClick();
            MakineleriGetir();
        }

        private void btnMakineSil_Click(object sender, EventArgs e)
        {
            if (seciliMakineID == -1) return;
            DialogResult cevap = MessageBox.Show("Bu makineyi sistemden kalıcı olarak silmek istediğinize emin misiniz?", "Kalıcı Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Makineler WHERE Makine_ID = @id", baglanti);
                    cmd.Parameters.AddWithValue("@id", seciliMakineID);
                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                }
                btnMakineTemizle.PerformClick();
                MakineleriGetir();
            }
        }

        private void btnMakineTemizle_Click(object sender, EventArgs e)
        {
            seciliMakineID = -1;
            txtMakineKodu.Clear();
            txtMakineAdi.Clear();
            cmbMakineTipi.SelectedIndex = -1;
            chkMakineAktif.Checked = true;
            dgvMakine.ClearSelection();
            btnMakineSil.Visible = false;
        }

        #endregion

        #region 3. SEKME: ÜRÜNLER (PARÇA YÖNETİMİ)

        private void UrunleriGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                string sorgu = @"
                    SELECT u.Urun_ID, u.Urun_Adi AS [Ürün Adı], mt.Tip_Adi AS [Üretildiği Hat], 
                           u.IsActive AS [Aktif], u.Makine_Tip_ID,
                           (SELECT COUNT(*) FROM UretimLoglari WHERE Urun_ID = u.Urun_ID) AS [Kullanim]
                    FROM Urunler u 
                    INNER JOIN MakineTipleri mt ON u.Makine_Tip_ID = mt.Tip_ID";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUrun.DataSource = dt;

                if (dgvUrun.Columns["Urun_ID"] != null) dgvUrun.Columns["Urun_ID"].Visible = false;
                if (dgvUrun.Columns["Makine_Tip_ID"] != null) dgvUrun.Columns["Makine_Tip_ID"].Visible = false;
                if (dgvUrun.Columns["Kullanim"] != null) dgvUrun.Columns["Kullanim"].Visible = false;
            }
        }

        private void dgvUrun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dgvUrun.Rows[e.RowIndex];
                seciliUrunID = Convert.ToInt32(satir.Cells["Urun_ID"].Value);
                txtUrunAdi.Text = satir.Cells["Ürün Adı"].Value.ToString();
                cmbUrunMakineTipi.SelectedValue = satir.Cells["Makine_Tip_ID"].Value;
                chkUrunAktif.Checked = Convert.ToBoolean(satir.Cells["Aktif"].Value);

                int kullanimSayisi = Convert.ToInt32(satir.Cells["Kullanim"].Value);
                btnUrunSil.Visible = (kullanimSayisi == 0);
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text) || cmbUrunMakineTipi.SelectedIndex == -1) return;

            if (AnaForm.KayitVarMi("Urunler", "Urun_Adi", txtUrunAdi.Text.Trim()))
            {
                MessageBox.Show("Bu ürün adı sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Urunler (Urun_Adi, Makine_Tip_ID, IsActive) VALUES (@adi, @tipId, @aktif)", baglanti);
                cmd.Parameters.AddWithValue("@adi", txtUrunAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@tipId", cmbUrunMakineTipi.SelectedValue);
                cmd.Parameters.AddWithValue("@aktif", chkUrunAktif.Checked);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnUrunTemizle.PerformClick();
            UrunleriGetir();
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliUrunID == -1 || string.IsNullOrWhiteSpace(txtUrunAdi.Text) || cmbUrunMakineTipi.SelectedIndex == -1) return;

            if (AnaForm.KayitVarMi("Urunler", "Urun_Adi", txtUrunAdi.Text.Trim(), "Urun_ID", seciliUrunID))
            {
                MessageBox.Show("Bu ürün adı sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Urunler SET Urun_Adi = @adi, Makine_Tip_ID = @tipId, IsActive = @aktif WHERE Urun_ID = @id", baglanti);
                cmd.Parameters.AddWithValue("@adi", txtUrunAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@tipId", cmbUrunMakineTipi.SelectedValue);
                cmd.Parameters.AddWithValue("@aktif", chkUrunAktif.Checked);
                cmd.Parameters.AddWithValue("@id", seciliUrunID);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnUrunTemizle.PerformClick();
            UrunleriGetir();
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (seciliUrunID == -1) return;
            DialogResult cevap = MessageBox.Show("Bu ürünü sistemden kalıcı olarak silmek istediğinize emin misiniz?", "Kalıcı Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Urunler WHERE Urun_ID = @id", baglanti);
                    cmd.Parameters.AddWithValue("@id", seciliUrunID);
                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                }
                btnUrunTemizle.PerformClick();
                UrunleriGetir();
            }
        }

        private void btnUrunTemizle_Click(object sender, EventArgs e)
        {
            seciliUrunID = -1;
            txtUrunAdi.Clear();
            cmbUrunMakineTipi.SelectedIndex = -1;
            chkUrunAktif.Checked = true;
            dgvUrun.ClearSelection();
            btnUrunSil.Visible = false;
        }

        #endregion

        #region 4. SEKME: HATA TANIMLARI (FİRE YÖNETİMİ)

        private void HataTipleriniGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                string sorgu = @"
                    SELECT h.Hata_ID, h.Hata_Adi AS [Hata Adı], h.Kritiklik_Seviyesi AS [Kritiklik], 
                           mt.Tip_Adi AS [Görüldüğü Hat], h.IsActive AS [Aktif], h.Makine_Tip_ID,
                           (SELECT COUNT(*) FROM UretimLoglari WHERE Hata_ID = h.Hata_ID) AS [Kullanim]
                    FROM HataTipleri h 
                    INNER JOIN MakineTipleri mt ON h.Makine_Tip_ID = mt.Tip_ID";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHata.DataSource = dt;

                if (dgvHata.Columns["Hata_ID"] != null) dgvHata.Columns["Hata_ID"].Visible = false;
                if (dgvHata.Columns["Makine_Tip_ID"] != null) dgvHata.Columns["Makine_Tip_ID"].Visible = false;
                if (dgvHata.Columns["Kullanim"] != null) dgvHata.Columns["Kullanim"].Visible = false;
            }
        }

        private void dgvHata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dgvHata.Rows[e.RowIndex];
                seciliHataID = Convert.ToInt32(satir.Cells["Hata_ID"].Value);
                txtHataAdi.Text = satir.Cells["Hata Adı"].Value.ToString();
                cmbKritiklik.Text = satir.Cells["Kritiklik"].Value.ToString();
                cmbHataMakineTipi.SelectedValue = satir.Cells["Makine_Tip_ID"].Value;
                chkHataAktif.Checked = Convert.ToBoolean(satir.Cells["Aktif"].Value);

                int kullanimSayisi = Convert.ToInt32(satir.Cells["Kullanim"].Value);
                btnHataSil.Visible = (kullanimSayisi == 0);
            }
        }

        private void btnHataEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHataAdi.Text) || cmbKritiklik.SelectedIndex == -1 || cmbHataMakineTipi.SelectedIndex == -1) return;

            if (AnaForm.KayitVarMi("HataTipleri", "Hata_Adi", txtHataAdi.Text.Trim()))
            {
                MessageBox.Show("Bu hata tanımı sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO HataTipleri (Hata_Adi, Kritiklik_Seviyesi, Makine_Tip_ID, IsActive) VALUES (@adi, @seviye, @tipId, @aktif)", baglanti);
                cmd.Parameters.AddWithValue("@adi", txtHataAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@seviye", cmbKritiklik.Text);
                cmd.Parameters.AddWithValue("@tipId", cmbHataMakineTipi.SelectedValue);
                cmd.Parameters.AddWithValue("@aktif", chkHataAktif.Checked);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnHataTemizle.PerformClick();
            HataTipleriniGetir();
        }

        private void btnHataGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliHataID == -1 || string.IsNullOrWhiteSpace(txtHataAdi.Text) || cmbKritiklik.SelectedIndex == -1 || cmbHataMakineTipi.SelectedIndex == -1) return;

            if (AnaForm.KayitVarMi("HataTipleri", "Hata_Adi", txtHataAdi.Text.Trim(), "Hata_ID", seciliHataID))
            {
                MessageBox.Show("Bu hata tanımı sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("UPDATE HataTipleri SET Hata_Adi = @adi, Kritiklik_Seviyesi = @seviye, Makine_Tip_ID = @tipId, IsActive = @aktif WHERE Hata_ID = @id", baglanti);
                cmd.Parameters.AddWithValue("@adi", txtHataAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@seviye", cmbKritiklik.Text);
                cmd.Parameters.AddWithValue("@tipId", cmbHataMakineTipi.SelectedValue);
                cmd.Parameters.AddWithValue("@aktif", chkHataAktif.Checked);
                cmd.Parameters.AddWithValue("@id", seciliHataID);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnHataTemizle.PerformClick();
            HataTipleriniGetir();
        }

        private void btnHataSil_Click(object sender, EventArgs e)
        {
            if (seciliHataID == -1) return;
            DialogResult cevap = MessageBox.Show("Bu hata tanımını sistemden kalıcı olarak silmek istediğinize emin misiniz?", "Kalıcı Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM HataTipleri WHERE Hata_ID = @id", baglanti);
                    cmd.Parameters.AddWithValue("@id", seciliHataID);
                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                }
                btnHataTemizle.PerformClick();
                HataTipleriniGetir();
            }
        }

        private void btnHataTemizle_Click(object sender, EventArgs e)
        {
            seciliHataID = -1;
            txtHataAdi.Clear();
            cmbKritiklik.SelectedIndex = -1;
            cmbHataMakineTipi.SelectedIndex = -1;
            chkHataAktif.Checked = true;
            dgvHata.ClearSelection();
            btnHataSil.Visible = false;
        }

        #endregion
    }
}