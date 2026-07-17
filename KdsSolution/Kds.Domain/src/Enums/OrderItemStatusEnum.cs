using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Enums
{
	public class OrderItemStatusEnum : Enumeration
	{
		private const string StatusReceived = "Received";
		private const string StatusPreparing = "Preparing";
		private const string StatusReady = "Ready";
		private const string StatusCancelled = "Cancelled";
		private const string StatusCompleted = "Completed";

		private OrderItemStatusEnum(int id, string name)
			: base(id, name)
		{
		}

		public static readonly OrderItemStatusEnum Received =
			new(1, StatusReceived);

		public static readonly OrderItemStatusEnum Preparing =
			new(2, StatusPreparing);

		public static readonly OrderItemStatusEnum Ready =
			new(3, StatusReady);

		public static readonly OrderItemStatusEnum Cancelled =
			new(4, StatusCancelled);

		public static readonly OrderItemStatusEnum Completed =
			new(5, StatusCompleted);

		public static OrderItemStatusEnum FromName(string name)
		{
			return name switch
			{
				StatusReceived => Received,
				StatusPreparing => Preparing,
				StatusReady => Ready,
				StatusCancelled => Cancelled,
				StatusCompleted => Completed,
				_ => throw new ArgumentException("Invalid OrderItemStatus name", nameof(name))
			};
		}
	}
}
