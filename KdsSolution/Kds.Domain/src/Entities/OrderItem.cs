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
			Id = Guid.NewGuid();
			Order = order;
			OrderId = order.Id;
			MenuItemId = menuItemId;
			Quantity = quantity;
			Remarks = remarks;
		}

		public Guid Id { get; protected set; }
		public Guid OrderId { get; protected set; }
		public Order Order { get; protected set; } = null!; 
		public long MenuItemId { get; protected set; }
		public MenuItem MenuItem { get; protected set; } = null!; 
		public long Quantity { get; protected set; } 
		public string? Remarks { get; protected set; } 
	}
}
