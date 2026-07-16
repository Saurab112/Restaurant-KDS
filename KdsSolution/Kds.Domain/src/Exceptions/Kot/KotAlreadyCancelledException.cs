using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Exceptions.Kot
{
	public class KotAlreadyCancelledException : Exception
	{
		public KotAlreadyCancelledException(long kotId, string message = "Kot already cancelled.") : base(message)
		{
			KotId = kotId;
		}
		private long KotId { get; }

		public override string Message => $"{base.Message}, Kot Id: {KotId}";
	}
}
