using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Enums
{
	public class OrderTypeEnum
	{
		public int Id { get; private set; }
		public string Name { get; private set; }

		private OrderTypeEnum(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public static readonly OrderTypeEnum DineIn = new(1, "DineIn");
		public static readonly OrderTypeEnum Takeaway = new(2, "Takeaway");
		public static readonly OrderTypeEnum Delivery = new(3, "Delivery");
	}
}
