using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Exceptions.OrderItem
{
	public class OrderItemAlreadyCancelledException : Exception
	{
		public OrderItemAlreadyCancelledException(long? orderItemId = null, string? message = "Order Item Already Cancelled.") : base(message)
		{
			OrderItemId = orderItemId;
		}

		private long? OrderItemId { get; }

		public override string Message => $"{base.Message}, Order Item Id: {OrderItemId}";
	}
}
