namespace ConsumedOrders
{
    partial class frmRoute
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoute));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.cmbShop = new System.Windows.Forms.ComboBox();
            this.lstbShop = new System.Windows.Forms.ListBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxAdd = new System.Windows.Forms.PictureBox();
            this.pBoxDelete = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(22, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.Text = "День:";
            // 
            // cmbDayOfWeek
            // 
            this.cmbDayOfWeek.Location = new System.Drawing.Point(65, 5);
            this.cmbDayOfWeek.Name = "cmbDayOfWeek";
            this.cmbDayOfWeek.Size = new System.Drawing.Size(172, 22);
            this.cmbDayOfWeek.TabIndex = 1;
            this.cmbDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.cmbDayOfWeek_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(9, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.Text = "Клиент:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(5, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.Text = "Магазин:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Location = new System.Drawing.Point(65, 32);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(172, 22);
            this.cmbCustomer.TabIndex = 6;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // cmbShop
            // 
            this.cmbShop.Location = new System.Drawing.Point(65, 60);
            this.cmbShop.Name = "cmbShop";
            this.cmbShop.Size = new System.Drawing.Size(172, 22);
            this.cmbShop.TabIndex = 7;
            // 
            // lstbShop
            // 
            this.lstbShop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstbShop.Location = new System.Drawing.Point(3, 88);
            this.lstbShop.Name = "lstbShop";
            this.lstbShop.Size = new System.Drawing.Size(234, 170);
            this.lstbShop.TabIndex = 8;
            this.lstbShop.SelectedIndexChanged += new System.EventHandler(this.lstbShop_SelectedIndexChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCustomer.Location = new System.Drawing.Point(3, 257);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(234, 15);
            this.lblCustomer.Text = "Клиент:";
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource2"))));
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxAdd);
            this.panel4.Controls.Add(this.pBoxDelete);
            this.panel4.Controls.Add(this.pBoxBack);
            this.panel4.Location = new System.Drawing.Point(0, 271);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
            // 
            // pBoxAdd
            // 
            this.pBoxAdd.Location = new System.Drawing.Point(47, 2);
            this.pBoxAdd.Name = "pBoxAdd";
            this.pBoxAdd.Size = new System.Drawing.Size(20, 20);
            this.pBoxAdd.Click += new System.EventHandler(this.pBoxAdd_Click);
            this.pBoxAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxDelete
            // 
            this.pBoxDelete.Location = new System.Drawing.Point(25, 2);
            this.pBoxDelete.Name = "pBoxDelete";
            this.pBoxDelete.Size = new System.Drawing.Size(20, 20);
            this.pBoxDelete.Click += new System.EventHandler(this.pBoxDelete_Click);
            this.pBoxDelete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxBack
            // 
            this.pBoxBack.Location = new System.Drawing.Point(3, 2);
            this.pBoxBack.Name = "pBoxBack";
            this.pBoxBack.Size = new System.Drawing.Size(20, 20);
            this.pBoxBack.Click += new System.EventHandler(this.pBoxBack_Click);
            this.pBoxBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // frmRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.lstbShop);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmbShop);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDayOfWeek);
            this.Controls.Add(this.label1);
            this.Name = "frmRoute";
            this.Text = "Маршруты";
            this.Load += new System.EventHandler(this.frmRoute_Load);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDayOfWeek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.ComboBox cmbShop;
        private System.Windows.Forms.ListBox lstbShop;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxAdd;
        private System.Windows.Forms.PictureBox pBoxDelete;
        private System.Windows.Forms.PictureBox pBoxBack;
    }
}