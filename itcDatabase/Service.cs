using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using itcClassess;

namespace itcDatabase
{
	public static class DatabaseService
	{
		private static bool _waitingIncomingMessage;
		private static string _incomingMessage = string.Empty;

		private static bool _waitingDonwloadFile;
		private static string _downloadFile = string.Empty;

		private static string _downloadFileName = "";

		public static void UpdateUserName()
		{
			GLOBAL.SysLog.WriteInfom(@"Update Users name.");
			GLOBAL.UserInfo.Number = GLOBAL.CONFIG.GetValue("UserId", "0", "Main");
			List<string> userName = GetOneRow("SELECT uFullName FROM tblUsers WHERE id = '" + GLOBAL.UserInfo.Number + "'");
			GLOBAL.SysLog.WriteWarning(userName != null ? "Find user name" : "Not found user name");
			GLOBAL.UserInfo.Name = userName != null ? userName[0] : "";
		}

        public static void UpdateGetUrlForPrintCheques()
        {
            try
            {
                GLOBAL.UrlForPrintCheques = Database.GetUrlForPrintCheques();
            }
            catch (Exception ex)
            {
                GLOBAL.SysLog.WriteError(ex.Message);
            }
        }

		public static List<string> GetOneRow(string sql)
		{
			if (!Database.Connected()) return null;
			List<string> buffer;
			Database.EXEC_Reader(sql);

			if ((buffer = Database.EXEC_GetRead()) != null)
			{
				Database.EXEC_CloseReader();
				return buffer;
			}
			else
			{
				GLOBAL.SysLog.WriteError("GetOneRow. ex:" + Database.LastException);
				Database.EXEC_CloseReader();
				return null;
			}
		}

		public static void FillComboBox(ComboBox comboBox, string table, string valueField, string nameField, string defValue)
		{
			comboBox.Items.Clear();
			if (!Database.Connected()) return;
			List<string> buffer;
            bool foundDef = false;
			if (!Database.EXEC_Reader("select " + valueField + ", " + nameField + " from " + table + " order by " + nameField))
			{
				GLOBAL.SysLog.WriteError("FillComboBox. Error exec:" + "select " + valueField + ", " + nameField + " from " + table + " order by " + nameField
					+ " \n ex:" + Database.LastException);
				return;
			}
			while ((buffer = Database.EXEC_GetRead()) != null)
			{
                var newItem = new ComboBoxItem(buffer[0], buffer[1]);
                int lastItemIndex = comboBox.Items.Add(newItem);

				if (buffer[0] == defValue)
				{
                    foundDef = true;
                    comboBox.SelectedItem = newItem;
				}
			}

            if (!foundDef) comboBox.SelectedIndex = comboBox.Items.Count - 1;
			Database.EXEC_CloseReader();
		}

		public static void FillListView(ListView listView, string table, List<string> fileds, string orderBy)
		{
			if (!Database.Connected()) return;
			List<string> buffer;

			string fieldsUnion = string.Empty;
			foreach (var filed in fileds)
			{
				if (fieldsUnion != string.Empty) fieldsUnion += ",";
				fieldsUnion += filed;
			}

            if (!Database.EXEC_Reader("select distinct " + fieldsUnion + " from " + table + " order by " + orderBy))
			{
                GLOBAL.SysLog.WriteError("FillListView. Error exec:" + "select distinct " + fieldsUnion + " from " + table + " order by " + orderBy
					+ " \n ex:" + Database.LastException);
				return;
			}

			while ((buffer = Database.EXEC_GetRead()) != null)
			{
				var ii = new ListViewItem { Text = string.Empty };

				foreach (var field in buffer)
				{
					if (ii.Text == string.Empty) ii.Text = field;
					else
					{
						ii.SubItems.Add(field);
					}
				}
				listView.Items.Add(ii);
			}
			Database.EXEC_CloseReader();
		}



