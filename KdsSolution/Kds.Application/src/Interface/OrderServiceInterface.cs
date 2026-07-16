using Kds.Application.DTO;
using Kds.Domain.Entities;

namespace Kds.Application.Interface
{
	public interface OrderServiceInterface
	{
		Task<Order> CreateTableOrder(OrderCreateDto orderCreateDto);
		Task MarkOrderItemAsPreparationStarted(long orderItemId);
		Task MarkOrderItemAsReady(long orderItemId);

	}
}
