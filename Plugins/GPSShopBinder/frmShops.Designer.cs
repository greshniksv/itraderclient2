namespace GPSShopBinder
{
	partial class frmShops
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShops));
            this.lblDisState = new System.Windows.Forms.Label();
            this.pbIndicator = new System.Windows.Forms.PictureBox();
            this.pgSatelitesActive = new System.Windows.Forms.ProgressBar();
            this.pnlMoreInfo = new System.Windows.Forms.Panel();
            this.ilblCloseInformPanel = new System.Windows.Forms.LinkLabel();
            this.lblBauds = new System.Windows.Forms.Label();
            this.lblCommState = new System.Windows.Forms.Label();
            this.lblGPSSentence = new System.Windows.Forms.Label();
            this.lblSatelites = new System.Windows.Forms.Label();
            this.lblFixation = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblShopLongitude = new System.Windows.Forms.Label();
            this.lblShopLatitude = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrLongitude = new System.Windows.Forms.Label();
            this.lblCurrLatitude = new System.Windows.Forms.Label();
            this.dgShops = new System.Windows.Forms.DataGrid();
            this.imgIconList = new System.Windows.Forms.ImageList();
            this.timUpdate = new System.Windows.Forms.Timer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxMoreInfo = new System.Windows.Forms.PictureBox();
            this.pBoxAccept = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.pnlMoreInfo.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDisState
            // 
            this.lblDisState.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblDisState.Location = new System.Drawing.Point(75, 16);
            this.lblDisState.Name = "lblDisState";
            this.lblDisState.Size = new System.Drawing.Size(158, 10);
            this.lblDisState.Text = "DisState:";
            // 
            // pbIndicator
            // 
            this.pbIndicator.Image = ((System.Drawing.Image)(resources.GetObject("pbIndicator.Image")));
            this.pbIndicator.Location = new System.Drawing.Point(221, 228);
            this.pbIndicator.Name = "pbIndicator";
            this.pbIndicator.Size = new System.Drawing.Size(17, 17);
            this.pbIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pgSatelitesActive
            // 
            this.pgSatelitesActive.Location = new System.Drawing.Point(74, 4);
            this.pgSatelitesActive.Name = "pgSatelitesActive";
            this.pgSatelitesActive.Size = new System.Drawing.Size(163, 11);
            // 
            // pnlMoreInfo
            // 
            this.pnlMoreInfo.BackColor = System.Drawing.Color.DarkGray;
            this.pnlMoreInfo.Controls.Add(this.lblDisState);
            this.pnlMoreInfo.Controls.Add(this.pgSatelitesActive);
            this.pnlMoreInfo.Controls.Add(this.ilblCloseInformPanel);
            this.pnlMoreInfo.Controls.Add(this.lblBauds);
            this.pnlMoreInfo.Controls.Add(this.lblCommState);
            this.pnlMoreInfo.Controls.Add(this.lblGPSSentence);
            this.pnlMoreInfo.Controls.Add(this.lblSatelites);
            this.pnlMoreInfo.Location = new System.Drawing.Point(0, 160);
            this.pnlMoreInfo.Name = "pnlMoreInfo";
            this.pnlMoreInfo.Size = new System.Drawing.Size(240, 54);
            this.pnlMoreInfo.Visible = false;
            // 
            // ilblCloseInformPanel
            // 
            this.ilblCloseInformPanel.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Underline);
            this.ilblCloseInformPanel.Location = new System.Drawing.Point(194, 38);
            this.ilblCloseInformPanel.Name = "ilblCloseInformPanel";
            this.ilblCloseInformPanel.Size = new System.Drawing.Size(45, 12);
            this.ilblCloseInformPanel.TabIndex = 5;
            this.ilblCloseInformPanel.Text = "Закрыть";
            this.ilblCloseInformPanel.Click += new System.EventHandler(this.ilblCloseInformPanel_Click);
            // 
            // lblBauds
            // 
            this.lblBauds.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblBauds.Location = new System.Drawing.Point(75, 28);
            this.lblBauds.Name = "lblBauds";
            this.lblBauds.Size = new System.Drawing.Size(158, 10);
            this.lblBauds.Text = "Bauds:";
            // 
            // lblCommState
            // 
            this.lblCommState.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCommState.Location = new System.Drawing.Point(3, 40);
            this.lblCommState.Name = "lblCommState";
            this.lblCommState.Size = new System.Drawing.Size(180, 10);
            this.lblCommState.Text = "CState:";
            // 
            // lblGPSSentence
            // 
            this.lblGPSSentence.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblGPSSentence.Location = new System.Drawing.Point(3, 3);
            this.lblGPSSentence.Name = "lblGPSSentence";
            this.lblGPSSentence.Size = new System.Drawing.Size(65, 24);
            this.lblGPSSentence.Text = "Sentence:";
            // 
            // lblSatelites
            // 
            this.lblSatelites.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblSatelites.Location = new System.Drawing.Point(3, 28);
            this.lblSatelites.Name = "lblSatelites";
            this.lblSatelites.Size = new System.Drawing.Size(63, 11);
            this.lblSatelites.Text = "Satelites: 0/0";
            // 
            // lblFixation
            // 
            this.lblFixation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFixation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblFixation.Location = new System.Drawing.Point(174, 221);
            this.lblFixation.Name = "lblFixation";
            this.lblFixation.Size = new System.Drawing.Size(59, 16);
            this.lblFixation.Text = "---";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(113, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.Text = "Фиксация:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Location = new System.Drawing.Point(-2, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 1);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(16, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.Text = "Широта:";
            // 
            // lblShopLongitude
            // 
            this.lblShopLongitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShopLongitude.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblShopLongitude.Location = new System.Drawing.Point(74, 195);
            this.lblShopLongitude.Name = "lblShopLongitude";
            this.lblShopLongitude.Size = new System.Drawing.Size(159, 16);
            this.lblShopLongitude.Text = "---";
            // 
            // lblShopLatitude
            // 
            this.lblShopLatitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShopLatitude.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblShopLatitude.Location = new System.Drawing.Point(74, 179);
            this.lblShopLatitude.Name = "lblShopLatitude";
            this.lblShopLatitude.Size = new System.Drawing.Size(159, 16);
            this.lblShopLatitude.Text = "---";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(16, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.Text = "Долгота:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(5, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 16);
            this.label5.Text = "Координаты выбранного магазина:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(16, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.Text = "Долгота:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(16, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.Text = "Широта:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCustomerName.Location = new System.Drawing.Point(61, 6);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(172, 14);
            this.lblCustomerName.Text = "----";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(5, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.Text = "Тек. координаты:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.Text = "Клиент:";
            // 
            // lblCurrLongitude
            // 
            this.lblCurrLongitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrLongitude.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCurrLongitude.Location = new System.Drawing.Point(74, 254);
            this.lblCurrLongitude.Name = "lblCurrLongitude";
            this.lblCurrLongitude.Size = new System.Drawing.Size(145, 16);
            this.lblCurrLongitude.Text = "---";
            // 
            // lblCurrLatitude
            // 
            this.lblCurrLatitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrLatitude.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCurrLatitude.Location = new System.Drawing.Point(74, 238);
            this.lblCurrLatitude.Name = "lblCurrLatitude";
            this.lblCurrLatitude.Size = new System.Drawing.Size(159, 16);
            this.lblCurrLatitude.Text = "---";
            // 
            // dgShops
            // 
            this.dgShops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgShops.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgShops.Location = new System.Drawing.Point(-2, 25);
            this.dgShops.Name = "dgShops";
            this.dgShops.RowHeadersVisible = false;
            this.dgShops.Size = new System.Drawing.Size(244, 137);
            this.dgShops.TabIndex = 21;
            this.dgShops.CurrentCellChanged += new System.EventHandler(this.dgShops_CurrentCellChanged);
            this.imgIconList.Images.Clear();
            this.imgIconList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imgIconList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            this.imgIconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.imgIconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            this.imgIconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
            // 
            // timUpdate
            // 
            this.timUpdate.Enabled = true;
            this.timUpdate.Interval = 1000;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxMoreInfo);
            this.panel4.Controls.Add(this.pBoxAccept);
            this.panel4.Controls.Add(this.pBoxBack);
            this.panel4.Location = new System.Drawing.Point(0, 272);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
            // 
            // pBoxMoreInfo
            // 
            this.pBoxMoreInfo.Location = new System.Drawing.Point(47, 2);
            this.pBoxMoreInfo.Name = "pBoxMoreInfo";
            this.pBoxMoreInfo.Size = new System.Drawing.Size(20, 20);
            this.pBoxMoreInfo.Click += new System.EventHandler(this.pBoxMoreInfo_Click);
            this.pBoxMoreInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxMoreInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
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
            // frmShops
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pbIndicator);
            this.Controls.Add(this.pnlMoreInfo);
            this.Controls.Add(this.lblFixation);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblShopLongitude);
            this.Controls.Add(this.lblShopLatitude);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrLongitude);
            this.Controls.Add(this.lblCurrLatitude);
            this.Controls.Add(this.dgShops);
            this.Name = "frmShops";
            this.Text = "frmShops";
            this.Load += new System.EventHandler(this.frmShops_Load);
            this.Closed += new System.EventHandler(this.frmShops_Closed);
            this.pnlMoreInfo.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbIndicator;
		private System.Windows.Forms.Panel pnlMoreInfo;
		private System.Windows.Forms.LinkLabel ilblCloseInformPanel;
		public System.Windows.Forms.Label lblCommState;
		public System.Windows.Forms.Label lblGPSSentence;
		public System.Windows.Forms.Label lblSatelites;
		private System.Windows.Forms.Label lblFixation;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblShopLongitude;
		private System.Windows.Forms.Label lblShopLatitude;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerName;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrLongitude;
		private System.Windows.Forms.Label lblCurrLatitude;
		private System.Windows.Forms.DataGrid dgShops;
		public System.Windows.Forms.Label lblDisState;
		public System.Windows.Forms.Label lblBauds;
		public System.Windows.Forms.ProgressBar pgSatelitesActive;
		private System.Windows.Forms.ImageList imgIconList;
        private System.Windows.Forms.Timer timUpdate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxMoreInfo;
        private System.Windows.Forms.PictureBox pBoxAccept;
        private System.Windows.Forms.PictureBox pBoxBack;
	}
}