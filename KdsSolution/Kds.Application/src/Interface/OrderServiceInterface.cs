using Kds.Application.DTO;
using Kds.Domain.Entities;

namespace Kds.Application.Interface
{
	public interface OrderServiceInterface
	{
		Task<Order> CreateTableOrder(OrderCreateDto orderCreateDto);
		Task MarkOrderAsReady(OrderStatusReadyDto dto);
		Task MarkKotAsPrinted(long orderId, long kotNo, long markKotAsPrintedUserId);
		Task MarkCancelledKotAsPrinted(long orderId, long kotNo, List<long> orderItemIds, long markAsCancelKotPrintedUserId);
		Task MarkOrderItemAsPreparationStarted(long orderItemId, long userId);
		Task MarkOrderItemAsReady(long orderItemId, long userId);

	}
}
