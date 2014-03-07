using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using itcClassess;
using System.Drawing;
using System.Resources;
using System.Reflection;

namespace iTrader.Client2
{
       
	public partial class FrmAutoconfig : Form
	{
        public FrmAutoconfig()
		{
			InitializeComponent();
		}

        private void FrmAutoconfig_Load(object sender, EventArgs e)
        {
            int size = GlobalVariables.GetIconSize();
            ResourceManager resMan = new ResourceManager("iTrader.Client2.resx.ButtonsIcons", Assembly.GetExecutingAssembly());
            pBoxBack.Image = (Bitmap)resMan.GetObject(string.Format("back{0}", size));
            pBoxBack.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAccept.Image = (Bitmap)resMan.GetObject(string.Format("accept{0}", size));
            pBoxAccept.SizeMode = PictureBoxSizeMode.CenterImage;
            pBoxAdd.Image = (Bitmap)resMan.GetObject(string.Format("add{0}", size));
            pBoxAdd.SizeMode = PictureBoxSizeMode.CenterImage;
        }

		private void Apply()
		{
			var progressMax = label2.Width;
			int col = 0;
			lblProgress.Text = "applying...";
			
			foreach (var configItemList in ConfigItemGroup.ConfigGroup)
			{
				if (configItemList.Name == cbxCaterogy.Text)
				{
					foreach (var configItem in configItemList.ConfigList)
					{
						col++;
						lblProgress.Width = (col * configItemList.ConfigList.Count/ 100) * progressMax / 100;
						Application.DoEvents();
						
						GLOBAL.CONFIG.SetValue(configItem.Variable, configItem.Value, configItem.Section);
					}
				}
			}
			lblProgress.Width = 1;
			lblProgress.Text = "";
			
			GLOBAL.SysLog.WriteInfom("Autoconfig. Apply config with [" + cbxCaterogy.Text+"] section.");
			MessageBox.Show(@"Конфигурация применилась");
		}

        //private void Download()
        //{
        //    string[] parameters = itcDatabase.DatabaseService.Autoconfig();

        //    if(parameters==null){ MessageBox.Show(@"Ошибка получения конфига. Нет конекта к сервачку."); return; }
        //    var progressMax = label2.Width;
        //    int col = 0;
			
        //    lblProgress.Text = "loading...";
        //    foreach (var parameter in parameters)
        //    {
        //        if (parameter.Length<=1) continue;
        //        col++;
        //        lblProgress.Width = (col*parameters.Length/100)*progressMax/100;
        //        Application.DoEvents();

        //        if (parameter.Length < 3) continue;
				
        //        // check if exist in comboBox (cbxCategory)
        //        List<ConfigItem> curentGroup = null;
        //        bool existInCombo = false;

        //        foreach (var item in ConfigItemGroup.ConfigGroup)
        //        {
        //            if(item.Name == parameter.Split(',')[0])
        //            {
        //                curentGroup = item.ConfigList;
        //                existInCombo = true;
        //            }
        //        }
				
        //        if(!existInCombo)
        //        {
        //            var newItem = new ConfigItemList()
        //                            {
        //                                ConfigList = new List<ConfigItem>(),
        //                                Name = parameter.Split(',')[0]
        //                            };
        //            curentGroup = newItem.ConfigList;
        //            ConfigItemGroup.ConfigGroup.Add(newItem);
        //            cbxCaterogy.Items.Add(parameter.Split(',')[0]);
        //        }

        //        if (curentGroup==null) throw new Exception("Cen't select current group in autoconfig.");

        //        curentGroup.Add(new ConfigItem() 
        //            { 
        //                Section = parameter.Split(',')[1], 
        //                Variable = parameter.Split(',')[2], 
        //                Value = parameter.Split(',')[3] 
        //            });
        //    }
        //    lblProgress.Width = 1;
        //    lblProgress.Text = "";

        //    cbxCaterogy.SelectedItem = cbxCaterogy.Items[cbxCaterogy.Items.Count - 1];


