using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Exceptions.Kot
{
	public class KotAlreadyReadyException : Exception
	{
		public KotAlreadyReadyException(long kotId, string message = "Kot already ready.") : base(message)
		{

		}
		private long KotId { get; }

		public override string Message => $"{base.Message}, Kot Id: {KotId}";
	}
}
