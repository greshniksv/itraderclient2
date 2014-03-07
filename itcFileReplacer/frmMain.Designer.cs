namespace itcFileReplacer
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lblInfo.Location = new System.Drawing.Point(42, 97);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(153, 57);
            this.lblInfo.Text = "Замена файлов. Подождите...";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.lblInfo);
            this.Name = "frmMain";
            this.Text = "File Replacer";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer timer;
    }
}

