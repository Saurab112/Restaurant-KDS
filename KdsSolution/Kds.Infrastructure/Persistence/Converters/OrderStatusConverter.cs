using Kds.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Infrastructure.Persistence.Converters
{
	public class OrderStatusConverter : ValueConverter<OrderStatusEnum, string>
	{
		public OrderStatusConverter()
			: base(
				status => status.Name,
				name => Enumeration.GetAll<OrderStatusEnum>().FirstOrDefault(status => status.Name == name)
			)
		{
		}
	}
}
