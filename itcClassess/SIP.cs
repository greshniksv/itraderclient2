using System;
using System.Runtime.InteropServices;

namespace itcClassess
{
	public class Sip
	{
		[DllImport("coredll.dll")]
		private static extern int SipShowIM(SipStatus i);

		[DllImport("coredll.dll")]
		private static extern bool SipSetInfo(ref Sipinfo pSipInfo);

		[DllImport("coredll.dll")]
		private static extern bool SipGetInfo(ref Sipinfo pSipInfo);

		private static bool _pvtVisible;

		private enum SipStatus
		{
			SipfOff = 0x0,
			SipfOn = 0x1
		}

		private struct Sipinfo
		{
			public Int32 CbSize;
			public Int32 FdwFlags;
			public Rect RcVisibleDesktop;
			public Rect RcSipRect;
			public Int32 DwImDataSize;
			public Int32 PvImData;
		}

		private struct Rect
		{
			public Int32 Left;
			public Int32 Top;
			public Int32 Right;
			public Int32 Bottom;
		}

		public static void Show()
		{
			SipShowIM(SipStatus.SipfOn);
		}

		public static void Hide()
		{
			SipShowIM(SipStatus.SipfOff);
		}

		public static void SetTop(Int32 top)
		{
			var mySi = new Sipinfo {CbSize = Marshal.SizeOf(typeof (Sipinfo))};
			SipGetInfo(ref mySi);
			mySi.RcSipRect.Top = top;
			mySi.RcSipRect.Bottom = top + 80;
			SipSetInfo(ref mySi);
		}

		public static void SetBottom(Int32 bottom)
		{
			var mySi = new Sipinfo {CbSize = Marshal.SizeOf(typeof (Sipinfo))};
			SipGetInfo(ref mySi);
			bottom = 320 - bottom;
			mySi.RcSipRect.Top = bottom - 80;
			mySi.RcSipRect.Bottom = bottom;
			SipSetInfo(ref mySi);
		}

		public static bool Visible
		{
			get
			{
				return _pvtVisible;
			}
			set
			{
				SipShowIM(value ? SipStatus.SipfOn : SipStatus.SipfOff);
				_pvtVisible = value;
			}
		}

	}

}
