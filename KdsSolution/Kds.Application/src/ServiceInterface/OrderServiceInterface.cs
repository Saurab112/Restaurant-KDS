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
		Task MarkKotAsPrinted(long orderId, long kotNo);
		Task MarkKotAsPreparationStarted(long orderId, long kotId);
		Task MarkKotAsReady(long orderId, long kotId);
		Task MarkKotAsCancelled(long orderId, long kotId);
		Task MarkOrderItemAsPreparationStarted(long orderItemId);
		Task MarkOrderItemAsReady(long orderItemId);

	}
}
