using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Exceptions.OrderItem
{
	public class OrderItemNotFoundException : Exception
	{
		public OrderItemNotFoundException(long orderItemId, string message = "Order Item Not Found.") : base(message)
		{
			OrderItemId = orderItemId;
		}

		public long OrderItemId { get; }
		public override string Message => $"{base.Message} OrderItemId: {OrderItemId}";
	}
}
