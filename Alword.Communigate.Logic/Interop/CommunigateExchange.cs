using Alword.Communigate.Logic.Utils;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace Alword.Communigate.Logic.Interop
{
	public class CommunigateExchange : ICommunigateExchange
	{
		private readonly string _host;
		private readonly int _port;
		private ICommunigateReceiver? _receiver;
		private NetworkStream? _stream;
		public CommunigateExchange(string host, int port)
		{
			_host = host;
			_port = port;
		}
		public void StartConnection()
		{
			var tcpClient = new TcpClient(_host, _port);
			_stream = tcpClient.GetStream();

			List<byte> messageBytes = new(1024);
			Task.Factory.StartNew(() =>
			{
				while (true)
				{
					byte currentByte = 0;
					do
					{
						currentByte = (byte)_stream.ReadByte();
						if (currentByte != 0) messageBytes.Add(currentByte);
					} while (currentByte != 0);

					var buffer = messageBytes.ToArray();
					var messageString = Encoding.UTF8.GetString(buffer);
					Debug.WriteLine($"S:{messageString}");
					_receiver?.Receive(messageString);
					messageBytes.Clear();
				}
			});

		}
		public Task Send<T>(T message) where T : class, new()
		{
			if (_stream is null) throw new ArgumentNullException(nameof(_stream), "Нет подключения");

			var xmlString = Xmls.From(message);
			Debug.WriteLine($"C:{xmlString}");
			var bytes = Encoding.UTF8.GetBytes(xmlString);
			var messageBytes = new byte[bytes.Length + 1];
			Array.Copy(bytes, 0, messageBytes, 0, bytes.Length);
			_stream.Write(messageBytes);
			return Task.CompletedTask;
		}

		public void Bind(ICommunigateReceiver communigateReceiver)
			=> _receiver = communigateReceiver;
	}
}
