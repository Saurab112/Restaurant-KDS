using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Interface
{
	public interface SequenceServiceInterface
	{
		Task<long> GenerateSequenceId(string sequenceKey, string sequenceGroup, long defaultValue = 1);

	}
}
