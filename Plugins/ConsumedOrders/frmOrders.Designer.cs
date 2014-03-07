namespace ConsumedOrders
{
    partial class frmOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrders));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPrickerBegin = new System.Windows.Forms.DateTimePicker();
            this.dtPickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dgOrders = new System.Windows.Forms.DataGrid();
            this.imageList = new System.Windows.Forms.ImageList();
            this.lblOrdersCount = new System.Windows.Forms.Label();
            this.lblEmptyOrdersCount = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxDelete = new System.Windows.Forms.PictureBox();
            this.pBoxCopy = new System.Windows.Forms.PictureBox();
            this.pBoxEdit = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.Text = "С даты:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(121, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.Text = "По дату:";
            // 
            // dtPrickerBegin
            // 
            this.dtPrickerBegin.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.dtPrickerBegin.Location = new System.Drawing.Point(3, 22);
            this.dtPrickerBegin.Name = "dtPrickerBegin";
            this.dtPrickerBegin.Size = new System.Drawing.Size(112, 20);
            this.dtPrickerBegin.TabIndex = 3;
            this.dtPrickerBegin.ValueChanged += new System.EventHandler(this.dtPrickerBegin_ValueChanged);
            // 
            // dtPickerEnd
            // 
            this.dtPickerEnd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.dtPickerEnd.Location = new System.Drawing.Point(121, 22);
            this.dtPickerEnd.Name = "dtPickerEnd";
            this.dtPickerEnd.Size = new System.Drawing.Size(116, 20);
            this.dtPickerEnd.TabIndex = 6;
            this.dtPickerEnd.ValueChanged += new System.EventHandler(this.dtPickerEnd_ValueChanged);
            // 
            // dgOrders
            // 
            this.dgOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOrders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgOrders.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.dgOrders.Location = new System.Drawing.Point(-2, 45);
            this.dgOrders.Name = "dgOrders";
            this.dgOrders.RowHeadersVisible = false;
            this.dgOrders.Size = new System.Drawing.Size(242, 209);
            this.dgOrders.TabIndex = 7;
            this.dgOrders.DoubleClick += new System.EventHandler(this.dgOrders_DoubleClick);
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource2"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource3"))));
            // 
            // lblOrdersCount
            // 
            this.lblOrdersCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrdersCount.BackColor = System.Drawing.SystemColors.Info;
            this.lblOrdersCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblOrdersCount.Location = new System.Drawing.Point(62, 255);
            this.lblOrdersCount.Name = "lblOrdersCount";
            this.lblOrdersCount.Size = new System.Drawing.Size(177, 16);
            this.lblOrdersCount.Text = "Всего:";
            this.lblOrdersCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblEmptyOrdersCount
            // 
            this.lblEmptyOrdersCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmptyOrdersCount.BackColor = System.Drawing.SystemColors.Info;
            this.lblEmptyOrdersCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblEmptyOrdersCount.Location = new System.Drawing.Point(1, 255);
            this.lblEmptyOrdersCount.Name = "lblEmptyOrdersCount";
            this.lblEmptyOrdersCount.Size = new System.Drawing.Size(62, 16);
            this.lblEmptyOrdersCount.Text = "Пустых:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxDelete);
            this.panel4.Controls.Add(this.pBoxCopy);
            this.panel4.Controls.Add(this.pBoxEdit);
            this.panel4.Controls.Add(this.pBoxBack);
            this.panel4.Location = new System.Drawing.Point(0, 272);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
            // 
            // pBoxDelete
            // 
            this.pBoxDelete.Location = new System.Drawing.Point(69, 2);
            this.pBoxDelete.Name = "pBoxDelete";
            this.pBoxDelete.Size = new System.Drawing.Size(20, 20);
            this.pBoxDelete.Click += new System.EventHandler(this.pBoxDelete_Click);
            this.pBoxDelete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxCopy
            // 
            this.pBoxCopy.Location = new System.Drawing.Point(47, 2);
            this.pBoxCopy.Name = "pBoxCopy";
            this.pBoxCopy.Size = new System.Drawing.Size(20, 20);
            this.pBoxCopy.Click += new System.EventHandler(this.pBoxCopy_Click);
            this.pBoxCopy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxCopy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxEdit
            // 
            this.pBoxEdit.Location = new System.Drawing.Point(25, 2);
            this.pBoxEdit.Name = "pBoxEdit";
            this.pBoxEdit.Size = new System.Drawing.Size(20, 20);
            this.pBoxEdit.Click += new System.EventHandler(this.pBoxEdit_Click);
            this.pBoxEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
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
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblEmptyOrdersCount);
            this.Controls.Add(this.lblOrdersCount);
            this.Controls.Add(this.dgOrders);
            this.Controls.Add(this.dtPickerEnd);
            this.Controls.Add(this.dtPrickerBegin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmOrders";
            this.Text = "Накладные";
            this.Load += new System.EventHandler(this.frmOrders_Load);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPrickerBegin;
        private System.Windows.Forms.DateTimePicker dtPickerEnd;
        private System.Windows.Forms.DataGrid dgOrders;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblOrdersCount;
        private System.Windows.Forms.Label lblEmptyOrdersCount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxEdit;
        private System.Windows.Forms.PictureBox pBoxBack;
        private System.Windows.Forms.PictureBox pBoxDelete;
        private System.Windows.Forms.PictureBox pBoxCopy;
    }
}