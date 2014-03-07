using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using itcLog;
using itcInterface;
using System.Windows.Forms;
using System.Drawing;

namespace itcClassess
{
    public delegate void UpdateStatusHandler (object sender, int persantag, string text);
	public delegate void DbStatusUpdatedDelegate();
    public delegate void NotifyHandler();
	delegate void DbStatusDelegate();

	/// <summary>
	/// Global class, for any access
	/// </summary>
	public static class GLOBAL
	{
        public static Form mainForm;
		public static Config CONFIG = new Config();
		public static Logs SysLog = new Logs();
		public static User UserInfo = new User();
		public static StatusInfo Status = new StatusInfo();
		public static Plugin PluginList = new Plugin();
        public static string TempOrderPath = @"\Program Files\iTraderClient2\Database\OrderTemp.xml";
        public static string UrlForPrintCheques;
		public static bool MainFormAuthentificate=false;
	}


    /// <summary>
	/// Class for combo box item, contained VALUE and NAME. ToString() return NAME.
	/// </summary>
	public class ComboBoxItem
	{
		public string Id { get; set; }
		public string Name { get; set; }

        public ComboBoxItem(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

		public override string ToString()
		{
			return Name;
		}
	}



	/// <summary>
	/// Status inform class
	/// </summary>
	public class StatusInfo
	{
		private event DbStatusUpdatedDelegate DbStatusUpdated;
		readonly Form _invokeForm = new Form();
		public delegate void InvokeEventHandler();
		public event InvokeEventHandler Invoke;
		private string _status;
		private int _presentage;

		public string Status 
		{ 
			get { return _status; } 
			set {
					_status = value; 
					var statusDelegate = new DbStatusDelegate(Invoke);
					_invokeForm.Invoke(statusDelegate, new object[] { });
				}	 
		}
		
		public int Percentage
		{
			get { return _presentage; } 
			set
			{
				_presentage = value;
				var statusDelegate = new DbStatusDelegate(Invoke);
				_invokeForm.Invoke(statusDelegate, new object[] { }); 
			}
		}

		public override string ToString()
		{
			return (_presentage > 0 ? "[" + _presentage + "%] " : "") + _status;
		}
	}



	/// <summary>
	/// User info
	/// </summary>
	public class User
	{
        private string _name = "";
        private string _number = "";

