using Kds.Domain.Enums;

namespace Kds.Domain.Entities
{
	public class Order
	{
		protected Order() { }

		public Order(string? tableNumber, OrderTypeEnum orderType)
		{
			TableNumber = tableNumber;
			OrderType = orderType;
			Status = OrderStatusEnum.Pending;
			CreatedOn = DateTime.Now;
		}

		public long OrderId { get; protected set; }
		public string? TableNumber { get; protected set; }
		public OrderTypeEnum OrderType { get; protected set; } = null!;
		public OrderStatusEnum Status { get; protected set; } = null!;
		public DateTime CreatedOn { get; protected set; }

		public ICollection<OrderItem> OrderItems { get; protected set; } = new List<OrderItem>();
		public ICollection<Kot> Kots { get; protected set; } = new List<Kot>();

		public void AddOrderItem(
			MenuItem menuItem,
			long quantity,
			string remarks,
			Kot kot
			)
		{
			var orderItem = new OrderItem(
				this,
				menuItem,
				quantity,
				remarks);
			OrderItems.Add(orderItem);
		}
	}
}
