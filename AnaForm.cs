using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QC_Master
{
    public partial class AnaForm : Form
    {
        public static int aktifKullaniciID;
        public static string aktifRol;
        public static string aktifKullanici;
        public static readonly string baglantiCumlesi = ConfigurationManager.ConnectionStrings["QCMasterConn"].ConnectionString;
        public AnaForm(int kullaniciID, string rol, string adSoyad)
        {
            InitializeComponent();
            aktifKullaniciID = kullaniciID;
            aktifRol = rol;
            aktifKullanici = adSoyad;
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            this.Text = $"QC-Master | Üretim ve Kontrol Merkezi - Hoş Geldiniz, {aktifKullanici}";
            // Varsayılan Gösterge Paneli sekmesinin tüm kullanıcı rolleri için oluşturulması
            SekmeVePanelEkle("tabGosterge", "Gösterge Paneli", new UC_Gosterge());
// Diğer sekmelerin kullanıcı rolüne göre oluşturulması
            if (aktifRol == "Sistem Yöneticisi")
            {
                SekmeVePanelEkle("tabUretim", "Üretim ve Fire Girişi", new UC_UretimGirisi());
                SekmeVePanelEkle("tabRapor", "Fire ve Kalite Raporları", new UC_Rapor());
                SekmeVePanelEkle("tabMakine", "Makine ve Ürün Yönetimi", new UC_Makine());
                SekmeVePanelEkle("tabPersonel", "Personel ve Vardiya Yönetimi", new UC_Personel());
            }
            else if (aktifRol == "Kalite Mühendisi")
            {
                SekmeVePanelEkle("tabRapor", "Fire ve Kalite Raporları", new UC_Rapor());
                SekmeVePanelEkle("tabMakine", "Makine ve Ürün Yönetimi", new UC_Makine());
            }
            else if (aktifRol == "Bant Operatörü")
            {
                SekmeVePanelEkle("tabUretim", "Üretim ve Fire Girişi", new UC_UretimGirisi());
            }
        }

        private void AnaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void SekmeVePanelEkle(string sekmeAnahtari, string sekmeBasligi, UserControl icerikPaneli)
        {
            // Yeni sekmenin TabControl koleksiyonuna eklenmesi
            tabControl1.TabPages.Add(sekmeAnahtari, sekmeBasligi);
            // Kullanıcı denetiminin sekme içerisine tam sığacak şekilde boyutlandırılması
            icerikPaneli.Dock = DockStyle.Fill;
            // İlgili denetimin oluşturulan sekmenin içerik koleksiyonuna dahil edilmesi
            tabControl1.TabPages[sekmeAnahtari].Controls.Add(icerikPaneli);
        }
    }
}
