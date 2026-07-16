using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Enums
{
	public class OrderItemStatusEnum
	{
		public int Id { get; private set; }
		public string Name { get; private set; }

		private OrderItemStatusEnum(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public static readonly OrderItemStatusEnum Received = new(1, "Received");
		public static readonly OrderItemStatusEnum Preparing = new(2, "Preparing");
		public static readonly OrderItemStatusEnum Ready = new(3, "Ready");
		public static readonly OrderItemStatusEnum Cancelled = new(4, "Cancelled");
		public static readonly OrderItemStatusEnum Completed = new(4, "Completed");
	}
}
