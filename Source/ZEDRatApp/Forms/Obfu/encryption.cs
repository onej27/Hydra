using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace ZEDRatApp.Forms.Obfu
{
	public static class encryption
	{
		public static string byte_arr_to_str(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			for (int i = 0; i < ba.Length; i++)
			{
				stringBuilder.AppendFormat("{0:x2}", ba[i]);
			}
			return stringBuilder.ToString();
		}

		public static byte[] str_to_byte_arr(string hex)
		{
			try
			{
				int length = hex.Length;
				byte[] array = new byte[length / 2];
				for (int i = 0; i < length; i += 2)
				{
					array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
				}
				return array;
			}
			catch
			{
				Console.WriteLine("\n\n  The session has ended, open program again.");
				Thread.Sleep(3500);
				Environment.Exit(0);
				return null;
			}
		}

		public static string encrypt_string(string plain_text, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			using MemoryStream memoryStream = new MemoryStream();
			using ICryptoTransform transform = aes.CreateEncryptor();
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] bytes = Encoding.Default.GetBytes(plain_text);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			return encryption.byte_arr_to_str(memoryStream.ToArray());
		}

		public static string decrypt_string(string cipher_text, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			using MemoryStream memoryStream = new MemoryStream();
			using ICryptoTransform transform = aes.CreateDecryptor();
			using CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] array = encryption.str_to_byte_arr(cipher_text);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			byte[] array2 = memoryStream.ToArray();
			return Encoding.Default.GetString(array2, 0, array2.Length);
		}

		public static string iv_key()
		{
			return Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-", StringComparison.Ordinal));
		}

		public static string sha256(string r)
		{
			return encryption.byte_arr_to_str(new SHA256Managed().ComputeHash(Encoding.Default.GetBytes(r)));
		}

		public static string encrypt(string message, string enc_key, string iv)
		{
			return encryption.encrypt_string(message, Encoding.Default.GetBytes(encryption.sha256(enc_key).Substring(0, 32)), Encoding.Default.GetBytes(encryption.sha256(iv).Substring(0, 16)));
		}

		public static string decrypt(string message, string enc_key, string iv)
		{
			return encryption.decrypt_string(message, Encoding.Default.GetBytes(encryption.sha256(enc_key).Substring(0, 32)), Encoding.Default.GetBytes(encryption.sha256(iv).Substring(0, 16)));
		}
	}
}
