namespace QC_Master
{
    partial class UC_Makine
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlYonetim = new System.Windows.Forms.TabControl();
            this.tpMakineTip = new System.Windows.Forms.TabPage();
            this.btnTipSil = new System.Windows.Forms.Button();
            this.btnTipTemizle = new System.Windows.Forms.Button();
            this.btnTipGuncelle = new System.Windows.Forms.Button();
            this.btnTipEkle = new System.Windows.Forms.Button();
            this.chkTipAktif = new System.Windows.Forms.CheckBox();
            this.txtTipAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMakineTip = new System.Windows.Forms.DataGridView();
            this.tpMakine = new System.Windows.Forms.TabPage();
            this.btnMakineSil = new System.Windows.Forms.Button();
            this.btnMakineTemizle = new System.Windows.Forms.Button();
            this.btnMakineGuncelle = new System.Windows.Forms.Button();
            this.btnMakineEkle = new System.Windows.Forms.Button();
            this.chkMakineAktif = new System.Windows.Forms.CheckBox();
            this.cmbMakineTipi = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMakineAdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMakineKodu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMakine = new System.Windows.Forms.DataGridView();
            this.tpUrun = new System.Windows.Forms.TabPage();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnUrunTemizle = new System.Windows.Forms.Button();
            this.btnUrunGuncelle = new System.Windows.Forms.Button();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.chkUrunAktif = new System.Windows.Forms.CheckBox();
            this.cmbUrunMakineTipi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUrunAdi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvUrun = new System.Windows.Forms.DataGridView();
            this.tpHata = new System.Windows.Forms.TabPage();
            this.btnHataSil = new System.Windows.Forms.Button();
            this.btnHataTemizle = new System.Windows.Forms.Button();
            this.btnHataGuncelle = new System.Windows.Forms.Button();
            this.btnHataEkle = new System.Windows.Forms.Button();
            this.chkHataAktif = new System.Windows.Forms.CheckBox();
            this.cmbHataMakineTipi = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbKritiklik = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHataAdi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvHata = new System.Windows.Forms.DataGridView();
            this.tabControlYonetim.SuspendLayout();
            this.tpMakineTip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakineTip)).BeginInit();
            this.tpMakine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakine)).BeginInit();
            this.tpUrun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrun)).BeginInit();
            this.tpHata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHata)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlYonetim
            // 
            this.tabControlYonetim.Controls.Add(this.tpMakineTip);
            this.tabControlYonetim.Controls.Add(this.tpMakine);
            this.tabControlYonetim.Controls.Add(this.tpUrun);
            this.tabControlYonetim.Controls.Add(this.tpHata);
            this.tabControlYonetim.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlYonetim.Location = new System.Drawing.Point(0, 0);
            this.tabControlYonetim.Name = "tabControlYonetim";
            this.tabControlYonetim.SelectedIndex = 0;
            this.tabControlYonetim.Size = new System.Drawing.Size(150, 150);
            this.tabControlYonetim.TabIndex = 0;
            // 
            // tpMakineTip
            // 
            this.tpMakineTip.Controls.Add(this.btnTipSil);
            this.tpMakineTip.Controls.Add(this.btnTipTemizle);
            this.tpMakineTip.Controls.Add(this.btnTipGuncelle);
            this.tpMakineTip.Controls.Add(this.btnTipEkle);
            this.tpMakineTip.Controls.Add(this.chkTipAktif);
            this.tpMakineTip.Controls.Add(this.txtTipAdi);
            this.tpMakineTip.Controls.Add(this.label1);
            this.tpMakineTip.Controls.Add(this.dgvMakineTip);
            this.tpMakineTip.Location = new System.Drawing.Point(4, 22);
            this.tpMakineTip.Name = "tpMakineTip";
            this.tpMakineTip.Padding = new System.Windows.Forms.Padding(3);
            this.tpMakineTip.Size = new System.Drawing.Size(142, 124);
            this.tpMakineTip.TabIndex = 0;
            this.tpMakineTip.Text = "Makine Tipleri / Hatlar";
            this.tpMakineTip.UseVisualStyleBackColor = true;
            // 
            // btnTipSil
            // 
            this.btnTipSil.BackColor = System.Drawing.Color.Red;
            this.btnTipSil.ForeColor = System.Drawing.Color.White;
            this.btnTipSil.Location = new System.Drawing.Point(760, 165);
            this.btnTipSil.Name = "btnTipSil";
            this.btnTipSil.Size = new System.Drawing.Size(120, 30);
            this.btnTipSil.TabIndex = 7;
            this.btnTipSil.Text = "SİL";
            this.btnTipSil.UseVisualStyleBackColor = false;
            this.btnTipSil.Visible = false;
            this.btnTipSil.Click += new System.EventHandler(this.btnTipSil_Click);
            // 
            // btnTipTemizle
            // 
            this.btnTipTemizle.Location = new System.Drawing.Point(630, 165);
            this.btnTipTemizle.Name = "btnTipTemizle";
            this.btnTipTemizle.Size = new System.Drawing.Size(120, 30);
            this.btnTipTemizle.TabIndex = 6;
            this.btnTipTemizle.Text = "TEMİZLE";
            this.btnTipTemizle.UseVisualStyleBackColor = true;
            this.btnTipTemizle.Click += new System.EventHandler(this.btnTipTemizle_Click);
            // 
            // btnTipGuncelle
            // 
            this.btnTipGuncelle.Location = new System.Drawing.Point(760, 120);
            this.btnTipGuncelle.Name = "btnTipGuncelle";
            this.btnTipGuncelle.Size = new System.Drawing.Size(120, 35);
            this.btnTipGuncelle.TabIndex = 5;
            this.btnTipGuncelle.Text = "GÜNCELLE";
            this.btnTipGuncelle.UseVisualStyleBackColor = true;
            this.btnTipGuncelle.Click += new System.EventHandler(this.btnTipGuncelle_Click);
            // 
            // btnTipEkle
            // 
            this.btnTipEkle.Location = new System.Drawing.Point(630, 120);
            this.btnTipEkle.Name = "btnTipEkle";
            this.btnTipEkle.Size = new System.Drawing.Size(120, 35);
            this.btnTipEkle.TabIndex = 4;
            this.btnTipEkle.Text = "EKLE";
            this.btnTipEkle.UseVisualStyleBackColor = true;
            this.btnTipEkle.Click += new System.EventHandler(this.btnTipEkle_Click);
            // 
            // chkTipAktif
            // 
            this.chkTipAktif.AutoSize = true;
            this.chkTipAktif.Checked = true;
            this.chkTipAktif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTipAktif.Location = new System.Drawing.Point(630, 80);
            this.chkTipAktif.Name = "chkTipAktif";
            this.chkTipAktif.Size = new System.Drawing.Size(101, 17);
            this.chkTipAktif.TabIndex = 3;
            this.chkTipAktif.Text = "Aktif Kullanımda";
            this.chkTipAktif.UseVisualStyleBackColor = true;
            // 
            // txtTipAdi
            // 
            this.txtTipAdi.Location = new System.Drawing.Point(630, 40);
            this.txtTipAdi.Name = "txtTipAdi";
            this.txtTipAdi.Size = new System.Drawing.Size(250, 20);
            this.txtTipAdi.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hat / Tip Adı:";
            // 
            // dgvMakineTip
            // 
            this.dgvMakineTip.AllowUserToAddRows = false;
            this.dgvMakineTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvMakineTip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMakineTip.Location = new System.Drawing.Point(10, 10);
            this.dgvMakineTip.MultiSelect = false;
            this.dgvMakineTip.Name = "dgvMakineTip";
            this.dgvMakineTip.ReadOnly = true;
            this.dgvMakineTip.RowHeadersVisible = false;
            this.dgvMakineTip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMakineTip.Size = new System.Drawing.Size(600, 500);
            this.dgvMakineTip.TabIndex = 0;
            this.dgvMakineTip.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMakineTip_CellClick);
            // 
            // tpMakine
            // 
            this.tpMakine.Controls.Add(this.btnMakineSil);
            this.tpMakine.Controls.Add(this.btnMakineTemizle);
            this.tpMakine.Controls.Add(this.btnMakineGuncelle);
            this.tpMakine.Controls.Add(this.btnMakineEkle);
            this.tpMakine.Controls.Add(this.chkMakineAktif);
            this.tpMakine.Controls.Add(this.cmbMakineTipi);
            this.tpMakine.Controls.Add(this.label4);
            this.tpMakine.Controls.Add(this.txtMakineAdi);
            this.tpMakine.Controls.Add(this.label3);
            this.tpMakine.Controls.Add(this.txtMakineKodu);
            this.tpMakine.Controls.Add(this.label2);
            this.tpMakine.Controls.Add(this.dgvMakine);
            this.tpMakine.Location = new System.Drawing.Point(4, 22);
            this.tpMakine.Name = "tpMakine";
            this.tpMakine.Size = new System.Drawing.Size(142, 124);
            this.tpMakine.TabIndex = 1;
            this.tpMakine.Text = "Makineler / Tezgahlar";
            this.tpMakine.UseVisualStyleBackColor = true;
            // 
            // btnMakineSil
            // 
            this.btnMakineSil.BackColor = System.Drawing.Color.Red;
            this.btnMakineSil.ForeColor = System.Drawing.Color.White;
            this.btnMakineSil.Location = new System.Drawing.Point(760, 285);
            this.btnMakineSil.Name = "btnMakineSil";
            this.btnMakineSil.Size = new System.Drawing.Size(120, 30);
            this.btnMakineSil.TabIndex = 11;
            this.btnMakineSil.Text = "SİL";
            this.btnMakineSil.UseVisualStyleBackColor = false;
            this.btnMakineSil.Visible = false;
            this.btnMakineSil.Click += new System.EventHandler(this.btnMakineSil_Click);
            // 
            // btnMakineTemizle
            // 
            this.btnMakineTemizle.Location = new System.Drawing.Point(630, 285);
            this.btnMakineTemizle.Name = "btnMakineTemizle";
            this.btnMakineTemizle.Size = new System.Drawing.Size(120, 30);
            this.btnMakineTemizle.TabIndex = 10;
            this.btnMakineTemizle.Text = "TEMİZLE";
            this.btnMakineTemizle.UseVisualStyleBackColor = true;
            this.btnMakineTemizle.Click += new System.EventHandler(this.btnMakineTemizle_Click);
            // 
            // btnMakineGuncelle
            // 
            this.btnMakineGuncelle.Location = new System.Drawing.Point(760, 240);
            this.btnMakineGuncelle.Name = "btnMakineGuncelle";
            this.btnMakineGuncelle.Size = new System.Drawing.Size(120, 35);
            this.btnMakineGuncelle.TabIndex = 9;
            this.btnMakineGuncelle.Text = "GÜNCELLE";
            this.btnMakineGuncelle.UseVisualStyleBackColor = true;
            this.btnMakineGuncelle.Click += new System.EventHandler(this.btnMakineGuncelle_Click);
            // 
            // btnMakineEkle
            // 
            this.btnMakineEkle.Location = new System.Drawing.Point(630, 240);
            this.btnMakineEkle.Name = "btnMakineEkle";
            this.btnMakineEkle.Size = new System.Drawing.Size(120, 35);
            this.btnMakineEkle.TabIndex = 8;
            this.btnMakineEkle.Text = "EKLE";
            this.btnMakineEkle.UseVisualStyleBackColor = true;
            this.btnMakineEkle.Click += new System.EventHandler(this.btnMakineEkle_Click);
            // 
            // chkMakineAktif
            // 
            this.chkMakineAktif.AutoSize = true;
            this.chkMakineAktif.Checked = true;
            this.chkMakineAktif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMakineAktif.Location = new System.Drawing.Point(630, 200);
            this.chkMakineAktif.Name = "chkMakineAktif";
            this.chkMakineAktif.Size = new System.Drawing.Size(101, 17);
            this.chkMakineAktif.TabIndex = 7;
            this.chkMakineAktif.Text = "Aktif Kullanımda";
            this.chkMakineAktif.UseVisualStyleBackColor = true;
            // 
            // cmbMakineTipi
            // 
            this.cmbMakineTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMakineTipi.FormattingEnabled = true;
            this.cmbMakineTipi.Location = new System.Drawing.Point(630, 160);
            this.cmbMakineTipi.Name = "cmbMakineTipi";
            this.cmbMakineTipi.Size = new System.Drawing.Size(250, 21);
            this.cmbMakineTipi.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bağlı Olduğu Hat:";
            // 
            // txtMakineAdi
            // 
            this.txtMakineAdi.Location = new System.Drawing.Point(630, 100);
            this.txtMakineAdi.Name = "txtMakineAdi";
            this.txtMakineAdi.Size = new System.Drawing.Size(250, 20);
            this.txtMakineAdi.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(630, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Makine Adı:";
            // 
            // txtMakineKodu
            // 
            this.txtMakineKodu.Location = new System.Drawing.Point(630, 40);
            this.txtMakineKodu.Name = "txtMakineKodu";
            this.txtMakineKodu.Size = new System.Drawing.Size(250, 20);
            this.txtMakineKodu.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Makine Kodu:";
            // 
            // dgvMakine
            // 
            this.dgvMakine.AllowUserToAddRows = false;
            this.dgvMakine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvMakine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMakine.Location = new System.Drawing.Point(10, 10);
            this.dgvMakine.MultiSelect = false;
            this.dgvMakine.Name = "dgvMakine";
            this.dgvMakine.ReadOnly = true;
            this.dgvMakine.RowHeadersVisible = false;
            this.dgvMakine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMakine.Size = new System.Drawing.Size(600, 500);
            this.dgvMakine.TabIndex = 0;
            this.dgvMakine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMakine_CellClick);
            // 
            // tpUrun
            // 
            this.tpUrun.Controls.Add(this.btnUrunSil);
            this.tpUrun.Controls.Add(this.btnUrunTemizle);
            this.tpUrun.Controls.Add(this.btnUrunGuncelle);
            this.tpUrun.Controls.Add(this.btnUrunEkle);
            this.tpUrun.Controls.Add(this.chkUrunAktif);
            this.tpUrun.Controls.Add(this.cmbUrunMakineTipi);
            this.tpUrun.Controls.Add(this.label6);
            this.tpUrun.Controls.Add(this.txtUrunAdi);
            this.tpUrun.Controls.Add(this.label5);
            this.tpUrun.Controls.Add(this.dgvUrun);
            this.tpUrun.Location = new System.Drawing.Point(4, 22);
            this.tpUrun.Name = "tpUrun";
            this.tpUrun.Size = new System.Drawing.Size(142, 124);
            this.tpUrun.TabIndex = 2;
            this.tpUrun.Text = "Üretilen Ürünler";
            this.tpUrun.UseVisualStyleBackColor = true;
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.BackColor = System.Drawing.Color.Red;
            this.btnUrunSil.ForeColor = System.Drawing.Color.White;
            this.btnUrunSil.Location = new System.Drawing.Point(760, 225);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(120, 30);
            this.btnUrunSil.TabIndex = 9;
            this.btnUrunSil.Text = "SİL";
            this.btnUrunSil.UseVisualStyleBackColor = false;
            this.btnUrunSil.Visible = false;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // btnUrunTemizle
            // 
            this.btnUrunTemizle.Location = new System.Drawing.Point(630, 225);
            this.btnUrunTemizle.Name = "btnUrunTemizle";
            this.btnUrunTemizle.Size = new System.Drawing.Size(120, 30);
            this.btnUrunTemizle.TabIndex = 8;
            this.btnUrunTemizle.Text = "TEMİZLE";
            this.btnUrunTemizle.UseVisualStyleBackColor = true;
            this.btnUrunTemizle.Click += new System.EventHandler(this.btnUrunTemizle_Click);
            // 
            // btnUrunGuncelle
            // 
            this.btnUrunGuncelle.Location = new System.Drawing.Point(760, 180);
            this.btnUrunGuncelle.Name = "btnUrunGuncelle";
            this.btnUrunGuncelle.Size = new System.Drawing.Size(120, 35);
            this.btnUrunGuncelle.TabIndex = 7;
            this.btnUrunGuncelle.Text = "GÜNCELLE";
            this.btnUrunGuncelle.UseVisualStyleBackColor = true;
            this.btnUrunGuncelle.Click += new System.EventHandler(this.btnUrunGuncelle_Click);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.Location = new System.Drawing.Point(630, 180);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(120, 35);
            this.btnUrunEkle.TabIndex = 6;
            this.btnUrunEkle.Text = "EKLE";
            this.btnUrunEkle.UseVisualStyleBackColor = true;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // chkUrunAktif
            // 
            this.chkUrunAktif.AutoSize = true;
            this.chkUrunAktif.Checked = true;
            this.chkUrunAktif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUrunAktif.Location = new System.Drawing.Point(630, 140);
            this.chkUrunAktif.Name = "chkUrunAktif";
            this.chkUrunAktif.Size = new System.Drawing.Size(101, 17);
            this.chkUrunAktif.TabIndex = 5;
            this.chkUrunAktif.Text = "Aktif Kullanımda";
            this.chkUrunAktif.UseVisualStyleBackColor = true;
            // 
            // cmbUrunMakineTipi
            // 
            this.cmbUrunMakineTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrunMakineTipi.FormattingEnabled = true;
            this.cmbUrunMakineTipi.Location = new System.Drawing.Point(630, 100);
            this.cmbUrunMakineTipi.Name = "cmbUrunMakineTipi";
            this.cmbUrunMakineTipi.Size = new System.Drawing.Size(250, 21);
            this.cmbUrunMakineTipi.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(630, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Üretileceği Hat:";
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.Location = new System.Drawing.Point(630, 40);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.Size = new System.Drawing.Size(250, 20);
            this.txtUrunAdi.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ürün Adı:";
            // 
            // dgvUrun
            // 
            this.dgvUrun.AllowUserToAddRows = false;
            this.dgvUrun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvUrun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrun.Location = new System.Drawing.Point(10, 10);
            this.dgvUrun.MultiSelect = false;
            this.dgvUrun.Name = "dgvUrun";
            this.dgvUrun.ReadOnly = true;
            this.dgvUrun.RowHeadersVisible = false;
            this.dgvUrun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUrun.Size = new System.Drawing.Size(600, 500);
            this.dgvUrun.TabIndex = 0;
            this.dgvUrun.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrun_CellClick);
            // 
            // tpHata
            // 
            this.tpHata.Controls.Add(this.btnHataSil);
            this.tpHata.Controls.Add(this.btnHataTemizle);
            this.tpHata.Controls.Add(this.btnHataGuncelle);
            this.tpHata.Controls.Add(this.btnHataEkle);
            this.tpHata.Controls.Add(this.chkHataAktif);
            this.tpHata.Controls.Add(this.cmbHataMakineTipi);
            this.tpHata.Controls.Add(this.label9);
            this.tpHata.Controls.Add(this.cmbKritiklik);
            this.tpHata.Controls.Add(this.label8);
            this.tpHata.Controls.Add(this.txtHataAdi);
            this.tpHata.Controls.Add(this.label7);
            this.tpHata.Controls.Add(this.dgvHata);
            this.tpHata.Location = new System.Drawing.Point(4, 22);
            this.tpHata.Name = "tpHata";
            this.tpHata.Size = new System.Drawing.Size(142, 124);
            this.tpHata.TabIndex = 3;
            this.tpHata.Text = "Hata Tanımları";
            this.tpHata.UseVisualStyleBackColor = true;
            // 
            // btnHataSil
            // 
            this.btnHataSil.BackColor = System.Drawing.Color.Red;
            this.btnHataSil.ForeColor = System.Drawing.Color.White;
            this.btnHataSil.Location = new System.Drawing.Point(760, 285);
            this.btnHataSil.Name = "btnHataSil";
            this.btnHataSil.Size = new System.Drawing.Size(120, 30);
            this.btnHataSil.TabIndex = 11;
            this.btnHataSil.Text = "SİL";
            this.btnHataSil.UseVisualStyleBackColor = false;
            this.btnHataSil.Visible = false;
            this.btnHataSil.Click += new System.EventHandler(this.btnHataSil_Click);
            // 
            // btnHataTemizle
            // 
            this.btnHataTemizle.Location = new System.Drawing.Point(630, 285);
            this.btnHataTemizle.Name = "btnHataTemizle";
            this.btnHataTemizle.Size = new System.Drawing.Size(120, 30);
            this.btnHataTemizle.TabIndex = 10;
            this.btnHataTemizle.Text = "TEMİZLE";
            this.btnHataTemizle.UseVisualStyleBackColor = true;
            this.btnHataTemizle.Click += new System.EventHandler(this.btnHataTemizle_Click);
            // 
            // btnHataGuncelle
            // 
            this.btnHataGuncelle.Location = new System.Drawing.Point(760, 240);
            this.btnHataGuncelle.Name = "btnHataGuncelle";
            this.btnHataGuncelle.Size = new System.Drawing.Size(120, 35);
            this.btnHataGuncelle.TabIndex = 9;
            this.btnHataGuncelle.Text = "GÜNCELLE";
            this.btnHataGuncelle.UseVisualStyleBackColor = true;
            this.btnHataGuncelle.Click += new System.EventHandler(this.btnHataGuncelle_Click);
            // 
            // btnHataEkle
            // 
            this.btnHataEkle.Location = new System.Drawing.Point(630, 240);
            this.btnHataEkle.Name = "btnHataEkle";
            this.btnHataEkle.Size = new System.Drawing.Size(120, 35);
            this.btnHataEkle.TabIndex = 8;
            this.btnHataEkle.Text = "EKLE";
            this.btnHataEkle.UseVisualStyleBackColor = true;
            this.btnHataEkle.Click += new System.EventHandler(this.btnHataEkle_Click);
            // 
            // chkHataAktif
            // 
            this.chkHataAktif.AutoSize = true;
            this.chkHataAktif.Checked = true;
            this.chkHataAktif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHataAktif.Location = new System.Drawing.Point(630, 200);
            this.chkHataAktif.Name = "chkHataAktif";
            this.chkHataAktif.Size = new System.Drawing.Size(101, 17);
            this.chkHataAktif.TabIndex = 7;
            this.chkHataAktif.Text = "Aktif Kullanımda";
            this.chkHataAktif.UseVisualStyleBackColor = true;
            // 
            // cmbHataMakineTipi
            // 
            this.cmbHataMakineTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHataMakineTipi.FormattingEnabled = true;
            this.cmbHataMakineTipi.Location = new System.Drawing.Point(630, 160);
            this.cmbHataMakineTipi.Name = "cmbHataMakineTipi";
            this.cmbHataMakineTipi.Size = new System.Drawing.Size(250, 21);
            this.cmbHataMakineTipi.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(630, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Görülebileceği Hat:";
            // 
            // cmbKritiklik
            // 
            this.cmbKritiklik.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKritiklik.FormattingEnabled = true;
            this.cmbKritiklik.Items.AddRange(new object[] {
            "Az",
            "Orta",
            "Kritik"});
            this.cmbKritiklik.Location = new System.Drawing.Point(630, 100);
            this.cmbKritiklik.Name = "cmbKritiklik";
            this.cmbKritiklik.Size = new System.Drawing.Size(250, 21);
            this.cmbKritiklik.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(630, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Kritiklik Seviyesi:";
            // 
            // txtHataAdi
            // 
            this.txtHataAdi.Location = new System.Drawing.Point(630, 40);
            this.txtHataAdi.Name = "txtHataAdi";
            this.txtHataAdi.Size = new System.Drawing.Size(250, 20);
            this.txtHataAdi.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(630, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Hata Adı:";
            // 
            // dgvHata
            // 
            this.dgvHata.AllowUserToAddRows = false;
            this.dgvHata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvHata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHata.Location = new System.Drawing.Point(10, 10);
            this.dgvHata.MultiSelect = false;
            this.dgvHata.Name = "dgvHata";
            this.dgvHata.ReadOnly = true;
            this.dgvHata.RowHeadersVisible = false;
            this.dgvHata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHata.Size = new System.Drawing.Size(600, 500);
            this.dgvHata.TabIndex = 0;
            this.dgvHata.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHata_CellClick);
            // 
            // UC_Makine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlYonetim);
            this.Name = "UC_Makine";
            this.Load += new System.EventHandler(this.UC_Makine_Load);
            this.tabControlYonetim.ResumeLayout(false);
            this.tpMakineTip.ResumeLayout(false);
            this.tpMakineTip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakineTip)).EndInit();
            this.tpMakine.ResumeLayout(false);
            this.tpMakine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMakine)).EndInit();
            this.tpUrun.ResumeLayout(false);
            this.tpUrun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrun)).EndInit();
            this.tpHata.ResumeLayout(false);
            this.tpHata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlYonetim;
        private System.Windows.Forms.TabPage tpMakineTip;
        private System.Windows.Forms.DataGridView dgvMakineTip;
        private System.Windows.Forms.TextBox txtTipAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTipGuncelle;
        private System.Windows.Forms.Button btnTipEkle;
        private System.Windows.Forms.CheckBox chkTipAktif;
        private System.Windows.Forms.Button btnTipTemizle;
        private System.Windows.Forms.TabPage tpMakine;
        private System.Windows.Forms.DataGridView dgvMakine;
        private System.Windows.Forms.TextBox txtMakineKodu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMakineTipi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMakineAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMakineEkle;
        private System.Windows.Forms.CheckBox chkMakineAktif;
        private System.Windows.Forms.Button btnMakineTemizle;
        private System.Windows.Forms.Button btnMakineGuncelle;
        private System.Windows.Forms.TabPage tpUrun;
        private System.Windows.Forms.TextBox txtUrunAdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvUrun;
        private System.Windows.Forms.CheckBox chkUrunAktif;
        private System.Windows.Forms.ComboBox cmbUrunMakineTipi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUrunTemizle;
        private System.Windows.Forms.Button btnUrunGuncelle;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.TabPage tpHata;
        private System.Windows.Forms.TextBox txtHataAdi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvHata;
        private System.Windows.Forms.ComboBox cmbHataMakineTipi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbKritiklik;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnHataGuncelle;
        private System.Windows.Forms.Button btnHataEkle;
        private System.Windows.Forms.CheckBox chkHataAktif;
        private System.Windows.Forms.Button btnHataTemizle;
        private System.Windows.Forms.Button btnTipSil;
        private System.Windows.Forms.Button btnMakineSil;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnHataSil;
    }
}
