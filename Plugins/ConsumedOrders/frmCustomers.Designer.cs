namespace ConsumedOrders
{
    partial class frmCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomers));
            this.imageList = new System.Windows.Forms.ImageList();
            this.dgCustomers = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pBoxBuyHistory = new System.Windows.Forms.PictureBox();
            this.pBoxDiscount = new System.Windows.Forms.PictureBox();
            this.pBoxAccept = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.pBoxKeyBoard = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource2"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource3"))));
            // 
            // dgCustomers
            // 
            this.dgCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCustomers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgCustomers.Location = new System.Drawing.Point(0, 29);
            this.dgCustomers.Name = "dgCustomers";
            this.dgCustomers.RowHeadersVisible = false;
            this.dgCustomers.Size = new System.Drawing.Size(240, 240);
            this.dgCustomers.TabIndex = 2;
            this.dgCustomers.DoubleClick += new System.EventHandler(this.dgCustomers_DoubleClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.Text = "Быстрый поиск:";
            // 
            // txbSearch
            // 
            this.txbSearch.Location = new System.Drawing.Point(106, 5);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(131, 21);
            this.txbSearch.TabIndex = 4;
            this.txbSearch.TextChanged += new System.EventHandler(this.txbSearch_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.pBoxKeyBoard);
            this.panel1.Controls.Add(this.pBoxBuyHistory);
            this.panel1.Controls.Add(this.pBoxDiscount);
            this.panel1.Controls.Add(this.pBoxAccept);
            this.panel1.Controls.Add(this.pBoxBack);
            this.panel1.Location = new System.Drawing.Point(0, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 24);
            // 
            // pBoxBuyHistory
            // 
            this.pBoxBuyHistory.Location = new System.Drawing.Point(69, 2);
            this.pBoxBuyHistory.Name = "pBoxBuyHistory";
            this.pBoxBuyHistory.Size = new System.Drawing.Size(20, 20);
            this.pBoxBuyHistory.Click += new System.EventHandler(this.pBoxBuyHistory_Click);
            this.pBoxBuyHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxBuyHistory.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxDiscount
            // 
            this.pBoxDiscount.Location = new System.Drawing.Point(47, 2);
            this.pBoxDiscount.Name = "pBoxDiscount";
            this.pBoxDiscount.Size = new System.Drawing.Size(20, 20);
            this.pBoxDiscount.Click += new System.EventHandler(this.pBoxDiscount_Click);
            this.pBoxDiscount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxDiscount.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxAccept
            // 
            this.pBoxAccept.Location = new System.Drawing.Point(25, 2);
            this.pBoxAccept.Name = "pBoxAccept";
            this.pBoxAccept.Size = new System.Drawing.Size(20, 20);
            this.pBoxAccept.Click += new System.EventHandler(this.pBoxAccept_Click);
            this.pBoxAccept.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxAccept.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
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
            // pBoxKeyBoard
            // 
            this.pBoxKeyBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBoxKeyBoard.Location = new System.Drawing.Point(217, 2);
            this.pBoxKeyBoard.Name = "pBoxKeyBoard";
            this.pBoxKeyBoard.Size = new System.Drawing.Size(20, 20);
            this.pBoxKeyBoard.Click += new System.EventHandler(this.pBoxKeyBoard_Click);
            this.pBoxKeyBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxKeyBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txbSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgCustomers);
            this.Name = "frmCustomers";
            this.Text = "Клиенты";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGrid dgCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pBoxBuyHistory;
        private System.Windows.Forms.PictureBox pBoxDiscount;
        private System.Windows.Forms.PictureBox pBoxAccept;
        private System.Windows.Forms.PictureBox pBoxBack;
        private System.Windows.Forms.PictureBox pBoxKeyBoard;
    }
}