		// ******************************************************************
		// ************** Update system *************************************
		// ******************************************************************
        // Banan version
        //public static void Updating()
        //{

        //    if (Database.Connected())
        //    {
        //        UpdateUserName();
        //    }
        //    else
        //    {
        //        GLOBAL.SysLog.WriteWarning("Error connect to local db");
        //        MessageBox.Show("Отсутствует подлючение к базе данных.\nРабота невозможна.\nПопробуйте в настройках указать путь к другой базе, перезапустить программу или произвести инициализацию БД.", @"Отсутствует подключение", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        //    }

        //    try
        //    {
        //        string serverIp;

        //        Status.UpdateStatus("Запуск обновления");
        //        GLOBAL.SysLog.WriteInfom("Start update programm");
        //        if (Database.EXEC_Reader("select ppoValue from tblPpcOptions where ppoVariable = 'UpdateURL' "))
        //        {
        //            var value = Database.EXEC_GetRead();
        //            serverIp = value[0];
        //        }
        //        else
        //        {
        //            // 93.157.24.7
        //            serverIp = "93.157.24.7:21000";
        //            GLOBAL.SysLog.WriteInfom("Error get serverUrl from database. Set default serverUrl:" + serverIp);
        //        }
        //        Database.EXEC_CloseReader();

        //        UpdateClient.CompleteDownloadFile += (ClientCompleteDownloadFile);
        //        UpdateClient.ErrorDownloadFile += (ClientErrorDownloadFile);
        //        UpdateClient.ErrorIncomingMessage += (ClientErrorIncomingMessage);
        //        UpdateClient.IncomingMessage += (ClientIncomingMessage);
        //        UpdateClient.ProgressDownloadFile += (ClientProgressDownloadFile);
        //        UpdateClient.StartDownloadFile += (ClientStartDownloadFile);
        //        UpdateClient.PathToSaveTmpFile = @"\Program Files\iTraderClient2\Update";
        //        //if (!UpdateClient.Connect("192.168.1.15", 21000, false)) 
        //        //{ GLOBAL.SysLog.WriteError("Cen't connect to update host"); return; }

        //        int serverPort = 0;
        //        try
        //        {
        //            serverPort = Int32.Parse(serverIp.Split(':')[1]);
        //            serverIp = serverIp.Split(':')[0];
        //        }
        //        catch (Exception)
        //        {
        //            Status.UpdateStatus("Ошибка разбора адреса сервера");
        //            //MessageBox.Show("Error connect to " + serverIp + " port:" + serverPort);
        //            GLOBAL.SysLog.WriteError("Error parse update url. updateUrl: " + serverIp);
        //            return;
        //        }


        //        if (!UpdateClient.Connect(serverIp, serverPort, false))
        //        {
        //            //MessageBox.Show("Error connect to " + serverIp);
        //            Status.UpdateStatus("Ошибка подкл. к обновениям");
        //            GLOBAL.SysLog.WriteError("Cen't connect to update host");
        //            return;
        //        }
        //        Thread.Sleep(100);

        //        UpdateClient.SendMessage(Encoding.ASCII.GetBytes("set_user_id:" + GLOBAL.UserInfo.Number + ";"));
				
        //        Thread.Sleep(100);

        //        UpdateClient.SendMessage(Encoding.ASCII.GetBytes("set_user_id:" + GLOBAL.UserInfo.Number + ";"));

        //        Thread.Sleep(100);

        //        GLOBAL.SysLog.WriteInfom("Sending log data to update server");
        //        //GLOBAL.Status.Status = "Отправка ЛОГ файла.";
        //        Status.UpdateStatus("Отправка ЛОГ файла.");

        //        var fileInfo = new FileInfo(GLOBAL.CONFIG.GetValue("Log", @"\Program Files\iTraderClient2\iTraderClient2.log", "Main"));
        //        long logFileLen = fileInfo.Length;
        //        TextReader textReader =
        //            new StreamReader(GLOBAL.CONFIG.GetValue("Log", @"\Program Files\iTraderClient2\iTraderClient2.log", "Main"));

