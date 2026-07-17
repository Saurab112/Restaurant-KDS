using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Entities
{
	public class Sequence
	{
		public long SequenceId { get; protected set; }
		public string SequenceKey { get; protected set; } = null!;
		public string SequenceGroup { get; protected set; } = null!;
		public long SequenceValue { get; protected set; }

	}
}
