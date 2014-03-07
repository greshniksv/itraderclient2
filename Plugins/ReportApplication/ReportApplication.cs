using System;
using System.Collections.Generic;
using System.Text;
using iTrader;
using ReportApplication;
using System.Resources;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using itcInterface;

namespace iTrader.Applications
{
	public class ReportApplication: IPlugin
	{
        FrmMain formMain;

        public ReportApplication()
        {

        }

        string IPlugin.GetPluginName()
        {
            return "Отчет";
        }

        string IPlugin.GetPluginDescription()
        {
            return "Отчет";
        }

        string IPlugin.GetPluginVersion()
        {
            return @"0." + Assembly.GetExecutingAssembly().GetName().Version.Revision;
        }

        Icon IPlugin.GetAppIcon()
        {
            ResourceManager resMan = new ResourceManager("iTrader.Applications.Properties.Resources", Assembly.GetExecutingAssembly());
            return (Icon)resMan.GetObject("icon");
        }

        void IPlugin.Run()
        {
            
            formMain = new FrmMain();
            formMain.RefreshData();
            formMain.ShowDialog();
            formMain.Close();
        }

        void IPlugin.RefreshData()
        {
            //formMain.RefreshData();
        }
        void IPlugin.Close()
        {
        }
	}
}
