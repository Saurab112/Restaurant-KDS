using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Entities
{
	public class OrderItem
	{
		protected OrderItem() { }

		public OrderItem(Order order, long menuItemId, long quantity, string? remarks)
		{
			Order = order;
			OrderId = order.OrderId;
			MenuItemId = menuItemId;
			Quantity = quantity;
			Remarks = remarks;
		}

		public long Id { get; protected set; }
		public long OrderId { get; protected set; }
		public Order Order { get; protected set; } = null!; 
		public long MenuItemId { get; protected set; }
		public MenuItem MenuItem { get; protected set; } = null!; 
		public long Quantity { get; protected set; } 
		public string? Remarks { get; protected set; } 
	}
}
