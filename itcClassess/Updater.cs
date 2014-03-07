using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using NetworkLib;
using System.IO;
using System.Reflection;
using System.IO.Compression;
using System.Diagnostics;
using System.Threading;

namespace itcClassess
{
    public static class Updater
    {
        private static string currentFile;
        public delegate void UpdateDoneHandler();
        public static event UpdateDoneHandler UpdateDone;
        public static void RunReplacer()
        {
            System.Windows.Forms.MessageBox.Show("Обновление завершено, программа будет перезапущена", "Уведомление",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk, System.Windows.Forms.MessageBoxDefaultButton.Button1);
            Thread thr = new Thread(() => ExecuteProgram(@"\Program Files\iTraderClient2\itcFileReplacer.exe", null));
            thr.Start();
            if (UpdateDone != null)
                UpdateDone();
        }

        private static void ExecuteProgram(string fileName, string arguments)
        {
            Process prc = null;
            //  output = string.Empty;

            try
            {
                // Устанавливаем параметры запуска процесса
                prc = new Process();
                prc.StartInfo.FileName = fileName;
                prc.StartInfo.Arguments = arguments;
                // Старт
                prc.Start();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Невозможно найти {0}", fileName), "Ошибка обновлений",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand, System.Windows.Forms.MessageBoxDefaultButton.Button1);
            }
        }
        public static void TryToUpdate()
        {
            Status.UpdateStatus("Проверка доступных обновлений...");
            int buffSize = 1024;
            byte[] data = new byte[buffSize];
            byte[] dataForInt = new byte[4];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.1.11"), 9002);
            Socket server = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);
            }
            catch (SocketException e)
            {
                Status.UpdateStatus("Нет соединения с сервером обновлений");
            }
            try
            {
                data = Encoding.UTF8.GetBytes(GLOBAL.UserInfo.Name);
                SocketExt.SendData(server, data);

                data = SocketExt.ReceiveData(server);
                int checkForUpdates = BitConverter.ToInt32(data, 0);
                /*
                 * checkForUpdates = 1: need send file version
                 * checkForUpdates = 2: need send file hash
                */
                data = SocketExt.ReceiveData(server);
                int compressionMethod = BitConverter.ToInt32(data, 0);
                /*
                 * compressionMethod = 1: none compression
                 * compressionMethod = 2: compression using GzipStream
                 */
                string newFileDirectory = @"\Program Files\iTraderClient2\newFiles";
                if (Directory.Exists(newFileDirectory))
                    Directory.Delete(newFileDirectory, true);
                bool updateWasNoNeed = true;
                if (checkForUpdates == 1)
                {
                    // for .NET assemblies
                    Dictionary<string, string> fileVersions = new Dictionary<string, string>();

                    // for other files (icons, configs etc...)
                    Dictionary<string, string> fileHash = new Dictionary<string, string>();
                    GetFilesInfo(ref fileVersions, ref fileHash);

                    // Sending .NET assemblies info 
                    int numberOfInfoPackets = fileVersions.Count;
                    dataForInt = BitConverter.GetBytes(numberOfInfoPackets);
                    SocketExt.SendData(server, dataForInt);
                    foreach (string key in fileVersions.Keys)
                    {
                        data = new byte[buffSize];
                        data = Encoding.ASCII.GetBytes(key + "=" + fileVersions[key]);
                        SocketExt.SendData(server, data);
                    }

                    //Sending other files info
                    numberOfInfoPackets = fileHash.Count;
                    dataForInt = BitConverter.GetBytes(numberOfInfoPackets);
                    SocketExt.SendData(server, dataForInt);
                    foreach (string key in fileHash.Keys)
                    {
                        data = new byte[buffSize];
                        data = Encoding.ASCII.GetBytes(key + "=" + fileHash[key]);
                        SocketExt.SendData(server, data);
                    }


                    if (!Directory.Exists(newFileDirectory))
                        Directory.CreateDirectory(newFileDirectory);
                    // getting newer files
                    dataForInt = SocketExt.ReceiveData(server);
                    numberOfInfoPackets = BitConverter.ToInt32(dataForInt, 0);
                    if (numberOfInfoPackets > 0)
                        updateWasNoNeed = false;
                    for (int i = 1; i <= numberOfInfoPackets; i++)
                    {
                        data = SocketExt.ReceiveData(server);
                        string fileName = newFileDirectory + Encoding.ASCII.GetString(data, 0, data.Length);
                        //UpdateLblInfo(string.Format("Getting file: {0}", fileName));
                        //UpdateProgress(0);
                        currentFile = Path.GetFileName(fileName);
                        SocketExt.RecieveFile(fileName, server, UpdateProgress);
                    }

                    // getting missed files
                    dataForInt = SocketExt.ReceiveData(server);
                    numberOfInfoPackets = BitConverter.ToInt32(dataForInt, 0);
                    if (numberOfInfoPackets > 0)
                        updateWasNoNeed = false;
                    for (int i = 1; i <= numberOfInfoPackets; i++)
                    {
                        data = SocketExt.ReceiveData(server);
                        string MissedFilePath = newFileDirectory + Encoding.ASCII.GetString(data, 0, data.Length);
                        currentFile = Path.GetFileName(MissedFilePath);
                        UpdateProgress(0);
                        if (!Directory.Exists(Path.GetDirectoryName(MissedFilePath)))
                            Directory.CreateDirectory(Path.GetDirectoryName(MissedFilePath));
                        SocketExt.RecieveFile(MissedFilePath, server, UpdateProgress);
                    }

                }
                else if (checkForUpdates == 2)
                {

                }
                if (compressionMethod == 2)
                {
                    Status.UpdateStatus("Распаковка файлов...");
                    DecompressGZipFiles();
                }
                // confirmation succesfull updating
                data = Encoding.ASCII.GetBytes("ok");
                SocketExt.SendData(server, data);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                if (updateWasNoNeed)
                    Status.UpdateStatus("Завершено");
                else
                    RunReplacer();
            }
            catch
            {
                Status.UpdateStatus("Произошла ошибка во время обновлений");
            }
        }

        private static void DecompressGZipFiles()
        {
            string newFileDirectory = @"\Program Files\iTraderClient2\newFiles";
            List<FileInfo> fiList = GetAllFiles(new DirectoryInfo(newFileDirectory));
            foreach (FileInfo fi in fiList)
            {
                string srcFile = fi.FullName;
                string dstFile = fi.FullName.Substring(0, fi.FullName.Length - fi.Extension.Length);

                FileStream fsIn = null; // will open and read the srcFile
                FileStream fsOut = null; // will be used by the GZipStream for output to the dstFile
                GZipStream gzip = null;
                const int bufferSize = 512;
                byte[] buffer = new byte[bufferSize];
                int count = 0;

                try
                {

                    fsIn = new FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    fsOut = new FileStream(dstFile, FileMode.Create, FileAccess.Write, FileShare.None);
                    gzip = new GZipStream(fsIn, CompressionMode.Decompress, true);
                    while (true)
                    {
                        count = gzip.Read(buffer, 0, bufferSize);
                        if (count != 0)
                        {
                            fsOut.Write(buffer, 0, count);
                        }
                        if (count != bufferSize)
                        {
                            // have reached the end
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // handle or display the error 
                    System.Diagnostics.Debug.Assert(false, ex.ToString());
                }
                finally
                {
                    if (gzip != null)
                    {
                        gzip.Close();
                        gzip = null;
                    }
                    if (fsOut != null)
                    {
                        fsOut.Close();
                        fsOut = null;
                    }
                    if (fsIn != null)
                    {
                        fsIn.Close();
                        fsIn = null;
                    }
                }
                File.Delete(fi.FullName);
            }
        }

        private static void UpdateProgress(int percent)
        {
            Status.UpdateStatus(string.Format(@"Скачивание {0} [{1}]", currentFile, percent));  
        }

        private static void GetFilesInfo(ref Dictionary<string, string> fileVersions, ref Dictionary<string, string> fileHash)
        {
            string curDir = @"\Program Files\iTraderClient2";
            DirectoryInfo dirInfo = new DirectoryInfo(curDir);
            List<FileInfo> files = GetAllFiles(dirInfo);
            //FileInfo[] files = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                if (file.Extension != ".pdb" && file.Extension != ".manifest" && file.Name != "itdb.client.sdf")
                {
                    string relativePath = file.FullName.Substring(curDir.Length, file.FullName.Length - curDir.Length);
                    if (relativePath.ToCharArray()[0] != '\\')
                        relativePath = "\\" + relativePath;
                    try
                    {
                        //string version = AssemblyName.GetAssemblyName(file.FullName).Version.ToString();
                        string version = Assembly.LoadFrom(file.FullName).GetName().Version.ToString();
                        fileVersions[relativePath] = version;
                    }
                    catch (Exception ex)// file is not .NET assembly
                    {
                        string md5Hash = GetMD5Hash(file.FullName);
                        fileHash[relativePath] = md5Hash;
                    }
                }
            }
        }

        private static List<FileInfo> GetAllFiles(DirectoryInfo dirInfo)
        {
            List<FileInfo> lstFileInfo = GetAllFiles(dirInfo, new List<FileInfo>());
            return lstFileInfo;
        }

        private static List<FileInfo> GetAllFiles(DirectoryInfo dirInfo, List<FileInfo> lstFileInfo)
        {
            FileInfo[] fiArr = dirInfo.GetFiles("*.*");
            foreach (FileInfo fi in fiArr)
            {
                lstFileInfo.Add(fi);
            }
            DirectoryInfo[] dirInfoArr = dirInfo.GetDirectories();
            foreach (DirectoryInfo di in dirInfoArr)
            {
                GetAllFiles(di, lstFileInfo);
            }
            return lstFileInfo;
        }

        private static string GenerateNewFullFileName(string fileName)
        {
            string[] files = Directory.GetFiles(@"\Program Files\iTraderClient2", fileName);
            //string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), fileName, SearchOption.AllDirectories);
            if (files.Length != 1)
                throw new Exception("Exception in GetOriginalFilePath method");
            return Path.GetDirectoryName(files[0]) + "\\" + Path.GetFileNameWithoutExtension(fileName) + "_upd" + Path.GetExtension(fileName);

        }

        private static string GetMD5Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher =
                       new System.Security.Cryptography.MD5CryptoServiceProvider();

            try
            {
                oFileStream = new FileStream(pathName, System.IO.FileMode.Open,
                    System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                arrbytHashValue = oMD5Hasher.ComputeHash(oFileStream);
                oFileStream.Close();

                strHashData = System.BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch (Exception ex)
            {

            }
            return (strResult);
        }
    }
}
