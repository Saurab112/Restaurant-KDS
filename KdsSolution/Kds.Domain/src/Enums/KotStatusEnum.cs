using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Enums
{
	public class KotStatusEnum : Enumeration
	{
		private const string StatusPending = "Pending";
		private const string StatusPreparing = "Preparing";
		private const string StatusReady = "Ready";
		private const string StatusCancelled = "Cancelled";
		private const string StatusCompleted = "Completed";

		private KotStatusEnum(int id, string name)
			: base(id, name)
		{
		}

		public static readonly KotStatusEnum Pending =
			new(1, StatusPending);

		public static readonly KotStatusEnum Preparing =
			new(2, StatusPreparing);

		public static readonly KotStatusEnum Ready =
			new(3, StatusReady);

		public static readonly KotStatusEnum Cancelled =
			new(4, StatusCancelled);

		public static readonly KotStatusEnum Completed =
			new(5, StatusCompleted);

		public static KotStatusEnum FromName(string name)
		{
			return name switch
			{
				StatusPreparing => Preparing,
				StatusReady => Ready,
				StatusCancelled => Cancelled,
				StatusPending => Pending,
				StatusCompleted => Completed,
				_ => throw new ArgumentException("Invalid KotStatus name", nameof(name))
			};
		}
	}
}
