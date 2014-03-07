namespace ConsumedOrders
{
    partial class frmCheques
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheques));
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStores = new System.Windows.Forms.ComboBox();
            this.txbSumm = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.listViewClients = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxKeyBoard = new System.Windows.Forms.PictureBox();
            this.pBoxPrint = new System.Windows.Forms.PictureBox();
            this.pBoxClear = new System.Windows.Forms.PictureBox();
            this.pBoxDelete = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource2"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource3"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource4"))));
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.Location = new System.Drawing.Point(55, 3);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(182, 22);
            this.cmbCustomers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.Text = "Клиент:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.Text = "Склад:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.Text = "Сумма:";
            // 
            // cmbStores
            // 
            this.cmbStores.Location = new System.Drawing.Point(55, 30);
            this.cmbStores.Name = "cmbStores";
            this.cmbStores.Size = new System.Drawing.Size(182, 22);
            this.cmbStores.TabIndex = 8;
            // 
            // txbSumm
            // 
            this.txbSumm.Location = new System.Drawing.Point(55, 56);
            this.txbSumm.Name = "txbSumm";
            this.txbSumm.Size = new System.Drawing.Size(100, 21);
            this.txbSumm.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(164, 57);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 20);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listViewClients
            // 
            this.listViewClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewClients.Columns.Add(this.columnHeader1);
            this.listViewClients.Columns.Add(this.columnHeader2);
            this.listViewClients.FullRowSelect = true;
            this.listViewClients.Location = new System.Drawing.Point(1, 82);
            this.listViewClients.Name = "listViewClients";
            this.listViewClients.Size = new System.Drawing.Size(237, 171);
            this.listViewClients.TabIndex = 11;
            this.listViewClients.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Клиент";
            this.columnHeader1.Width = 145;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Сумма";
            this.columnHeader2.Width = 76;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxKeyBoard);
            this.panel4.Controls.Add(this.pBoxPrint);
            this.panel4.Controls.Add(this.pBoxClear);
            this.panel4.Controls.Add(this.pBoxDelete);
            this.panel4.Controls.Add(this.pBoxBack);
            this.panel4.Location = new System.Drawing.Point(0, 271);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
            // 
            // pBoxKeyBoard
            // 
            this.pBoxKeyBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBoxKeyBoard.Location = new System.Drawing.Point(216, 1);
            this.pBoxKeyBoard.Name = "pBoxKeyBoard";
            this.pBoxKeyBoard.Size = new System.Drawing.Size(20, 20);
            this.pBoxKeyBoard.Click += new System.EventHandler(this.pBoxKeyBoard_Click);
            this.pBoxKeyBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxKeyBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxPrint
            // 
            this.pBoxPrint.Location = new System.Drawing.Point(69, 2);
            this.pBoxPrint.Name = "pBoxPrint";
            this.pBoxPrint.Size = new System.Drawing.Size(20, 20);
            this.pBoxPrint.Click += new System.EventHandler(this.pBoxPrint_Click);
            this.pBoxPrint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxPrint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxClear
            // 
            this.pBoxClear.Location = new System.Drawing.Point(47, 2);
            this.pBoxClear.Name = "pBoxClear";
            this.pBoxClear.Size = new System.Drawing.Size(20, 20);
            this.pBoxClear.Click += new System.EventHandler(this.pBoxClear_Click);
            this.pBoxClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxDelete
            // 
            this.pBoxDelete.Location = new System.Drawing.Point(25, 2);
            this.pBoxDelete.Name = "pBoxDelete";
            this.pBoxDelete.Size = new System.Drawing.Size(20, 20);
            this.pBoxDelete.Click += new System.EventHandler(this.pBoxDelete_Click);
            this.pBoxDelete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxDelete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
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
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStatus.Location = new System.Drawing.Point(0, 256);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(236, 13);
            this.lblStatus.Text = "Статус:";
            // 
            // frmCheques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.listViewClients);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txbSumm);
            this.Controls.Add(this.cmbStores);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCustomers);
            this.Name = "frmCheques";
            this.Text = "Перфокарта";
            this.Load += new System.EventHandler(this.frmCheques_Load);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStores;
        private System.Windows.Forms.TextBox txbSumm;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView listViewClients;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxDelete;
        private System.Windows.Forms.PictureBox pBoxBack;
        private System.Windows.Forms.PictureBox pBoxPrint;
        private System.Windows.Forms.PictureBox pBoxClear;
        private System.Windows.Forms.PictureBox pBoxKeyBoard;
        private System.Windows.Forms.Label lblStatus;
    }
}