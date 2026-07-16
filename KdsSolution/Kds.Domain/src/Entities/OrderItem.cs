using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Entities
{
	public class OrderItem
	{
		protected OrderItem() { }

		public OrderItem(Order order, MenuItem menuItem, long quantity, string? remarks)
		{
			Order = order;
			OrderId = order.OrderId;
			MenuItem = menuItem;
			Quantity = quantity;
			Remarks = remarks;
			CreatedOn = DateTime.Now;
		}

		public long Id { get; protected set; }
		public long OrderId { get; protected set; }
		public Order Order { get; protected set; } = null!; 
		public long MenuItemId { get; protected set; }
		public MenuItem MenuItem { get; protected set; } = null!; 
		public long Quantity { get; protected set; } 
		public string? Remarks { get; protected set; } 
		//newly added
		public DateTime CreatedOn { get; protected set; }
	}
}