        //        string buffer;
        //        string allBuffer = string.Empty;
        //        int readed = 0;
        //        while ((buffer = textReader.ReadLine()) != null)
        //        {
        //            readed += buffer.Length;
        //            GLOBAL.Status.Percentage = (int)(readed * 100 / logFileLen);
        //            if (buffer.IndexOf(';') == -1) allBuffer += buffer;
        //            else
        //            {
        //                allBuffer += buffer;
        //                string type = allBuffer.Substring(allBuffer.IndexOf("[") + 1, allBuffer.IndexOf("]") - (allBuffer.IndexOf("[") + 1));
        //                string dateTime = allBuffer.Substring(allBuffer.IndexOf("]") + 1, allBuffer.IndexOf(">") - (allBuffer.IndexOf("]") + 1));
        //                string date = dateTime.Trim().Split(' ')[0];
        //                string time = dateTime.Trim().Split(' ')[1];
        //                string message = allBuffer.Substring(allBuffer.IndexOf(">") + 1, allBuffer.IndexOf(";") - (allBuffer.IndexOf(">") + 1));

        //                allBuffer = string.Empty;
        //                UpdateClient.SendMessage(Encoding.ASCII.GetBytes("set_log:{" + type + "," + date + "," + time + "," + message + "};"));
        //                Thread.Sleep(10);
        //            }
        //        }
        //        textReader.Close();
        //        GLOBAL.SysLog.Clear();

        //        GLOBAL.SysLog.WriteInfom("Check file version");
        //        //GLOBAL.Status.Percentage = 50;
        //        //GLOBAL.Status.Status = "Пересчет контрольной суммы";
        //        Status.UpdateStatus("Пересчет контрольной суммы", 50);
        //        string fileHashSend = "set_file_hash: ";
        //        string[] files = Directory.GetFiles(@"\Program Files\itraderclient2");
        //        foreach (var file in files)
        //        {
        //            fileHashSend += "{" + Path.GetFileName(file) + "," + MD5_HASH.GetMd5HashFromFile(file) + "}";
        //        }
        //        UpdateClient.SendMessage(Encoding.ASCII.GetBytes(fileHashSend));


        //        //GLOBAL.Status.Percentage = 80;
        //        //GLOBAL.Status.Status = "Пересчет контрольной суммы";
        //        Status.UpdateStatus("Пересчет контрольной суммы", 80);
        //        fileHashSend = "set_file_hash: ";
        //        files = Directory.GetFiles(@"\Program Files\itraderclient2\plugins");
        //        foreach (var file in files)
        //        {
        //            fileHashSend += "{" + Path.GetFileName(file) + "," + MD5_HASH.GetMd5HashFromFile(file) + "}";
        //        }
        //        UpdateClient.SendMessage(Encoding.ASCII.GetBytes(fileHashSend));

        //        //GLOBAL.Status.Percentage = 0;
        //        //GLOBAL.Status.Status = "Запрос на обновление";
        //        Status.UpdateStatus("Запрос на обновление");

        //        UpdateClient.SendMessage(Encoding.ASCII.GetBytes("get_need_update;"));
        //        if (!WaitMessage())
        //        {
        //            //MessageBox.Show("Error waiting message");
        //            GLOBAL.SysLog.WriteInfom("Error waiting message ");
        //            return;
        //        }

        //        // Download update file
        //        if (_incomingMessage == "YES")
        //        {
        //            GLOBAL.SysLog.WriteWarning("Server say need update !");
        //            //GLOBAL.Status.Status = "Получаем список файлов";
        //            Status.UpdateStatus("Получаем список файлов");

        //            UpdateClient.SendMessage(Encoding.ASCII.GetBytes("get_file_update;"));

