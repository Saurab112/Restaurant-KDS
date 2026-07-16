using Kds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Interface
{
	public interface KotRepositoryInterface
	{
		Task<Kot?> GetKotByIdAsync(long kotId);
		Task<Kot?> GetByKotNumber(long kotNo);
	}
}
