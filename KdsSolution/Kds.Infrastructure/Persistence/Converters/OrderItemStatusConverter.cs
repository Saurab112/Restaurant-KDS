using Kds.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Converters
{
	public class OrderItemStatusConverter : ValueConverter<OrderItemStatusEnum, string>
	{
		public OrderItemStatusConverter() : base(
			v => v.Name,
			v => OrderItemStatusEnum.FromName(v))
		{
		}
	}

}