        //            if (!WaitMessage())
        //            {
        //                GLOBAL.SysLog.WriteInfom("Error waiting message ");
        //                //Console.WriteLine("Error waiting message");
        //                return;
        //            }

        //            string[] updateFiles = _incomingMessage.Split(',');

        //            GLOBAL.SysLog.WriteInfom("Need download " + updateFiles.Length + " file. ");

        //            foreach (var updateFile in updateFiles)
        //            {
        //                if (updateFile.IndexOf("no") != -1) continue;

        //                //GLOBAL.Status.Status = "Загружаю: " + updateFile;
        //                Status.UpdateStatus("Загружаю: " + updateFile);
        //                _downloadFileName = "Загружаю: " + updateFile;
        //                UpdateClient.SendMessage(Encoding.ASCII.GetBytes("get_file:" + updateFile + ";"));

        //                if (!WaitDownloadFile())
        //                {
        //                    GLOBAL.SysLog.WriteError("Error doqnload file " + updateFile);
        //                    MessageBox.Show("Error download file: " + updateFile);
        //                }
        //                else
        //                {
        //                    if (!Directory.Exists(@"\Program Files\itraderclient2\Update\"))
        //                    {
        //                        Directory.CreateDirectory(@"\Program Files\itraderclient2\Update\");
        //                    }

        //                    if (!Directory.Exists(@"\Program Files\itraderclient2\Update\File\"))
        //                    {
        //                        Directory.CreateDirectory(@"\Program Files\itraderclient2\Update\File\");
        //                    }

        //                    if (File.Exists(@"\Program Files\itraderclient2\Update\File\" + updateFile))
        //                    { File.Delete(@"\Program Files\itraderclient2\Update\File\" + updateFile); }

        //                    File.Move(_downloadFile, @"\Program Files\itraderclient2\Update\File\" + updateFile);
        //                    GLOBAL.SysLog.WriteInfom("File " + updateFile + " success download and move");
        //                }
        //            }

        //            UpdateClient.Disconnect();
        //            //GLOBAL.Status.Percentage = 0;
        //            //GLOBAL.Status.Status = "Обновление завершено";
        //            Status.UpdateStatus("Обновление завершено");

        //            try
        //            {
        //                foreach (var plugin in GLOBAL.PluginList.PluginList)
        //                {
        //                    try { plugin.Close(); }
        //                    catch { }
        //                }
        //                Thread.Sleep(500);

        //                for (int i = 0; i < 5; i++)
        //                {
        //                    try
        //                    {
        //                        File.Delete(@"\Program Files\itraderclient2\updfil.exe");
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        GLOBAL.SysLog.WriteError("Error DELETE updateTMP programm. " + ex);
        //                    }
        //                }

        //                File.Copy(@"\Program Files\itraderclient2\itcUpdateFile.exe", @"\Program Files\itraderclient2\updfil.exe");
        //                var myProc = new System.Diagnostics.Process
        //                {
        //                    StartInfo =
        //                    {
        //                        FileName = @"\Program Files\itraderclient2\updfil.exe",
        //                        Arguments = ""
        //                    }
        //                };
        //                myProc.Start();
        //            }
        //            catch (Exception ex)
        //            {
        //                GLOBAL.SysLog.WriteError("Error run update file programm. " + ex);
        //                MessageBox.Show("Error run. " + ex);
        //            }
        //            Application.Exit();
        //            return;

        //        }

        //        UpdateClient.Disconnect();
        //        //GLOBAL.Status.Percentage = 0;
        //        //GLOBAL.Status.Status = "Обновление завершено";
        //        Status.UpdateStatus("Обновление завершено");
        //    }
        //    catch (Exception ex)
        //    {
        //        GLOBAL.SysLog.WriteError("Error update. info:" + ex);
        //        Status.UpdateStatus("Ошибка обновления");
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            UpdateClient.Disconnect();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }
        //}

