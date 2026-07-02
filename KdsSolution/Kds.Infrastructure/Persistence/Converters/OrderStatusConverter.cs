using Kds.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Converters
{
	public class OrderStatusConverter : ValueConverter<OrderStatusEnum, int>
	{
		public OrderStatusConverter()
			: base(
				status => status.Id, 
				id => ConvertToOrderStatus(id) 
			)
		{
		}

		private static OrderStatusEnum ConvertToOrderStatus(int id) => id switch
		{
			1 => OrderStatusEnum.Pending,
			2 => OrderStatusEnum.Preparing,
			3 => OrderStatusEnum.Ready,
			4 => OrderStatusEnum.Completed,
			5 => OrderStatusEnum.Cancelled,
			_ => throw new ArgumentOutOfRangeException(nameof(id), $"Unknown Order Status ID: {id}")
		};
	}
}
