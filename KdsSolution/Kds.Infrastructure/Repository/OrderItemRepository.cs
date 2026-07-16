using Kds.Application.Interface;
using Kds.Domain.Entities;
using Kds.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kds.Infrastructure.Repository
{
	public class OrderItemRepository: OrderItemRepositoryInterface
	{
		private readonly AppDbContext _dbContext;

		public OrderItemRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<OrderItem?> GetByOrderItemId(long orderItemId)
		{
			return await _dbContext.OrderItems
				.Include(e => e.Order)
				.FirstOrDefaultAsync(x => x.Id == orderItemId);
		}
	}
}
