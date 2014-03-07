using System;

using System.Collections.Generic;
using System.Text;

namespace itcClassess
{

	/// <summary>
	/// 
	/// </summary>
	internal static class Service
	{

		public static int GetMasLen(byte[] source)
		{
			for (int i = source.Length - 1; i > 0; i--)
			{
				if (source[i] != '\0') return i + 1;
			}
			return 0;
		}

		public static bool CompareByte(byte[] source, byte[] compare)
		{
			if (source.Length != compare.Length) return false;

			for (int i = 0; i < source.Length; i++)
			{
				if (compare[i] != source[i]) return false;
			}
			return true;
		}

		public static string GetBetween(string data, char start, char end)
		{
			if (data.IndexOf(start) == -1) return null;
			if (data.IndexOf(end) == -1) return null;
			return data.Substring(data.IndexOf(start) + 1, data.IndexOf(end) - (data.IndexOf(start) + 1));
		}

		public static void MasCopy(byte[] source, ref byte[] dest)
		{
			for (int i = 0; i < source.Length; i++)
			{
				dest[i] = source[i];
			}
		}

		public static void MasCopyForce(byte[] source, ref byte[] dest)
		{
			dest = new byte[source.Length];
			for (int i = 0; i < source.Length; i++)
			{
				dest[i] = source[i];
			}
		}

		public static string GetBetween(byte[] source, char start, char end)
		{
			string buf = string.Empty;
			bool canRead = false;
			for (int i = 0; i < source.Length; i++)
			{
				if (source[i] == end) { break; }
				if (canRead)
					buf += (char)source[i];
				if (source[i] == start) canRead = true;
			}
			return buf;
		}

		public static byte[] GetBetweenByte(byte[] source, char start, char end)
		{
			int bufPizion = 0;
			bool canRead = false;
			for (int i = 0; i < source.Length; i++)
			{
				if (source[i] == end) { break; }
				if (canRead)
					bufPizion++;
				if (source[i] == start) canRead = true;
			}
			var buf = new byte[bufPizion];

			bufPizion = 0;
			canRead = false;
			for (int i = 0; i < source.Length; i++)
			{
				if (source[i] == end) { break; }
				if (canRead)
				{
					buf[bufPizion] = source[i];
					bufPizion++;
				}
				if (source[i] == start) canRead = true;
			}

			return buf;
		}

		public static int GetBlockLen(byte[] source)
		{
			int blockLen = 0;
			string len = string.Empty;
			for (int i = 0; i < source.Length; i++)
			{
				if (source[i] == '|')
				{
					break;
				}

				len += (char)source[i];
			}

			int length = 0;
			try
			{
				length = Int32.Parse(len);
			}
			catch
			{
				return 0;
			}

			return Int32.Parse(len);
		}

		public static void CutMas(ref byte[] source, int start, int end)
		{
			var buf = new byte[source.Length - (end - start)];
			int bufPosition = 0;
			for (int i = 0; i < source.Length; i++)
			{
				if (i < start || i >= end)
				{
					buf[bufPosition] = source[i];
					bufPosition++;
				}
			}

			source = buf;
		}

		public static byte[] GetBlockMas(byte[] source, int start, int end)
		{
			var buf = new byte[end - start];
			int bufPosition = 0;
			for (int i = start; i < end; i++)
			{
				buf[bufPosition] = source[i];
				bufPosition++;
			}

			return buf;
		}


		public static void AddToBeg(ref byte[] source, int sourceCount, byte[] add, int addCount)
		{
			var buf = new byte[sourceCount + addCount];
			for (int i = 0; i < addCount; i++)
			{
				buf[i] = add[i];
			}

			for (int i = 0; i < sourceCount; i++)
			{
				buf[i + addCount] = source[i];
			}

			source.Initialize();
			source = buf;
		}

		public static void AddToEnd(ref byte[] source, int sourceCount, byte[] add, int addCount)
		{
			var buf = new byte[sourceCount + addCount];

			for (int i = 0; i < sourceCount; i++)
			{
				buf[i] = source[i];
			}

			for (int i = 0; i < addCount; i++)
			{
				buf[i + sourceCount] = add[i];
			}

			source = buf;
		}

	}
}
