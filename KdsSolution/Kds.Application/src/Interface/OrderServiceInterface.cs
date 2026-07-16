using Kds.Application.DTO;
using Kds.Domain.Entities;

namespace Kds.Application.Interface
{
	public interface OrderServiceInterface
	{
		Task<Order> CreateTableOrder(OrderCreateDto orderCreateDto);
		Task MarkOrderItemAsPreparationStarted(long orderItemId, long userId);
		Task MarkOrderItemAsReady(long orderItemId, long userId);

	}
}
