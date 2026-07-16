using Kds.Application.DTO;
using Kds.Application.ServiceInterface;
using Kds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Services
{
	public class OrderService : OrderServiceInterface
	{
		public Task<Order> CreateTableOrder(OrderCreateDto orderCreateDto)
		{
			throw new NotImplementedException();
		}
	}
}
