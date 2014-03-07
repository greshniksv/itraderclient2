namespace ConsumedOrders
{
    partial class frmOrderDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderDetails));
            this.imageList = new System.Windows.Forms.ImageList();
            this.dgOrderDetails = new System.Windows.Forms.DataGrid();
            this.lblOrderCaption = new System.Windows.Forms.LinkLabel();
            this.cmbStores = new System.Windows.Forms.ComboBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.KOCheck = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOfficial = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.pnlComment = new System.Windows.Forms.Panel();
            this.btnChangeComment = new System.Windows.Forms.Button();
            this.btnCancelComment = new System.Windows.Forms.Button();
            this.txbComment = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pBoxKeyBoard = new System.Windows.Forms.PictureBox();
            this.pBoxDebit = new System.Windows.Forms.PictureBox();
            this.pBoxChangeComment = new System.Windows.Forms.PictureBox();
            this.pBoxChangeShop = new System.Windows.Forms.PictureBox();
            this.pBoxBuyHistory = new System.Windows.Forms.PictureBox();
            this.pBoxDiscounts = new System.Windows.Forms.PictureBox();
            this.pBoxDeleteItem = new System.Windows.Forms.PictureBox();
            this.pBoxEditItem = new System.Windows.Forms.PictureBox();
            this.pBoxAddItem = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.pnlDebit = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDebit = new System.Windows.Forms.TextBox();
            this.btnSetDept = new System.Windows.Forms.Button();
            this.lblSku = new System.Windows.Forms.Label();
            this.chkReturn = new System.Windows.Forms.CheckBox();
            this.pnlComment.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlDebit.SuspendLayout();
            this.SuspendLayout();
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource2"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource3"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource4"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource5"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource6"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource7"))));
            // 
            // dgOrderDetails
            // 
            this.dgOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOrderDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgOrderDetails.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.dgOrderDetails.Location = new System.Drawing.Point(-2, 44);
            this.dgOrderDetails.Name = "dgOrderDetails";
            this.dgOrderDetails.RowHeadersVisible = false;
            this.dgOrderDetails.Size = new System.Drawing.Size(244, 188);
            this.dgOrderDetails.TabIndex = 5;
            this.dgOrderDetails.DoubleClick += new System.EventHandler(this.dgOrderDetails_DoubleClick);
            // 
            // lblOrderCaption
            // 
            this.lblOrderCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrderCaption.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblOrderCaption.Location = new System.Drawing.Point(3, 27);
            this.lblOrderCaption.Name = "lblOrderCaption";
            this.lblOrderCaption.Size = new System.Drawing.Size(235, 14);
            this.lblOrderCaption.TabIndex = 37;
            this.lblOrderCaption.Text = "Customer (and Shop Title)";
            // 
            // cmbStores
            // 
            this.cmbStores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStores.Location = new System.Drawing.Point(115, 3);
            this.cmbStores.Name = "cmbStores";
            this.cmbStores.Size = new System.Drawing.Size(123, 22);
            this.cmbStores.TabIndex = 36;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.dtpOrderDate.Location = new System.Drawing.Point(2, 3);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(111, 20);
            this.dtpOrderDate.TabIndex = 35;
            // 
            // KOCheck
            // 
            this.KOCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.KOCheck.Enabled = false;
            this.KOCheck.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.KOCheck.Location = new System.Drawing.Point(57, 251);
            this.KOCheck.Name = "KOCheck";
            this.KOCheck.Size = new System.Drawing.Size(41, 19);
            this.KOCheck.TabIndex = 45;
            this.KOCheck.Text = "КО";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(144, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 15);
            // 
            // chkOfficial
            // 
            this.chkOfficial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOfficial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkOfficial.Location = new System.Drawing.Point(-1, 251);
            this.chkOfficial.Name = "chkOfficial";
            this.chkOfficial.Size = new System.Drawing.Size(59, 19);
            this.chkOfficial.TabIndex = 44;
            this.chkOfficial.Text = "Офиц.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(148, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.Text = "Сумма:";
            // 
            // lblCost
            // 
            this.lblCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCost.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCost.Location = new System.Drawing.Point(186, 253);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(51, 13);
            this.lblCost.Text = "0";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlComment
            // 
            this.pnlComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlComment.Controls.Add(this.btnChangeComment);
            this.pnlComment.Controls.Add(this.btnCancelComment);
            this.pnlComment.Controls.Add(this.txbComment);
            this.pnlComment.Location = new System.Drawing.Point(1, 156);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(238, 71);
            this.pnlComment.Visible = false;
            this.pnlComment.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlComment_MouseDown);
            // 
            // btnChangeComment
            // 
            this.btnChangeComment.Location = new System.Drawing.Point(123, 49);
            this.btnChangeComment.Name = "btnChangeComment";
            this.btnChangeComment.Size = new System.Drawing.Size(112, 20);
            this.btnChangeComment.TabIndex = 2;
            this.btnChangeComment.Text = "Изменить";
            this.btnChangeComment.Click += new System.EventHandler(this.btnChangeComment_Click);
            // 
            // btnCancelComment
            // 
            this.btnCancelComment.Location = new System.Drawing.Point(3, 49);
            this.btnCancelComment.Name = "btnCancelComment";
            this.btnCancelComment.Size = new System.Drawing.Size(113, 20);
            this.btnCancelComment.TabIndex = 1;
            this.btnCancelComment.Text = "Отмена";
            this.btnCancelComment.Click += new System.EventHandler(this.btnCancelComment_Click);
            // 
            // txbComment
            // 
            this.txbComment.Location = new System.Drawing.Point(3, 2);
            this.txbComment.Multiline = true;
            this.txbComment.Name = "txbComment";
            this.txbComment.Size = new System.Drawing.Size(233, 45);
            this.txbComment.TabIndex = 0;
            this.txbComment.GotFocus += new System.EventHandler(this.txbComment_GotFocus);
            this.txbComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbComment_KeyDown);
            this.txbComment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbComment_KeyPress);
            this.txbComment.LostFocus += new System.EventHandler(this.txbComment_LostFocus);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.pBoxKeyBoard);
            this.panel2.Controls.Add(this.pBoxDebit);
            this.panel2.Controls.Add(this.pBoxChangeComment);
            this.panel2.Controls.Add(this.pBoxChangeShop);
            this.panel2.Controls.Add(this.pBoxBuyHistory);
            this.panel2.Controls.Add(this.pBoxDiscounts);
            this.panel2.Controls.Add(this.pBoxDeleteItem);
            this.panel2.Controls.Add(this.pBoxEditItem);
            this.panel2.Controls.Add(this.pBoxAddItem);
            this.panel2.Controls.Add(this.pBoxBack);
            this.panel2.Location = new System.Drawing.Point(0, 272);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 24);
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
            // pBoxDebit
            // 
            this.pBoxDebit.Location = new System.Drawing.Point(179, 2);
            this.pBoxDebit.Name = "pBoxDebit";
            this.pBoxDebit.Size = new System.Drawing.Size(20, 20);
            this.pBoxDebit.Click += new System.EventHandler(this.pBoxDebit_Click);
            this.pBoxDebit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxDebit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxChangeComment
            // 
            this.pBoxChangeComment.Location = new System.Drawing.Point(156, 2);
            this.pBoxChangeComment.Name = "pBoxChangeComment";
            this.pBoxChangeComment.Size = new System.Drawing.Size(20, 20);
            this.pBoxChangeComment.Click += new System.EventHandler(this.pBoxChangeComment_Click);
            this.pBoxChangeComment.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxChangeComment.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxChangeShop
            // 
            this.pBoxChangeShop.Location = new System.Drawing.Point(134, 2);
            this.pBoxChangeShop.Name = "pBoxChangeShop";
            this.pBoxChangeShop.Size = new System.Drawing.Size(20, 20);
            this.pBoxChangeShop.Click += new System.EventHandler(this.pBoxChangeShop_Click);
            this.pBoxChangeShop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxChangeShop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxBuyHistory
            // 
            this.pBoxBuyHistory.Location = new System.Drawing.Point(112, 2);
            this.pBoxBuyHistory.Name = "pBoxBuyHistory";
            this.pBoxBuyHistory.Size = new System.Drawing.Size(20, 20);
            this.pBoxBuyHistory.Click += new System.EventHandler(this.pBoxBuyHistory_Click);
            this.pBoxBuyHistory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxBuyHistory.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxDiscounts
            // 
            this.pBoxDiscounts.Location = new System.Drawing.Point(91, 2);
            this.pBoxDiscounts.Name = "pBoxDiscounts";
            this.pBoxDiscounts.Size = new System.Drawing.Size(20, 20);
            this.pBoxDiscounts.Click += new System.EventHandler(this.pBoxDiscount_Click);
            this.pBoxDiscounts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxDiscounts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxDeleteItem
            // 
            this.pBoxDeleteItem.Location = new System.Drawing.Point(69, 2);
            this.pBoxDeleteItem.Name = "pBoxDeleteItem";
            this.pBoxDeleteItem.Size = new System.Drawing.Size(20, 20);
            this.pBoxDeleteItem.Click += new System.EventHandler(this.pBoxDeleteItem_Click);
            this.pBoxDeleteItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxDeleteItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxEditItem
            // 
            this.pBoxEditItem.Location = new System.Drawing.Point(47, 2);
            this.pBoxEditItem.Name = "pBoxEditItem";
            this.pBoxEditItem.Size = new System.Drawing.Size(20, 20);
            this.pBoxEditItem.Click += new System.EventHandler(this.pBoxEditItem_Click);
            this.pBoxEditItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxEditItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
            // 
            // pBoxAddItem
            // 
            this.pBoxAddItem.Location = new System.Drawing.Point(25, 2);
            this.pBoxAddItem.Name = "pBoxAddItem";
            this.pBoxAddItem.Size = new System.Drawing.Size(20, 20);
            this.pBoxAddItem.Click += new System.EventHandler(this.pBoxAddItem_Click);
            this.pBoxAddItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxAddItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
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
            // pnlDebit
            // 
            this.pnlDebit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDebit.Controls.Add(this.label1);
            this.pnlDebit.Controls.Add(this.txbDebit);
            this.pnlDebit.Controls.Add(this.btnSetDept);
            this.pnlDebit.Location = new System.Drawing.Point(0, 192);
            this.pnlDebit.Name = "pnlDebit";
            this.pnlDebit.Size = new System.Drawing.Size(240, 39);
            this.pnlDebit.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.Text = "Инкасация дебита:";
            // 
            // txbDebit
            // 
            this.txbDebit.Location = new System.Drawing.Point(3, 16);
            this.txbDebit.Name = "txbDebit";
            this.txbDebit.Size = new System.Drawing.Size(154, 21);
            this.txbDebit.TabIndex = 1;
            this.txbDebit.GotFocus += new System.EventHandler(this.txbComment_GotFocus);
            this.txbDebit.LostFocus += new System.EventHandler(this.txbComment_LostFocus);
            // 
            // btnSetDept
            // 
            this.btnSetDept.Location = new System.Drawing.Point(158, 16);
            this.btnSetDept.Name = "btnSetDept";
            this.btnSetDept.Size = new System.Drawing.Size(80, 21);
            this.btnSetDept.TabIndex = 0;
            this.btnSetDept.Text = "Задать";
            this.btnSetDept.Click += new System.EventHandler(this.btnSetDept_Click);
            // 
            // lblSku
            // 
            this.lblSku.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSku.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSku.Location = new System.Drawing.Point(3, 236);
            this.lblSku.Name = "lblSku";
            this.lblSku.Size = new System.Drawing.Size(233, 16);
            this.lblSku.Text = "СКЮ: Пиво=0 БАН=0 САН=0 МВ=0";
            // 
            // chkReturn
            // 
            this.chkReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkReturn.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkReturn.Location = new System.Drawing.Point(97, 251);
            this.chkReturn.Name = "chkReturn";
            this.chkReturn.Size = new System.Drawing.Size(44, 19);
            this.chkReturn.TabIndex = 49;
            this.chkReturn.Text = "Взт";
            // 
            // frmOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.chkReturn);
            this.Controls.Add(this.lblSku);
            this.Controls.Add(this.pnlDebit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlComment);
            this.Controls.Add(this.KOCheck);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkOfficial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblOrderCaption);
            this.Controls.Add(this.cmbStores);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.dgOrderDetails);
            this.Name = "frmOrderDetails";
            this.Text = "Накладная";
            this.Load += new System.EventHandler(this.frmOrderDetails_Load);
            this.pnlComment.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlDebit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGrid dgOrderDetails;
        private System.Windows.Forms.LinkLabel lblOrderCaption;
        private System.Windows.Forms.ComboBox cmbStores;
        public System.Windows.Forms.DateTimePicker dtpOrderDate;
        public System.Windows.Forms.CheckBox KOCheck;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.CheckBox chkOfficial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Panel pnlComment;
        private System.Windows.Forms.Button btnChangeComment;
        private System.Windows.Forms.Button btnCancelComment;
        private System.Windows.Forms.TextBox txbComment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pBoxAddItem;
        private System.Windows.Forms.PictureBox pBoxBack;
        private System.Windows.Forms.PictureBox pBoxChangeComment;
        private System.Windows.Forms.PictureBox pBoxChangeShop;
        private System.Windows.Forms.PictureBox pBoxBuyHistory;
        private System.Windows.Forms.PictureBox pBoxDiscounts;
        private System.Windows.Forms.PictureBox pBoxDeleteItem;
        private System.Windows.Forms.PictureBox pBoxEditItem;
        private System.Windows.Forms.Panel pnlDebit;
        private System.Windows.Forms.TextBox txbDebit;
        private System.Windows.Forms.Button btnSetDept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pBoxDebit;
        private System.Windows.Forms.PictureBox pBoxKeyBoard;
        private System.Windows.Forms.Label lblSku;
        public System.Windows.Forms.CheckBox chkReturn;
    }
}