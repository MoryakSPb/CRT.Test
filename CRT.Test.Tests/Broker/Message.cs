using CRT.Test.Interfaces;

namespace CRT.Test.Tests.Broker
{
	internal record Message(in string Text) : IMessage
	{
		public override string ToString() => Text;
	}
}