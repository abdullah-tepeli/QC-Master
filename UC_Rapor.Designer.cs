namespace QC_Master
{
    partial class UC_Rapor
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
            this.lblFiltreKullanici = new System.Windows.Forms.Label();
            this.cmbFiltreKullanici = new System.Windows.Forms.ComboBox();
            this.lblFiltreMakine = new System.Windows.Forms.Label();
            this.cmbFiltreMakine = new System.Windows.Forms.ComboBox();
            this.lblFiltreUrun = new System.Windows.Forms.Label();
            this.cmbFiltreUrun = new System.Windows.Forms.ComboBox();
            this.lblFiltreHata = new System.Windows.Forms.Label();
            this.cmbFiltreHata = new System.Windows.Forms.ComboBox();
            this.lblBaslangic = new System.Windows.Forms.Label();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.lblBitis = new System.Windows.Forms.Label();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.lblSirala = new System.Windows.Forms.Label();
            this.cmbSirala = new System.Windows.Forms.ComboBox();
            this.lblYon = new System.Windows.Forms.Label();
            this.cmbYon = new System.Windows.Forms.ComboBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgvRapor = new System.Windows.Forms.DataGridView();
            this.btnOnceki = new System.Windows.Forms.Button();
            this.nudSayfaNo = new System.Windows.Forms.NumericUpDown();
            this.lblToplamSayfa = new System.Windows.Forms.Label();
            this.btnGit = new System.Windows.Forms.Button();
            this.btnSonraki = new System.Windows.Forms.Button();
            this.lblToplamKayit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSayfaNo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFiltreKullanici
            // 
            this.lblFiltreKullanici.AutoSize = true;
            this.lblFiltreKullanici.Location = new System.Drawing.Point(20, 15);
            this.lblFiltreKullanici.Name = "lblFiltreKullanici";
            this.lblFiltreKullanici.Size = new System.Drawing.Size(51, 13);
            this.lblFiltreKullanici.TabIndex = 0;
            this.lblFiltreKullanici.Text = "Operatör:";
            // 
            // cmbFiltreKullanici
            // 
            this.cmbFiltreKullanici.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltreKullanici.FormattingEnabled = true;
            this.cmbFiltreKullanici.Location = new System.Drawing.Point(20, 35);
            this.cmbFiltreKullanici.Name = "cmbFiltreKullanici";
            this.cmbFiltreKullanici.Size = new System.Drawing.Size(150, 21);
            this.cmbFiltreKullanici.TabIndex = 1;
            // 
            // lblFiltreMakine
            // 
            this.lblFiltreMakine.AutoSize = true;
            this.lblFiltreMakine.Location = new System.Drawing.Point(180, 15);
            this.lblFiltreMakine.Name = "lblFiltreMakine";
            this.lblFiltreMakine.Size = new System.Drawing.Size(45, 13);
            this.lblFiltreMakine.TabIndex = 2;
            this.lblFiltreMakine.Text = "Makine:";
            // 
            // cmbFiltreMakine
            // 
            this.cmbFiltreMakine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltreMakine.FormattingEnabled = true;
            this.cmbFiltreMakine.Location = new System.Drawing.Point(180, 35);
            this.cmbFiltreMakine.Name = "cmbFiltreMakine";
            this.cmbFiltreMakine.Size = new System.Drawing.Size(150, 21);
            this.cmbFiltreMakine.TabIndex = 3;
            this.cmbFiltreMakine.SelectedIndexChanged += new System.EventHandler(this.cmbFiltreMakine_SelectedIndexChanged);
            // 
            // lblFiltreUrun
            // 
            this.lblFiltreUrun.AutoSize = true;
            this.lblFiltreUrun.Location = new System.Drawing.Point(340, 15);
            this.lblFiltreUrun.Name = "lblFiltreUrun";
            this.lblFiltreUrun.Size = new System.Drawing.Size(33, 13);
            this.lblFiltreUrun.TabIndex = 4;
            this.lblFiltreUrun.Text = "Ürün:";
            // 
            // cmbFiltreUrun
            // 
            this.cmbFiltreUrun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltreUrun.FormattingEnabled = true;
            this.cmbFiltreUrun.Location = new System.Drawing.Point(340, 35);
            this.cmbFiltreUrun.Name = "cmbFiltreUrun";
            this.cmbFiltreUrun.Size = new System.Drawing.Size(150, 21);
            this.cmbFiltreUrun.TabIndex = 5;
            // 
            // lblFiltreHata
            // 
            this.lblFiltreHata.AutoSize = true;
            this.lblFiltreHata.Location = new System.Drawing.Point(500, 15);
            this.lblFiltreHata.Name = "lblFiltreHata";
            this.lblFiltreHata.Size = new System.Drawing.Size(53, 13);
            this.lblFiltreHata.TabIndex = 6;
            this.lblFiltreHata.Text = "Hata Tipi:";
            // 
            // cmbFiltreHata
            // 
            this.cmbFiltreHata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltreHata.FormattingEnabled = true;
            this.cmbFiltreHata.Location = new System.Drawing.Point(500, 35);
            this.cmbFiltreHata.Name = "cmbFiltreHata";
            this.cmbFiltreHata.Size = new System.Drawing.Size(150, 21);
            this.cmbFiltreHata.TabIndex = 7;
            // 
            // lblBaslangic
            // 
            this.lblBaslangic.AutoSize = true;
            this.lblBaslangic.Location = new System.Drawing.Point(20, 70);
            this.lblBaslangic.Name = "lblBaslangic";
            this.lblBaslangic.Size = new System.Drawing.Size(56, 13);
            this.lblBaslangic.TabIndex = 8;
            this.lblBaslangic.Text = "Başlangıç:";
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.AccessibleName = "Başlangıç:";
            this.dtpBaslangic.Checked = false;
            this.dtpBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBaslangic.Location = new System.Drawing.Point(20, 90);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.ShowCheckBox = true;
            this.dtpBaslangic.Size = new System.Drawing.Size(150, 20);
            this.dtpBaslangic.TabIndex = 9;
            // 
            // lblBitis
            // 
            this.lblBitis.AutoSize = true;
            this.lblBitis.Location = new System.Drawing.Point(180, 70);
            this.lblBitis.Name = "lblBitis";
            this.lblBitis.Size = new System.Drawing.Size(29, 13);
            this.lblBitis.TabIndex = 10;
            this.lblBitis.Text = "Bitiş:";
            // 
            // dtpBitis
            // 
            this.dtpBitis.AccessibleName = "Bitiş:";
            this.dtpBitis.Checked = false;
            this.dtpBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBitis.Location = new System.Drawing.Point(180, 90);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.ShowCheckBox = true;
            this.dtpBitis.Size = new System.Drawing.Size(150, 20);
            this.dtpBitis.TabIndex = 11;
            // 
            // lblSirala
            // 
            this.lblSirala.AutoSize = true;
            this.lblSirala.Location = new System.Drawing.Point(340, 70);
            this.lblSirala.Name = "lblSirala";
            this.lblSirala.Size = new System.Drawing.Size(36, 13);
            this.lblSirala.TabIndex = 12;
            this.lblSirala.Text = "Sırala:";
            // 
            // cmbSirala
            // 
            this.cmbSirala.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbSirala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSirala.FormattingEnabled = true;
            this.cmbSirala.Items.AddRange(new object[] {
            "Varsayılan",
            "Operatör",
            "Makine",
            "Hata",
            "Tarih"});
            this.cmbSirala.Location = new System.Drawing.Point(340, 90);
            this.cmbSirala.Name = "cmbSirala";
            this.cmbSirala.Size = new System.Drawing.Size(120, 21);
            this.cmbSirala.TabIndex = 13;
            // 
            // lblYon
            // 
            this.lblYon.AutoSize = true;
            this.lblYon.Location = new System.Drawing.Point(470, 70);
            this.lblYon.Name = "lblYon";
            this.lblYon.Size = new System.Drawing.Size(29, 13);
            this.lblYon.TabIndex = 14;
            this.lblYon.Text = "Yön:";
            // 
            // cmbYon
            // 
            this.cmbYon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYon.FormattingEnabled = true;
            this.cmbYon.Items.AddRange(new object[] {
            "Artan",
            "Azalan"});
            this.cmbYon.Location = new System.Drawing.Point(470, 90);
            this.cmbYon.Name = "cmbYon";
            this.cmbYon.Size = new System.Drawing.Size(80, 21);
            this.cmbYon.TabIndex = 15;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Location = new System.Drawing.Point(570, 85);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(120, 35);
            this.btnFiltrele.TabIndex = 16;
            this.btnFiltrele.Text = "SORGULA";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(700, 85);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(100, 35);
            this.btnTemizle.TabIndex = 17;
            this.btnTemizle.Text = "Filtreyi Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // dgvRapor
            // 
            this.dgvRapor.AllowUserToAddRows = false;
            this.dgvRapor.AllowUserToDeleteRows = false;
            this.dgvRapor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRapor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRapor.Location = new System.Drawing.Point(20, 140);
            this.dgvRapor.Name = "dgvRapor";
            this.dgvRapor.ReadOnly = true;
            this.dgvRapor.Size = new System.Drawing.Size(910, 340);
            this.dgvRapor.TabIndex = 18;
            // 
            // btnOnceki
            // 
            this.btnOnceki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOnceki.Location = new System.Drawing.Point(20, 500);
            this.btnOnceki.Name = "btnOnceki";
            this.btnOnceki.Size = new System.Drawing.Size(90, 35);
            this.btnOnceki.TabIndex = 19;
            this.btnOnceki.Text = "ÖNCEKİ";
            this.btnOnceki.UseVisualStyleBackColor = true;
            this.btnOnceki.Click += new System.EventHandler(this.btnOnceki_Click);
            // 
            // nudSayfaNo
            // 
            this.nudSayfaNo.AccessibleName = "Sayfa No:";
            this.nudSayfaNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudSayfaNo.Location = new System.Drawing.Point(120, 505);
            this.nudSayfaNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSayfaNo.Name = "nudSayfaNo";
            this.nudSayfaNo.Size = new System.Drawing.Size(60, 20);
            this.nudSayfaNo.TabIndex = 20;
            this.nudSayfaNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblToplamSayfa
            // 
            this.lblToplamSayfa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblToplamSayfa.AutoSize = true;
            this.lblToplamSayfa.Location = new System.Drawing.Point(185, 510);
            this.lblToplamSayfa.Name = "lblToplamSayfa";
            this.lblToplamSayfa.Size = new System.Drawing.Size(21, 13);
            this.lblToplamSayfa.TabIndex = 21;
            this.lblToplamSayfa.Text = "/ 0";
            // 
            // btnGit
            // 
            this.btnGit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGit.Location = new System.Drawing.Point(230, 500);
            this.btnGit.Name = "btnGit";
            this.btnGit.Size = new System.Drawing.Size(50, 35);
            this.btnGit.TabIndex = 22;
            this.btnGit.Text = "GİT";
            this.btnGit.UseVisualStyleBackColor = true;
            this.btnGit.Click += new System.EventHandler(this.btnGit_Click);
            // 
            // btnSonraki
            // 
            this.btnSonraki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSonraki.Location = new System.Drawing.Point(290, 500);
            this.btnSonraki.Name = "btnSonraki";
            this.btnSonraki.Size = new System.Drawing.Size(90, 35);
            this.btnSonraki.TabIndex = 23;
            this.btnSonraki.Text = "SONRAKİ";
            this.btnSonraki.UseVisualStyleBackColor = true;
            this.btnSonraki.Click += new System.EventHandler(this.btnSonraki_Click);
            // 
            // lblToplamKayit
            // 
            this.lblToplamKayit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToplamKayit.AutoSize = true;
            this.lblToplamKayit.Location = new System.Drawing.Point(750, 510);
            this.lblToplamKayit.Name = "lblToplamKayit";
            this.lblToplamKayit.Size = new System.Drawing.Size(80, 13);
            this.lblToplamKayit.TabIndex = 24;
            this.lblToplamKayit.Text = "Toplam: 0 Kayıt";
            // 
            // UC_Rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblToplamKayit);
            this.Controls.Add(this.btnSonraki);
            this.Controls.Add(this.btnGit);
            this.Controls.Add(this.lblToplamSayfa);
            this.Controls.Add(this.nudSayfaNo);
            this.Controls.Add(this.btnOnceki);
            this.Controls.Add(this.dgvRapor);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnFiltrele);
            this.Controls.Add(this.cmbYon);
            this.Controls.Add(this.lblYon);
            this.Controls.Add(this.cmbSirala);
            this.Controls.Add(this.lblSirala);
            this.Controls.Add(this.dtpBitis);
            this.Controls.Add(this.lblBitis);
            this.Controls.Add(this.dtpBaslangic);
            this.Controls.Add(this.lblBaslangic);
            this.Controls.Add(this.cmbFiltreHata);
            this.Controls.Add(this.lblFiltreHata);
            this.Controls.Add(this.cmbFiltreUrun);
            this.Controls.Add(this.lblFiltreUrun);
            this.Controls.Add(this.cmbFiltreMakine);
            this.Controls.Add(this.lblFiltreMakine);
            this.Controls.Add(this.cmbFiltreKullanici);
            this.Controls.Add(this.lblFiltreKullanici);
            this.Name = "UC_Rapor";
            this.Load += new System.EventHandler(this.UC_Rapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSayfaNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFiltreKullanici;
        private System.Windows.Forms.ComboBox cmbFiltreKullanici;
        private System.Windows.Forms.Label lblFiltreMakine;
        private System.Windows.Forms.ComboBox cmbFiltreMakine;
        private System.Windows.Forms.Label lblFiltreUrun;
        private System.Windows.Forms.ComboBox cmbFiltreUrun;
        private System.Windows.Forms.Label lblFiltreHata;
        private System.Windows.Forms.ComboBox cmbFiltreHata;
        private System.Windows.Forms.Label lblBaslangic;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.Label lblBitis;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.Label lblSirala;
        private System.Windows.Forms.ComboBox cmbSirala;
        private System.Windows.Forms.Label lblYon;
        private System.Windows.Forms.ComboBox cmbYon;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgvRapor;
        private System.Windows.Forms.Button btnOnceki;
        private System.Windows.Forms.NumericUpDown nudSayfaNo;
        private System.Windows.Forms.Label lblToplamSayfa;
        private System.Windows.Forms.Button btnGit;
        private System.Windows.Forms.Button btnSonraki;
        private System.Windows.Forms.Label lblToplamKayit;
    }
}
