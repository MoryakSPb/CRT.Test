using CRT.Test.Interfaces;

namespace CRT.Test.Tests.Broker
{
	internal sealed class Subscriber : ISubscriber
	{
		public void NewMessage(in IMessage message)
		{
			LastMessage = message.ToString();
		}

		internal string LastMessage { get; private set; }
	}
}