using System.Collections.Generic;
using CRT.Test.Interfaces;

namespace CRT.Test
{
	public sealed class MessageBroker : IMessageBroker
	{
		private readonly List<ISubscriber> _subscribers = new();

		void IMessageBroker.Post(IMessage message)
		{
			foreach (ISubscriber subscriber in _subscribers)
			{
				subscriber.NewMessage(message);
			}
		}

		void IMessageBroker.Subscribe(ISubscriber subscriber)
		{
			_subscribers.Add(subscriber);
		}

		void IMessageBroker.Unsubscribe(ISubscriber subscriber)
		{
			_subscribers.Remove(subscriber);
		}
	}
}