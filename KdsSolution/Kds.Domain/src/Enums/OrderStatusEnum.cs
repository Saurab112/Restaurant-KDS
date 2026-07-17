namespace Kds.Domain.Enums
{
	public class OrderStatusEnum : Enumeration
	{
		private const string StatusPending = "Pending";
		private const string StatusPreparing = "Preparing";
		private const string StatusReady = "Ready";
		private const string StatusCompleted = "Completed";
		private const string StatusCancelled = "Cancelled";

		private OrderStatusEnum(int id, string name)
			: base(id, name)
		{
		}

		public static readonly OrderStatusEnum Pending =
			new(1, StatusPending);

		public static readonly OrderStatusEnum Preparing =
			new(2, StatusPreparing);

		public static readonly OrderStatusEnum Ready =
			new(3, StatusReady);

		public static readonly OrderStatusEnum Completed =
			new(4, StatusCompleted);

		public static readonly OrderStatusEnum Cancelled =
			new(5, StatusCancelled);
	}
}