		public string Number 
        {
            get { return _number; }
            set { _number = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
	}



	/// <summary>
	/// Log menegment class
	/// </summary>
	public class Logs
	{
		private readonly Log _log = new Log();

		public bool Initialization(string logFile, long maxLen)
		{
			return _log.Initialization(logFile, maxLen);
		}

		public string WriteInfom(string message)
		{
			return _log.Write(message, MessageType.Information);
		}

        public string ReadAll()
        {
            return _log.ReadAll();
        }

		public string WriteWarning(string message)
		{
			return _log.Write(message, MessageType.Warning);
		}

		public string WriteError(string message)
		{
			return _log.Write(message, MessageType.Error);
		}

		public bool Clear()
		{
			return _log.Clear();
		}

	}

	/// <summary>
	/// Config menegment class
	/// </summary>
	public class Config
	{
		public void Initialization(string configFile)
		{
			itcConfig3.Config.Initialization(configFile);
		}

		public string GetValue(string variable, string defaultValue, string section)
		{
			return itcConfig3.Config.GetValue(variable, defaultValue, section);
		}

		public void SetValue(string variable, string value, string section)
		{
			itcConfig3.Config.SetValue(variable, value, section);
		}
	}


	/// <summary>
	/// Plugin collection
	/// </summary>
	public class Plugin
	{
		private List<IPlugin> _pluginList = new List<IPlugin>();

		public List<IPlugin> PluginList
		{
			get { return _pluginList; }
			set { _pluginList = value; }
		}

		public int Load()
		{
			GLOBAL.SysLog.WriteInfom("Loading application plugins");
			string pluginDir = GLOBAL.CONFIG.GetValue(@"AppPluginsDir", @"\Program Files\iTraderClient2\Plugins", "Main");
			if(!Directory.Exists(pluginDir))
			{
				Directory.CreateDirectory(pluginDir);
			}

			string[] files = Directory.GetFiles(pluginDir);
			GLOBAL.SysLog.WriteInfom("Found " + files.Length + " files in application plugins directory");

			// Read each file in plugin directory
			foreach (string file in files)
			{

				// Load assembly from file
				GLOBAL.SysLog.WriteInfom("Loading " + file);
				System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom(file);
                
				Type[] assemblyTypes = assembly.GetTypes();
				bool isPlugin = false;

				foreach (var assemblyType in assemblyTypes)
				{
                    if (assemblyType.GetInterfaces().Length > 0 && assemblyType.GetInterfaces()[0].Name == "IPlugin" && assemblyType.GetInterfaces()[0] != null)
					{
                        object appObj = assembly.CreateInstance(assemblyType.FullName);
                        var app = appObj as IPlugin;
                        
						// Put that instance to application plugins collection
						_pluginList.Add(app);
						isPlugin = true;
						break;
					}
				}
					
				if (!isPlugin) GLOBAL.SysLog.WriteInfom(file + " is not IPlugin");


			}

			return _pluginList.Count;
		}

        public void RefreshData()
        {
			for (int i = 0; i < PluginList.Count; i++)
        	{
				//if (PluginList[i] != null) PluginList[i].RefreshData();
        	}
        }
    }


	
	/// <summary>
	/// My Stopwatch. Timer.
	/// </summary>
	public class MyStopwatch
	{
		public MyStopwatch()
		{
			ElapsedMilliseconds = 0;
		}

		public long ElapsedMilliseconds { get; set; }
		private Thread _tick;
		private const int TickTime = 10;
		private bool _pause;

		public void Start()
		{
			_tick = new Thread(TickThread);
			_tick.Start();
		}

		public void Stop()
		{
			_tick.Abort();
		}

		public void Pause()
		{
			_pause = !_pause;
		}

		public void Reset()
		{
			ElapsedMilliseconds = 0;
		}

		private void TickThread()
		{
			while (true)
			{
				ElapsedMilliseconds += TickTime;
				Thread.Sleep(TickTime);
			}
		}
	}

	public static class MD5_HASH
	{
		public static string GetMd5HashFromFile(string fileName)
		{
			if (fileName.ToLower().IndexOf("pid")!=-1)
			{
				return "00000000000000000000000000000000";
			}

			try
			{
				var file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				MD5 md5 = new MD5CryptoServiceProvider();
				byte[] retVal = md5.ComputeHash(file);
				file.Close();

				var sb = new StringBuilder();
				for (int i = 0; i < retVal.Length; i++)
				{
					sb.Append(retVal[i].ToString("x2"));
				}
				return sb.ToString();
			}
			catch (Exception ex)
			{
				GLOBAL.SysLog.WriteError("Error get MD5 hash for file: "+fileName+". \nex:"+ex);
				return "00000000000000000000000000000000";
			}
		}
	}

    public static class GlobalVariables
    {
        private static int iconsize = 0;
        public static int GetIconSize()
        {
            if (iconsize > 0)
                return iconsize;
            iconsize = 16;
            // ~ 320 x 240
            if (Math.Abs(Screen.PrimaryScreen.Bounds.Width - 240) <= 50 && Math.Abs(Screen.PrimaryScreen.Bounds.Height - 320) <= 50)
                iconsize = 16;
            // ~ 800 x 480
            else if (Math.Abs(Screen.PrimaryScreen.Bounds.Width - 480) <= 50 && Math.Abs(Screen.PrimaryScreen.Bounds.Height - 800) <= 50)
                iconsize = 32;

            return iconsize;
        }
    }

	
	

}
