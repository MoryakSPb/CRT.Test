using System.Linq;
using CRT.Test.Interfaces;
using NUnit.Framework;

namespace CRT.Test.Tests.Broker
{
	[TestFixture]
	public sealed class Tests
	{
		private readonly IMessageBroker _broker = new MessageBroker();
		private readonly Subscriber[] _subscribers = Enumerable.Repeat(new Subscriber(), 5).ToArray();

		[SetUp]
		public void SetUp()
		{
			foreach (Subscriber subscriber in _subscribers)
			{
				_broker.Subscribe(subscriber);
			}
		}

		[Test]
		[TestCase("test message")]
		public void SubscribeTest(string text)
		{
			_broker.Post(new Message(text));
			Assert.IsTrue(_subscribers.All(x => x is not null && x.LastMessage == text));
		}

		[TearDown]
		public void TearDown()
		{
			foreach (Subscriber subscriber in _subscribers)
			{
				_broker.Unsubscribe(subscriber);
			}
		}
	}
}