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
    public partial class UC_Personel : UserControl
    {
        // Bellekte tutulan aktif seçim ID'leri. Yeni kayıtta -1 olarak kalır.
        private int seciliVardiyaID = -1;
        private int seciliPersonelID = -1;

        public UC_Personel()
        {
            InitializeComponent();
        }

        // Kullanıcı denetimi yüklendiğinde temel listeleri ve veri ızgaralarını başlatır.
        private void UC_Personel_Load(object sender, EventArgs e)
        {
            RolleriDoldur();
            VardiyalariComboIcinDoldur();
            TumTablolariYenile();
        }

        // Sistemdeki vardiya ve personel tablolarını eşzamanlı olarak günceller.
        private void TumTablolariYenile()
        {
            VardiyalariGetir();
            PersonelleriGetir();
        }

        // Personel eklendiğinde/güncellendiğinde seçilebilecek rol listesini veritabanından çeker.
        private void RolleriDoldur()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Rol_ID, Rol_Adi FROM Roller", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbRol.DataSource = dt;
                cmbRol.DisplayMember = "Rol_Adi";
                cmbRol.ValueMember = "Rol_ID";
                cmbRol.SelectedIndex = -1;
            }
        }

        // Personel atamaları için vardiya listesini getirir ve 'Atanmadı' seçeneğini ekler.
        private void VardiyalariComboIcinDoldur()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Vardiya_ID, Vardiya_Adi FROM Vardiyalar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow dr = dt.NewRow();
                dr["Vardiya_ID"] = -1;
                dr["Vardiya_Adi"] = "<Vardiya Atanmadı>";
                dt.Rows.InsertAt(dr, 0);

                cmbVardiya.DataSource = dt;
                cmbVardiya.DisplayMember = "Vardiya_Adi";
                cmbVardiya.ValueMember = "Vardiya_ID";
                cmbVardiya.SelectedIndex = 0;
            }
        }

        #region 1. SEKME: VARDİYA YÖNETİMİ

        private void VardiyalariGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                // Vardiyaya atanmış personel sayısı kontrol edilerek akıllı silme için gizli sütun oluşturulur.
                string sorgu = @"
                    SELECT Vardiya_ID, Vardiya_Adi AS [Vardiya Adı], 
                           Baslangic_Saati AS [Başlangıç], Bitis_Saati AS [Bitiş],
                           (SELECT COUNT(*) FROM Kullanicilar WHERE Vardiya_ID = v.Vardiya_ID) AS [Kullanim]
                    FROM Vardiyalar v";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvVardiya.DataSource = dt;

                if (dgvVardiya.Columns["Vardiya_ID"] != null) dgvVardiya.Columns["Vardiya_ID"].Visible = false;
                if (dgvVardiya.Columns["Kullanim"] != null) dgvVardiya.Columns["Kullanim"].Visible = false;
            }
        }

        private void dgvVardiya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dgvVardiya.Rows[e.RowIndex];
                seciliVardiyaID = Convert.ToInt32(satir.Cells["Vardiya_ID"].Value);
                txtVardiyaAdi.Text = satir.Cells["Vardiya Adı"].Value.ToString();

                // SQL TimeSpan formatını DateTimePicker için uygun forma dönüştürür
                dtpBaslangic.Value = DateTime.Today.Add((TimeSpan)satir.Cells["Başlangıç"].Value);
                dtpBitis.Value = DateTime.Today.Add((TimeSpan)satir.Cells["Bitiş"].Value);

                int kullanimSayisi = Convert.ToInt32(satir.Cells["Kullanim"].Value);
                btnVardiyaSil.Visible = (kullanimSayisi == 0);
            }
        }

        private void btnVardiyaEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVardiyaAdi.Text)) return;

            if (AnaForm.KayitVarMi("Vardiyalar", "Vardiya_Adi", txtVardiyaAdi.Text.Trim()))
            {
                MessageBox.Show("Bu vardiya adı sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Vardiyalar (Vardiya_Adi, Baslangic_Saati, Bitis_Saati) VALUES (@adi, @bas, @bit)", baglanti);
                cmd.Parameters.AddWithValue("@adi", txtVardiyaAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@bas", dtpBaslangic.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@bit", dtpBitis.Value.TimeOfDay);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnVardiyaTemizle.PerformClick();
            VardiyalariGetir();
            VardiyalariComboIcinDoldur(); // Personel sekmesindeki listeyi günceller
        }

        private void btnVardiyaGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliVardiyaID == -1 || string.IsNullOrWhiteSpace(txtVardiyaAdi.Text)) return;

            if (AnaForm.KayitVarMi("Vardiyalar", "Vardiya_Adi", txtVardiyaAdi.Text.Trim(), "Vardiya_ID", seciliVardiyaID))
            {
                MessageBox.Show("Bu vardiya adı sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Vardiyalar SET Vardiya_Adi = @adi, Baslangic_Saati = @bas, Bitis_Saati = @bit WHERE Vardiya_ID = @id", baglanti);
                cmd.Parameters.AddWithValue("@adi", txtVardiyaAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@bas", dtpBaslangic.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@bit", dtpBitis.Value.TimeOfDay);
                cmd.Parameters.AddWithValue("@id", seciliVardiyaID);
                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnVardiyaTemizle.PerformClick();
            VardiyalariGetir();
            VardiyalariComboIcinDoldur();
        }

        private void btnVardiyaSil_Click(object sender, EventArgs e)
        {
            if (seciliVardiyaID == -1) return;
            DialogResult cevap = MessageBox.Show("Bu vardiyayı sistemden kalıcı olarak silmek istediğinize emin misiniz?", "Kalıcı Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Vardiyalar WHERE Vardiya_ID = @id", baglanti);
                    cmd.Parameters.AddWithValue("@id", seciliVardiyaID);
                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                }
                btnVardiyaTemizle.PerformClick();
                VardiyalariGetir();
                VardiyalariComboIcinDoldur();
            }
        }

        private void btnVardiyaTemizle_Click(object sender, EventArgs e)
        {
            seciliVardiyaID = -1;
            txtVardiyaAdi.Clear();
            dtpBaslangic.Value = DateTime.Now;
            dtpBitis.Value = DateTime.Now;
            dgvVardiya.ClearSelection();
            btnVardiyaSil.Visible = false;
        }

        #endregion

        #region 2. SEKME: PERSONEL YÖNETİMİ

        private void PersonelleriGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                // Üretim loglarında kaydı olan personel kalıcı olarak silinemez, akıllı silme için log sayısı çekilir.
                string sorgu = @"
                    SELECT k.Kullanici_ID, k.Sicil_No AS [Sicil No], k.Ad_Soyad AS [Ad Soyad], 
                           r.Rol_Adi AS [Yetki/Rol], ISNULL(v.Vardiya_Adi, 'Atanmadı') AS [Vardiya], 
                           k.IsActive AS [Aktif], k.Rol_ID, k.Vardiya_ID,
                           (SELECT COUNT(*) FROM UretimLoglari WHERE Kullanici_ID = k.Kullanici_ID) AS [Kullanim]
                    FROM Kullanicilar k
                    INNER JOIN Roller r ON k.Rol_ID = r.Rol_ID
                    LEFT JOIN Vardiyalar v ON k.Vardiya_ID = v.Vardiya_ID";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPersonel.DataSource = dt;

                if (dgvPersonel.Columns["Kullanici_ID"] != null) dgvPersonel.Columns["Kullanici_ID"].Visible = false;
                if (dgvPersonel.Columns["Rol_ID"] != null) dgvPersonel.Columns["Rol_ID"].Visible = false;
                if (dgvPersonel.Columns["Vardiya_ID"] != null) dgvPersonel.Columns["Vardiya_ID"].Visible = false;
                if (dgvPersonel.Columns["Kullanim"] != null) dgvPersonel.Columns["Kullanim"].Visible = false;
            }
        }

        private void dgvPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dgvPersonel.Rows[e.RowIndex];
                seciliPersonelID = Convert.ToInt32(satir.Cells["Kullanici_ID"].Value);
                txtSicilNo.Text = satir.Cells["Sicil No"].Value.ToString();
                txtAdSoyad.Text = satir.Cells["Ad Soyad"].Value.ToString();

                cmbRol.SelectedValue = satir.Cells["Rol_ID"].Value;
                cmbVardiya.SelectedValue = satir.Cells["Vardiya_ID"].Value != DBNull.Value ? satir.Cells["Vardiya_ID"].Value : -1;
                chkPersonelAktif.Checked = Convert.ToBoolean(satir.Cells["Aktif"].Value);

                txtSifre.Clear(); // Güvenlik sebebiyle mevcut şifre ekrana getirilmez

                int kullanimSayisi = Convert.ToInt32(satir.Cells["Kullanim"].Value);
                btnPersonelSil.Visible = (kullanimSayisi == 0);
            }
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSicilNo.Text) || string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) || cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Sicil, ad soyad, şifre ve rol alanları boş bırakılamaz.", "Eksik Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (AnaForm.KayitVarMi("Kullanicilar", "Sicil_No", txtSicilNo.Text.Trim()))
            {
                MessageBox.Show("Bu sicil numarası sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                string sorgu = "INSERT INTO Kullanicilar (Sicil_No, Ad_Soyad, Sifre_Hash, Rol_ID, Vardiya_ID, IsActive) " +
                               "VALUES (@sicil, @ad, @sifre, @rol, @vardiya, @aktif)";
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@sicil", txtSicilNo.Text.Trim());
                cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text.Trim());

                // GirisFormu içerisindeki genel hash metodu kullanılarak DRY prensibi sağlanmıştır.
                cmd.Parameters.AddWithValue("@sifre", GirisFormu.SifreyiHashle(txtSifre.Text));

                cmd.Parameters.AddWithValue("@rol", cmbRol.SelectedValue);
                cmd.Parameters.AddWithValue("@aktif", chkPersonelAktif.Checked);

                if (Convert.ToInt32(cmbVardiya.SelectedValue) == -1)
                    cmd.Parameters.AddWithValue("@vardiya", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@vardiya", cmbVardiya.SelectedValue);

                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnPersonelTemizle.PerformClick();
            PersonelleriGetir();
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliPersonelID == -1 || string.IsNullOrWhiteSpace(txtSicilNo.Text) ||
                string.IsNullOrWhiteSpace(txtAdSoyad.Text) || cmbRol.SelectedIndex == -1) return;

            if (AnaForm.KayitVarMi("Kullanicilar", "Sicil_No", txtSicilNo.Text.Trim(), "Kullanici_ID", seciliPersonelID))
            {
                MessageBox.Show("Bu sicil numarası sistemde zaten mevcut.", "Mükerrer Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
            {
                string sorgu = "UPDATE Kullanicilar SET Sicil_No = @sicil, Ad_Soyad = @ad, Rol_ID = @rol, Vardiya_ID = @vardiya, IsActive = @aktif ";

                // Kullanıcı şifre alanını boş bıraktıysa şifre güncellenmez, mevcut hash korunur.
                if (!string.IsNullOrWhiteSpace(txtSifre.Text))
                {
                    sorgu += ", Sifre_Hash = @sifre ";
                }
                sorgu += "WHERE Kullanici_ID = @id";

                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@sicil", txtSicilNo.Text.Trim());
                cmd.Parameters.AddWithValue("@ad", txtAdSoyad.Text.Trim());
                cmd.Parameters.AddWithValue("@rol", cmbRol.SelectedValue);
                cmd.Parameters.AddWithValue("@aktif", chkPersonelAktif.Checked);
                cmd.Parameters.AddWithValue("@id", seciliPersonelID);

                if (!string.IsNullOrWhiteSpace(txtSifre.Text))
                {
                    cmd.Parameters.AddWithValue("@sifre", GirisFormu.SifreyiHashle(txtSifre.Text));
                }

                if (Convert.ToInt32(cmbVardiya.SelectedValue) == -1)
                    cmd.Parameters.AddWithValue("@vardiya", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@vardiya", cmbVardiya.SelectedValue);

                baglanti.Open();
                cmd.ExecuteNonQuery();
            }
            btnPersonelTemizle.PerformClick();
            PersonelleriGetir();
        }

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            if (seciliPersonelID == -1) return;
            DialogResult cevap = MessageBox.Show("Bu personeli sistemden kalıcı olarak silmek istediğinize emin misiniz?", "Kalıcı Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                using (SqlConnection baglanti = new SqlConnection(AnaForm.baglantiCumlesi))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Kullanicilar WHERE Kullanici_ID = @id", baglanti);
                    cmd.Parameters.AddWithValue("@id", seciliPersonelID);
                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                }
                btnPersonelTemizle.PerformClick();
                PersonelleriGetir();
            }
        }

        private void btnPersonelTemizle_Click(object sender, EventArgs e)
        {
            seciliPersonelID = -1;
            txtSicilNo.Clear();
            txtAdSoyad.Clear();
            txtSifre.Clear();
            cmbRol.SelectedIndex = -1;
            cmbVardiya.SelectedIndex = 0; // "<Vardiya Atanmadı>" seçeneğine döner
            chkPersonelAktif.Checked = true;
            dgvPersonel.ClearSelection();
            btnPersonelSil.Visible = false;
        }

        #endregion
    }
}