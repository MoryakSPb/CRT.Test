using System;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using CRT.Test.Interfaces;
using NUnit.Framework;

namespace CRT.Test.Tests.Encrypt
{
	[TestFixture]
	public sealed class Tests
	{
		private const int KEY_LENGTH = 30;
		private readonly IEncrypt _encryption = new Encryption();
		private readonly Random _random = new();
		private string _key;

		[SetUp]
		public void SetUp()
		{
			_key = GetRandomString(KEY_LENGTH);
		}

		[Test]
		[Repeat(100)]
		public void Encrypt()
		{
			string source = GetRandomString(_random.Next(1, 100000));
			string encrypted = _encryption.Encrypt(source, _key);
			string decrypted = _encryption.Dencrypt(encrypted, _key);
			Assert.IsTrue(decrypted == source);
		}

		[Test]
		[Repeat(100)]
		public void EncryptEnumerable()
		{
			string[] sources = Enumerable.Repeat(GetRandomString(_random.Next(1, 100000)), _random.Next(25, 100)).ToArray();
			Assert.IsTrue(sources.SequenceEqual(_encryption.Dencrypt(_encryption.Encrypt(sources, _key), _key)));
		}

		private string GetRandomString(int length)
		{
			StringBuilder keyBuilder = new(length);
			for (int i = 0; i < length; i++)
			{
				keyBuilder.Append(
					(char)_random.Next(
						UnicodeRanges.BasicLatin.FirstCodePoint,
						UnicodeRanges.BasicLatin.FirstCodePoint + UnicodeRanges.BasicLatin.Length));
			}

			return keyBuilder.ToString();
		}
	}
}