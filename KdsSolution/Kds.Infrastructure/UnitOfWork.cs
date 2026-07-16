using Kds.Application.UnitOfWork;
using Kds.Infrastructure.Data;

namespace Kds.Infrastructure
{
	public class UnitOfWork : UnitOfWorkInterface
	{
		private readonly AppDbContext _dbContext;

		public UnitOfWork(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task SaveChangesAsync(CancellationToken t)
		{
			await _dbContext.SaveChangesAsync(t);
		}
	}
}
