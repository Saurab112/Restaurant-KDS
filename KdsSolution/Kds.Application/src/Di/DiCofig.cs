using Kds.Application.Interface;
using Kds.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kds.Application.Di
{
	public static class DiCofig
	{
		public static void ServiceInterfaceDiConfig(this IServiceCollection services)
		{
			services.AddScoped<OrderServiceInterface, OrderService>();
			services.AddScoped<KotServiceInterface, KotService>();
			services.AddScoped<MenuItemServiceInterface, MenuItemService>();
			services.AddScoped<SequenceServiceInterface, SequenceService>();
		}
	}
}
