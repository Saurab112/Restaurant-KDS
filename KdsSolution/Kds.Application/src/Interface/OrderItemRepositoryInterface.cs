using Kds.Domain.Entities;

namespace Kds.Application.Interface
{
	public interface OrderItemRepositoryInterface
	{
		Task<OrderItem?> GetByOrderItemId(long orderItemId);

	}
}
