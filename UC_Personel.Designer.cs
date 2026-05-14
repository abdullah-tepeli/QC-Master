namespace QC_Master
{
    partial class UC_Personel
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
            this.tabControlPersonel = new System.Windows.Forms.TabControl();
            this.tpVardiya = new System.Windows.Forms.TabPage();
            this.dgvVardiya = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVardiyaAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.btnVardiyaEkle = new System.Windows.Forms.Button();
            this.btnVardiyaGuncelle = new System.Windows.Forms.Button();
            this.btnVardiyaTemizle = new System.Windows.Forms.Button();
            this.btnVardiyaSil = new System.Windows.Forms.Button();
            this.tpPersonel = new System.Windows.Forms.TabPage();
            this.dgvPersonel = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSicilNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVardiya = new System.Windows.Forms.ComboBox();
            this.chkPersonelAktif = new System.Windows.Forms.CheckBox();
            this.btnPersonelEkle = new System.Windows.Forms.Button();
            this.btnPersonelGuncelle = new System.Windows.Forms.Button();
            this.btnPersonelTemizle = new System.Windows.Forms.Button();
            this.btnPersonelSil = new System.Windows.Forms.Button();
            this.tabControlPersonel.SuspendLayout();
            this.tpVardiya.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVardiya)).BeginInit();
            this.tpPersonel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlPersonel
            // 
            this.tabControlPersonel.Controls.Add(this.tpVardiya);
            this.tabControlPersonel.Controls.Add(this.tpPersonel);
            this.tabControlPersonel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPersonel.Location = new System.Drawing.Point(0, 0);
            this.tabControlPersonel.Name = "tabControlPersonel";
            this.tabControlPersonel.SelectedIndex = 0;
            this.tabControlPersonel.Size = new System.Drawing.Size(150, 150);
            this.tabControlPersonel.TabIndex = 0;
            // 
            // tpVardiya
            // 
            this.tpVardiya.Controls.Add(this.btnVardiyaSil);
            this.tpVardiya.Controls.Add(this.btnVardiyaTemizle);
            this.tpVardiya.Controls.Add(this.btnVardiyaGuncelle);
            this.tpVardiya.Controls.Add(this.btnVardiyaEkle);
            this.tpVardiya.Controls.Add(this.dtpBitis);
            this.tpVardiya.Controls.Add(this.label3);
            this.tpVardiya.Controls.Add(this.dtpBaslangic);
            this.tpVardiya.Controls.Add(this.label2);
            this.tpVardiya.Controls.Add(this.txtVardiyaAdi);
            this.tpVardiya.Controls.Add(this.label1);
            this.tpVardiya.Controls.Add(this.dgvVardiya);
            this.tpVardiya.Location = new System.Drawing.Point(4, 22);
            this.tpVardiya.Name = "tpVardiya";
            this.tpVardiya.Padding = new System.Windows.Forms.Padding(3);
            this.tpVardiya.Size = new System.Drawing.Size(142, 124);
            this.tpVardiya.TabIndex = 0;
            this.tpVardiya.Text = "Vardiya Tanımları";
            this.tpVardiya.UseVisualStyleBackColor = true;
            // 
            // dgvVardiya
            // 
            this.dgvVardiya.AllowUserToAddRows = false;
            this.dgvVardiya.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvVardiya.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVardiya.Location = new System.Drawing.Point(10, 10);
            this.dgvVardiya.MultiSelect = false;
            this.dgvVardiya.Name = "dgvVardiya";
            this.dgvVardiya.ReadOnly = true;
            this.dgvVardiya.RowHeadersVisible = false;
            this.dgvVardiya.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVardiya.Size = new System.Drawing.Size(600, 500);
            this.dgvVardiya.TabIndex = 0;
            this.dgvVardiya.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVardiya_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vardiya Adı:";
            // 
            // txtVardiyaAdi
            // 
            this.txtVardiyaAdi.Location = new System.Drawing.Point(630, 40);
            this.txtVardiyaAdi.Name = "txtVardiyaAdi";
            this.txtVardiyaAdi.Size = new System.Drawing.Size(250, 20);
            this.txtVardiyaAdi.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mesai Başlangıç:";
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBaslangic.Location = new System.Drawing.Point(630, 100);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.ShowUpDown = true;
            this.dtpBaslangic.Size = new System.Drawing.Size(250, 20);
            this.dtpBaslangic.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(630, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mesai Bitiş:";
            // 
            // dtpBitis
            // 
            this.dtpBitis.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBitis.Location = new System.Drawing.Point(630, 160);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.ShowUpDown = true;
            this.dtpBitis.Size = new System.Drawing.Size(250, 20);
            this.dtpBitis.TabIndex = 6;
            // 
            // btnVardiyaEkle
            // 
            this.btnVardiyaEkle.Location = new System.Drawing.Point(630, 200);
            this.btnVardiyaEkle.Name = "btnVardiyaEkle";
            this.btnVardiyaEkle.Size = new System.Drawing.Size(120, 35);
            this.btnVardiyaEkle.TabIndex = 7;
            this.btnVardiyaEkle.Text = "EKLE";
            this.btnVardiyaEkle.UseVisualStyleBackColor = true;
            this.btnVardiyaEkle.Click += new System.EventHandler(this.btnVardiyaEkle_Click);
            // 
            // btnVardiyaGuncelle
            // 
            this.btnVardiyaGuncelle.Location = new System.Drawing.Point(760, 200);
            this.btnVardiyaGuncelle.Name = "btnVardiyaGuncelle";
            this.btnVardiyaGuncelle.Size = new System.Drawing.Size(120, 35);
            this.btnVardiyaGuncelle.TabIndex = 8;
            this.btnVardiyaGuncelle.Text = "GÜNCELLE";
            this.btnVardiyaGuncelle.UseVisualStyleBackColor = true;
            this.btnVardiyaGuncelle.Click += new System.EventHandler(this.btnVardiyaGuncelle_Click);
            // 
            // btnVardiyaTemizle
            // 
            this.btnVardiyaTemizle.Location = new System.Drawing.Point(630, 245);
            this.btnVardiyaTemizle.Name = "btnVardiyaTemizle";
            this.btnVardiyaTemizle.Size = new System.Drawing.Size(120, 30);
            this.btnVardiyaTemizle.TabIndex = 9;
            this.btnVardiyaTemizle.Text = "TEMİZLE";
            this.btnVardiyaTemizle.UseVisualStyleBackColor = true;
            this.btnVardiyaTemizle.Click += new System.EventHandler(this.btnVardiyaTemizle_Click);
            // 
            // btnVardiyaSil
            // 
            this.btnVardiyaSil.BackColor = System.Drawing.Color.Red;
            this.btnVardiyaSil.ForeColor = System.Drawing.Color.White;
            this.btnVardiyaSil.Location = new System.Drawing.Point(760, 245);
            this.btnVardiyaSil.Name = "btnVardiyaSil";
            this.btnVardiyaSil.Size = new System.Drawing.Size(120, 30);
            this.btnVardiyaSil.TabIndex = 10;
            this.btnVardiyaSil.Text = "SİL";
            this.btnVardiyaSil.UseVisualStyleBackColor = false;
            this.btnVardiyaSil.Visible = false;
            this.btnVardiyaSil.Click += new System.EventHandler(this.btnVardiyaSil_Click);
            // 
            // tpPersonel
            // 
            this.tpPersonel.Controls.Add(this.btnPersonelSil);
            this.tpPersonel.Controls.Add(this.btnPersonelTemizle);
            this.tpPersonel.Controls.Add(this.btnPersonelGuncelle);
            this.tpPersonel.Controls.Add(this.btnPersonelEkle);
            this.tpPersonel.Controls.Add(this.chkPersonelAktif);
            this.tpPersonel.Controls.Add(this.cmbVardiya);
            this.tpPersonel.Controls.Add(this.label8);
            this.tpPersonel.Controls.Add(this.cmbRol);
            this.tpPersonel.Controls.Add(this.label7);
            this.tpPersonel.Controls.Add(this.txtSifre);
            this.tpPersonel.Controls.Add(this.label6);
            this.tpPersonel.Controls.Add(this.txtAdSoyad);
            this.tpPersonel.Controls.Add(this.label5);
            this.tpPersonel.Controls.Add(this.txtSicilNo);
            this.tpPersonel.Controls.Add(this.label4);
            this.tpPersonel.Controls.Add(this.dgvPersonel);
            this.tpPersonel.Location = new System.Drawing.Point(4, 22);
            this.tpPersonel.Name = "tpPersonel";
            this.tpPersonel.Size = new System.Drawing.Size(142, 124);
            this.tpPersonel.TabIndex = 1;
            this.tpPersonel.Text = "Personel ve Yetki Yönetimi";
            this.tpPersonel.UseVisualStyleBackColor = true;
            // 
            // dgvPersonel
            // 
            this.dgvPersonel.AllowUserToAddRows = false;
            this.dgvPersonel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPersonel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonel.Location = new System.Drawing.Point(10, 10);
            this.dgvPersonel.MultiSelect = false;
            this.dgvPersonel.Name = "dgvPersonel";
            this.dgvPersonel.ReadOnly = true;
            this.dgvPersonel.RowHeadersVisible = false;
            this.dgvPersonel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonel.Size = new System.Drawing.Size(600, 500);
            this.dgvPersonel.TabIndex = 0;
            this.dgvPersonel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonel_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Sicil No:";
            // 
            // txtSicilNo
            // 
            this.txtSicilNo.Location = new System.Drawing.Point(630, 40);
            this.txtSicilNo.Name = "txtSicilNo";
            this.txtSicilNo.Size = new System.Drawing.Size(250, 20);
            this.txtSicilNo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ad Soyad:";
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(630, 100);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(250, 20);
            this.txtAdSoyad.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(630, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Şifre:";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(630, 160);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(250, 20);
            this.txtSifre.TabIndex = 6;
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(630, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Kullanıcı Rolü:";
            // 
            // cmbRol
            // 
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(630, 220);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(250, 21);
            this.cmbRol.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(630, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Vardiya Grubu:";
            // 
            // cmbVardiya
            // 
            this.cmbVardiya.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVardiya.FormattingEnabled = true;
            this.cmbVardiya.Location = new System.Drawing.Point(630, 280);
            this.cmbVardiya.Name = "cmbVardiya";
            this.cmbVardiya.Size = new System.Drawing.Size(250, 21);
            this.cmbVardiya.TabIndex = 10;
            // 
            // chkPersonelAktif
            // 
            this.chkPersonelAktif.AutoSize = true;
            this.chkPersonelAktif.Checked = true;
            this.chkPersonelAktif.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPersonelAktif.Location = new System.Drawing.Point(630, 320);
            this.chkPersonelAktif.Name = "chkPersonelAktif";
            this.chkPersonelAktif.Size = new System.Drawing.Size(96, 17);
            this.chkPersonelAktif.TabIndex = 11;
            this.chkPersonelAktif.Text = "Aktif / Çalışıyor";
            this.chkPersonelAktif.UseVisualStyleBackColor = true;
            // 
            // btnPersonelEkle
            // 
            this.btnPersonelEkle.Location = new System.Drawing.Point(630, 355);
            this.btnPersonelEkle.Name = "btnPersonelEkle";
            this.btnPersonelEkle.Size = new System.Drawing.Size(120, 35);
            this.btnPersonelEkle.TabIndex = 12;
            this.btnPersonelEkle.Text = "EKLE";
            this.btnPersonelEkle.UseVisualStyleBackColor = true;
            this.btnPersonelEkle.Click += new System.EventHandler(this.btnPersonelEkle_Click);
            // 
            // btnPersonelGuncelle
            // 
            this.btnPersonelGuncelle.Location = new System.Drawing.Point(760, 355);
            this.btnPersonelGuncelle.Name = "btnPersonelGuncelle";
            this.btnPersonelGuncelle.Size = new System.Drawing.Size(120, 35);
            this.btnPersonelGuncelle.TabIndex = 13;
            this.btnPersonelGuncelle.Text = "GÜNCELLE";
            this.btnPersonelGuncelle.UseVisualStyleBackColor = true;
            this.btnPersonelGuncelle.Click += new System.EventHandler(this.btnPersonelGuncelle_Click);
            // 
            // btnPersonelTemizle
            // 
            this.btnPersonelTemizle.Location = new System.Drawing.Point(630, 400);
            this.btnPersonelTemizle.Name = "btnPersonelTemizle";
            this.btnPersonelTemizle.Size = new System.Drawing.Size(120, 30);
            this.btnPersonelTemizle.TabIndex = 14;
            this.btnPersonelTemizle.Text = "TEMİZLE";
            this.btnPersonelTemizle.UseVisualStyleBackColor = true;
            this.btnPersonelTemizle.Click += new System.EventHandler(this.btnPersonelTemizle_Click);
            // 
            // btnPersonelSil
            // 
            this.btnPersonelSil.BackColor = System.Drawing.Color.Red;
            this.btnPersonelSil.ForeColor = System.Drawing.Color.White;
            this.btnPersonelSil.Location = new System.Drawing.Point(760, 400);
            this.btnPersonelSil.Name = "btnPersonelSil";
            this.btnPersonelSil.Size = new System.Drawing.Size(120, 30);
            this.btnPersonelSil.TabIndex = 15;
            this.btnPersonelSil.Text = "SİL";
            this.btnPersonelSil.UseVisualStyleBackColor = false;
            this.btnPersonelSil.Visible = false;
            this.btnPersonelSil.Click += new System.EventHandler(this.btnPersonelSil_Click);
            // 
            // UC_Personel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlPersonel);
            this.Name = "UC_Personel";
            this.Load += new System.EventHandler(this.UC_Personel_Load);
            this.tabControlPersonel.ResumeLayout(false);
            this.tpVardiya.ResumeLayout(false);
            this.tpVardiya.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVardiya)).EndInit();
            this.tpPersonel.ResumeLayout(false);
            this.tpPersonel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPersonel;
        private System.Windows.Forms.TabPage tpVardiya;
        private System.Windows.Forms.DataGridView dgvVardiya;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVardiyaAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVardiyaEkle;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.Button btnVardiyaSil;
        private System.Windows.Forms.Button btnVardiyaTemizle;
        private System.Windows.Forms.Button btnVardiyaGuncelle;
        private System.Windows.Forms.TabPage tpPersonel;
        private System.Windows.Forms.DataGridView dgvPersonel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSicilNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btnPersonelEkle;
        private System.Windows.Forms.CheckBox chkPersonelAktif;
        private System.Windows.Forms.ComboBox cmbVardiya;
        private System.Windows.Forms.Button btnPersonelSil;
        private System.Windows.Forms.Button btnPersonelTemizle;
        private System.Windows.Forms.Button btnPersonelGuncelle;
    }
}
