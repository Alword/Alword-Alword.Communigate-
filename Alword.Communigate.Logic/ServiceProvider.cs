using Microsoft.Extensions.DependencyInjection;

namespace Alword.Communigate.Logic
{
	internal static class ServiceProvider
	{
		public static IServiceCollection AddCommunigate(this IServiceCollection services)
		{
			return services;
		}
	}
}
