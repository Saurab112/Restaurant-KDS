using Kds.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Converters
{
	public class OrderItemStatusConverter : ValueConverter<OrderItemStatusEnum, int>
	{
		public OrderItemStatusConverter()
			: base(
				status => status.Id,
				id => ConvertToOrderItemStatus(id)
			)
		{
		}
		private static OrderItemStatusEnum ConvertToOrderItemStatus(int id) => id switch
		{
			1 => OrderItemStatusEnum.Received,
			2 => OrderItemStatusEnum.Preparing,
			3 => OrderItemStatusEnum.Ready,
			4 => OrderItemStatusEnum.Completed,
			5 => OrderItemStatusEnum.Cancelled,
			_ => throw new ArgumentOutOfRangeException(nameof(id), $"Unknown Order Item Status ID: {id}")
		};
	
	}

}
