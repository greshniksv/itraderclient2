using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace itcConfig3
{
	/// <summary>
	/// Item of config file
	/// </summary>
	public class ConfigItem
	{
		public ConfigItem() { }

		public ConfigItem(string variable, string value, bool isComment)
		{
			Variable = variable;
			Value = value;
			IsComment = isComment;
		}

		public bool IsComment { get; set; }

		public string Variable { get; set; }

		public string Value { get; set; }
	}

	/// <summary>
	/// Section item of config file
	/// </summary>
	internal class SectionItem
	{
		public string Name { get; set; }
		private List<ConfigItem> _configItemList = new List<ConfigItem>();
		public List<ConfigItem> ConfigItemList
		{
			get { return _configItemList; }
			set { _configItemList = value; }
		}
	}

	/// <summary>
	/// Class for work wish config file
	/// </summary>
	public static class Config
	{
		private static string _configFile;
		private static TextReader _textReader;
		private static TextWriter _textWriter;
		private static readonly List<SectionItem> SectionItemList = new List<SectionItem>();

		/// <summary>
		/// Initialize and load config file
		/// </summary>
		/// <param name="configFile"> Path to config file </param>
		public static void Initialization(string configFile)
		{
			if (configFile.Length < 2)
			{ throw new Exception("Minimum name size 3 symbol"); }

			if (!Directory.Exists(Path.GetDirectoryName(configFile)))
			{ throw new Exception("Not existing folder [" + Path.GetDirectoryName(configFile) + "]"); }


			_configFile = configFile;
			LoadingConfig();
		}

		private static void Create()
		{
			try
			{
				_textWriter = new StreamWriter(_configFile, false);
				_textWriter.WriteLine("### Config file created " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " ###\n");
				_textWriter.Close();
			}
			catch (Exception ex)
			{
				throw new Exception("ERROR CREATE CONFIG FILE [" + _configFile + "] \n " + ex);
			}
		}

		private static string ReadBetween(string data, char start, char stop)
		{
			string buffer = string.Empty;

			bool read = false;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] == stop) return buffer;
				if (read) buffer += data[i];
				if (data[i] == start) read = true;
			}
			return null;
		}

		private static ConfigItem ReadConfigItem(string data)
		{
			var buffer = new ConfigItem(data.Substring(0, data.IndexOf('=')).Trim(),
			data.Substring(data.IndexOf('=') + 1, data.Length - (data.IndexOf('=') + 1)).Trim(), false);
			return buffer;
		}


		private static void LoadingConfig()
		{
			if (!File.Exists(_configFile)) Create();

			_textReader = new StreamReader(_configFile);

			string buffer;
			var configItemList = new List<ConfigItem>();
			string sectionName = "default";
			while ((buffer = _textReader.ReadLine()) != null)
			{
				// ---- Read comment -------------
				if (buffer.IndexOf('#') != -1)
				{
					configItemList.Add(new ConfigItem { IsComment = true, Variable = null, Value = buffer.Trim() });
				}

				// ---- Read config item -------------
				if (buffer.IndexOf('=') != -1)
				{
					configItemList.Add(ReadConfigItem(buffer));
				}

				// ---- Read section item -------------
				if (buffer.IndexOf('[') != -1)
				{
					var sectionItem = new SectionItem { ConfigItemList = configItemList, Name = sectionName.Trim() };
					SectionItemList.Add(sectionItem);

					sectionName = ReadBetween(buffer, '[', ']').Trim();
					configItemList = new List<ConfigItem>();
				}
			}

			if (configItemList.Count > 0)
			{
				var sectionItem = new SectionItem { ConfigItemList = configItemList, Name = sectionName };
				SectionItemList.Add(sectionItem);
			}

			_textReader.Close();
		}

		public static void SaveConfig()
		{
			_textWriter = new StreamWriter(_configFile, false);
			//_textWriter.WriteLine("### Config file created " + DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " ###\n");

			foreach (var sectionItem in SectionItemList)
			{
				if (sectionItem.Name != "default")
				{
					_textWriter.WriteLine("\n\n[" + sectionItem.Name + "]");
				}

				foreach (var configItem in sectionItem.ConfigItemList)
				{
					if (configItem.IsComment) _textWriter.WriteLine(configItem.Value);
					else
					{
						_textWriter.WriteLine(configItem.Variable + " = " + configItem.Value);
					}
				}

			}

			_textWriter.Close();
		}

		/// <summary>
		/// Function for get list of section 
		/// </summary>
		/// <returns> return List with section name </returns>
		public static List<string> GetSectionList()
		{
			var sectionList = new List<string>();
			foreach (var sectionItem in SectionItemList)
			{
				sectionList.Add(sectionItem.Name);
			}
			return sectionList;
		}

		/// <summary>
		/// Function return the config item list
		/// </summary>
		/// <param name="section"> you mast set section name </param>
		/// <returns> return List of config item in section </returns>
		public static List<ConfigItem> GetConfigItemList(string section)
		{
			foreach (var sectionItem in SectionItemList)
			{
				if (sectionItem.Name != section) continue;
				return sectionItem.ConfigItemList;
			}
			return null;
		}

		/// <summary>
		/// Get variable from config
		/// </summary>
		/// <param name="variable"> variable name </param>
		/// <param name="defaultValue"> default value, if value not exist </param>
		/// <param name="section"> section name </param>
		/// <returns> string value </returns>
		public static string GetValue(string variable, string defaultValue, string section)
		{
			foreach (var sectionItem in SectionItemList)
			{
				if (sectionItem.Name.Trim() != section.Trim()) continue;
				foreach (var configItem in sectionItem.ConfigItemList)
				{
					if (configItem.Variable.Trim() == variable.Trim())
					{
						return configItem.Value;
					}
				}
			}

			SetValue(variable.Trim(), defaultValue.Trim(), section.Trim());

			return defaultValue;
		}

		/// <summary>
		/// Set variable to config 
		/// </summary>
		/// <param name="variable"> variable name </param>
		/// <param name="value"> value of variable </param>
		/// <param name="section"> section name </param>
		public static void SetValue(string variable, string value, string section)
		{
			bool exist = false;
			foreach (var sectionItem in SectionItemList)
			{
				if (sectionItem.Name.Trim() != section.Trim()) continue;
				foreach (var configItem in sectionItem.ConfigItemList)
				{
					if (configItem.Variable.Trim() == variable.Trim())
					{
						configItem.Value = value.Trim();
						exist = true;
					}
				}
			}

			if (!exist)
			{
				// --- find section -----------
				if (GetSectionList().Contains(section))
				{
					foreach (var sectionItem in SectionItemList)
					{
						if (sectionItem.Name.Trim() != section.Trim()) continue;
						sectionItem.ConfigItemList.Add(new ConfigItem(variable.Trim(), value.Trim(), false));
						//return;
					}
				}
				else
				{
					// --- Create new section and new variable --------
					var sectionItem = new SectionItem { Name = section.Trim() };
					sectionItem.ConfigItemList.Add(new ConfigItem(variable.Trim(), value.Trim(), false));
					SectionItemList.Add(sectionItem);
				}
			}

			SaveConfig();
			return;
		}

		/// <summary>
		/// Get variable from config
		/// </summary>
		/// <param name="variable"> variable name </param>
		/// <param name="defaultValue"> default value, if value not exist </param>
		/// <returns> string value </returns>
		public static string GetValue(string variable, string defaultValue)
		{
			const string section = "default";

			foreach (var sectionItem in SectionItemList)
			{
				if (sectionItem.Name.Trim() != section.Trim()) continue;
				foreach (var configItem in sectionItem.ConfigItemList)
				{
					if (configItem.Variable.Trim() == variable.Trim())
					{
						return configItem.Value;
					}
				}
			}

			SetValue(variable.Trim(), defaultValue.Trim(), section.Trim());

			return defaultValue;
		}

		/// <summary>
		/// Set variable to config 
		/// </summary>
		/// <param name="variable"> variable name </param>
		/// <param name="value"> value of variable </param>
		public static void SetValue(string variable, string value)
		{
			const string section = "default";

			bool exist = false;
			foreach (var sectionItem in SectionItemList)
			{
				if (sectionItem.Name.Trim() != section.Trim()) continue;
				foreach (var configItem in sectionItem.ConfigItemList)
				{
					if (configItem.Variable.Trim() == variable.Trim())
					{
						configItem.Value = value;
						exist = true;
					}
				}
			}

			if (!exist)
			{
				// --- find section -----------
				if (GetSectionList().Contains(section))
				{
					foreach (var sectionItem in SectionItemList)
					{
						if (sectionItem.Name.Trim() != section.Trim()) continue;
						sectionItem.ConfigItemList.Add(new ConfigItem(variable.Trim(), value.Trim(), false));
						//return;
					}
				}
				else
				{
					// --- Create new section and new variable --------
					var sectionItem = new SectionItem { Name = section.Trim() };
					sectionItem.ConfigItemList.Add(new ConfigItem(variable.Trim(), value.Trim(), false));
					SectionItemList.Add(sectionItem);
				}
			}

			SaveConfig();
			return;
		}


		private static new bool Equals(object obj)
		{
			return false;
		}

		private static new int GetHashCode()
		{
			return 0;
		}

		private static new string ToString()
		{
			return null;
		}
	}

}
