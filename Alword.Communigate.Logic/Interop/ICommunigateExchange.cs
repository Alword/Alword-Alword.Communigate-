namespace Alword.Communigate.Logic.Interop
{
	public interface ICommunigateExchange
	{
		public Task Send<T>(T message) where T : class, new();
		public void Bind(ICommunigateReceiver communigateReceiver);
		public void StartConnection();
	}
}
