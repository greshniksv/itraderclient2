using System;

using System.Collections.Generic;
using System.Text;

namespace itcClassess
{
	// ********************************************************************************************************
	// 
	// ********************************************************************************************************


	/// <summary>
	/// 
	/// </summary>

	public static class GreshnikCrypt
	{
		private static int _mixStart;
		private static int _mixCount;
		//public static event ProgressEventHandler Progress;

		/// <summary>
		/// Cript password without salt
		/// </summary>
		/// <param name="saveData"> data to save </param>
		/// <param name="encoding">Encoding of data</param>
		/// <returns> return crypted hash </returns>
		public static string CryptPassword(string saveData, Encoding encoding)
		{
			const string sumbols = @" 123456789`~1!2@3#4$5%6^7&8*9(0)-_=+/\qQwWeErRtTyYuUiIoOpP[{]}aAsSdDfFgGhHjJkKlL;:'|zZxXcCvVbBnNmM,<.>/?";
			byte[] sumbolMass = Encoding.ASCII.GetBytes(sumbols);
			int hashLen = 256;

			if (saveData.Length <= 50) hashLen = 512;
			if (saveData.Length <= 35) hashLen = 256;

			var hashPassword = new byte[hashLen];
			var rand = new Random();
			for (int i = 0; i < hashPassword.Length; i++)
			{
				hashPassword[i] = sumbolMass[rand.Next(0, sumbolMass.Length)];
			}
			hashPassword = Crypt(hashPassword, encoding.GetBytes(saveData));
			if (hashPassword == null) return null;
			return encoding.GetString(hashPassword, 0, hashPassword.Length);
		}

		/// <summary>
		/// Decript password without salt
		/// </summary>
		/// <param name="hash"> Hash data </param>
		/// <param name="encoding"> Encoding of data </param>
		/// <returns> return password </returns>
		public static string DecryptPassword(string hash, Encoding encoding)
		{
			byte[] hashPassword = encoding.GetBytes(hash);
			var dec = Decrypt(hashPassword);
			return encoding.GetString(dec, 0, dec.Length);
		}

		/// <summary>
		/// Cript password without salt
		/// </summary>
		/// <param name="saveData"> data to save </param>
		/// <param name="salt"> salt for hash </param>
		/// <param name="encoding">Encoding of data</param>
		/// <returns> return crypted hash </returns>
		public static string CryptPassword(string saveData, string salt, Encoding encoding)
		{
			const string sumbols = @" 123456789`~1!2@3#4$5%6^7&8*9(0)-_=+/\qQwWeErRtTyYuUiIoOpP[{]}aAsSdDfFgGhHjJkKlL;:'|zZxXcCvVbBnNmM,<.>/?";
			byte[] sumbolMass = Encoding.ASCII.GetBytes(sumbols);
			int hashLen = 256;

			if (saveData.Length <= 50) hashLen = 512;
			if (saveData.Length <= 35) hashLen = 256;

			var hashPassword = new byte[hashLen];
			var rand = new Random();
			for (int i = 0; i < hashPassword.Length; i++)
			{
				hashPassword[i] = sumbolMass[rand.Next(0, sumbolMass.Length)];
			}
			hashPassword = Crypt(hashPassword, encoding.GetBytes(saveData), encoding.GetBytes(salt));
			if (hashPassword == null) return null;
			return encoding.GetString(hashPassword, 0, hashPassword.Length);
		}

		/// <summary>
		/// Decript password without salt
		/// </summary>
		/// <param name="hash"> Hash data </param>
		/// <param name="salt"> Salt of hash </param>
		/// <param name="encoding"> Encoding of data </param>
		/// <returns> return password </returns>
		public static string DecryptPassword(string hash, string salt, Encoding encoding)
		{
			byte[] hashPassword = encoding.GetBytes(hash);
			var dec = Decrypt(hashPassword, encoding.GetBytes(salt));
			return encoding.GetString(dec, 0, dec.Length);
		}





		/// <summary>
		/// Decript hash data. Without password.
		/// </summary>
		/// <param name="data"> Hash data </param>
		/// <returns> If hash corrent or incorrect function return data </returns>
		public static byte[] Decrypt(byte[] data)
		{
			int saveDataLen;
			int position = data[0];
			int lenSaveDataSize = data[1];
			var saveDataLenSig = new byte[lenSaveDataSize];
			saveDataLenSig.Initialize();

			for (int i = 0; i < lenSaveDataSize; i++)
			{
				saveDataLenSig[i] = data[position + 1];
				position = data[position] + position;
				if (position >= data.Length) position -= data.Length;
			}

			try
			{
				saveDataLen = Int32.Parse(Encoding.ASCII.GetString(saveDataLenSig, 0, saveDataLenSig.Length));
			}
			catch (Exception)
			{
				throw new Exception("Error cinvert to int: " + Encoding.ASCII.GetString(saveDataLenSig, 0, saveDataLenSig.Length));
			}

			var saveData = new byte[saveDataLen];
			saveData.Initialize();

			for (int i = 0; i < saveDataLen; i++)
			{
				saveData[i] = data[position + 1];
				position = data[position] + position;
				if (position >= data.Length) position -= data.Length;
			}

			return saveData;
		}

