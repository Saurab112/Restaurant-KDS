using Kds.Domain.Enums;

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
		public KotStatusEnum Status { get; protected set; }
		public ICollection<OrderItem> OrderItems { get; protected set; } = new List<OrderItem>();
		public DateTime? KotPreparationStartedOn { get; protected set; }
		public DateTime? KotReadyOn { get; protected set; }
		public DateTime? KotCancelledOn { get; protected set; }
		public DateTime? KotCompletedOn { get; protected set; }

		public void MarkAsPreparationStarted()
		{
			Status = KotStatusEnum.Preparing;
		}
		public void MarkAsReady()
		{
			Status = KotStatusEnum.Ready;
			KotReadyOn = DateTime.Now;
		}
		public void MarkAsCancelled()
		{
			Status = KotStatusEnum.Cancelled;
			KotCancelledOn = DateTime.Now;
		}

		public void MarkAsCompleted()
		{
			Status = KotStatusEnum.Completed;
			KotCompletedOn = DateTime.Now;
		}

	}
}
