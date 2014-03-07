using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Drawing;
using System.Windows.Forms;
using itcClassess;
using itcDatabase;
using itcInterface;
using OpenNETCF.IO.Serial;
using OpenNETCF.IO.Serial.GPS;

namespace GPSShopBinder
{
	public class GPSShopBinder : IPlugin
	{
		private static frmCustomers formCustomers;
		private static frmShops formShops;
		private static GPS GPSDevice;
		private static int LastPort = 0;
		private static bool _autoconfig = false;

		string IPlugin.GetPluginName()
		{
			return "GPS";
		}

		string IPlugin.GetPluginDescription()
		{
			return @"Плагин, позволяющий привязать торговую точку к месту на карте";
		}

		string IPlugin.GetPluginVersion()
		{
			return @"0." + Assembly.GetExecutingAssembly().GetName().Version.Revision;
		}

		Icon IPlugin.GetAppIcon()
		{
			var resMan = new ResourceManager("GPSShopBinder.Properties.Resources", Assembly.GetExecutingAssembly());
			return (Icon)resMan.GetObject("searchweb");
		}

		void IPlugin.Run()
		{
            formCustomers = new frmCustomers();
			formShops = new frmShops();
			GPSDevice = new GPS();
			GPSDevice.BaudRate = BaudRates.CBR_4800;

			List<string> gpsPort = DatabaseService.GetOneRow("select pcValue from tblPpcConfig where pcValue ='GPSPort'") ??
			                       new List<string>(){"1"};

			formShops.ComPort = Int32.Parse(gpsPort[0]);
			GLOBAL.SysLog.WriteInfom("GPSDevice. Activate COM" + gpsPort[0] + ":");
			GPSDevice.ComPort = "COM" + gpsPort[0] + ":";
			GPSDevice.Error += (GPSDeviceError);
			GPSDevice.Position += (GPSDevicePosition);
			GPSDevice.Satellite += (GPSDevice_Satellite);
			GPSDevice.GpsSentence += (GPSDevice_GpsSentence);
			GPSDevice.GpsCommState += (GPSDevice_GpsCommState);
			GPSDevice.GpsAutoDiscovery += (GPSDevice_GpsAutoDiscovery);
			formShops.GpsDevice = GPSDevice;
			GPSDevice.Start();

			formCustomers.ShowDialog();
			string selCust = formCustomers.SelectedCustomers;
			if (selCust!=null)
				formShops.ShowShops(selCust);

			formShops.Close();
			formCustomers.Close();
		}
        void IPlugin.RefreshData()
        {
            //
        }

		void IPlugin.Close()
		{
            if (formShops != null)
			    formShops.Close();
            if (formCustomers != null)
			    formCustomers.Close();
		}

		void GPSDevice_GpsAutoDiscovery(object sender, AutoDiscoverStates state, string port, BaudRates bauds)
		{
			string stinf = "DisState:";
			switch (state)
			{
				case AutoDiscoverStates.Failed: stinf += "Failed"; break;
				case AutoDiscoverStates.FailedToOpen: stinf += "FailedToOpen"; break;
				case AutoDiscoverStates.NoGPSDetected: stinf += "NoGPSDetected"; break;
				case AutoDiscoverStates.Opened: stinf += "Opened"; break;
				case AutoDiscoverStates.Testing: stinf += "Testing"; break;
				default: stinf += " -- "; break;
			}

			string baudsInf = "Bauds:";
			switch (bauds)
			{
				case BaudRates.CBR_110: baudsInf += "CBR_110"; break;
				case BaudRates.CBR_115200: baudsInf += "CBR_115200"; break;
				case BaudRates.CBR_1200: baudsInf += "CBR_1200"; break;
				case BaudRates.CBR_128000: baudsInf += "CBR_128000"; break;
				case BaudRates.CBR_14400: baudsInf += "CBR_14400"; break;
				case BaudRates.CBR_19200: baudsInf += "CBR_19200"; break;
				case BaudRates.CBR_230400: baudsInf += "CBR_230400"; break;
				case BaudRates.CBR_2400: baudsInf += "CBR_2400"; break;
				case BaudRates.CBR_256000: baudsInf += "CBR_256000"; break;
				case BaudRates.CBR_300: baudsInf += "CBR_300"; break;
				case BaudRates.CBR_38400: baudsInf += "CBR_38400"; break;
				case BaudRates.CBR_460800: baudsInf += "CBR_460800"; break;
				case BaudRates.CBR_4800: baudsInf += "CBR_4800"; break;
				case BaudRates.CBR_56000: baudsInf += "CBR_56000"; break;
				case BaudRates.CBR_57600: baudsInf += "CBR_57600"; break;
				case BaudRates.CBR_600: baudsInf += "CBR_600"; break;
				case BaudRates.CBR_921600: baudsInf += "CBR_921600"; break;
				case BaudRates.CBR_9600: baudsInf += "CBR_9600"; break;
				default: baudsInf += " -- "; break;
			}

			try
			{
				if (formShops.InvokeRequired)
				{
					formShops.Invoke
					(
						new NotifyHandler(
							delegate()
							{
								formShops.Bauds = baudsInf;
								formShops.DisState = stinf;
							}
						)
					);
				}
			}
			catch (Exception)
			{

			}


		}

