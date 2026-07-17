using Kds.Domain.Enums;

namespace Kds.Domain.Entities
{
	public class OrderItem
	{
		protected OrderItem() { }

		public OrderItem(Order order, Kot kot, MenuItem menuItem, long quantity, string? remarks)
		{
			Order = order;
			OrderId = order.OrderId;
			Kot = kot;
			MenuItem = menuItem;
			Quantity = quantity;
			Remarks = remarks;
			Status = OrderItemStatusEnum.Received;
			CreatedOn = DateTime.Now;
		}

		public long Id { get; protected set; }
		public long OrderId { get; protected set; }
		public Order Order { get; protected set; } = null!;
		public long KotId { get; protected set; }
		public Kot Kot { get; protected set; } = null!;
		public long MenuItemId { get; protected set; }
		public MenuItem MenuItem { get; protected set; } = null!; 
		public long Quantity { get; protected set; } 
		public string? Remarks { get; protected set; } 
		public DateTime CreatedOn { get; protected set; }
		public OrderItemStatusEnum Status { get; protected set; } = null!;
		public DateTime? CancelledOn { get; protected set; }
		public void MarkAsReady()
		{
			Status = OrderItemStatusEnum.Ready;
		}
		public bool IsCancelled()
		{
			return Status == OrderItemStatusEnum.Cancelled;
		}
		public bool IsPreparationStarted()
		{
			return Status == OrderItemStatusEnum.Preparing;
		}
		public bool IsReady()
		{
			return Status == OrderItemStatusEnum.Ready;
		}

		public bool IsCompleted()
		{
			return Status == OrderItemStatusEnum.Completed;
		}

		public void MarkAsPreparationStarted()
		{
			Status = OrderItemStatusEnum.Preparing;
		}
	}
}
