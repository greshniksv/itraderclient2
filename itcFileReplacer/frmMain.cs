using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace itcFileReplacer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void ExecuteProgram(string fileName, string arguments)
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

        private List<FileInfo> GetAllFiles(DirectoryInfo dirInfo)
        {
            List<FileInfo> lstFileInfo = GetAllFiles(dirInfo, new List<FileInfo>());
            return lstFileInfo;
        }

        private List<FileInfo> GetAllFiles(DirectoryInfo dirInfo, List<FileInfo> lstFileInfo)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            Thread.Sleep(1500);
            GC.Collect();
            string newFilesPath = @"\Program Files\iTraderClient2\newFiles";
            string FilePath = @"\Program Files\iTraderClient2\";
            List<FileInfo> files = GetAllFiles(new DirectoryInfo(newFilesPath));
            foreach (FileInfo file in files)
            {
                string relativePath = file.FullName.Substring(newFilesPath.Length, file.FullName.Length - newFilesPath.Length);
                string destFilePath = FilePath + relativePath;
                if (File.Exists(destFilePath))
                    File.Delete(destFilePath);
                File.Copy(file.FullName, destFilePath, true);
            }
            Thread thr = new Thread(() => ExecuteProgram(@"\Program Files\iTraderClient2\iTrader.Client2.exe", null));
            thr.Start();
            Application.Exit();
        }
    }
}