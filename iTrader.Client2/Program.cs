using System;
using System.Windows.Forms;
using System.IO;

namespace iTrader.Client2
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[MTAThread]
		static void Main()
		{
			// MultiRunLock 
			try
			{
				// open lock to file or check for file locked.
				TextWriter textWriterLock = new StreamWriter(@"\Program Files\iTraderClient2\run.pid", false);
				textWriterLock.Write("!");
			}
			catch (Exception)
			{
				//MessageBox.Show("Programm alrady runing");
				Application.Exit();
				return;
			}

			// ---- Run main form -----------------
			Application.Run(new FrmMain());
		}
	}
}