using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Enums
{
	public class KotStatusEnum
	{
		public int Id { get; private set; }
		public string Name { get; private set; }

		private KotStatusEnum(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public static readonly KotStatusEnum Pending = new(1, "Pending");
		public static readonly KotStatusEnum Preparing = new(2, "Preparing");
		public static readonly KotStatusEnum Ready = new(3, "Ready");
		public static readonly KotStatusEnum Cancelled = new(4, "Cancelled");
		public static readonly KotStatusEnum Completed = new(5, "Completed");
	}
}
