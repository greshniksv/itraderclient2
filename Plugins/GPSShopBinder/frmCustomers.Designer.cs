namespace GPSShopBinder
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
            this.edtCustomerName = new System.Windows.Forms.TextBox();
            this.updateTimer = new System.Windows.Forms.Timer();
            this.label1 = new System.Windows.Forms.Label();
            this.dgCustomers = new System.Windows.Forms.DataGrid();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxAccept = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            // 
            // edtCustomerName
            // 
            this.edtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtCustomerName.Location = new System.Drawing.Point(87, 3);
            this.edtCustomerName.Name = "edtCustomerName";
            this.edtCustomerName.Size = new System.Drawing.Size(150, 21);
            this.edtCustomerName.TabIndex = 9;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 4000;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.Text = "Быстрый поиск";
            // 
            // dgCustomers
            // 
            this.dgCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCustomers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgCustomers.Location = new System.Drawing.Point(3, 30);
            this.dgCustomers.Name = "dgCustomers";
            this.dgCustomers.RowHeadersVisible = false;
            this.dgCustomers.Size = new System.Drawing.Size(234, 261);
            this.dgCustomers.TabIndex = 11;
            this.dgCustomers.DoubleClick += new System.EventHandler(this.dgCustomers_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxAccept);
            this.panel4.Controls.Add(this.pBoxBack);
            this.panel4.Location = new System.Drawing.Point(-2, 272);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
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
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.dgCustomers);
            this.Controls.Add(this.edtCustomerName);
            this.Controls.Add(this.label1);
            this.Name = "frmCustomers";
            this.Text = "frmCustomers";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.TextBox edtCustomerName;
		private System.Windows.Forms.Timer updateTimer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dgCustomers;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxAccept;
        private System.Windows.Forms.PictureBox pBoxBack;
	}
}