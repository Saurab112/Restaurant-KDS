using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Interface
{
	public interface SequenceRepositoryInterface
	{
		Task<long> GenerateSequenceId(string sequenceKey, string sequenceGroup, long defaultValue = 1);
	}
}
