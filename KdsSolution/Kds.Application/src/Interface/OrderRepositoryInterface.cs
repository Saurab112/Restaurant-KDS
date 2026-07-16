using Kds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Interface
{
	public interface OrderRepositoryInterface
	{
		Task InsertAsync(Order restaurantOrder);
		Task<Order?> GetByIdAsync(long orderId);
	}
}
