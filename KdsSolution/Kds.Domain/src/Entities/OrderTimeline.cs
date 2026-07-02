using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Entities
{
	public class OrderTimeline
	{
		protected OrderTimeline() { }

		internal OrderTimeline(Guid orderId, string fromStatus, string toStatus)
		{
			Id = Guid.NewGuid();
			OrderId = orderId;
			FromStatus = fromStatus;
			ToStatus = toStatus;
			ChangedAt = DateTime.Now;
		}

		public Guid Id { get; protected set; }
		public Guid OrderId { get; protected set; }
		public Order Order { get; protected set; } = null!;
		public string FromStatus { get; protected set; } = null!;
		public string ToStatus { get; protected set; } = null!;
		public DateTime ChangedAt { get; protected set; }
	}
}
