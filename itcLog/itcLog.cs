using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace itcLog
{
	public enum MessageType
	{
		Information, Warning, Error
	}

	internal class Translit
	{
		public char Run { get; set; }
		public string Eng { get; set; }
	}

	public class Log
	{
		private string _logFile = string.Empty;
		private long _maxLen = 1000*1024;

		public bool Initialization(string logFile, long maxLen)
		{
			try
			{
				_maxLen = maxLen;
				_logFile = logFile;
				if (!File.Exists(_logFile))
				{
					Write(@"Initialize log file", MessageType.Information);
				}
			}
			catch (Exception)
			{
				_logFile = string.Empty;
				return false;
			}

			return true;
		}

        public string ReadAll()
        {
            string data = string.Empty;
            try
            {
                TextReader tr = new StreamReader(_logFile, Encoding.UTF8);
                data = tr.ReadToEnd();
                tr.Close();
            }
            catch 
            {
                throw new Exception("Error read log file!");
            }

            return data;
        }

		public string Write(string message, MessageType messageType)
		{
            string addMessage = string.Empty;
            Encoding enc = Encoding.ASCII;
			var russCharList = new List<Translit>();

			russCharList.Add(new Translit { Run = 'й', Eng = "y" }); russCharList.Add(new Translit { Run = 'о', Eng = "o" });
			russCharList.Add(new Translit { Run = 'ц', Eng = "c'" }); russCharList.Add(new Translit { Run = 'л', Eng = "l" });
			russCharList.Add(new Translit { Run = 'у', Eng = "u" }); russCharList.Add(new Translit { Run = 'д', Eng = "d" });
			russCharList.Add(new Translit { Run = 'к', Eng = "k" }); russCharList.Add(new Translit { Run = 'ж', Eng = "j" });
			russCharList.Add(new Translit { Run = 'е', Eng = "e" }); russCharList.Add(new Translit { Run = 'э', Eng = "e" });
			russCharList.Add(new Translit { Run = 'н', Eng = "n" }); russCharList.Add(new Translit { Run = 'я', Eng = "ya" });
			russCharList.Add(new Translit { Run = 'г', Eng = "g" }); russCharList.Add(new Translit { Run = 'ч', Eng = "ch" });
			russCharList.Add(new Translit { Run = 'ш', Eng = "sh" }); russCharList.Add(new Translit { Run = 'с', Eng = "c" });
			russCharList.Add(new Translit { Run = 'щ', Eng = "sh'" }); russCharList.Add(new Translit { Run = 'м', Eng = "m" });
			russCharList.Add(new Translit { Run = 'з', Eng = "z" }); russCharList.Add(new Translit { Run = 'и', Eng = "i" });
			russCharList.Add(new Translit { Run = 'х', Eng = "h" }); russCharList.Add(new Translit { Run = 'т', Eng = "t" });
			russCharList.Add(new Translit { Run = 'ъ', Eng = "'" }); russCharList.Add(new Translit { Run = 'ь', Eng = "'" });
			russCharList.Add(new Translit { Run = 'ф', Eng = "f" }); russCharList.Add(new Translit { Run = 'б', Eng = "b" });
			russCharList.Add(new Translit { Run = 'ы', Eng = "i" }); russCharList.Add(new Translit { Run = 'ю', Eng = "u" });
			russCharList.Add(new Translit { Run = 'в', Eng = "v" }); russCharList.Add(new Translit { Run = 'а', Eng = "a" }); 
			russCharList.Add(new Translit { Run = 'п', Eng = "p" }); russCharList.Add(new Translit { Run = 'р', Eng = "r" });
			

            try
            {

                switch (messageType)
                {
                    case MessageType.Information:
                        addMessage = "[..] ";
                        break;
                    case MessageType.Warning:
                        addMessage = "[!!] ";
                        break;
                    case MessageType.Error:
                        addMessage = "[EE] ";
                        break;
                }
                addMessage += DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + " > " + message + ";\n";

				// fix rus sumbol
            	string buf = string.Empty;
            	for (int i = 0; i < addMessage.Length; i++)
            	{
            		bool exist = false;
            		foreach (var translit in russCharList)
            		{
						if (addMessage[i] == translit.Run)
						{
							buf += translit.Eng;
							exist = true;
						}
            		}
					if (!exist) buf += addMessage[i];
            	}
            	addMessage = buf;


                if (File.Exists(_logFile))
                {
                    var fileInfo = new FileInfo(_logFile);
                    if (fileInfo.Length > _maxLen) Clear();
                }

                byte[] buffer = enc.GetBytes(addMessage);
                FileStream outFile = !File.Exists(_logFile) ? File.Open(_logFile, FileMode.OpenOrCreate, FileAccess.ReadWrite) : File.Open(_logFile, FileMode.Append, FileAccess.Write);
                outFile.Write(buffer, 0, buffer.Length);
                outFile.Close();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return null;
		}

		public bool Clear()
		{
			File.Open(_logFile, FileMode.Truncate).Close();
			return true;
		}

	}


}
