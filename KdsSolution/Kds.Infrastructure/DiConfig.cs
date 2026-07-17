using Kds.Application.Interface;
using Kds.Application.UnitOfWork;
using Kds.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure
{
	public static class DiConfig
	{
		public static void RepositoryInterfaceDiConfig(this IServiceCollection services)
		{
			services.AddScoped<OrderRepositoryInterface, OrderRepository>();
			services.AddScoped<KotRepositoryInterface, KotRepository>();
			services.AddScoped<OrderItemRepositoryInterface, OrderItemRepository>();
			services.AddScoped<MenuItemRepositoryInterface, MenuItemRepository>();
			services.AddScoped<UnitOfWorkInterface, UnitOfWork>();
		}

	}
}
