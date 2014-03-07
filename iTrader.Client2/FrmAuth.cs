using System;
using System.Drawing;
using System.Windows.Forms;

namespace iTrader.Client2
{
	public partial class FrmAuth : Form
	{
		public bool Result = false;
		private string _password=null;
		private string _typed = "";
		private Color _defaultButtonColor;

		public FrmAuth()
		{
			InitializeComponent();
		}

		private void CheckPassword()
		{
			var resultWithPass = itcDatabase.DatabaseService.GetOneRow("SELECT ppoValue FROM tblPpcOptions where ppoVariable='ConfigPassword'");
			if (resultWithPass != null)
			{
				_password = resultWithPass[0].Trim();
			}
			else
			{
				Result = true;
				Close();
			}

			switch (_typed.Length)
			{
				case 0:
					btnNum1.BackColor = _defaultButtonColor;
					btnNum2.BackColor = _defaultButtonColor;
					btnNum3.BackColor = _defaultButtonColor;
					btnNum4.BackColor = _defaultButtonColor;
					btnNum5.BackColor = _defaultButtonColor;
					btnNum6.BackColor = _defaultButtonColor;
					btnNum7.BackColor = _defaultButtonColor;
					btnNum8.BackColor = _defaultButtonColor;
					btnNum9.BackColor = _defaultButtonColor;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;

				case 1:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = _defaultButtonColor;
					btnNum3.BackColor = _defaultButtonColor;
					btnNum4.BackColor = _defaultButtonColor;
					btnNum5.BackColor = _defaultButtonColor;
					btnNum6.BackColor = _defaultButtonColor;
					btnNum7.BackColor = _defaultButtonColor;
					btnNum8.BackColor = _defaultButtonColor;
					btnNum9.BackColor = _defaultButtonColor;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
				case 2:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = _defaultButtonColor;
					btnNum4.BackColor = _defaultButtonColor;
					btnNum5.BackColor = _defaultButtonColor;
					btnNum6.BackColor = _defaultButtonColor;
					btnNum7.BackColor = _defaultButtonColor;
					btnNum8.BackColor = _defaultButtonColor;
					btnNum9.BackColor = _defaultButtonColor;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
				case 3:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = Color.DarkSeaGreen;
					btnNum4.BackColor = _defaultButtonColor;
					btnNum5.BackColor = _defaultButtonColor;
					btnNum6.BackColor = _defaultButtonColor;
					btnNum7.BackColor = _defaultButtonColor;
					btnNum8.BackColor = _defaultButtonColor;
					btnNum9.BackColor = _defaultButtonColor;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
				case 4:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = Color.DarkSeaGreen;
					btnNum4.BackColor = Color.DarkSeaGreen;
					btnNum5.BackColor = _defaultButtonColor;
					btnNum6.BackColor = _defaultButtonColor;
					btnNum7.BackColor = _defaultButtonColor;
					btnNum8.BackColor = _defaultButtonColor;
					btnNum9.BackColor = _defaultButtonColor;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
				case 5:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = Color.DarkSeaGreen;
					btnNum4.BackColor = Color.DarkSeaGreen;
					btnNum5.BackColor = Color.DarkSeaGreen;
					btnNum6.BackColor = _defaultButtonColor;
					btnNum7.BackColor = _defaultButtonColor;
					btnNum8.BackColor = _defaultButtonColor;
					btnNum9.BackColor = _defaultButtonColor;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
				case 6:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = Color.DarkSeaGreen;
					btnNum4.BackColor = Color.DarkSeaGreen;
					btnNum5.BackColor = Color.DarkSeaGreen;
					btnNum6.BackColor = Color.DarkSeaGreen;
					btnNum7.BackColor = _defaultButtonColor;
					btnNum8.BackColor = _defaultButtonColor;
					btnNum9.BackColor = _defaultButtonColor;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
				case 7:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = Color.DarkSeaGreen;
					btnNum4.BackColor = Color.DarkSeaGreen;
					btnNum5.BackColor = Color.DarkSeaGreen;
					btnNum6.BackColor = Color.DarkSeaGreen;
					btnNum7.BackColor = Color.DarkSeaGreen;
					btnNum8.BackColor = _defaultButtonColor;
					btnNum9.BackColor = _defaultButtonColor;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
				case 8:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = Color.DarkSeaGreen;
					btnNum4.BackColor = Color.DarkSeaGreen;
					btnNum5.BackColor = Color.DarkSeaGreen;
					btnNum6.BackColor = Color.DarkSeaGreen;
					btnNum7.BackColor = Color.DarkSeaGreen;
					btnNum8.BackColor = Color.DarkSeaGreen;
					btnNum9.BackColor = _defaultButtonColor;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
				case 9:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = Color.DarkSeaGreen;
					btnNum4.BackColor = Color.DarkSeaGreen;
					btnNum5.BackColor = Color.DarkSeaGreen;
					btnNum6.BackColor = Color.DarkSeaGreen;
					btnNum7.BackColor = Color.DarkSeaGreen;
					btnNum8.BackColor = Color.DarkSeaGreen;
					btnNum9.BackColor = Color.DarkSeaGreen;
					btnNum0.BackColor = _defaultButtonColor;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
				case 10:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = Color.DarkSeaGreen;
					btnNum4.BackColor = Color.DarkSeaGreen;
					btnNum5.BackColor = Color.DarkSeaGreen;
					btnNum6.BackColor = Color.DarkSeaGreen;
					btnNum7.BackColor = Color.DarkSeaGreen;
					btnNum8.BackColor = Color.DarkSeaGreen;
					btnNum9.BackColor = Color.DarkSeaGreen;
					btnNum0.BackColor = Color.DarkSeaGreen;
					btnNumSharp.BackColor = Color.DarkSeaGreen;
					btnNumClear.BackColor = Color.DarkSeaGreen;
					break;

				default:
					btnNum1.BackColor = Color.DarkSeaGreen;
					btnNum2.BackColor = Color.DarkSeaGreen;
					btnNum3.BackColor = Color.DarkSeaGreen;
					btnNum4.BackColor = Color.DarkSeaGreen;
					btnNum5.BackColor = Color.DarkSeaGreen;
					btnNum6.BackColor = Color.DarkSeaGreen;
					btnNum7.BackColor = Color.DarkSeaGreen;
					btnNum8.BackColor = Color.DarkSeaGreen;
					btnNum9.BackColor = Color.DarkSeaGreen;
					btnNum0.BackColor = Color.DarkSeaGreen;
					btnNumSharp.BackColor = _defaultButtonColor;
					btnNumClear.BackColor = _defaultButtonColor;
					break;
			}


			if (_password == _typed && _password.Length>0)
			{
				Result = true;
				Close();
			}
			
		}