        //    //    HttpWebResponse response;
        //    //    const string urlToDown = "http://hs.poisk.lg.ua:9854/Autoconfig.txt";
        //    //    try
        //    //    {
        //    //        WebRequest request = WebRequest.Create(urlToDown);
        //    //        response = (HttpWebResponse)request.GetResponse();
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        MessageBox.Show(@"Error WebRequest");
        //    //        GLOBAL.SysLog.WriteError("Autoconfig. Error web request. ex: "+ex);
        //    //        return;
        //    //    }

        //    //    if (response != null)
        //    //    {
        //    //        Stream stream = response.GetResponseStream();

        //    //        if (stream != null)
        //    //        {
        //    //            var buf = new byte[100];
        //    //            int fileLen;
        //    //            FileStream fileStream = File.OpenWrite(@"\Program Files\iTraderClient2\Update\Autoconfig.cfg");
        //    //            while ((fileLen = stream.Read(buf, 0, 100)) > 0)
        //    //            {
        //    //                fileStream.Write(buf, 0, fileLen);
        //    //            }
        //    //            fileStream.Close();

        //    //            TextReader textReader = new StreamReader(@"\Program Files\iTraderClient2\Update\Autoconfig.cfg");
        //    //            string bufs;
        //    //            ConfigItemGroup.ConfigGroup.Clear();

        //    //            ConfigItemList cil = null;
        //    //            while ((bufs = textReader.ReadLine()) != null)
        //    //            {
        //    //                if (bufs.IndexOf('[') != -1)
        //    //                {
        //    //                    if (cil != null)
        //    //                    {
        //    //                        if (cil.ConfigList.Count > 0)
        //    //                        {
        //    //                            cbxCaterogy.Items.Add(cil.Name);
        //    //                            cbxCaterogy.SelectedItem = cil.Name;
        //    //                            ConfigItemGroup.ConfigGroup.Add(cil);
        //    //                        }
        //    //                    }

        //    //                    bufs = bufs.Replace('[', ' ');
        //    //                    bufs = bufs.Replace(']', ' ');
        //    //                    bufs = bufs.Trim();
        //    //                    string groupName = bufs;
        //    //                    bufs = string.Empty;
        //    //                    cil = new ConfigItemList { Name = groupName };
        //    //                }


        //    //                if (bufs.IndexOf('=') != -1)
        //    //                {
        //    //                    int pos = bufs.IndexOf('=');
        //    //                    string var = bufs.Substring(0, pos);
        //    //                    string val = bufs.Substring(pos + 1, bufs.Length - (pos + 1));
        //    //                    var ci = new ConfigItem { Variable = var.Trim(), Value = val.Trim() };
        //    //                    if (cil != null) cil.ConfigList.Add(ci); else MessageBox.Show(@"ERROR. CIL is null");
        //    //                }

        //    //            }
        //    //            textReader.Close();

        //    //            File.Delete(@"\Program Files\iTraderClient2\Update\Autoconfig.cfg");
        //    //            stream.Close();
        //    //            response.Close();

        //    //            lstParams.Items.Clear();
        //    //            foreach (var configItemList in ConfigItemGroup.ConfigGroup)
        //    //            {
        //    //                if (configItemList.Name == cbxCaterogy.Text)
        //    //                {
        //    //                    lstParams.Items.Clear();
        //    //                    foreach (var configItem in configItemList.ConfigList)
        //    //                    {
        //    //                        var ii = new ListViewItem();
        //    //                        ii.SubItems[0].Text = configItem.Variable;
        //    //                        ii.SubItems.Add(configItem.Value);
        //    //                        lstParams.Items.Add(ii);
        //    //                    }
        //    //                }
        //    //            }


        //    //        }
        //    //        else
        //    //        {
        //    //            GLOBAL.SysLog.WriteError("Autoconfig. Download stream is null");
        //    //            MessageBox.Show(@"Download stream is null", @"ERROR");
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        MessageBox.Show(@"HttpWebResponse is null", @"ERROR");
        //    //        GLOBAL.SysLog.WriteError("Autoconfig. HttpWebResponse is null");
        //    //    }

