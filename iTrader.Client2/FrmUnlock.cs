using System;
using System.Drawing;
using System.Windows.Forms;
using itcClassess;

namespace iTrader.Client2
{
	public partial class FrmUnlock : Form
	{
		public FrmUnlock()
		{
			InitializeComponent();
		}

// ReSharper disable InconsistentNaming
		private void FrmUnlock_Load(object sender, EventArgs e)
// ReSharper restore InconsistentNaming
		{
			int x = (Screen.PrimaryScreen.Bounds.Width / 2) - (Width / 2);
			int y = (Screen.PrimaryScreen.Bounds.Height / 2) - (Height / 2);
			Location = new Point(x,y);
		}

// ReSharper disable InconsistentNaming
		private void btnCancel_Click(object sender, EventArgs e)
// ReSharper restore InconsistentNaming
		{
			DialogResult = DialogResult.No;
			Close();
		}

// ReSharper disable InconsistentNaming
		private void btnOk_Click(object sender, EventArgs e)
// ReSharper restore InconsistentNaming
		{
			DialogResult = txbPassword.Text=="ldyqfx" ? DialogResult.Yes : DialogResult.No;
			Close();
		}

		private void txbPassword_GotFocus(object sender, EventArgs e)
		{
			Sip.Show();
		}

		private void txbPassword_LostFocus(object sender, EventArgs e)
		{
			Sip.Hide();
		}
	}
}