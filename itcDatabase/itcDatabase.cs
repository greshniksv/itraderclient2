using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.SqlServerCe;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using itcClassess;
using itcInterface;


namespace itcDatabase
{
    public delegate void DbStatusUpdatedDelegate();
	delegate void DbStatusDelegate();


	public static class Database
	{       
        // Events
		public static event DbStatusUpdatedDelegate DbStatusUpdated;
		
		private const string DefDbFile = @"\Program Files\iTraderClient2\Database\itdb.client.sdf";
		private const string DefInternetUrl = @"http://194.146.135.170:6666/itdb/sqlcesa35.dll";
		private const string DefPublisher = @"itradersql";
		private const string DefPublication = @"itdbPubl";
		private const string DefPublisherDatabase = @"itdb.server";
		public static string LastException { get; set; }

		private static SqlCeConnection _dbConnection;
		private static SqlCeCommand _dbCmd;
		private static SqlCeCommand _dbTransCmd;
		private static SqlCeTransaction _dbTrans;
		private static SqlCeReplication _repl;
		private static string _dbFileName = string.Empty;
		private static SqlCeDataReader _sqlCeDataReader;

		public static void SetDatabaseFile(string fileName)
		{
			_dbFileName = fileName;

            try
            {
                _dbConnection = new SqlCeConnection("Data Source = \"" + _dbFileName + "\"");
            }

            catch (SqlCeException err)
            {
                GLOBAL.SysLog.WriteError(@"error connect to database ex:" + err);
            }

		}

		public static void Connect()
		{
			if (_dbConnection.State == ConnectionState.Closed)
			{
				try
				{
					_dbConnection.Open();
					_dbCmd = _dbConnection.CreateCommand();
				}

				catch (SqlCeException err)
				{
                    MessageBox.Show("Error connect to database:" + err.Message);
					GLOBAL.SysLog.WriteError(@"error connect to database ex:" + err);
				}
			}
			else
			{
				GLOBAL.SysLog.WriteWarning(@"Already connected to database");
			}
		}

		public static void Disconnect()
		{
			GLOBAL.SysLog.WriteWarning(@"Disconnect from database");
			if (_dbConnection.State == ConnectionState.Open)
			{
				try
				{
					_dbCmd.Dispose();
					_dbConnection.Close();
				}

				catch (SqlCeException err)
				{
					GLOBAL.SysLog.WriteError(@"Error disconnect from database ex:"+err);
				}

			}
			else
			{
				GLOBAL.SysLog.WriteWarning(@"Disconnect error. There is no connection to database");
			}
		}

		public static void SyncCompletedCallback(IAsyncResult ar)
		{
			try
			{
				var repl = (SqlCeReplication)ar.AsyncState;

				repl.EndSynchronize(ar);
				repl.SaveProperties();

				// Release unusable resources
				repl.Dispose();
				Connect();
				GLOBAL.SysLog.WriteInfom(@"Sync complete");
                Status.UpdateStatus("Синхронизация завершена");
                if (DbStatusUpdated != null)
                    DbStatusUpdated();
			}

			catch (SqlCeException err)
			{
				GLOBAL.SysLog.WriteInfom(@"Sync complete");
				Status.UpdateStatus("Синхронизация завершена");
                if (DbStatusUpdated != null)
                    DbStatusUpdated();
				GLOBAL.SysLog.WriteError(@"Error database sync. ex:" + err);
				MessageBox.Show(err + " \nSyncCompletedCallback. \n Error database sync");
				Thread.Sleep(2000);
			}

			finally
			{
				GLOBAL.SysLog.WriteInfom(@"Sync complete");
                Status.UpdateStatus("Синхронизация завершена");

				//DatabaseService.Updating();
                //Updater.TryToUpdate();
			}

			// reinit plugin list
			foreach (var plugin in GLOBAL.PluginList.PluginList)
			{
				plugin.RefreshData();
			}
		}

		public static void OnStartTableDownloadCallback(IAsyncResult ar, string tableName)
		{
            Status.UpdateStatus("Загрузка таблицы " + tableName);
		}

		public static void OnStartTableUploadCallback(IAsyncResult ar, string tableName)
		{
            Status.UpdateStatus("Отправка таблицы " + tableName);
		}

		public static void OnSynchronizationCallback(IAsyncResult ar, int percentComplete)
		{
			GLOBAL.Status.Percentage = percentComplete;
            Status.UpdateStatus("Синхронизация", percentComplete);
		}

