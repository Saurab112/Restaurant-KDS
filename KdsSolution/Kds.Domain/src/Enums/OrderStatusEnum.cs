using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Enums
{
	public class OrderStatusEnum
	{
		public int Id { get; private set; }
		public string Name { get; private set; }

		private OrderStatusEnum(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public static readonly OrderStatusEnum Pending = new(1, "Pending");
		public static readonly OrderStatusEnum Preparing = new(2, "Preparing");
		public static readonly OrderStatusEnum Ready = new(3, "Ready");
		public static readonly OrderStatusEnum Completed = new(4, "Completed");
		public static readonly OrderStatusEnum Cancelled = new(5, "Cancelled");
	}
}
