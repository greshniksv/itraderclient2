namespace iTrader.Client2
{
	partial class FrmAutoconfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoconfig));
            this.lstParams = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCaterogy = new System.Windows.Forms.ComboBox();
            this.imageList = new System.Windows.Forms.ImageList();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxAdd = new System.Windows.Forms.PictureBox();
            this.pBoxAccept = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstParams
            // 
            this.lstParams.Columns.Add(this.columnHeader1);
            this.lstParams.Columns.Add(this.columnHeader2);
            this.lstParams.Columns.Add(this.columnHeader3);
            this.lstParams.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lstParams.FullRowSelect = true;
            this.lstParams.Location = new System.Drawing.Point(3, 55);
            this.lstParams.Name = "lstParams";
            this.lstParams.Size = new System.Drawing.Size(234, 186);
            this.lstParams.TabIndex = 6;
            this.lstParams.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Параметр";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Значение";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Секция";
            this.columnHeader3.Width = 60;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 15);
            this.label1.Text = "Выберите категорию";
            // 
            // cbxCaterogy
            // 
            this.cbxCaterogy.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbxCaterogy.Location = new System.Drawing.Point(3, 29);
            this.cbxCaterogy.Name = "cbxCaterogy";
            this.cbxCaterogy.Size = new System.Drawing.Size(234, 20);
            this.cbxCaterogy.TabIndex = 5;
            this.cbxCaterogy.SelectedIndexChanged += new System.EventHandler(this.cbxCaterogy_SelectedIndexChanged);
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource2"))));
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(4, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 20);
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.Silver;
            this.lblProgress.Location = new System.Drawing.Point(4, 244);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(41, 20);
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxAdd);
            this.panel4.Controls.Add(this.pBoxAccept);
            this.panel4.Controls.Add(this.pBoxBack);
            this.panel4.Location = new System.Drawing.Point(0, 269);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
            // 
            // pBoxAdd
            // 
            this.pBoxAdd.Location = new System.Drawing.Point(48, 2);
            this.pBoxAdd.Name = "pBoxAdd";
            this.pBoxAdd.Size = new System.Drawing.Size(20, 20);
            this.pBoxAdd.Click += new System.EventHandler(this.pBoxAdd_Click);
            this.pBoxAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
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
            // FrmAutoconfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstParams);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCaterogy);
            this.Name = "FrmAutoconfig";
            this.Text = "Автоконфиг";
            this.Load += new System.EventHandler(this.FrmAutoconfig_Load);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lstParams;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCaterogy;
        private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxAdd;
        private System.Windows.Forms.PictureBox pBoxAccept;
        private System.Windows.Forms.PictureBox pBoxBack;
	}
}