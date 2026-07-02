using Kds.Domain.Enums;

namespace Kds.Domain.Entities
{
	public class Order
	{
		protected Order() { }

		public Order(string ticketNumber, string? tableNumber, OrderTypeEnum orderType)
		{
			Id = Guid.NewGuid();
			TicketNumber = ticketNumber;
			TableNumber = tableNumber;
			OrderType = orderType;
			Status = OrderStatusEnum.Pending;
			CreatedAt = DateTime.Now;
		}

		public Guid Id { get; protected set; }
		public string TicketNumber { get; protected set; } = null!;
		public string? TableNumber { get; protected set; }
		public OrderTypeEnum OrderType { get; protected set; } = null!;
		public OrderStatusEnum Status { get; protected set; } = null!;
		public DateTime CreatedAt { get; protected set; }

		public ICollection<OrderItem> OrderItems { get; protected set; } = new List<OrderItem>();
		public ICollection<OrderTimeline> OrderTimelines { get; protected set; } = new List<OrderTimeline>();
	}
}
