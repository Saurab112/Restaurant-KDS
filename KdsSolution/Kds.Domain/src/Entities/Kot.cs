using Kds.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Kds.Domain.Entities
{
	public class Kot
	{
		protected Kot() { }

		public Kot(Order order,long kotNo)
		{
			RestaurantOrder = order;
			CreatedOn = DateTime.Now;
			KotNo = kotNo;
			Status = KotStatusEnum.Pending;
		}
		public long Id { get; protected set; }
		public long OrderId { get; protected set; }
		public Order RestaurantOrder { get; protected set; }
		public DateTime CreatedOn { get; protected set; }
		public long KotNo { get; protected set; }
		public bool IsKotPrinted { get; protected set; }
		public DateTime KotPrintedOn { get; protected set; }
		public bool IsCancelKotPrinted { get; protected set;  }
		public DateTime CancelledKotPrintedOn { get; protected set;  }
		public KotStatusEnum Status { get; protected set; }
	}
}