		private void FrmAuth_Load(object sender, EventArgs e)
		{
			_defaultButtonColor = btnNum1.BackColor;
			var resultWithPass = itcDatabase.DatabaseService.GetOneRow("SELECT ppoValue FROM tblPpcOptions where ppoVariable='ConfigPassword'");
			var r = itcDatabase.DatabaseService.GetOneRow("SELECT count(ppoValue) FROM tblPpcOptions");
			if(resultWithPass!=null)
			{
				_password = resultWithPass[0].Trim();
			}
			else
			{
				Result = true;
				Close();
			}
		}


		private void btnNum1_Click(object sender, EventArgs e)
		{
			_typed += "1";
			CheckPassword();
		}

		private void btnNum2_Click(object sender, EventArgs e)
		{
			_typed += "2";
			CheckPassword();
		}

		private void btnNum3_Click(object sender, EventArgs e)
		{
			_typed += "3";
			CheckPassword();
		}

		private void btnNum4_Click(object sender, EventArgs e)
		{
			_typed += "4";
			CheckPassword();
		}

		private void btnNum5_Click(object sender, EventArgs e)
		{
			_typed += "5";
			CheckPassword();
		}

		private void btnNum6_Click(object sender, EventArgs e)
		{
			_typed += "6";
			CheckPassword();
		}

		private void btnNum7_Click(object sender, EventArgs e)
		{
			_typed += "7";
			CheckPassword();
		}

		private void btnNum8_Click(object sender, EventArgs e)
		{
			_typed += "8";
			CheckPassword();
		}

		private void btnNum9_Click(object sender, EventArgs e)
		{
			_typed += "9";
			CheckPassword();
		}

		private void btnNum0_Click(object sender, EventArgs e)
		{
			_typed += "0";
			CheckPassword();
		}

		private void btnNumClear_Click(object sender, EventArgs e)
		{
			_typed = "";
			CheckPassword();
		}

		private void btnNumSharp_Click(object sender, EventArgs e)
		{
			MessageBox.Show(@"Вы получили полный доспуп системного администратора!");

			MessageBox.Show(@"Желаете очистить все базы данных? ",@"Внимание",MessageBoxButtons.YesNo,
				MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);

			MessageBox.Show(@"Все ваши накладные были полностью удалены с кпк и с сервера!", @"Внимание", 
				MessageBoxButtons.OK,MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

			MessageBox.Show(@"Ваш супервайзер получил уведомоление о том что вы стерли все накладные.", @"Внимание", 
				MessageBoxButtons.OK,MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

			MessageBox.Show(@"Приятного рабочего дня", @"Внимание", MessageBoxButtons.OK,
				MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}



	}
}