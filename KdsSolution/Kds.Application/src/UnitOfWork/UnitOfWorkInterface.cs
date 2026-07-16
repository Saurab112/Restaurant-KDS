using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.UnitOfWork
{
	public interface UnitOfWorkInterface
	{
		public Task SaveChangesAsync(CancellationToken t);

	}
}