		/// <summary>
		/// Decript hash data with password.
		/// </summary>
		/// <param name="data"> Hash data </param>
		/// <param name="salt"> Password </param>
		/// <returns> If password and hash corrent or incorrect function return data </returns>
		public static byte[] Decrypt(byte[] data, byte[] salt)
		{
			int saveDataLen;
			int passwordPosition = 0;
			int position = salt[0] + data[0];
			int lenSaveDataSize = data[position + 1];
			position = data[position] + position + salt[passwordPosition];
			passwordPosition++;
			if (position >= data.Length) position -= data.Length;

			var saveDataLenSig = new byte[lenSaveDataSize];
			saveDataLenSig.Initialize();

			for (int i = 0; i < lenSaveDataSize; i++)
			{
				saveDataLenSig[i] = data[position + 1];
				position = data[position] + position + salt[passwordPosition];
				passwordPosition++;
				if (passwordPosition >= salt.Length) passwordPosition -= salt.Length;
				if (position >= data.Length) position -= data.Length;
				if (position + 1 == data.Length) position = 0;
			}

			try
			{
				saveDataLen = Int32.Parse(Encoding.ASCII.GetString(saveDataLenSig, 0, saveDataLenSig.Length));
			}
			catch (Exception)
			{
				//throw new Exception("Error convert to int: " + Encoding.ASCII.GetString(saveDataLenSig));
				var rand = new Random();
				saveDataLen = rand.Next(1, (40 * data.Length / 100));
			}

			var saveData = new byte[saveDataLen];
			saveData.Initialize();

			for (int i = 0; i < saveDataLen; i++)
			{
				saveData[i] = data[position + 1];
				position = data[position] + position + salt[passwordPosition];
				passwordPosition++;
				if (passwordPosition >= salt.Length) passwordPosition -= salt.Length;
				if (position >= data.Length) position -= data.Length;
				if (position + 1 == data.Length) position = 0;
			}

			return saveData;
		}

		/// <summary>
		/// Crypt data
		/// </summary>
		/// <param name="data"> Random hash data </param>
		/// <param name="saveData"> Data to save </param>
		/// <returns> Return null if data cent inset to hash and if data success plased to hash return crypted data </returns>
		public static byte[] Crypt(byte[] data, byte[] saveData)
		{
			if (saveData.Length > 255) throw new Exception("Password to long.");
			if (saveData.Length > (45 * data.Length / 100)) throw new Exception("Password to long for this data.");

			int progress2 = 0;
			const long maxTry = 10000000;
			_mixStart = 0;
			_mixCount = 0;
			var buffer = new byte[data.Length];
			CopyMass(data, buffer);
			Mix(buffer);
			Mix(buffer);
			Mix(buffer);


			for (int i = 0; i < maxTry; i++)
			{

				int progress1 = i * 100 / (int)(maxTry);
				if (progress2 != progress1)
				{
					progress2 = progress1;
					//if (Progress != null)
					//	Progress("", progress1);
				}

				if (!TryInsertData(buffer, saveData))
				{
					Mix(buffer);
				}
				else
				{
					//if (Progress != null)
					//	Progress("Found optimum start position #" + _mixStart + " Mix count:" + _mixCount, -1);
					return buffer;
				}
			}
			return null;
		}


		/// <summary>
		/// Crypt data
		/// </summary>
		/// <param name="data"> Random hash data </param>
		/// <param name="saveData"> Data to save </param>
		/// <param name="salt"> Salt to crypt data </param>
		/// <returns> Return null if data cent inset to hash and if data success plased to hash return crypted data </returns>
		public static byte[] Crypt(byte[] data, byte[] saveData, byte[] salt)
		{
			//if (saveData.Length > 255) throw new Exception("Save data to long.");
			if (saveData.Length > (45 * data.Length / 100)) throw new Exception("Password to long for this data.");

			int progress2 = 0;
			const long maxTry = 10000000;
			_mixStart = 0;
			_mixCount = 0;
			var buffer = new byte[data.Length];
			CopyMass(data, buffer);
			Mix(buffer);
			Mix(buffer);
			Mix(buffer);


			for (int i = 0; i < maxTry; i++)
			{

				int progress1 = i * 100 / (int)(maxTry);
				if (progress2 != progress1)
				{
					progress2 = progress1;
					//if (Progress != null)
					//	Progress("", progress1);
				}

				if (!TryInsertData(buffer, saveData, salt))
				{
					Mix(buffer);
				}
				else
				{
					//if (Progress != null)
					//	Progress("Found optimum start position #" + _mixStart + " Mix count:" + _mixCount, -1);
					return buffer;
				}
			}
			return null;
		}