        //}

        private void LblProgress(int percent)
        {
            var progressMax = label2.Width;
            lblProgress.Width = percent * progressMax / 100;
        }

        private void GetConfigList()
        {
            ConfigItemGroup.ConfigGroup.Clear();
            cbxCaterogy.Items.Clear();

            LblProgress(10);
            var configData = GetFileFromWeb("http://sync.npf-poisk.org.ua/ppc_config.txt");
            var configDataList = configData.Split('\n');

            var groupName = string.Empty;
            List<ConfigItem> curentConfigList = null;
            for (int i = 0; i < configDataList.Length; i++)
            {
                LblProgress(10 + i);
                if (configDataList[i].IndexOf("*") != -1)
                {

                    groupName = configDataList[i].Replace('*', ' ').Trim();

                    bool exist = false;
                    foreach (var item in ConfigItemGroup.ConfigGroup)
                    {
                        if (item.Name == groupName)
                        {
                            curentConfigList = item.ConfigList;
                        }
                    }

                    if (!exist)
                    {
                        curentConfigList = new List<ConfigItem>();
                        ConfigItemGroup.ConfigGroup.Add(new ConfigItemList { ConfigList = curentConfigList, Name = groupName });
                        cbxCaterogy.Items.Add(groupName);
                    }
                }

                if (configDataList[i].Trim().Length > 3 && configDataList[i].IndexOf("=") != -1)
                {
                    curentConfigList.Add(new ConfigItem()
                    {
                        Section = "Replication",
                        Variable = configDataList[i].Split('=')[0].Trim(),
                        Value = configDataList[i].Split('=')[1].Trim()
                    });
                }
            }
            cbxCaterogy.SelectedItem = cbxCaterogy.Items[cbxCaterogy.Items.Count - 1];
            LblProgress(1);
        }

        private string GetFileFromWeb(string url)
        {
            string data = string.Empty;
            HttpWebResponse response;
            //const string urlToDown = "http://hs.poisk.lg.ua:9854/Autoconfig.txt";
            try
            {
                WebRequest request = WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error WebRequest");
                GLOBAL.SysLog.WriteError("Autoconfig. Error web request. ex: " + ex);
                return null;
            }

            if (response != null)
            {
                Stream stream = response.GetResponseStream();


                if (stream != null)
                {
                    var buf = new byte[100];
                    int fileLen;
                    while ((fileLen = stream.Read(buf, 0, 100)) > 0)
                    {
                        data += System.Text.Encoding.UTF8.GetString(buf, 0, fileLen);
                    }
                    //MessageBox.Show(data);
                }
                stream.Close();
            }

            return data;
        }

		private void cbxCaterogy_SelectedIndexChanged(object sender, EventArgs e)
		{
			lstParams.Items.Clear();
			foreach (var configItemList in ConfigItemGroup.ConfigGroup)
			{
				if (configItemList.Name == cbxCaterogy.Text)
				{
					lstParams.Items.Clear();
					foreach (var configItem in configItemList.ConfigList)
					{
						var ii = new ListViewItem();
						ii.SubItems[0].Text = configItem.Variable;
						ii.SubItems.Add(configItem.Value);
						ii.SubItems.Add(configItem.Section);
						lstParams.Items.Add(ii);
					}
				}
			}


		}


        private void pBoxButton_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(80, 80, 80);
        }

        private void pBoxButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BackColor = Color.FromArgb(217, 204, 192);
        }

        private void pBoxBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pBoxAccept_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void pBoxAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GetConfigList();
            }
            catch 
            {
                MessageBox.Show("Exception!");
            }
        }




	}

	internal class ConfigItem
	{
		public string Value { get; set; }
		public string Variable { get; set; }
		public string Section { get; set; }
	}

	internal class ConfigItemList
	{
		public string Name { get; set; }
		public List<ConfigItem> ConfigList = new List<ConfigItem>();
	}

	internal static class ConfigItemGroup
	{
		public static List<ConfigItemList> ConfigGroup = new List<ConfigItemList>();
	}

}