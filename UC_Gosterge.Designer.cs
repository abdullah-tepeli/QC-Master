namespace QC_Master
{
    partial class UC_Gosterge
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPersonel = new System.Windows.Forms.TextBox();
            this.lblPersonel = new System.Windows.Forms.Label();
            this.txtMakine = new System.Windows.Forms.TextBox();
            this.lblMakine = new System.Windows.Forms.Label();
            this.txtOran = new System.Windows.Forms.TextBox();
            this.lblOran = new System.Windows.Forms.Label();
            this.txtFire = new System.Windows.Forms.TextBox();
            this.lblFire = new System.Windows.Forms.Label();
            this.txtUretim = new System.Windows.Forms.TextBox();
            this.lblUretim = new System.Windows.Forms.Label();
            this.gridSonIslemler = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSonIslemler)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPersonel);
            this.panel1.Controls.Add(this.lblPersonel);
            this.panel1.Controls.Add(this.txtMakine);
            this.panel1.Controls.Add(this.lblMakine);
            this.panel1.Controls.Add(this.txtOran);
            this.panel1.Controls.Add(this.lblOran);
            this.panel1.Controls.Add(this.txtFire);
            this.panel1.Controls.Add(this.lblFire);
            this.panel1.Controls.Add(this.txtUretim);
            this.panel1.Controls.Add(this.lblUretim);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 120);
            this.panel1.TabIndex = 0;
            // 
            // txtPersonel
            // 
            this.txtPersonel.Location = new System.Drawing.Point(430, 68);
            this.txtPersonel.Name = "txtPersonel";
            this.txtPersonel.ReadOnly = true;
            this.txtPersonel.Size = new System.Drawing.Size(100, 20);
            this.txtPersonel.TabIndex = 9;
            this.txtPersonel.Text = "0";
            // 
            // lblPersonel
            // 
            this.lblPersonel.AutoSize = true;
            this.lblPersonel.Location = new System.Drawing.Point(280, 70);
            this.lblPersonel.Name = "lblPersonel";
            this.lblPersonel.Size = new System.Drawing.Size(109, 13);
            this.lblPersonel.TabIndex = 8;
            this.lblPersonel.Text = "Vardiyadaki Personel:";
            // 
            // txtMakine
            // 
            this.txtMakine.Location = new System.Drawing.Point(150, 68);
            this.txtMakine.Name = "txtMakine";
            this.txtMakine.ReadOnly = true;
            this.txtMakine.Size = new System.Drawing.Size(100, 20);
            this.txtMakine.TabIndex = 7;
            this.txtMakine.Text = "0";
            // 
            // lblMakine
            // 
            this.lblMakine.AutoSize = true;
            this.lblMakine.Location = new System.Drawing.Point(20, 70);
            this.lblMakine.Name = "lblMakine";
            this.lblMakine.Size = new System.Drawing.Size(80, 13);
            this.lblMakine.TabIndex = 6;
            this.lblMakine.Text = "Aktif Makineler:";
            // 
            // txtOran
            // 
            this.txtOran.Location = new System.Drawing.Point(670, 18);
            this.txtOran.Name = "txtOran";
            this.txtOran.ReadOnly = true;
            this.txtOran.Size = new System.Drawing.Size(100, 20);
            this.txtOran.TabIndex = 5;
            this.txtOran.Text = "%0";
            // 
            // lblOran
            // 
            this.lblOran.AutoSize = true;
            this.lblOran.Location = new System.Drawing.Point(550, 20);
            this.lblOran.Name = "lblOran";
            this.lblOran.Size = new System.Drawing.Size(109, 13);
            this.lblOran.TabIndex = 4;
            this.lblOran.Text = "Günlük Fire Oranı (%):";
            // 
            // txtFire
            // 
            this.txtFire.Location = new System.Drawing.Point(430, 18);
            this.txtFire.Name = "txtFire";
            this.txtFire.ReadOnly = true;
            this.txtFire.Size = new System.Drawing.Size(100, 20);
            this.txtFire.TabIndex = 3;
            this.txtFire.Text = "0";
            // 
            // lblFire
            // 
            this.lblFire.AutoSize = true;
            this.lblFire.Location = new System.Drawing.Point(280, 20);
            this.lblFire.Name = "lblFire";
            this.lblFire.Size = new System.Drawing.Size(102, 13);
            this.lblFire.TabIndex = 2;
            this.lblFire.Text = "Günlük Toplam Fire:";
            // 
            // txtUretim
            // 
            this.txtUretim.Location = new System.Drawing.Point(150, 18);
            this.txtUretim.Name = "txtUretim";
            this.txtUretim.ReadOnly = true;
            this.txtUretim.Size = new System.Drawing.Size(100, 20);
            this.txtUretim.TabIndex = 1;
            this.txtUretim.Text = "0";
            // 
            // lblUretim
            // 
            this.lblUretim.AutoSize = true;
            this.lblUretim.Location = new System.Drawing.Point(20, 20);
            this.lblUretim.Name = "lblUretim";
            this.lblUretim.Size = new System.Drawing.Size(115, 13);
            this.lblUretim.TabIndex = 0;
            this.lblUretim.Text = "Günlük Toplam Üretim:";
            // 
            // gridSonIslemler
            // 
            this.gridSonIslemler.AllowUserToAddRows = false;
            this.gridSonIslemler.AllowUserToDeleteRows = false;
            this.gridSonIslemler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSonIslemler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSonIslemler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSonIslemler.Location = new System.Drawing.Point(0, 120);
            this.gridSonIslemler.Name = "gridSonIslemler";
            this.gridSonIslemler.ReadOnly = true;
            this.gridSonIslemler.Size = new System.Drawing.Size(150, 30);
            this.gridSonIslemler.TabIndex = 1;
            // 
            // UC_Gosterge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridSonIslemler);
            this.Controls.Add(this.panel1);
            this.Name = "UC_Gosterge";
            this.Load += new System.EventHandler(this.UC_Gosterge_Load);
            this.VisibleChanged += new System.EventHandler(this.UC_Gosterge_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSonIslemler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridSonIslemler;
        private System.Windows.Forms.Label lblUretim;
        private System.Windows.Forms.TextBox txtFire;
        private System.Windows.Forms.Label lblFire;
        private System.Windows.Forms.TextBox txtUretim;
        private System.Windows.Forms.TextBox txtOran;
        private System.Windows.Forms.Label lblOran;
        private System.Windows.Forms.Label lblPersonel;
        private System.Windows.Forms.TextBox txtMakine;
        private System.Windows.Forms.Label lblMakine;
        private System.Windows.Forms.TextBox txtPersonel;
    }
}
