using Kds.Application.Interface;
using Kds.Domain.Entities;
using Kds.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kds.Infrastructure.Repository
{
	public class OrderRepository : OrderRepositoryInterface
	{
		private readonly AppDbContext _dbContext;

		public OrderRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<Order?> GetByIdAsync(long orderId)
		{
			return await _dbContext.Orders
				.Include(e => e.OrderItems)
				.ThenInclude(e => e.MenuItem)
				.Include(e => e.OrderItems)
						.ThenInclude(e => e.Kot)
				.SingleOrDefaultAsync(e => e.OrderId == orderId)
				.ConfigureAwait(false);
		}

		public async Task InsertAsync(Order restaurantOrder)
		{
			await _dbContext.Orders.AddAsync(restaurantOrder);
		}
	}
}
