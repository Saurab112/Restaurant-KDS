using Kds.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Converters
{
	public class OrderTypeConverter : ValueConverter<OrderTypeEnum, int>
	{
		public OrderTypeConverter()
			: base(
				type => type.Id,
				id => ConvertToOrderType(id)
			)
		{
		}

		private static OrderTypeEnum ConvertToOrderType(int id) => id switch
		{
			1 => OrderTypeEnum.DineIn,
			2 => OrderTypeEnum.Takeaway,
			3 => OrderTypeEnum.Delivery,
			_ => throw new ArgumentOutOfRangeException(nameof(id), $"Unknown Order Type ID: {id}")
		};
	}
}
