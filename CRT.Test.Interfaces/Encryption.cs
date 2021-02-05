using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRT.Test.Interfaces;

namespace CRT.Test
{
	public sealed class Encryption : IEncrypt
	{
		private static string Process(in string source, in string key, in int multiplier)
		{
			StringBuilder text = new(source.Length);
			int keyIndex = -1;
			foreach (char sourceChar in source)
			{
				keyIndex++;
				if (keyIndex == key.Length) keyIndex = 0;
				unchecked
				{
					text.Append((char)(sourceChar + key[keyIndex] * multiplier));
				}
			}

			return text.ToString();
		}

		string IEncrypt.Encrypt(string source, string key) => Process(source, key, 1);

		string IEncrypt.Dencrypt(string encrypted, string key) => Process(encrypted, key, -1);

		IEnumerable<string> IEncrypt.Encrypt(IEnumerable<string> source, string key)
		{
			return source.Select(x => ((IEncrypt)this).Encrypt(x, key));
		}

		IEnumerable<string> IEncrypt.Dencrypt(IEnumerable<string> encrypted, string key)
		{
			return encrypted.Select(x => ((IEncrypt)this).Dencrypt(x, key));
		}
	}
}