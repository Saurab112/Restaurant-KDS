using Kds.Application.Interface;
using Kds.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Repository
{
	public class SequenceRepository : SequenceRepositoryInterface
	{
		private readonly AppDbContext _dbContext;
		public SequenceRepository(AppDbContext context)
		{
			_dbContext = context;
		}

		public async Task<long> GenerateSequenceId(string sequenceKey, string sequenceGroup, long defaultValue = 1)
		{
			await _dbContext.Database.ExecuteSqlRawAsync(@"INSERT INTO sequence (sequence_key, sequence_group, sequence_value) 
            VALUES ({0}, {1}, {2}) ON DUPLICATE KEY UPDATE sequence_value = LAST_INSERT_ID(sequence_value + 1);", sequenceKey, sequenceGroup, defaultValue);

			var nextValue = await _dbContext.Database
				.SqlQuery<long>($@"SELECT sequence_value AS Value 
                           FROM sequence 
                           WHERE sequence_key = {sequenceKey} 
                           AND sequence_group = {sequenceGroup}")
				.SingleAsync();

			return nextValue;
		}
	}
}
