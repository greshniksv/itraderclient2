namespace ConsumedOrders
{
    partial class frmBuysHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuysHistory));
            this.pictBack = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pBoxKeyBoard = new System.Windows.Forms.PictureBox();
            this.edtProductTitle = new System.Windows.Forms.TextBox();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.dgBuysHistory = new System.Windows.Forms.DataGrid();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.pnlProductInfo = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlProductInfo.SuspendLayout();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.pBoxKeyBoard);
            this.panel1.Controls.Add(this.pictBack);
            this.panel1.Controls.Add(this.edtProductTitle);
            this.panel1.Location = new System.Drawing.Point(0, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 25);
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
            // dateEnd
            // 
            this.dateEnd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.dateEnd.Location = new System.Drawing.Point(119, 20);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(119, 20);
            this.dateEnd.TabIndex = 26;
            this.dateEnd.ValueChanged += new System.EventHandler(this.dateEnd_ValueChanged);
            // 
            // dateStart
            // 
            this.dateStart.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.dateStart.Location = new System.Drawing.Point(2, 20);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(115, 20);
            this.dateStart.TabIndex = 25;
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
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
            this.lblProductInfo.Size = new System.Drawing.Size(234, 24);
            this.lblProductInfo.Text = "Напиток Ювента \"Чай зеленый с жасмином\" 0,5 /UA1.007.Х014340-06/";
            // 
            // dgBuysHistory
            // 
            this.dgBuysHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBuysHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgBuysHistory.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.dgBuysHistory.Location = new System.Drawing.Point(-2, 42);
            this.dgBuysHistory.Name = "dgBuysHistory";
            this.dgBuysHistory.RowHeadersVisible = false;
            this.dgBuysHistory.Size = new System.Drawing.Size(244, 226);
            this.dgBuysHistory.TabIndex = 24;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomer.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCustomer.Location = new System.Drawing.Point(3, 2);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(237, 15);
            this.lblCustomer.Text = "Customer";
            // 
            // pnlProductInfo
            // 
            this.pnlProductInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProductInfo.BackColor = System.Drawing.Color.Gray;
            this.pnlProductInfo.Controls.Add(this.lblProductInfo);
            this.pnlProductInfo.Location = new System.Drawing.Point(2, 42);
            this.pnlProductInfo.Name = "pnlProductInfo";
            this.pnlProductInfo.Size = new System.Drawing.Size(236, 26);
            // 
            // frmBuysHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.dgBuysHistory);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.pnlProductInfo);
            this.Name = "frmBuysHistory";
            this.Text = "История покупок";
            this.Load += new System.EventHandler(this.frmBuysHistory_Load);
            this.panel1.ResumeLayout(false);
            this.pnlProductInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox edtProductTitle;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.DataGrid dgBuysHistory;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Panel pnlProductInfo;
        private System.Windows.Forms.PictureBox pBoxKeyBoard;
    }
}