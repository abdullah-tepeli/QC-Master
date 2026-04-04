namespace QC_Master
{
    partial class UC_UretimGirisi
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
            this.lblMakine = new System.Windows.Forms.Label();
            this.cmbMakine = new System.Windows.Forms.ComboBox();
            this.lblUrun = new System.Windows.Forms.Label();
            this.cmbUrun = new System.Windows.Forms.ComboBox();
            this.lblDurum = new System.Windows.Forms.Label();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMakine
            // 
            this.lblMakine.AutoSize = true;
            this.lblMakine.Location = new System.Drawing.Point(30, 30);
            this.lblMakine.Name = "lblMakine";
            this.lblMakine.Size = new System.Drawing.Size(86, 13);
            this.lblMakine.TabIndex = 0;
            this.lblMakine.Text = "Çalışılan Makine:";
            // 
            // cmbMakine
            // 
            this.cmbMakine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMakine.FormattingEnabled = true;
            this.cmbMakine.Location = new System.Drawing.Point(180, 28);
            this.cmbMakine.Name = "cmbMakine";
            this.cmbMakine.Size = new System.Drawing.Size(250, 21);
            this.cmbMakine.TabIndex = 1;
            this.cmbMakine.SelectedIndexChanged += new System.EventHandler(this.cmbMakine_SelectedIndexChanged);
            // 
            // lblUrun
            // 
            this.lblUrun.AutoSize = true;
            this.lblUrun.Location = new System.Drawing.Point(30, 80);
            this.lblUrun.Name = "lblUrun";
            this.lblUrun.Size = new System.Drawing.Size(77, 13);
            this.lblUrun.TabIndex = 2;
            this.lblUrun.Text = "Üretilen Parça:";
            // 
            // cmbUrun
            // 
            this.cmbUrun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrun.FormattingEnabled = true;
            this.cmbUrun.Location = new System.Drawing.Point(180, 78);
            this.cmbUrun.Name = "cmbUrun";
            this.cmbUrun.Size = new System.Drawing.Size(250, 21);
            this.cmbUrun.TabIndex = 3;
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(30, 130);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(76, 13);
            this.lblDurum.TabIndex = 4;
            this.lblDurum.Text = "Kalite Durumu:";
            // 
            // cmbDurum
            // 
            this.cmbDurum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDurum.FormattingEnabled = true;
            this.cmbDurum.Location = new System.Drawing.Point(180, 128);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(250, 21);
            this.cmbDurum.TabIndex = 5;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(180, 180);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(250, 50);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "SİSTEME İŞLE";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // UC_UretimGirisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.cmbDurum);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.cmbUrun);
            this.Controls.Add(this.lblUrun);
            this.Controls.Add(this.cmbMakine);
            this.Controls.Add(this.lblMakine);
            this.Name = "UC_UretimGirisi";
            this.Load += new System.EventHandler(this.UC_UretimGirisi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMakine;
        private System.Windows.Forms.ComboBox cmbMakine;
        private System.Windows.Forms.Label lblUrun;
        private System.Windows.Forms.ComboBox cmbUrun;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.ComboBox cmbDurum;
        private System.Windows.Forms.Button btnKaydet;
    }
}
