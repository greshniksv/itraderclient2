namespace itcUpdateFile
{
    partial class FrmUpdateFile
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
			this.lbxInformation = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer();
			this.SuspendLayout();
			// 
			// lbxInformation
			// 
			this.lbxInformation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
			this.lbxInformation.Location = new System.Drawing.Point(3, 83);
			this.lbxInformation.Name = "lbxInformation";
			this.lbxInformation.Size = new System.Drawing.Size(234, 158);
			this.lbxInformation.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(237, 80);
			this.label1.Text = "Происходит обновление файлов, дождитесь завершения операции. Не нажимайте стилусо" +
				"м и не жмите в ресет. Программа все сделает автоматически.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// FrmUpdateFile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 294);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbxInformation);
			this.MinimizeBox = false;
			this.Name = "FrmUpdateFile";
			this.Text = "Обновлние файлов";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxInformation;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
    }
}

