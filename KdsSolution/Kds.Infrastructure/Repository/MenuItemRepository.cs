using Kds.Application.Interface;
using Kds.Domain.Entities;
using Kds.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Kds.Infrastructure.Repository
{
	public class MenuItemRepository: MenuItemRepositoryInterface
	{
		private readonly AppDbContext _dbContext;

		public MenuItemRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task InsertAsync(MenuItem menuItem)
		{
			await _dbContext.MenuItems.AddAsync(menuItem);
		}

		public async Task<MenuItem?> GetByIdAsync(long id)
		{
			return await _dbContext.MenuItems
				.FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<IList<MenuItem>> GetAllAsync()
		{
			return await _dbContext.MenuItems
				.ToListAsync();
		}

		public async Task<MenuItem?> GetByName(string menuItemName)
		{
			return await _dbContext.MenuItems
				.FirstOrDefaultAsync(m => m.Name == menuItemName);
		}
	}
}
