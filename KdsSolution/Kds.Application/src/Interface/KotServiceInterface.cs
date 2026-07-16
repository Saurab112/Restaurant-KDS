using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Interface
{
	public interface KotServiceInterface
	{
		Task MarkKotAsPreparationStarted(long kotId);
		Task MarkKotAsReady(long kotId);
		Task MarkKotAsCancelled(long kotId);
	}
}
