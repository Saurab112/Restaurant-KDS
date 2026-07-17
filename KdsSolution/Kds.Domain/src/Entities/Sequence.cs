using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Entities
{
	public class Sequence
	{
		public string SequenceKey { get; private set; } = default!;
		public string SequenceGroup { get; private set; } = default!;
		public long SequenceValue { get; private set; }

		private Sequence() { } 

		public Sequence(string sequenceKey, string sequenceGroup, long sequenceValue = 1)
		{
			SequenceKey = sequenceKey;
			SequenceGroup = sequenceGroup;
			SequenceValue = sequenceValue;
		}
	}
}