		private static void Replicate()
		{
			try
			{
				var hwr = (HttpWebRequest)WebRequest.Create(GLOBAL.CONFIG.GetValue("InternetUrl", DefInternetUrl, "Replication"));   //new HttpWebRequest();
				var response = (HttpWebResponse)hwr.GetResponse();
                Status.UpdateStatus("Статус соединения: " + response.StatusDescription);
                //if (DbStatusUpdated != null)
                //    DbStatusUpdated();
				response.Close();

				_repl = new SqlCeReplication
				{
					SubscriberConnectionString = "Data Source=\"" + _dbFileName + "\""
				};

				if (!File.Exists(_dbFileName))
				{
					// Create new subscription if no database is available
					_repl.AddSubscription(AddOption.CreateDatabase);
					_repl.InternetUrl = GLOBAL.CONFIG.GetValue("InternetUrl", DefInternetUrl,"Replication");
					_repl.Publisher = GLOBAL.CONFIG.GetValue("Publisher", DefPublisher, "Replication");
					_repl.PublisherDatabase = GLOBAL.CONFIG.GetValue("PublisherDatabase", DefPublisherDatabase, "Replication");
					_repl.PublisherSecurityMode = SecurityType.NTAuthentication;
					_repl.Publication = GLOBAL.CONFIG.GetValue("Publication", DefPublication, "Replication");
					_repl.Subscriber = (GLOBAL.UserInfo.Name == string.Empty) ? "[Unnamed]" : GLOBAL.UserInfo.Name;
					_repl.ExchangeType = ExchangeType.BiDirectional;
					_repl.HostName = GLOBAL.CONFIG.GetValue("UserId","0" ,"Main");

				}
				else
				{
					// Load previously created subscription
					_repl.LoadProperties();
				}

				_repl.BeginSynchronize
				(
                    (SyncCompletedCallback),
                    new OnStartTableUpload(OnStartTableUploadCallback),
                    (OnStartTableDownloadCallback),
                    (OnSynchronizationCallback),
					_repl
				);

                GLOBAL.CONFIG.SetValue("DateSync", DateTime.Now.ToString("yyyy-MM-dd"), "Main");
			}
			catch (Exception ex)
			{
				GLOBAL.SysLog.WriteError(@"Error database replicate. ex:" + ex);
                //MessageBox.Show(ex.ToString());
                Status.UpdateStatus("Ошибка! Нет подключения к серверу!");
                DialogResult result;
                MessageBox.Show("Перезагрузите телефон и КПК и попробуйте еще", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                result = MessageBox.Show("Перезапустить КПК?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    Disconnect();
                    ResetDevice RD = new ResetDevice();
                    RD.Run();
                }
               
                if (DbStatusUpdated != null)
                    DbStatusUpdated();
			}
			
		}

		public static void InitDatabase()
		{
			GLOBAL.SysLog.WriteWarning("Start database initialization.");
            Status.UpdateStatus("Подготовка к инициализации");
			Thread.Sleep(500);

			try
			{
				Disconnect();
				if (File.Exists(_dbFileName))
					File.Delete(_dbFileName);
				Replicate();
			}

			catch (Exception err)
			{
				GLOBAL.SysLog.WriteError(@"Error init database. ex:" + err);
                Status.UpdateStatus("Синхронизация завершена");
			}
		}

		public static void Sync()
		{
			GLOBAL.SysLog.WriteInfom("Start database sync");
            Status.UpdateStatus("Подготовка к синхронизации");
			Replicate();
		}

		public static bool Connected()
		{
			return _dbConnection.State == ConnectionState.Open;
		}


        public static int EXEC_RowCount(string table)
        {
			if (_dbConnection.State == ConnectionState.Closed)
			{
				GLOBAL.SysLog.WriteError("EXEC_RowCount. DB is closed. Try exec sql: " + string.Format(@"SELECT COUNT(*) FROM {0}", table));
				MessageBox.Show("DB is closed. Try exec sql: " + string.Format(@"SELECT COUNT(*) FROM {0}", table), "Error");
				return -1;
			}

            return (int)EXEC_ExecuteScalar(string.Format(@"SELECT COUNT(*) FROM {0}", table));
        }

		public static bool EXEC_Reader(string sql)
		{
			if (_dbConnection.State == ConnectionState.Closed)
			{
				GLOBAL.SysLog.WriteError("EXEC_Reader. DB is closed. Try exec sql: " + sql);
				MessageBox.Show("DB is closed. Try exec sql: " + sql, "Error");
				return false;
			}

			try
			{
				_dbCmd.CommandText = sql;
				_sqlCeDataReader = _dbCmd.ExecuteReader();
			}
			catch (Exception ex)
			{
				GLOBAL.SysLog.WriteError("Error execute query: " +sql+ " \nEx:"+ex);
				return false;
			}
			
            return true;
		}

		public static List<string> EXEC_GetRead()
		{
			try
			{
				var buffer = new List<string>();

				if (_sqlCeDataReader.Read())
				{
					for (int i = 0; i < _sqlCeDataReader.FieldCount; i++)
					{
						buffer.Add(_sqlCeDataReader[i].ToString());
					}
				}
				else return null;

				return buffer;
			}
			catch (Exception ex)
			{
				GLOBAL.SysLog.WriteError("Error run exec read. " + " \nEx:" + ex);
				return null;
			}
			
		}

        public static List<object> EXEC_rdrReadObjects()
        {
            var buffer = new List<object>();

            if (_sqlCeDataReader.Read())
            {
                for (int i = 0; i < _sqlCeDataReader.FieldCount; i++)
                {
                    buffer.Add(_sqlCeDataReader[i]);
                }
            }
            else return null;

            return buffer;
        }

		public static void EXEC_CloseReader()
		{
            if (_sqlCeDataReader != null && !_sqlCeDataReader.IsClosed)
			    _sqlCeDataReader.Close();
		}

		public static void EXEC_SqlNonQuery(string sql)
		{
			if (_dbConnection.State == ConnectionState.Closed)
			{
				GLOBAL.SysLog.WriteError("EXEC_SqlNonQuery. DB is closed. Try exec sql: " + sql);
				MessageBox.Show("DB is closed. Try exec sql: " + sql, "Error");
				return;
			}

		    _dbCmd.CommandText = sql;
		    _dbCmd.ExecuteNonQuery();
		}

        public static object EXEC_ExecuteScalar(string sql, bool skipErrors)
        {
			if (_dbConnection.State == ConnectionState.Closed)
			{
				GLOBAL.SysLog.WriteError("EXEC_ExecuteScalar. DB is closed. Try exec sql: " + sql);
				MessageBox.Show("DB is closed. Try exec sql: " + sql, "Error");
				return null;
			}

        	try
            {
                _dbCmd.CommandText = sql;
                return _dbCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                if (!skipErrors)
                    MessageBox.Show(ex.Message+"\nsql:"+sql, "Error during execute query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                GLOBAL.SysLog.WriteError("Error during executeScalar. \nsql:"+sql+" \nex:"+ex);
                return null;
            }
        }

        public static object EXEC_ExecuteScalar(string sql)
        {
            return Database.EXEC_ExecuteScalar(sql, true);
        }

        public static DataSet EXEC_GetDataSet(string sql, string tblName)
        {
            var ds = new DataSet();
            var da = new SqlCeDataAdapter(sql, _dbConnection);
            da.Fill(ds, tblName);
            return ds;
        }

        public static void FillDataGrid(DataGrid dg, DataSet ds, string tblName, string sql)
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, _dbConnection);
                ds.Clear();               
                da.Fill(ds, tblName);
                dg.DataSource = ds.Tables[0].DefaultView;
            }
        }

