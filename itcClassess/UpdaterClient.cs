using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace itcClassess
{

	// File transfer delegate
	public delegate void StartDownloadFileEventHandler();
	public delegate void CompleteDownloadFileEventHandler(string fileName);
	public delegate void ProgressDownloadFileEventHandler(int persentOfDownloadFile);
	public delegate void ErrorDownloadFileEventHandler(string message);

	// Big message transfer delegate
	public delegate void IncomingMessageEventHandler(byte[] message);
	public delegate void ErrorIncomingMessageEventHandler(string message);

	public static class UpdateClient
	{

		public static Encoding Encodings = Encoding.ASCII;

		// File transfer events
		public static event StartDownloadFileEventHandler StartDownloadFile;
		public static event CompleteDownloadFileEventHandler CompleteDownloadFile;
		public static event ProgressDownloadFileEventHandler ProgressDownloadFile;
		public static event ErrorDownloadFileEventHandler ErrorDownloadFile;

		// Big messaga transfer events
		public static event IncomingMessageEventHandler IncomingMessage;
		public static event ErrorIncomingMessageEventHandler ErrorIncomingMessage;

		private static TcpClient _tcpClient = new TcpClient();
		public static NetworkStream TcpStream { get; set; }
		private static IPAddress _ipAddress;
		private static int _tcpPort;
		private static Thread _getIncomingDataThread;
		private static bool _getIncomingDataActive;
		private static int _autectification = -1;
		public static string PathToSaveTmpFile = string.Empty;




		public static string LastException { get; set; }
		public static bool UseCompression { get; set; }

		public static bool Connect(IPAddress ipAddress, int tcpPort, bool useCompression)
		{
			UseCompression = useCompression;
			try
			{
				_tcpClient.Connect((_ipAddress = ipAddress), (_tcpPort = tcpPort));
			}
			catch (Exception ex)
			{
				LastException = ex.ToString();
				return false;
			}

			TcpStream = _tcpClient.GetStream();
			_getIncomingDataThread = new Thread(GetIncomingData);
			_getIncomingDataThread.Start();

			var sw = new MyStopwatch();
			sw.Start();

			while (sw.ElapsedMilliseconds < 15000)
			{
				if (_autectification > -1) break;
				Thread.Sleep(100);
			}

			if (_autectification == -1)
				if (ErrorIncomingMessage != null)
					ErrorIncomingMessage("Server not response autentification");

			if (_autectification == 0)
				if (ErrorIncomingMessage != null)
					ErrorIncomingMessage("Server deny autentification");

			byte[] compressInfo = (UseCompression
									? Encoding.ASCII.GetBytes("[_tcs_use_compression]")
									: Encoding.ASCII.GetBytes("[_tcs_not_use_compression]"));
			NetworkSend(compressInfo, compressInfo.Length);

			return true;
		}


		public static bool Connect(string ipAddress, int tcpPort, bool useCompression)
		{
			UseCompression = useCompression;
			try
			{
				_tcpClient =_tcpClient ?? new TcpClient();

				//var entry = Dns.GetHostEntry(ipAddress);
				//ipAddress = entry.AddressList[0].ToString();

				_tcpClient.Connect(_ipAddress = IPAddress.Parse(ipAddress), (_tcpPort = tcpPort));
			}
			catch (Exception ex)
			{
				LastException = ex.ToString();
				return false;
			}

			TcpStream = _tcpClient.GetStream();
			_getIncomingDataThread = new Thread(GetIncomingData);
			_getIncomingDataThread.Start();

			var sw = new MyStopwatch();
			sw.Start();

			while (sw.ElapsedMilliseconds < 15000)
			{
				if (_autectification > -1) break;
				Thread.Sleep(100);
			}
			sw.Stop();

			if (_autectification == -1)
				if (ErrorIncomingMessage != null)
					ErrorIncomingMessage("Server not response autentification");

			if (_autectification == 0)
				if (ErrorIncomingMessage != null)
					ErrorIncomingMessage("Server deny autentification");

			byte[] compressInfo = (UseCompression
									? Encoding.ASCII.GetBytes("[_tcs_use_compression]")
									: Encoding.ASCII.GetBytes("[_tcs_not_use_compression]"));
			NetworkSend(compressInfo, compressInfo.Length);

			return true;
		}

		public static void Disconnect()
		{
			//TcpStream.Flush();
			TcpStream.Close();
			_tcpClient.Close();
			
			try
			{
			    _getIncomingDataThread.Abort();
			    //_getIncomingDataThread.Join();
			    _getIncomingDataThread = null;
			}
			catch { }
			
			//_getIncomingDataActive = false;
			_tcpClient = null;
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		
		

		public static void GetIncomingData()
		{
			NetworkStream tcpStream = TcpStream;
			_getIncomingDataActive = true;
			var message = new byte[1050];
			var ssMessage = Encoding.ASCII.GetBytes("");
			int blockCount = 0;

			// ---- Transfer file variables ---------------
			bool transferFile = false;
			FileStream fileStream = null;
			long fileSize = 0;
			long completeSize = 0;
			string fileName = string.Empty;
			int lastFileTransferPersent = 0;

			// ---- Transfer big message variables ---------------
			bool transferMessage = false;
			byte[] incomingMessage = null;
			long incomingMessageSize = 0;
			long writeCursorPosition = 0;

			// ---- Verification client ------------------
			bool transferData = false;
			var transferredData = new byte[512];


			while (true)
			{

				int bytesRead;

				try
				{
					bytesRead = tcpStream.Read(message, 0, 1050);
					Service.AddToEnd(ref ssMessage, ssMessage.Length, message, bytesRead);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Client: TCPStreamError. ex:" + ex);
					break;
				}

				if (bytesRead <= 0)
				{
					break;
				}


				// ---- execute incomming message 
				while (true)
				{
					if (ssMessage.Length < 5) break;
					bool ERROR = false;
					var iMessage = new byte[1024];
					try
					{
						// ---- block_len|DataOfBlock
						var block = Service.GetBlockLen(ssMessage);
						if (block < 1)
						{
							if (ErrorIncomingMessage != null)
								ErrorIncomingMessage("Error BLOCK sise < 0. Block: " + blockCount);
						}
						if (block + block.ToString().Length + 1 > ssMessage.Length) break;
						iMessage = Service.GetBlockMas(ssMessage, (block.ToString().Length + 1), block + (block.ToString().Length + 1));
						Service.CutMas(ref ssMessage, 0, block.ToString().Length + 1 + block);
						blockCount++;

					}
					catch (Exception ex)
					{
						if (ErrorIncomingMessage != null)
							ErrorIncomingMessage("Error pasre block message ex:" + ex);
						ERROR = true;
					}

					if (!ERROR)
					{


						// =============================================
						// Client autentification
						// =============================================

						// ---- Message with context: [_tcs_autentification: DATA]
						if (Encoding.ASCII.GetString(iMessage, 0, iMessage.Length).IndexOf("[_tcs_autentification_end]") != -1)
						{
							var rez = GreshnikCrypt.Crypt(transferredData, Encoding.ASCII.GetBytes("gClientServerSV©"), Encoding.ASCII.GetBytes("GreshnikSV©POISK"));
							NetworkSend(Encoding.ASCII.GetBytes("[_tcs_autentification_start]"), Encoding.ASCII.GetBytes("[_tcs_autentification_start]").Length);
							NetworkSend(rez, rez.Length);
							NetworkSend(Encoding.ASCII.GetBytes("[_tcs_autentification_end]"), Encoding.ASCII.GetBytes("[_tcs_autentification_end]").Length);
							GC.Collect();
							GC.WaitForPendingFinalizers();
							transferData = false;
						}


						if (transferData)
						{
							Service.MasCopy(iMessage, ref transferredData);
						}

						// ---- Message with context: [_tcs_autentification_start]
						if (Encoding.ASCII.GetString(iMessage, 0, iMessage.Length).IndexOf("[_tcs_autentification_start]") != -1)
						{
							transferData = true;
						}

						// ---- Message with context: [_tcs_autentification_success]
						if (Encoding.ASCII.GetString(iMessage, 0, iMessage.Length).IndexOf("[_tcs_autentification_success]") != -1)
						{
							_autectification = 1;
						}

						// ---- Message with context: [_tcs_autentification_fail]
						if (Encoding.ASCII.GetString(iMessage, 0, iMessage.Length).IndexOf("[_tcs_autentification_fail]") != -1)
						{
							_autectification = 0;
						}



						// =============================================
						// Function for transfer message
						// =============================================

						// ---- Message with context: [_tcs_message_end]
						if (Encoding.ASCII.GetString(iMessage, 0, iMessage.Length).IndexOf("_tcs_message_end") != -1)
						{
							incomingMessageSize = 0;
							writeCursorPosition = 0;
							transferMessage = false;

							if (UseCompression)
							{
								incomingMessage = QuickLZ.decompress(incomingMessage);
							}

							GC.Collect();
							GC.WaitForPendingFinalizers();

							if (IncomingMessage != null)
								IncomingMessage(incomingMessage);
							//_getIncomingDataActive = false;
							//return;
						}

						if (transferMessage)
						{
							for (int i = 0; i < iMessage.Length; i++)
							{
								if (writeCursorPosition < incomingMessageSize)
								{
									incomingMessage[writeCursorPosition] = iMessage[i];
									writeCursorPosition++;
								}
								else
								{
									incomingMessage.Initialize();
									incomingMessageSize = 0;
									writeCursorPosition = 0;
									transferMessage = false;
									if (ErrorIncomingMessage != null)
										ErrorIncomingMessage("To many byte for message.");
								}
							}
						}


						// ---- Message with context: [_tcs_message_start:(file_len)]
						if (Encoding.ASCII.GetString(iMessage, 0, iMessage.Length).IndexOf("_tcs_message_start:") != -1)
						{

							string tmpFileSize = Service.GetBetween(iMessage, ':', ']');
							if (tmpFileSize == null)
							{
								transferMessage = false;
								if (ErrorIncomingMessage != null)
									ErrorIncomingMessage("Error get incoming message size.");
							}
							else
							{
								bool existException = false;
								try
								{
									incomingMessageSize = Int32.Parse(tmpFileSize);
								}
								catch (Exception ex)
								{
									existException = true;
									transferMessage = false;
									if (ErrorIncomingMessage != null)
										ErrorIncomingMessage("Error convert string to int on incoming message size. [" + tmpFileSize + "]. ex:" + ex);
								}

								if (!existException)
								{
									transferMessage = true;
									incomingMessage = new byte[incomingMessageSize];
									incomingMessage.Initialize();
								}
							}
						}


						// =============================================
						// Function for transfer file 
						// =============================================

						// ---- Message with context: [_tcs_file_end]
						if (Encoding.ASCII.GetString(iMessage, 0, iMessage.Length).IndexOf("_tcs_file_end") != -1)
						{
							completeSize = 0;
							if (fileStream == null)
							{
								if (ErrorDownloadFile != null)
									ErrorDownloadFile("File stream is NULL");
							}
							else
							{
								fileStream.Close();
								var fileInfo = new FileInfo(fileName);
								if (fileInfo.Length < 1)
								{
									if (ErrorDownloadFile != null)
										ErrorDownloadFile("File size is 0 byte.");
									//_getIncomingDataActive = false;
									//return;
								}
								else
								{

									GC.Collect();
									GC.WaitForPendingFinalizers();
									transferFile = false;
									if (CompleteDownloadFile != null)
										CompleteDownloadFile(fileName);
									//_getIncomingDataActive = false;
									//return;
								}
							}
						}


						if (transferFile)
						{

							if (UseCompression)
							{
								iMessage = QuickLZ.decompress(iMessage);
							}


							fileStream.Write(iMessage, 0, iMessage.Length);
							completeSize += iMessage.Length;
							if (lastFileTransferPersent != (int)(completeSize * 100 / fileSize))
							{
								if (ProgressDownloadFile != null)
									ProgressDownloadFile((int)(completeSize * 100 / fileSize));
								lastFileTransferPersent = (int)(completeSize * 100 / fileSize);
							}
						}

						// ---- Message with context: [_tcs_file_start:(file_len)]
						if (Encoding.ASCII.GetString(iMessage, 0, iMessage.Length).IndexOf("_tcs_file_start:") != -1)
						{
							completeSize = 0;
							string tmpFileSize = Service.GetBetween(iMessage, ':', ']');
							if (tmpFileSize == null)
							{
								transferFile = false;
								ErrorDownloadFile("Error get incoming file size.");
							}
							else
							{
								bool existException = false;
								try
								{
									fileSize = Int32.Parse(tmpFileSize);
								}
								catch (Exception ex)
								{
									existException = true;
									transferFile = false;
									ErrorDownloadFile("Error convert string to int incoming file size. [" + tmpFileSize + "]. ex:" + ex);
								}

								if (!existException)
								{
									if (PathToSaveTmpFile == string.Empty)
									{
										PathToSaveTmpFile = Path.GetTempPath();
									}

									fileName = PathToSaveTmpFile + @"\" + Guid.NewGuid() + ".tmp";

									fileStream = File.Open(fileName, FileMode.Create, FileAccess.Write);

									transferFile = true;
									if (StartDownloadFile != null)
										StartDownloadFile();
								}
							}
						}
					}
				}


			}
			
			_getIncomingDataActive = false;
		}


		public static void SendMessage(byte[] data)
		{
			if (data.Length<2) return;
			if (!_getIncomingDataActive) _getIncomingDataThread.Start();

			if (UseCompression)
			{
				data = QuickLZ.compress(data);
			}

			byte[] startMessage = Encodings.GetBytes("[_tcs_message_start:" + data.Length + "]");
			byte[] endMessage = Encodings.GetBytes("[_tcs_message_end]");
			NetworkSend(startMessage, startMessage.Length);


			if (data.Length <= 1000)
			{
				NetworkSend(data, data.Length);
			}
			else
			{
				var buffer = new byte[1024];

				for (int i = 0; i < data.Length; i += 1000)
				{
					int byteCount = 0;
					for (int j = 0; j < 1000; j++)
					{
						if (i + j < data.Length)
						{
							buffer[j] = data[i + j];
							byteCount++;
						}
					}
					NetworkSend(buffer, byteCount);
				}
			}

			NetworkSend(endMessage, endMessage.Length);
		}

		public static bool SendFile(string file)
		{
			if (!_getIncomingDataActive) _getIncomingDataThread.Start();

			FileStream fileStream;

			var fileInfo = new FileInfo(file);
			byte[] startMessage = Encodings.GetBytes("[_tcs_file_start:" + fileInfo.Length + "]");
			byte[] endMessage = Encodings.GetBytes("[_tcs_file_end]");
			NetworkSend(startMessage, startMessage.Length);

			try
			{
				fileStream = File.Open(file, FileMode.Open, FileAccess.Read);
			}
			catch (Exception ex)
			{
				LastException = ex.ToString();
				return false;
			}

			var buffer = new byte[1024];
			int bytesCount;
			while ((bytesCount = fileStream.Read(buffer, 0, 1000 * 64)) > 0)
			{

				if (UseCompression)
				{
					buffer = QuickLZ.compress(buffer);
					NetworkSend(buffer, buffer.Length);
				}
				else
				{
					NetworkSend(buffer, bytesCount);
				}

				buffer = new byte[1024];
			}

			NetworkSend(endMessage, endMessage.Length);
			return true;
		}


		private static void NetworkSend(byte[] message, int count)
		{
			try
			{
				byte[] add = Encoding.ASCII.GetBytes(count + "|");
				Service.AddToBeg(ref message, count, add, add.Length);
				TcpStream.Write(message, 0, message.Length);
			}
			catch (Exception)
			{
				return;
			}
			
		}
	}

}
