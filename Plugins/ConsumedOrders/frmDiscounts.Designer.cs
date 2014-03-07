namespace ConsumedOrders
{
    partial class frmDiscounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiscounts));
            this.dgDiscounts = new System.Windows.Forms.DataGrid();
            this.imageList = new System.Windows.Forms.ImageList();
            this.cmbStores = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxDiscountDetails = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgDiscounts
            // 
            this.dgDiscounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDiscounts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgDiscounts.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.dgDiscounts.Location = new System.Drawing.Point(-2, 42);
            this.dgDiscounts.Name = "dgDiscounts";
            this.dgDiscounts.RowHeadersVisible = false;
            this.dgDiscounts.Size = new System.Drawing.Size(244, 253);
            this.dgDiscounts.TabIndex = 34;
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            // 
            // cmbStores
            // 
            this.cmbStores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStores.Location = new System.Drawing.Point(53, 18);
            this.cmbStores.Name = "cmbStores";
            this.cmbStores.Size = new System.Drawing.Size(184, 22);
            this.cmbStores.TabIndex = 36;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCustomer.Location = new System.Drawing.Point(3, 4);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(234, 15);
            this.lblCustomer.Text = "Клиент:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.Text = "Склад:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxDiscountDetails);
            this.panel4.Controls.Add(this.pBoxBack);
            this.panel4.Location = new System.Drawing.Point(0, 272);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
            // 
            // pBoxDiscountDetails
            // 
            this.pBoxDiscountDetails.Location = new System.Drawing.Point(25, 2);
            this.pBoxDiscountDetails.Name = "pBoxDiscountDetails";
            this.pBoxDiscountDetails.Size = new System.Drawing.Size(20, 20);
            this.pBoxDiscountDetails.Click += new System.EventHandler(this.pBoxDiscountDetails_Click);
            this.pBoxDiscountDetails.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxDiscountDetails.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
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
            // frmDiscounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgDiscounts);
            this.Controls.Add(this.cmbStores);
            this.Controls.Add(this.lblCustomer);
            this.Name = "frmDiscounts";
            this.Text = "Скидки";
            this.Load += new System.EventHandler(this.frmDiscounts_Load);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dgDiscounts;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ComboBox cmbStores;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxDiscountDetails;
        private System.Windows.Forms.PictureBox pBoxBack;
    }
}