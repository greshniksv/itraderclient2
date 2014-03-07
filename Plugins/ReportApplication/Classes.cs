using System;

using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ReportApplication
{

	public class ComboIntString
	{
		private int _int = 0;
		private string _str = "";

		public int Int
		{
			get { return _int; }
			set { _int = value; }
		}

		public string Str
		{
			get { return _str; }
			set { _str = value; }
		}

		public ComboIntString()
			: this(0,string.Empty)
		{
			_int = Int;
			_str = Str;
		}

		public ComboIntString(int Int, string Str)
		{
			_int = Int;
			_str = Str;
		}

		public override string ToString()
		{
			return _str;
			//return base.ToString();
		}

	}

}
