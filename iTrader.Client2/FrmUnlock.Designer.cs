namespace iTrader.Client2
{
	partial class FrmUnlock
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
			this.label1 = new System.Windows.Forms.Label();
			this.txbPassword = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 15);
			this.label1.Text = "Введите пароль:";
			// 
			// txbPassword
			// 
			this.txbPassword.Location = new System.Drawing.Point(7, 27);
			this.txbPassword.Name = "txbPassword";
			this.txbPassword.PasswordChar = '*';
			this.txbPassword.Size = new System.Drawing.Size(174, 21);
			this.txbPassword.TabIndex = 1;
			this.txbPassword.GotFocus += new System.EventHandler(this.txbPassword_GotFocus);
			this.txbPassword.LostFocus += new System.EventHandler(this.txbPassword_LostFocus);
			// 
			// btnOk
			// 
			this.btnOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.btnOk.Location = new System.Drawing.Point(100, 58);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(81, 20);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "ОК";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.btnCancel.Location = new System.Drawing.Point(10, 58);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 20);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmUnlock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(191, 91);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txbPassword);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MinimizeBox = false;
			this.Name = "FrmUnlock";
			this.Text = "FrmUnlock";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.FrmUnlock_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txbPassword;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
	}
}