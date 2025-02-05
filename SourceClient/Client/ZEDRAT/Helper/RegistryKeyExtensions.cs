using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;

namespace Client.ZEDRAT.Helper
{
	public static class RegistryKeyExtensions
	{
		private static bool IsNameOrValueNull(this string keyName, RegistryKey key)
		{
			if (!string.IsNullOrEmpty(keyName))
			{
				return key == null;
			}
			return true;
		}

		public static string GetValueSafe(this RegistryKey key, string keyName, string defaultValue = "")
		{
			try
			{
				return key.GetValue(keyName, defaultValue).ToString();
			}
			catch
			{
				return defaultValue;
			}
		}

		public static RegistryKey OpenReadonlySubKeySafe(this RegistryKey key, string name)
		{
			try
			{
				return key.OpenSubKey(name, writable: false);
			}
			catch
			{
				return null;
			}
		}

		public static RegistryKey OpenWritableSubKeySafe(this RegistryKey key, string name)
		{
			try
			{
				return key.OpenSubKey(name, writable: true);
			}
			catch
			{
				return null;
			}
		}

		public static RegistryKey CreateSubKeySafe(this RegistryKey key, string name)
		{
			try
			{
				return key.CreateSubKey(name);
			}
			catch
			{
				return null;
			}
		}

		public static bool DeleteSubKeyTreeSafe(this RegistryKey key, string name)
		{
			try
			{
				key.DeleteSubKeyTree(name, throwOnMissingSubKey: true);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool RenameSubKeySafe(this RegistryKey key, string oldName, string newName)
		{
			try
			{
				key.CopyKey(oldName, newName);
				key.DeleteSubKeyTree(oldName);
				return true;
			}
			catch
			{
				key.DeleteSubKeyTreeSafe(newName);
				return false;
			}
		}

		public static void CopyKey(this RegistryKey key, string oldName, string newName)
		{
			using RegistryKey destKey = key.CreateSubKey(newName);
			using RegistryKey sourceKey = key.OpenSubKey(oldName, writable: true);
			RegistryKeyExtensions.RecursiveCopyKey(sourceKey, destKey);
		}

		private static void RecursiveCopyKey(RegistryKey sourceKey, RegistryKey destKey)
		{
			string[] valueNames = sourceKey.GetValueNames();
			foreach (string name in valueNames)
			{
				destKey.SetValue(name, sourceKey.GetValue(name), sourceKey.GetValueKind(name));
			}
			valueNames = sourceKey.GetSubKeyNames();
			foreach (string text in valueNames)
			{
				using RegistryKey sourceKey2 = sourceKey.OpenSubKey(text);
				using RegistryKey destKey2 = destKey.CreateSubKey(text);
				RegistryKeyExtensions.RecursiveCopyKey(sourceKey2, destKey2);
			}
		}

		public static bool SetValueSafe(this RegistryKey key, string name, object data, RegistryValueKind kind)
		{
			try
			{
				key.SetValue(name, data, kind);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool DeleteValueSafe(this RegistryKey key, string name)
		{
			try
			{
				key.DeleteValue(name);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool RenameValueSafe(this RegistryKey key, string oldName, string newName)
		{
			try
			{
				key.CopyValue(oldName, newName);
				key.DeleteValue(oldName);
				return true;
			}
			catch
			{
				key.DeleteValueSafe(newName);
				return false;
			}
		}

		public static void CopyValue(this RegistryKey key, string oldName, string newName)
		{
			key.SetValue(valueKind: key.GetValueKind(oldName), name: newName, value: key.GetValue(oldName));
		}

		public static bool ContainsSubKey(this RegistryKey key, string name)
		{
			string[] subKeyNames = key.GetSubKeyNames();
			for (int i = 0; i < subKeyNames.Length; i++)
			{
				if (subKeyNames[i] == name)
				{
					return true;
				}
			}
			return false;
		}

		public static bool ContainsValue(this RegistryKey key, string name)
		{
			string[] valueNames = key.GetValueNames();
			for (int i = 0; i < valueNames.Length; i++)
			{
				if (valueNames[i] == name)
				{
					return true;
				}
			}
			return false;
		}

		public static IEnumerable<string> GetFormattedKeyValues(this RegistryKey key)
		{
			if (key == null)
			{
				yield break;
			}
			foreach (string item in from keyVal in key.GetValueNames()
				where !keyVal.IsNameOrValueNull(key)
				select keyVal into k
				where !string.IsNullOrEmpty(k)
				select k)
			{
				yield return $"{item}||{key.GetValueSafe(item)}";
			}
		}

		public static object GetDefault(this RegistryValueKind valueKind)
		{
			switch (valueKind)
			{
			case RegistryValueKind.Binary:
				return new byte[0];
			case RegistryValueKind.MultiString:
				return new string[0];
			case RegistryValueKind.DWord:
				return 0;
			case RegistryValueKind.QWord:
				return 0L;
			case RegistryValueKind.String:
			case RegistryValueKind.ExpandString:
				return "";
			default:
				return null;
			}
		}
	}
}