        public static void SetBindingSource(BindingSource bs, DataSet ds, string tblName, string sql)
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, _dbConnection);
                ds.Clear();
                da.Fill(ds, tblName);
                bs.DataSource = ds.Tables[0];
                // Это нужно вызывать при смене DataSource
               // bs.ResetBindings(false);
            }
        }

		// ========================================
		// Sql command Transaction
		// ========================================

		public static void TRANS_Begin()
		{
			_dbTransCmd = _dbConnection.CreateCommand();
            _dbTrans = _dbConnection.BeginTransaction();
            _dbTransCmd.Transaction = _dbTrans;
		}

		public static bool TRANS_Exec(string sql)
		{
			if (_dbConnection.State == ConnectionState.Closed)
			{
				GLOBAL.SysLog.WriteError("DB is closed. Try exec sql: " + sql);
				MessageBox.Show("TRANS_Exec. DB is closed. Try exec sql: " + sql, "Error");
				return false;
			}

			try
			{
				_dbTransCmd.CommandText = sql;
				_dbTransCmd.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message);
				LastException = ex.ToString();
				return false;
			}
			return true;
		}

		public static void TRANS_Commit()
		{
			_dbTrans.Commit();
		}

		public static void TRANS_Abort()
		{
			_dbTrans.Commit();
        }

        #region Good Style
        public static string GetUrlForPrintCheques()
        {
            string query = "SELECT ppoValue FROM tblPpcOptions WHERE ppoVariable = 'wsPrintChequesUrl'";
            return (string)EXEC_ExecuteScalar(query);
        }
        #endregion
    }

}
