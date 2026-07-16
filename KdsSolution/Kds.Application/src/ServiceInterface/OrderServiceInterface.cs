using Kds.Application.DTO;
using Kds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.ServiceInterface
{
	public interface OrderServiceInterface
	{
		Task<Order> CreateTableOrder(OrderCreateDto orderCreateDto);


	}
}
