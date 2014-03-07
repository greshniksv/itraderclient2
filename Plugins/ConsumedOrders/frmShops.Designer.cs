namespace ConsumedOrders
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
            this.imageList = new System.Windows.Forms.ImageList();
            this.dgShops = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pBoxAccept = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            // 
            // dgShops
            // 
            this.dgShops.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgShops.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgShops.Location = new System.Drawing.Point(0, 29);
            this.dgShops.Name = "dgShops";
            this.dgShops.RowHeadersVisible = false;
            this.dgShops.Size = new System.Drawing.Size(244, 240);
            this.dgShops.TabIndex = 4;
            this.dgShops.DoubleClick += new System.EventHandler(this.dgShops_DoubleClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Клиент:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.pBoxAccept);
            this.panel1.Controls.Add(this.pBoxBack);
            this.panel1.Location = new System.Drawing.Point(0, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 24);
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
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgShops);
            this.Name = "frmShops";
            this.Text = "Магазины";
            this.Load += new System.EventHandler(this.frmShops_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGrid dgShops;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pBoxAccept;
        private System.Windows.Forms.PictureBox pBoxBack;
    }
}