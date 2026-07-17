using Kds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.DTO
{
	public class OrderItemDto
	{
		public long MenuItemId { get; set; }
		public long Quantity { get; set; }
		public string? Remarks { get; set; }
	}
}