		void GPSDevice_GpsCommState(object sender, GpsCommStateEventArgs e)
		{
			string rez3 = "";
			switch (e.State)
			{
				case States.AutoDiscovery: rez3 = "CState: Discovery"; break;
				case States.Opening: rez3 = "CState: Opening"; break;
				case States.Running: rez3 = "CState: Running"; break;
				case States.Stopped: rez3 = "CState: Stopped"; break;
				case States.Stopping: rez3 = "CState: Stopping"; break;
				default: break;
			}

			try
			{
				if (formShops.InvokeRequired)
				{
					formShops.Invoke
						(
							new NotifyHandler(
								delegate()
									{
										formShops.CommState = rez3;
									}
								)
						);
				}
			}catch(Exception) { }
		}

		void GPSDevice_GpsSentence(object sender, GpsSentenceEventArgs e)
		{
			try
			{
				if (formShops.InvokeRequired)
				{
					formShops.Invoke
					(
						new NotifyHandler(
							delegate()
							{
								formShops.GpsSentence = "Sentence: " + e.Sentence;
							}
						)
					);
				}
			}
			catch (Exception)
			{
				
			}
			
		}

		void GPSDevice_Satellite(object sender, Satellite[] satellites)
		{
			int col = GPSDevice.SatInView;
			int Active = 0;
			var rand = new Random();
			for (int i = 0; i < satellites.Length; i++)
			{
				if (satellites[i].Active == true) { Active++; }
			}

			try
			{
				if (formShops.InvokeRequired)
				{
					formShops.Invoke
					(
						new NotifyHandler(
							delegate()
							{
								formShops.Satelites = "Satelites: " + col + "/" + Active;
								formShops.SatelitesActive = (Active * 89 / col) + rand.Next(1, 10);
							}
						)
					);
				}
			}
			catch (Exception)
			{
			}
			

		}

		private void GPSDeviceError(object sender, Exception exception, string message, string gps_data)
		{
			//MessageBox.Show("GPSDeviceError.  \nMessage:" + message + ". \nGPS_Data:" + gps_data + " ex:" + exception + ".");
			GLOBAL.SysLog.WriteError("GPSDeviceError. ex:"+exception+". \nMessage:"+message+". \nGPS_Data:"+gps_data);

			try
			{
				GPSDevice.Stop();
			}
			catch (Exception) { }


			if (!_autoconfig)
			{
				DialogResult rezult = 
					MessageBox.Show(@"Ошибка включения GPS. " +
					  @"Кофигурация неверна либо GPS модуль отсудствует. " +
					  @"Включить автокнофигуратор ? ", 
						@"Внимание", MessageBoxButtons.YesNo,
					  MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);
				if (rezult == DialogResult.Yes) _autoconfig = true;
			}

			if (_autoconfig)
			{

				GPSDevice = new GPS {BaudRate = BaudRates.CBR_4800};
				if (LastPort < 16)
				{
					LastPort++;
					formShops.ComPort = LastPort;
					GLOBAL.SysLog.WriteInfom("GPSDevice. Activate COM" + LastPort + ":");
					GPSDevice.ComPort = "COM" + LastPort + ":";
					GPSDevice.Error += (GPSDeviceError);
					GPSDevice.Position += (GPSDevicePosition);
					GPSDevice.Satellite += (GPSDevice_Satellite);
					GPSDevice.GpsSentence += (GPSDevice_GpsSentence);
					GPSDevice.GpsCommState += (GPSDevice_GpsCommState);
					GPSDevice.GpsAutoDiscovery += (GPSDevice_GpsAutoDiscovery);
					formShops.GpsDevice = GPSDevice;
					GPSDevice.Start();
				}
				else
				{
					MessageBox.Show(@"Автоконфигуратор ЖПС не сработал. Какая жаль :)");
				}
			}

		}

		private void GPSDevicePosition(object sender, Position pos)
		{
			formShops.UpdateGPSPositionAsync(pos);
		}










	}
}
