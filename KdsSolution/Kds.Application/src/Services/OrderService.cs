using Kds.Application.DTO;
using Kds.Application.Interface;
using Kds.Domain.Entities;

namespace Kds.Application.Services
{
	public class OrderService : OrderServiceInterface
	{
		public Task<Order> CreateTableOrder(OrderCreateDto orderCreateDto)
		{
			throw new NotImplementedException();

		}

		public Task MarkCancelledKotAsPrinted(long orderId, long kotNo, List<long> orderItemIds, long markAsCancelKotPrintedUserId)
		{
			throw new NotImplementedException();
		}

		public Task MarkKotAsPrinted(long orderId, long kotNo, long markKotAsPrintedUserId)
		{
			throw new NotImplementedException();
		}

		public Task MarkOrderAsReady(OrderStatusReadyDto dto)
		{
			throw new NotImplementedException();
		}

		public Task MarkOrderItemAsPreparationStarted(long orderItemId, long userId)
		{
			throw new NotImplementedException();
		}

		public Task MarkOrderItemAsReady(long orderItemId, long userId)
		{
			throw new NotImplementedException();
		}
	}
}
