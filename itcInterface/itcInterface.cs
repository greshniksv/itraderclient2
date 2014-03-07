using System.Drawing;

namespace itcInterface
{
	/// <summary>
	/// Plugin interface
	/// </summary>
	public interface IPlugin
	{
		/// Methods
		string GetPluginName();
		string GetPluginDescription();
		string GetPluginVersion();
		Icon GetAppIcon();
		void Run();
        void RefreshData();
		void Close();
	}
}