		private static void CopyMass(byte[] source, byte[] dest)
		{
			for (int i = 0; i < source.Length; i++)
			{
				dest[i] = source[i];
			}
		}

		private static byte[] ConMass(byte[] source, byte[] addToBeg)
		{
			var buffer = new byte[source.Length + addToBeg.Length];
			int position = 0;

			for (int i = 0; i < addToBeg.Length; i++)
			{
				buffer[position] = addToBeg[i];
				position++;
			}

			for (int i = 0; i < source.Length; i++)
			{
				buffer[position] = source[i];
				position++;
			}
			return buffer;
		}

		private static bool TryInsertData(byte[] data, byte[] saveData)
		{
			var dataCotainsList = new List<DataCotains>();
			int position = 0;
			byte[] saveDataLenSig = Encoding.ASCII.GetBytes(saveData.Length.ToString());
			var addinInfo = new byte[saveDataLenSig.Length + 1];
			if (saveDataLenSig.Length > 256) throw new Exception("SaveData to big.");
			addinInfo[0] = (byte)saveDataLenSig.Length;
			for (int i = 0; i < saveDataLenSig.Length; i++)
			{
				addinInfo[i + 1] = saveDataLenSig[i];
			}
			saveData = ConMass(saveData, addinInfo);

			for (int i = 0; i < saveData.Length; i++)
			{
				if (position + 1 >= data.Length) return false;
				dataCotainsList.Add(new DataCotains { Position = position, Char = saveData[i] });
				int newPosition = data[position] + position;
				if (newPosition >= data.Length) newPosition -= data.Length;

				foreach (var dataCotainse in dataCotainsList)
				{
					if (newPosition == dataCotainse.Position - 1) return false;
					if (newPosition == dataCotainse.Position) return false;
					if (newPosition == dataCotainse.Position + 1) return false;
				}

				position = newPosition;
			}

			foreach (var dataCotainse in dataCotainsList)
			{
				data[dataCotainse.Position + 1] = dataCotainse.Char;
			}

			return true;
		}

		private static bool TryInsertData(byte[] data, byte[] saveData, byte[] password)
		{
			var dataCotainsList = new List<DataCotains>();
			int position = password[0] + data[0];
			if (position >= data.Length) position -= data.Length;
			int passwordPosition = 0;

			byte[] saveDataLenSig = Encoding.ASCII.GetBytes(saveData.Length.ToString());
			var addinInfo = new byte[saveDataLenSig.Length + 1];
			if (saveDataLenSig.Length > 256) throw new Exception("SaveData to big.");
			addinInfo[0] = (byte)saveDataLenSig.Length;
			for (int i = 0; i < saveDataLenSig.Length; i++)
			{
				addinInfo[i + 1] = saveDataLenSig[i];
			}
			saveData = ConMass(saveData, addinInfo);

			for (int i = 0; i < saveData.Length; i++)
			{
				if (position + 1 >= data.Length) return false;
				dataCotainsList.Add(new DataCotains { Position = position, Char = saveData[i] });
				int newPosition = data[position] + position + password[passwordPosition];
				passwordPosition++;
				if (passwordPosition >= password.Length) passwordPosition -= password.Length;
				if (newPosition >= data.Length) newPosition -= data.Length;

				foreach (var dataCotainse in dataCotainsList)
				{
					if (newPosition == dataCotainse.Position - 1) return false;
					if (newPosition == dataCotainse.Position) return false;
					if (newPosition == dataCotainse.Position + 1) return false;
				}

				position = newPosition;
			}

			foreach (var dataCotainse in dataCotainsList)
			{
				data[dataCotainse.Position + 1] = dataCotainse.Char;
			}

			return true;
		}

		/// <summary>
		/// Mix data
		/// </summary>
		/// <param name="data"> Data </param>
		private static void Mix(byte[] data)
		{
			int count = 80 * data.Length / 100;
			int position = _mixStart;
			for (int i = 0; i < count; i++)
			{
				byte tempSumbol = data[position];
				int newPosition = position + tempSumbol;
				while (newPosition >= data.Length) { newPosition -= data.Length; }
				data[position] = data[newPosition];
				data[newPosition] = tempSumbol;
				position = newPosition + 1;
				if (position >= data.Length) position -= data.Length;
			}
			_mixCount++;
			_mixStart++;
			if (_mixStart >= data.Length) _mixStart -= data.Length;
		}
	}


	internal class DataCotains
	{
		public int Position { get; set; }
		public byte Char { get; set; }
	}
}
