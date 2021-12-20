using Alword.Communigate.Logic.Command;
using Alword.Communigate.Logic.Config;
using Alword.Communigate.Logic.Interop;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Xunit;

namespace Alword.Communigate.Logic.Tests
{
	public class CommunigateSenderTests
	{
		[Fact]
		public async Task AsyncLogin()
		{
			// arrange
			var sut = Client();
			// act
			var loginCommad = new Login()
			{
				Password = "admin",
				AuthData = "alword@mail.example.com",
			};
			var response = await sut.LoginAsync(loginCommad);
			// assert
			Assert.Equal(loginCommad.AuthData, response.UserName);
		}

		[Fact]
		public async Task AsyncMailBoxLogin()
		{
			// arrange
			var sut = AuthorizedClient();
			var command = new MailboxList();
			// act
			var response = await sut.MailboxList(command);
			// assert
			Assert.Single(response);
		}

		[Fact]
		public async Task AsyncMailBoxSync()
		{
			// arrange
			var sut = AuthorizedClient();
			var command = new MailboxSync()
			{
				Folder = "INBOX"
			};
			// act
			var response = await sut.MailboxSync(command);
			// assert
			Assert.Single(response);
		}

		private CommunigateSender Client()
		{
			var options = Options.Create(new CommunigateConfig()
			{
				Host = "127.0.0.1",
				Port = 11024,
			});
			var client = new CommunigateSender(options);
			return client;
		}

		private CommunigateSender AuthorizedClient()
		{
			var client = Client();
			var loginCommad = new Login()
			{
				Password = "admin",
				AuthData = "alword@mail.example.com",
			};
			client.LoginAsync(loginCommad).GetAwaiter().GetResult();
			return client;
		}
	}
}
