namespace CRT.Test.Interfaces
{
	public interface IMessageBroker
	{
		void Post(IMessage message);

		void Subscribe(ISubscriber Subscriber);

		void Unsubscribe(ISubscriber Subscriber);
	}
}