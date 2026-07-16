using Kds.Application.DTO;
using Kds.Application.ServiceInterface;
using Kds.Domain.Entities;
using Kds.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Services
{
	public class OrderService : OrderServiceInterface
	{
		public Task<Order> CreateTableOrder(OrderCreateDto orderCreateDto)
		{
			var order = new Order(orderCreateDto.TableNumber, OrderTypeEnum.DineIn);
			var kotNo = 1;
			var kot = new Kot(order, kotNo);
			throw new NotImplementedException();
		}
	}
}
