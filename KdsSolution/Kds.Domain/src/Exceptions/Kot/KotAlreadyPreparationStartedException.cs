using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Exceptions.Kot
{
	public class KotAlreadyPreparationStartedException : Exception
	{
		public KotAlreadyPreparationStartedException(long kotId, string message = "Kot already preparation started.") : base(message)
		{
			KotId = kotId;
		}
		private long KotId { get; }

		public override string Message => $"{base.Message}, Kot Id: {KotId}";
	}
}
