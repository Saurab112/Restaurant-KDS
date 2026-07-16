using Kds.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.DTO
{
	public class OrderCreateDto
	{
		public string? TableNumber { get; set; }
		public OrderTypeEnum OrderType { get; set; }
		public List<OrderItemDto> OrderItems { get; set; }

	}
}
