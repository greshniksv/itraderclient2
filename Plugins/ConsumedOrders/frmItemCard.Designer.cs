namespace ConsumedOrders
{
    partial class frmItemCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemCard));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbtnClose = new System.Windows.Forms.ToolBarButton();
            this.tbtnOk = new System.Windows.Forms.ToolBarButton();
            this.tbtnDiscounts = new System.Windows.Forms.ToolBarButton();
            this.tbtnBuysHistory = new System.Windows.Forms.ToolBarButton();
            this.imageList = new System.Windows.Forms.ImageList();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.lblRemains = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numUpDownProductCount = new System.Windows.Forms.NumericUpDown();
            this.chkNoOrder = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblShop = new System.Windows.Forms.Label();
            this.txbProductFacing = new System.Windows.Forms.TextBox();
            this.txbProductShopPrice = new System.Windows.Forms.TextBox();
            this.txbRest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblThirdValue = new System.Windows.Forms.Label();
            this.lblSecondValue = new System.Windows.Forms.Label();
            this.lblFirstValue = new System.Windows.Forms.Label();
            this.lblFirstDate = new System.Windows.Forms.Label();
            this.lblSecondDate = new System.Windows.Forms.Label();
            this.lblThirdDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pBoxKeyBoard = new System.Windows.Forms.PictureBox();
            this.pBoxAccept = new System.Windows.Forms.PictureBox();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.Add(this.tbtnClose);
            this.toolBar1.Buttons.Add(this.tbtnOk);
            this.toolBar1.Buttons.Add(this.tbtnDiscounts);
            this.toolBar1.Buttons.Add(this.tbtnBuysHistory);
            this.toolBar1.Name = "toolBar1";
            // 
            // tbtnClose
            // 
            this.tbtnClose.ImageIndex = 0;
            this.tbtnClose.ToolTipText = "Закрыть";
            // 
            // tbtnOk
            // 
            this.tbtnOk.ImageIndex = 1;
            this.tbtnOk.ToolTipText = "OK";
            // 
            // tbtnDiscounts
            // 
            this.tbtnDiscounts.ImageIndex = 2;
            this.tbtnDiscounts.ToolTipText = "Скидки";
            // 
            // tbtnBuysHistory
            // 
            this.tbtnBuysHistory.ImageIndex = 3;
            this.tbtnBuysHistory.ToolTipText = "История покупок";
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            // 
            // lblProduct
            // 
            this.lblProduct.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblProduct.Location = new System.Drawing.Point(3, 6);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(234, 37);
            this.lblProduct.Text = "Товар:";
            // 
            // lblStore
            // 
            this.lblStore.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStore.Location = new System.Drawing.Point(3, 43);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(234, 17);
            this.lblStore.Text = "Склад:";
            // 
            // lblRemains
            // 
            this.lblRemains.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblRemains.Location = new System.Drawing.Point(3, 62);
            this.lblRemains.Name = "lblRemains";
            this.lblRemains.Size = new System.Drawing.Size(234, 18);
            this.lblRemains.Text = "Остаток на складе:";
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCount.Location = new System.Drawing.Point(3, 84);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(41, 14);
            this.lblCount.Text = "Заказ:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.numUpDownProductCount);
            this.panel1.Controls.Add(this.chkNoOrder);
            this.panel1.Controls.Add(this.lblStore);
            this.panel1.Controls.Add(this.lblCount);
            this.panel1.Controls.Add(this.lblProduct);
            this.panel1.Controls.Add(this.lblRemains);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 110);
            // 
            // numUpDownProductCount
            // 
            this.numUpDownProductCount.Location = new System.Drawing.Point(44, 81);
            this.numUpDownProductCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDownProductCount.Name = "numUpDownProductCount";
            this.numUpDownProductCount.Size = new System.Drawing.Size(64, 22);
            this.numUpDownProductCount.TabIndex = 17;
            this.numUpDownProductCount.ValueChanged += new System.EventHandler(this.numUpDownProductCount_ValueChanged);
            this.numUpDownProductCount.GotFocus += new System.EventHandler(this.txbProductCount_GotFocus);
            this.numUpDownProductCount.LostFocus += new System.EventHandler(this.txbProductCount_LostFocus);
            // 
            // chkNoOrder
            // 
            this.chkNoOrder.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.chkNoOrder.Location = new System.Drawing.Point(112, 82);
            this.chkNoOrder.Name = "chkNoOrder";
            this.chkNoOrder.Size = new System.Drawing.Size(93, 20);
            this.chkNoOrder.TabIndex = 12;
            this.chkNoOrder.Text = "Без заказа";
            this.chkNoOrder.CheckStateChanged += new System.EventHandler(this.chkNoOrder_CheckStateChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.BurlyWood;
            this.panel2.Controls.Add(this.lblShop);
            this.panel2.Controls.Add(this.txbProductFacing);
            this.panel2.Controls.Add(this.txbProductShopPrice);
            this.panel2.Controls.Add(this.txbRest);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 87);
            // 
            // lblShop
            // 
            this.lblShop.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblShop.Location = new System.Drawing.Point(6, 22);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(225, 16);
            this.lblShop.Text = "Торг. точка:";
            // 
            // txbProductFacing
            // 
            this.txbProductFacing.Location = new System.Drawing.Point(159, 58);
            this.txbProductFacing.Name = "txbProductFacing";
            this.txbProductFacing.Size = new System.Drawing.Size(72, 21);
            this.txbProductFacing.TabIndex = 8;
            this.txbProductFacing.GotFocus += new System.EventHandler(this.txbProductCount_GotFocus);
            this.txbProductFacing.LostFocus += new System.EventHandler(this.txbProductCount_LostFocus);
            // 
            // txbProductShopPrice
            // 
            this.txbProductShopPrice.Location = new System.Drawing.Point(83, 58);
            this.txbProductShopPrice.Name = "txbProductShopPrice";
            this.txbProductShopPrice.Size = new System.Drawing.Size(72, 21);
            this.txbProductShopPrice.TabIndex = 7;
            this.txbProductShopPrice.GotFocus += new System.EventHandler(this.txbProductCount_GotFocus);
            this.txbProductShopPrice.LostFocus += new System.EventHandler(this.txbProductCount_LostFocus);
            // 
            // txbRest
            // 
            this.txbRest.Location = new System.Drawing.Point(6, 58);
            this.txbRest.Name = "txbRest";
            this.txbRest.Size = new System.Drawing.Size(72, 21);
            this.txbRest.TabIndex = 6;
            this.txbRest.GotFocus += new System.EventHandler(this.txbProductCount_GotFocus);
            this.txbRest.LostFocus += new System.EventHandler(this.txbProductCount_LostFocus);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(157, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.Text = "Фейсинг:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(81, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 16);
            this.label3.Text = "Цена:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.Text = "Остаток:";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(24, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 16);
            this.label1.Text = "Информация по товару в ТТ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.lblThirdValue);
            this.panel3.Controls.Add(this.lblSecondValue);
            this.panel3.Controls.Add(this.lblFirstValue);
            this.panel3.Controls.Add(this.lblFirstDate);
            this.panel3.Controls.Add(this.lblSecondDate);
            this.panel3.Controls.Add(this.lblThirdDate);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(0, 197);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 74);
            // 
            // lblThirdValue
            // 
            this.lblThirdValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblThirdValue.Location = new System.Drawing.Point(161, 40);
            this.lblThirdValue.Name = "lblThirdValue";
            this.lblThirdValue.Size = new System.Drawing.Size(70, 16);
            this.lblThirdValue.Text = "----";
            // 
            // lblSecondValue
            // 
            this.lblSecondValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSecondValue.Location = new System.Drawing.Point(81, 40);
            this.lblSecondValue.Name = "lblSecondValue";
            this.lblSecondValue.Size = new System.Drawing.Size(70, 16);
            this.lblSecondValue.Text = "----";
            // 
            // lblFirstValue
            // 
            this.lblFirstValue.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblFirstValue.Location = new System.Drawing.Point(8, 40);
            this.lblFirstValue.Name = "lblFirstValue";
            this.lblFirstValue.Size = new System.Drawing.Size(70, 16);
            this.lblFirstValue.Text = "----";
            // 
            // lblFirstDate
            // 
            this.lblFirstDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblFirstDate.Location = new System.Drawing.Point(8, 24);
            this.lblFirstDate.Name = "lblFirstDate";
            this.lblFirstDate.Size = new System.Drawing.Size(70, 16);
            this.lblFirstDate.Text = "----";
            // 
            // lblSecondDate
            // 
            this.lblSecondDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSecondDate.Location = new System.Drawing.Point(81, 25);
            this.lblSecondDate.Name = "lblSecondDate";
            this.lblSecondDate.Size = new System.Drawing.Size(70, 15);
            this.lblSecondDate.Text = "----";
            // 
            // lblThirdDate
            // 
            this.lblThirdDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblThirdDate.Location = new System.Drawing.Point(162, 25);
            this.lblThirdDate.Name = "lblThirdDate";
            this.lblThirdDate.Size = new System.Drawing.Size(70, 15);
            this.lblThirdDate.Text = "----";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label5.Location = new System.Drawing.Point(24, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 21);
            this.label5.Text = "3 последних заказа:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.pBoxKeyBoard);
            this.panel4.Controls.Add(this.pBoxAccept);
            this.panel4.Controls.Add(this.pBoxBack);
            this.panel4.Location = new System.Drawing.Point(0, 272);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 23);
            // 
            // pBoxKeyBoard
            // 
            this.pBoxKeyBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pBoxKeyBoard.Location = new System.Drawing.Point(218, 2);
            this.pBoxKeyBoard.Name = "pBoxKeyBoard";
            this.pBoxKeyBoard.Size = new System.Drawing.Size(20, 20);
            this.pBoxKeyBoard.Click += new System.EventHandler(this.pBoxKeyBoard_Click);
            this.pBoxKeyBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseDown);
            this.pBoxKeyBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBoxButton_MouseUp);
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
            // frmItemCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmItemCard";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.frmItemCard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbtnClose;
        private System.Windows.Forms.ToolBarButton tbtnOk;
        private System.Windows.Forms.ToolBarButton tbtnDiscounts;
        private System.Windows.Forms.ToolBarButton tbtnBuysHistory;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Label lblRemains;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbProductFacing;
        private System.Windows.Forms.TextBox txbProductShopPrice;
        private System.Windows.Forms.TextBox txbRest;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblShop;
        private System.Windows.Forms.Label lblFirstDate;
        private System.Windows.Forms.Label lblSecondDate;
        private System.Windows.Forms.Label lblThirdDate;
        private System.Windows.Forms.CheckBox chkNoOrder;
        private System.Windows.Forms.Label lblThirdValue;
        private System.Windows.Forms.Label lblSecondValue;
        private System.Windows.Forms.Label lblFirstValue;
        private System.Windows.Forms.NumericUpDown numUpDownProductCount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pBoxAccept;
        private System.Windows.Forms.PictureBox pBoxBack;
        private System.Windows.Forms.PictureBox pBoxKeyBoard;



    }
}