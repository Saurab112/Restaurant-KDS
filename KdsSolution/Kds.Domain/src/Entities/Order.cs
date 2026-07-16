using Kds.Domain.Enums;
using Kds.Domain.Exceptions.OrderItem;

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

		public void AddOrderItem(MenuItem menuItem, long quantity, string? remarks, Kot kot)
		{
			var orderItem = new OrderItem(this, kot, menuItem, quantity, remarks);
			OrderItems.Add(orderItem);
		}

		public void MarkOrderItemAsPreparationStarted(long orderItemId)
		{
			var orderItem = OrderItems.SingleOrDefault(a => a.Id == orderItemId) ?? throw new OrderItemNotFoundException(orderItemId);
			if (orderItem.IsPreparationStarted()) throw new OrderItemAlreadyPreparationStartedException();
			if (orderItem.IsReady()) throw new OrderItemAlreadyReadyException();
			if (orderItem.IsCancelled()) throw new OrderItemAlreadyCancelledException();

			orderItem.MarkAsPreparationStarted();

			var kot = Kots.Where(a => a.Id == orderItem.KotId).SingleOrDefault();
			if (kot.OrderItems.All(a => a.Status == OrderItemStatusEnum.Preparing))
			{
				kot.MarkAsPreparationStarted();
			}

		}
		public void MarkOrderItemAsReady(long orderItemId)
		{
			var orderItem = OrderItems.SingleOrDefault(a => a.Id == orderItemId) ?? throw new OrderItemNotFoundException(orderItemId);
			if (orderItem.IsReady()) throw new OrderItemAlreadyReadyException();
			if (orderItem.IsCancelled()) throw new OrderItemAlreadyCancelledException();
			if (orderItem.IsCompleted()) throw new OrderItemAlreadyCompletedException();
			orderItem.MarkAsReady();

			var kot = Kots.Where(a => a.Id == orderItem.KotId).SingleOrDefault();
			if (kot.OrderItems.All(a => a.Status == OrderItemStatusEnum.Ready))
			{
				kot.MarkAsReady();
			}
		}
	}
}
