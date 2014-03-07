using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using itcLog;

namespace itcUpdateFile
{
	public partial class FrmUpdateFile : Form
	{
		readonly Log _syslog = new Log();
		List<string> _filePathList = new List<string>();
		private const string _path = @"\Program Files\itraderclient2\Update\File\";

		public FrmUpdateFile()
		{
			InitializeComponent();
		}

		private void Replacing()
		{
			//const string path = @"\Program Files\itraderclient2\Update\File\";
			_syslog.Initialization(@"\Program Files\itraderclient2\", 10000000);
			if (!_syslog.Initialization(@"\Program Files\iTraderClient2\iTraderClient2.log", 1000000))
			{
				ToListbox("Error write log");
			}

			if (!Directory.Exists(_path))
			{
				MessageBox.Show(@"Не найдены файлы для обновления. Нажмите [OK] и повторите операцию.");
			}
			else
			{
				var fileLocations = new List<string>();

				ToListbox("Get update file list");
				string[] updateFileMas = Directory.GetFiles(_path);

				// Get file location
				ToListbox("Get file location");
				string[] files = Directory.GetFiles(@"\Program Files\itraderclient2");
				foreach (var file in files)
				{
					fileLocations.Add(file.ToLower());
				}

				files = Directory.GetFiles(@"\Program Files\itraderclient2\plugins");
				foreach (var file in files)
				{
					fileLocations.Add(file.ToLower());
				}

				GC.Collect();
				GC.WaitForPendingFinalizers();

				// Replacing old files 
				foreach (var updateFile in updateFileMas)
				{
					bool pathExist = false;
					foreach (var fileLocation in fileLocations)
					{
						if (Path.GetFileName(updateFile) == null) continue;
						if (Path.GetFileName(fileLocation) == null) continue;

						if (Path.GetFileName(updateFile).ToLower() == Path.GetFileName(fileLocation).ToLower())
						{
							pathExist = true;
							for (int i = 0; i < 5; i++)
							{
								ToListbox("move: " + Path.GetFileName(updateFile));
								try
								{
									File.Delete(fileLocation);
									File.Copy(updateFile, fileLocation);
									break;
								}
								catch (Exception ex)
								{
									// Error file move :(
									ToListbox("ERROR move " + Path.GetFileName(updateFile) + ". " + ex);
									Thread.Sleep(1000);
								}
							}
						}
					}

					if(!pathExist)
					{
						if (_filePathList.Count==0)
							GetFilePathList();

						foreach (var filePathItem in _filePathList)
						{
							if(Path.GetFileName(filePathItem).ToLower()==Path.GetFileName(updateFile).ToLower())
							{
								for (int i = 0; i < 5; i++)
								{
									ToListbox("move: " + Path.GetFileName(updateFile));
									try
									{
										File.Delete(filePathItem);
										File.Copy(updateFile, filePathItem);
										break;
									}
									catch (Exception ex)
									{
										// Error file move :(
										ToListbox("ERROR move " + Path.GetFileName(updateFile) + ". " + ex);
										Thread.Sleep(1000);
									}
								}
							}
						}

					}

				}

				Directory.Delete(_path, true);
				ToListbox("Finish");
			}

			try
			{
				var myProc = new System.Diagnostics.Process
				{
					StartInfo = { FileName = @"\Program Files\itraderclient2\itrader.client2.exe", Arguments = "" }
				};
				myProc.Start();
			}
			catch (Exception ex) { MessageBox.Show(@"Error run. " + ex); }
			Application.Exit();
			return;
		}

		private void ToListbox(string message)
		{
			Application.DoEvents();
			_syslog.Write("Updater. "+message, MessageType.Warning);
			lbxInformation.Items.Insert(0, message);
			Application.DoEvents();
		}

		private void GetFilePathList()
		{
			TextReader textReader = new StreamReader(_path+"filePath.conf");
			string buf;
			while ((buf = textReader.ReadLine())!=null)
			{
				_filePathList.Add(buf);
			}
			textReader.Close();
		}


		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			Replacing();
		}

	}
}