		public static string[] Autoconfig()
		{
			string serverIp;
            
			GLOBAL.SysLog.WriteInfom("Run autoconfig get data");
			if (Database.EXEC_Reader("select ppoValue from tblPpcOptions where ppoVariable = 'UpdateURL' "))
			{
				var value = Database.EXEC_GetRead();
				serverIp = value[0];
			}
			else
			{
				serverIp = "93.157.24.7:21000";
				GLOBAL.SysLog.WriteError("Error get serverUrl from database. Set default serverUrl:" + serverIp);
				//return null;
			}
			Database.EXEC_CloseReader();

			UpdateClient.CompleteDownloadFile += (ClientCompleteDownloadFile);
			UpdateClient.ErrorDownloadFile += (ClientErrorDownloadFile);
			UpdateClient.ErrorIncomingMessage += (ClientErrorIncomingMessage);
			UpdateClient.IncomingMessage += (ClientIncomingMessage);
			UpdateClient.ProgressDownloadFile += (ClientProgressDownloadFile);
			UpdateClient.StartDownloadFile += (ClientStartDownloadFile);
			UpdateClient.PathToSaveTmpFile = @"\Program Files\iTraderClient2\Update";
			//if (!UpdateClient.Connect("192.168.1.15", 21000, false)) { GLOBAL.SysLog.WriteError("Cen't connect to update host"); return null; }

			int serverPort = 0;
			try
			{
				serverPort = Int32.Parse(serverIp.Split(':')[1]);
				serverIp = serverIp.Split(':')[0];
			}
			catch (Exception)
			{
				MessageBox.Show("Error connect to " + serverIp + " port:" + serverPort);
				GLOBAL.SysLog.WriteError("Cen't connect to update host");
				return null;
			}

			if (!UpdateClient.Connect(serverIp, 21000, false))
			{
				MessageBox.Show("Error connect to " + serverIp);
				GLOBAL.SysLog.WriteError("Cen't connect to update host");
				return null;
			}
			Thread.Sleep(1500);

			UpdateClient.SendMessage(Encoding.ASCII.GetBytes("set_user_id:" + GLOBAL.UserInfo.Number + ";"));

			GLOBAL.Status.Status = "Отправка ЛОГ файла.";

			UpdateClient.SendMessage(Encoding.ASCII.GetBytes("get_autoconfig;"));

			if (!WaitMessage())
			{
				MessageBox.Show("Error waiting message");
			}

			string[] parameters = _incomingMessage.Split('{', '}');

			UpdateClient.Disconnect();
			GLOBAL.Status.Percentage = 0;
			GLOBAL.Status.Status = "Обновление завершено";
			return parameters;
		}


