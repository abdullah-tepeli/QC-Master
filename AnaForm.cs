using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int aktifKullaniciID;
        private string aktifRol;
        private string aktifKullanici;
        public AnaForm(int kullaniciID, string rol, string adSoyad)
        {
            InitializeComponent();
            aktifKullaniciID = kullaniciID;
            aktifRol = rol;
            aktifKullanici = adSoyad;
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            this.Text = $"QC-Master | Üretim ve Kontrol Merkezi - Hoş Geldin, {aktifKullanici}";
            tabControl1.TabPages.Add("tabGosterge", "Gösterge Paneli");
            if (aktifRol == "Sistem Yöneticisi")
            {
                tabControl1.TabPages.Add("tabUretim", "Üretim ve Fire Girişi");
                tabControl1.TabPages.Add("tabRapor", "Fire ve Kalite Raporları");
                tabControl1.TabPages.Add("tabMakine", "Makine ve Ürün Yönetimi");
                tabControl1.TabPages.Add("tabPersonel", "Personel ve Vardiya Yönetimi");
            }
            else if (aktifRol == "Kalite Mühendisi")
            {
                tabControl1.TabPages.Add("tabRapor", "Fire ve Kalite Raporları");
                tabControl1.TabPages.Add("tabMakine", "Makine ve Ürün Yönetimi");
            }
            else if (aktifRol == "Bant Operatörü")
            {
                tabControl1.TabPages.Add("tabUretim", "Üretim ve Fire Girişi");
            }
        }

        private void AnaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
