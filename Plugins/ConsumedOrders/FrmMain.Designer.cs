namespace ConsumedOrders
{
	partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.imageList = new System.Windows.Forms.ImageList();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnReserves = new System.Windows.Forms.Button();
            this.btnPerf = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnRoute = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSyncAll = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pBoxBack = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            // 
            // btnCustomers
            // 
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.btnCustomers.Location = new System.Drawing.Point(8, 71);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(222, 17);
            this.btnCustomers.TabIndex = 48;
            this.btnCustomers.Text = "Клиенты";
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStatus.Location = new System.Drawing.Point(3, 253);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(237, 17);
            this.lblStatus.Text = "Ready";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Location = new System.Drawing.Point(0, 239);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(227, 1);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.btnNewOrder.Location = new System.Drawing.Point(8, 24);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(222, 20);
            this.btnNewOrder.TabIndex = 47;
            this.btnNewOrder.Text = "Оформить накладную";
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnReserves
            // 
            this.btnReserves.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.btnReserves.Location = new System.Drawing.Point(8, 94);
            this.btnReserves.Name = "btnReserves";
            this.btnReserves.Size = new System.Drawing.Size(222, 17);
            this.btnReserves.TabIndex = 51;
            this.btnReserves.Text = "Остатки товаров";
            this.btnReserves.Click += new System.EventHandler(this.btnReserves_Click);
            // 
            // btnPerf
            // 
            this.btnPerf.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnPerf.Location = new System.Drawing.Point(8, 140);
            this.btnPerf.Name = "btnPerf";
            this.btnPerf.Size = new System.Drawing.Size(222, 17);
            this.btnPerf.TabIndex = 52;
            this.btnPerf.Text = "Перфокарта и Пробитие чеков";
            this.btnPerf.Click += new System.EventHandler(this.btnPerf_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.Text = "Справочники и документы";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Location = new System.Drawing.Point(26, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(201, 1);
            // 
            // btnRoute
            // 
            this.btnRoute.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnRoute.Location = new System.Drawing.Point(8, 163);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(222, 17);
            this.btnRoute.TabIndex = 55;
            this.btnRoute.Text = "Маршруты";
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(56, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 1);
            // 
            // btnOrderList
            // 
            this.btnOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.btnOrderList.Location = new System.Drawing.Point(8, 117);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(222, 17);
            this.btnOrderList.TabIndex = 45;
            this.btnOrderList.Text = "Накладные";
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.Text = "Задачи";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(8, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.Text = "Обмен даннными";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(56, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 1);
            // 
            // btnSyncAll
            // 
            this.btnSyncAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            this.btnSyncAll.Location = new System.Drawing.Point(8, 209);
            this.btnSyncAll.Name = "btnSyncAll";
            this.btnSyncAll.Size = new System.Drawing.Size(222, 20);
            this.btnSyncAll.TabIndex = 46;
            this.btnSyncAll.Text = "Синхронизация";
            this.btnSyncAll.Click += new System.EventHandler(this.btnSyncAll_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(204)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.pBoxBack);
            this.panel3.Location = new System.Drawing.Point(0, 271);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 23);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.btnReserves);
            this.Controls.Add(this.btnPerf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.btnRoute);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnOrderList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSyncAll);
            this.Name = "frmMain";
            this.Text = "Оформление РН";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnReserves;
        private System.Windows.Forms.Button btnPerf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSyncAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pBoxBack;


    }
}