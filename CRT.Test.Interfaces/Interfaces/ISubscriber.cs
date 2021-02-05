namespace CRT.Test.Interfaces
{
	public interface ISubscriber
	{
		void NewMessage(in IMessage message);
	}
}