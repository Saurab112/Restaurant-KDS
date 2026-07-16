using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Exceptions.Kot
{
	public class KotNotFoundException : Exception
	{
		public KotNotFoundException(long kotId, string message = "Kot Not Found.") : base(message)
		{
			KotId = kotId;
		}

		public long KotId { get; }
		public override string Message => $"{base.Message} KotId: {KotId}";
	}
}