		/// <summary>
		/// Sending perfocard to server
		/// </summary>
		/// <param name="skladName"> Name of sklad </param>
		/// <param name="clientAndCostList"> List (0: Client1, 1: Cost1, 2: Client2 ...) </param>
		/// <returns></returns>
		public static bool SendPerfocard(string skladName, List<string> clientAndCostList)
		{
			try
			{

				string serverIp;
				GLOBAL.SysLog.WriteInfom("Sending repfocard data");
				if (Database.EXEC_Reader("select ppoValue from tblPpcOptions where ppoVariable = 'UpdateURL' "))
				{
					var value = Database.EXEC_GetRead();
					serverIp = value[0];
				}
				else
				{
					serverIp = "93.157.24.7:21000";
					GLOBAL.SysLog.WriteError("Error get serverUrl from database. Set default serverUrl:" + serverIp);
				}
				Database.EXEC_CloseReader();

				UpdateClient.CompleteDownloadFile += (ClientCompleteDownloadFile);
				UpdateClient.ErrorDownloadFile += (ClientErrorDownloadFile);
				UpdateClient.ErrorIncomingMessage += (ClientErrorIncomingMessage);
				UpdateClient.IncomingMessage += (ClientIncomingMessage);
				UpdateClient.ProgressDownloadFile += (ClientProgressDownloadFile);
				UpdateClient.StartDownloadFile += (ClientStartDownloadFile);
				UpdateClient.PathToSaveTmpFile = @"\Program Files\iTraderClient2\Update";

				int serverPort = 0;
				try
				{
					serverPort = Int32.Parse(serverIp.Split(':')[1]);
					serverIp = serverIp.Split(':')[0];
				}
				catch (Exception)
				{
					MessageBox.Show("Error connect to " + serverIp + " port:" + serverPort);
					GLOBAL.SysLog.WriteError("Cen't connect to update host");
					return false;
				}

				if (!UpdateClient.Connect(serverIp, 21000, false))
				{
					MessageBox.Show("Error connect to " + serverIp);
					GLOBAL.SysLog.WriteError("Cen't connect to update host");
					return false;
				}
				Thread.Sleep(1500);

				UpdateClient.SendMessage(Encoding.ASCII.GetBytes("set_user_id:" + GLOBAL.UserInfo.Number + ";"));

				GLOBAL.Status.Status = "Отправка перфокарты";

				string sendingData = string.Empty;
				sendingData += skladName + ";";

				foreach (var clientAndCost in clientAndCostList)
				{
					sendingData += clientAndCost + ";";
				}

				UpdateClient.SendMessage(Encoding.ASCII.GetBytes("set_perfocard:" + sendingData + ";"));

				UpdateClient.Disconnect();
				GLOBAL.Status.Percentage = 0;
				GLOBAL.Status.Status = "Обновление завершено";
				return true;
			}
			catch (Exception ex)
			{
				GLOBAL.SysLog.WriteError("Error send perfocard. info: "+ex);
				return false;
			}
		}


		static void ClientStartDownloadFile()
		{

		}

		static void ClientProgressDownloadFile(int persentOfDownloadFile)
		{
			//GLOBAL.Status.Percentage = persentOfDownloadFile;
			Status.UpdateStatus(_downloadFileName, persentOfDownloadFile);
			//GLOBAL.Status.Status = "Запрос на обновление";
		}

		static void ClientIncomingMessage(byte[] message)
		{
			_waitingIncomingMessage = false;
			_incomingMessage = Encoding.ASCII.GetString(message, 0, message.Length);
		}

		static void ClientErrorIncomingMessage(string message)
		{
			_waitingIncomingMessage = false;
			GLOBAL.SysLog.WriteError("Updater system. ErrorIncomingMessage:" + message);
		}

		static void ClientErrorDownloadFile(string message)
		{
			_waitingDonwloadFile = false;
			GLOBAL.SysLog.WriteError("Updater system. ErrorDownloadFile:" + message);
		}

		static void ClientCompleteDownloadFile(string fileName)
		{
			_downloadFile = fileName;
			_waitingDonwloadFile = false;
			GLOBAL.SysLog.WriteInfom("Updater system. CompleteDownloadFile:" + fileName);
		}

		static bool WaitMessage()
		{
			_waitingIncomingMessage = true;
			var stopwatch = new MyStopwatch();
			stopwatch.Start();

			while (stopwatch.ElapsedMilliseconds < 5000)
			{
				Thread.Sleep(100);
				if (!_waitingIncomingMessage) break;
			}
			stopwatch.Stop();

			if (_waitingIncomingMessage)
			{
				return false;
			}
			return true;
		}

		static bool WaitDownloadFile()
		{
			_waitingDonwloadFile = true;
			var stopwatch = new MyStopwatch();
			stopwatch.Start();

			while (stopwatch.ElapsedMilliseconds < 1000 * 60)
			{
				Thread.Sleep(1000);
				if (!_waitingDonwloadFile) break;
			}
			stopwatch.Stop();

			if (_waitingDonwloadFile)
			{
				return false;
			}
			return true;
		}

	}
}
