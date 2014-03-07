namespace ConsumedOrders
{
    partial class frmPrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrice));
            this.pnlToolBar = new System.Windows.Forms.Panel();
            this.pBoxKeyBoard = new System.Windows.Forms.PictureBox();
            this.pictFilters = new System.Windows.Forms.PictureBox();
            this.pictAdd = new System.Windows.Forms.PictureBox();
            this.pictBack = new System.Windows.Forms.PictureBox();
            this.edtProductTitle = new System.Windows.Forms.TextBox();
            this.dgPrice = new System.Windows.Forms.DataGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblPrices = new System.Windows.Forms.Label();
            this.pnlProductsFilter = new System.Windows.Forms.Panel();
            this.chkbShowFullPrice = new System.Windows.Forms.CheckBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.rbnView = new System.Windows.Forms.RadioButton();
            this.rbnType = new System.Windows.Forms.RadioButton();
            this.rbnGroup = new System.Windows.Forms.RadioButton();
            this.pnlToolBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlProductsFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolBar
            // 
            this.pnlToolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.pnlToolBar.Controls.Add(this.pBoxKeyBoard);
            this.pnlToolBar.Controls.Add(this.pictFilters);
            this.pnlToolBar.Controls.Add(this.pictAdd);
            this.pnlToolBar.Controls.Add(this.pictBack);
            this.pnlToolBar.Controls.Add(this.edtProductTitle);
            this.pnlToolBar.Location = new System.Drawing.Point(0, 269);
            this.pnlToolBar.Name = "pnlToolBar";
            this.pnlToolBar.Size = new System.Drawing.Size(240, 25);
            // 
            // pBoxKeyBoard
            // 
            this.pBoxKeyBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBoxKeyBoard.Location = new System.Drawing.Point(217, 3);
            this.pBoxKeyBoard.Name = "pBoxKeyBoard";
            this.pBoxKeyBoard.Size = new System.Drawing.Size(20, 20);
            this.pBoxKeyBoard.Click += new System.EventHandler(this.pBoxKeyBoard_Click);
            this.pBoxKeyBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictAdd_MouseDown);
            this.pBoxKeyBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictAdd_MouseUp);
            // 
            // pictFilters
            // 
            this.pictFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.pictFilters.Image = ((System.Drawing.Image)(resources.GetObject("pictFilters.Image")));
            this.pictFilters.Location = new System.Drawing.Point(176, 3);
            this.pictFilters.Name = "pictFilters";
            this.pictFilters.Size = new System.Drawing.Size(20, 20);
            this.pictFilters.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictFilters.Click += new System.EventHandler(this.pictFilters_Click);
            this.pictFilters.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictAdd_MouseDown);
            this.pictFilters.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictAdd_MouseUp);
            // 
            // pictAdd
            // 
            this.pictAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictAdd.Image = ((System.Drawing.Image)(resources.GetObject("pictAdd.Image")));
            this.pictAdd.Location = new System.Drawing.Point(150, 3);
            this.pictAdd.Name = "pictAdd";
            this.pictAdd.Size = new System.Drawing.Size(20, 20);
            this.pictAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictAdd.Click += new System.EventHandler(this.pictAdd_Click);
            this.pictAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictAdd_MouseDown);
            this.pictAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictAdd_MouseUp);
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
            this.pictBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictAdd_MouseDown);
            this.pictBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictAdd_MouseUp);
            // 
            // edtProductTitle
            // 
            this.edtProductTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtProductTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.edtProductTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.edtProductTitle.Location = new System.Drawing.Point(22, 3);
            this.edtProductTitle.Name = "edtProductTitle";
            this.edtProductTitle.Size = new System.Drawing.Size(126, 19);
            this.edtProductTitle.TabIndex = 17;
            this.edtProductTitle.TextChanged += new System.EventHandler(this.edtProductTitle_TextChanged);
            this.edtProductTitle.GotFocus += new System.EventHandler(this.edtProductTitle_GotFocus);
            this.edtProductTitle.LostFocus += new System.EventHandler(this.edtProductTitle_LostFocus);
            // 
            // dgPrice
            // 
            this.dgPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPrice.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgPrice.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.dgPrice.Location = new System.Drawing.Point(-2, 50);
            this.dgPrice.Name = "dgPrice";
            this.dgPrice.RowHeadersVisible = false;
            this.dgPrice.Size = new System.Drawing.Size(243, 219);
            this.dgPrice.TabIndex = 6;
            this.dgPrice.DoubleClick += new System.EventHandler(this.dgPrice_DoubleClick);
            this.dgPrice.CurrentCellChanged += new System.EventHandler(this.dgPrice_CurrentCellChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.lblProduct);
            this.panel1.Controls.Add(this.lblPrices);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 48);
            // 
            // lblProduct
            // 
            this.lblProduct.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblProduct.Location = new System.Drawing.Point(3, 5);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(236, 14);
            this.lblProduct.Text = "Товар:";
            // 
            // lblPrices
            // 
            this.lblPrices.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblPrices.Location = new System.Drawing.Point(3, 19);
            this.lblPrices.Name = "lblPrices";
            this.lblPrices.Size = new System.Drawing.Size(236, 14);
            this.lblPrices.Text = "Цены:";
            // 
            // pnlProductsFilter
            // 
            this.pnlProductsFilter.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pnlProductsFilter.Controls.Add(this.chkbShowFullPrice);
            this.pnlProductsFilter.Controls.Add(this.cmbFilter);
            this.pnlProductsFilter.Controls.Add(this.rbnView);
            this.pnlProductsFilter.Controls.Add(this.rbnType);
            this.pnlProductsFilter.Controls.Add(this.rbnGroup);
            this.pnlProductsFilter.Location = new System.Drawing.Point(0, 1);
            this.pnlProductsFilter.Name = "pnlProductsFilter";
            this.pnlProductsFilter.Size = new System.Drawing.Size(240, 48);
            this.pnlProductsFilter.Visible = false;
            // 
            // chkbShowFullPrice
            // 
            this.chkbShowFullPrice.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkbShowFullPrice.Location = new System.Drawing.Point(138, 22);
            this.chkbShowFullPrice.Name = "chkbShowFullPrice";
            this.chkbShowFullPrice.Size = new System.Drawing.Size(99, 20);
            this.chkbShowFullPrice.TabIndex = 4;
            this.chkbShowFullPrice.Text = "Весь прайс";
            this.chkbShowFullPrice.Visible = false;
            this.chkbShowFullPrice.CheckStateChanged += new System.EventHandler(this.chkbShowFullPrice_CheckStateChanged);
            // 
            // cmbFilter
            // 
            this.cmbFilter.Location = new System.Drawing.Point(3, 23);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(129, 22);
            this.cmbFilter.TabIndex = 3;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // rbnView
            // 
            this.rbnView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rbnView.Location = new System.Drawing.Point(162, 2);
            this.rbnView.Name = "rbnView";
            this.rbnView.Size = new System.Drawing.Size(60, 20);
            this.rbnView.TabIndex = 2;
            this.rbnView.Text = "Вид";
            this.rbnView.CheckedChanged += new System.EventHandler(this.rbn_FilterCheckedChanged);
            // 
            // rbnType
            // 
            this.rbnType.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rbnType.Location = new System.Drawing.Point(88, 2);
            this.rbnType.Name = "rbnType";
            this.rbnType.Size = new System.Drawing.Size(60, 20);
            this.rbnType.TabIndex = 1;
            this.rbnType.Text = "Тип";
            this.rbnType.CheckedChanged += new System.EventHandler(this.rbn_FilterCheckedChanged);
            // 
            // rbnGroup
            // 
            this.rbnGroup.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.rbnGroup.Location = new System.Drawing.Point(3, 2);
            this.rbnGroup.Name = "rbnGroup";
            this.rbnGroup.Size = new System.Drawing.Size(68, 20);
            this.rbnGroup.TabIndex = 0;
            this.rbnGroup.Text = "Группа";
            this.rbnGroup.CheckedChanged += new System.EventHandler(this.rbn_FilterCheckedChanged);
            // 
            // frmPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.pnlProductsFilter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgPrice);
            this.Controls.Add(this.pnlToolBar);
            this.Name = "frmPrice";
            this.Text = "Прайс";
            this.Load += new System.EventHandler(this.frmPrice_Load);
            this.pnlToolBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlProductsFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolBar;
        private System.Windows.Forms.PictureBox pictAdd;
        private System.Windows.Forms.PictureBox pictBack;
        private System.Windows.Forms.TextBox edtProductTitle;
        private System.Windows.Forms.DataGrid dgPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPrices;
        private System.Windows.Forms.PictureBox pictFilters;
        private System.Windows.Forms.Panel pnlProductsFilter;
        private System.Windows.Forms.CheckBox chkbShowFullPrice;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.RadioButton rbnView;
        private System.Windows.Forms.RadioButton rbnType;
        private System.Windows.Forms.RadioButton rbnGroup;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.PictureBox pBoxKeyBoard;
    }
}