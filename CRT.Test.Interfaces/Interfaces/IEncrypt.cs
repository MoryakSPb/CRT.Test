using System.Collections.Generic;

namespace CRT.Test.Interfaces
{
	public interface IEncrypt
	{
		string Encrypt(string source, string key);

		string Dencrypt(string encrypted, string key);

		IEnumerable<string> Encrypt(IEnumerable<string> source, string key);

		IEnumerable<string> Dencrypt(IEnumerable<string> encrypted, string key);
	}
}