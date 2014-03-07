namespace ConsumedOrders
{
    partial class frmReserves
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReserves));
            this.dgProducts = new System.Windows.Forms.DataGrid();
            this.pnlProductInfo = new System.Windows.Forms.Panel();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictBack = new System.Windows.Forms.PictureBox();
            this.edtProductTitle = new System.Windows.Forms.TextBox();
            this.fullPriceCheck = new System.Windows.Forms.CheckBox();
            this.cmbStores = new System.Windows.Forms.ComboBox();
            this.pnlPrices = new System.Windows.Forms.Panel();
            this.lblPrices = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.pBoxKeyBoard = new System.Windows.Forms.PictureBox();
            this.pnlProductInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlPrices.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgProducts
            // 
            this.dgProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgProducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgProducts.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.dgProducts.Location = new System.Drawing.Point(-2, 59);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.RowHeadersVisible = false;
            this.dgProducts.Size = new System.Drawing.Size(244, 211);
            this.dgProducts.TabIndex = 18;
            this.dgProducts.CurrentCellChanged += new System.EventHandler(this.dgProducts_CurrentCellChanged);
            // 
            // pnlProductInfo
            // 
            this.pnlProductInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductInfo.BackColor = System.Drawing.Color.Gray;
            this.pnlProductInfo.Controls.Add(this.lblProductInfo);
            this.pnlProductInfo.Location = new System.Drawing.Point(2, 23);
            this.pnlProductInfo.Name = "pnlProductInfo";
            this.pnlProductInfo.Size = new System.Drawing.Size(236, 37);
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductInfo.BackColor = System.Drawing.SystemColors.Info;
            this.lblProductInfo.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblProductInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProductInfo.Location = new System.Drawing.Point(1, 1);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(234, 35);
            this.lblProductInfo.Text = "Напиток Ювента \"Чай зеленый с жасмином\" 0,5 /UA1.007.Х014340-06/\r\nЦены: 46743 436" +
                "72 2362 2367 23";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.pBoxKeyBoard);
            this.panel1.Controls.Add(this.pictBack);
            this.panel1.Controls.Add(this.edtProductTitle);
            this.panel1.Location = new System.Drawing.Point(0, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 25);
            // 
            // pictBack
            // 
            this.pictBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictBack.Image = ((System.Drawing.Image)(resources.GetObject("pictBack.Image")));
            this.pictBack.Location = new System.Drawing.Point(1, 3);
            this.pictBack.Name = "pictBack";
            this.pictBack.Size = new System.Drawing.Size(20, 20);
            this.pictBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictBack.Click += new System.EventHandler(this.pictBack_Click);
            this.pictBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictBack_MouseDown);
            this.pictBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictBack_MouseUp);
            // 
            // edtProductTitle
            // 
            this.edtProductTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtProductTitle.Location = new System.Drawing.Point(22, 2);
            this.edtProductTitle.Name = "edtProductTitle";
            this.edtProductTitle.Size = new System.Drawing.Size(181, 21);
            this.edtProductTitle.TabIndex = 12;
            this.edtProductTitle.TextChanged += new System.EventHandler(this.edtProductTitle_TextChanged);
            this.edtProductTitle.GotFocus += new System.EventHandler(this.edtProductTitle_GotFocus);
            this.edtProductTitle.LostFocus += new System.EventHandler(this.edtProductTitle_LostFocus);
            // 
            // fullPriceCheck
            // 
            this.fullPriceCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fullPriceCheck.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.fullPriceCheck.Location = new System.Drawing.Point(3, 2);
            this.fullPriceCheck.Name = "fullPriceCheck";
            this.fullPriceCheck.Size = new System.Drawing.Size(99, 20);
            this.fullPriceCheck.TabIndex = 21;
            this.fullPriceCheck.Text = "Полный прайс";
            this.fullPriceCheck.CheckStateChanged += new System.EventHandler(this.fullPriceCheck_CheckStateChanged);
            // 
            // cmbStores
            // 
            this.cmbStores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStores.Location = new System.Drawing.Point(104, 1);
            this.cmbStores.Name = "cmbStores";
            this.cmbStores.Size = new System.Drawing.Size(134, 22);
            this.cmbStores.TabIndex = 22;
            this.cmbStores.SelectedIndexChanged += new System.EventHandler(this.cmbStores_SelectedIndexChanged);
            // 
            // pnlPrices
            // 
            this.pnlPrices.BackColor = System.Drawing.SystemColors.Info;
            this.pnlPrices.Controls.Add(this.lblPrices);
            this.pnlPrices.Controls.Add(this.lblProduct);
            this.pnlPrices.Location = new System.Drawing.Point(0, 23);
            this.pnlPrices.Name = "pnlPrices";
            this.pnlPrices.Size = new System.Drawing.Size(240, 36);
            // 
            // lblPrices
            // 
            this.lblPrices.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblPrices.Location = new System.Drawing.Point(3, 19);
            this.lblPrices.Name = "lblPrices";
            this.lblPrices.Size = new System.Drawing.Size(234, 14);
            this.lblPrices.Text = "Цены:";
            // 
            // lblProduct
            // 
            this.lblProduct.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblProduct.Location = new System.Drawing.Point(3, 6);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(234, 14);
            this.lblProduct.Text = "Товар";
            // 
            // pBoxKeyBoard
            // 
            this.pBoxKeyBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBoxKeyBoard.Location = new System.Drawing.Point(217, 2);
            this.pBoxKeyBoard.Name = "pBoxKeyBoard";
            this.pBoxKeyBoard.Size = new System.Drawing.Size(20, 20);
            this.pBoxKeyBoard.Click += new System.EventHandler(this.pBoxKeyBoard_Click);
            this.pBoxKeyBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictBack_MouseDown);
            this.pBoxKeyBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictBack_MouseUp);
            // 
            // frmReserves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.pnlPrices);
            this.Controls.Add(this.dgProducts);
            this.Controls.Add(this.pnlProductInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fullPriceCheck);
            this.Controls.Add(this.cmbStores);
            this.Name = "frmReserves";
            this.Text = "Просмотр остатков";
            this.Load += new System.EventHandler(this.frmReserves_Load);
            this.pnlProductInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlPrices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dgProducts;
        private System.Windows.Forms.Panel pnlProductInfo;
        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictBack;
        private System.Windows.Forms.TextBox edtProductTitle;
        private System.Windows.Forms.CheckBox fullPriceCheck;
        private System.Windows.Forms.ComboBox cmbStores;
        private System.Windows.Forms.Panel pnlPrices;
        private System.Windows.Forms.Label lblPrices;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.PictureBox pBoxKeyBoard;
    }
}