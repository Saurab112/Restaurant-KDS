using Kds.Application.Interface;
using Kds.Domain.Entities;
using Kds.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Repository
{
	public class KotRepository: KotRepositoryInterface
	{
		private readonly AppDbContext _dbContext;

		public KotRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<Kot?> GetKotByIdAsync(long kotId)
		{
			return await _dbContext.Kots.FirstOrDefaultAsync(a => a.Id == kotId);
		}

		public async Task<Kot?> GetByKotNumber(long kotNo)
		{
			return await _dbContext.Kots.Where(a => a.KotNo == kotNo).SingleOrDefaultAsync();
		}
	}
}
