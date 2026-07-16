using Kds.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Entities
{
	public class Kot
	{
		public long Id { get; protected set; }
		public long OrderId { get; protected set; }
		public Order Order { get; protected set; }
		public DateTime CreatedOn { get; protected set; }
		public long KotNo { get; protected set; }
		public bool IsKotPrinted { get; protected set; }
		public DateTime KotPrintedOn { get; protected set; }
		public bool IsCancelKotPrinted { get; protected set;  }
		public DateTime CancelledKotPrintedOn { get; protected set;  }
		public KotStatusEnum Status { get; protected set; }
	}
}
