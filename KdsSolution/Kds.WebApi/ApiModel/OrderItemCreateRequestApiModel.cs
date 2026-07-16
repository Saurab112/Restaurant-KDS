using System.ComponentModel.DataAnnotations;

namespace Kds.WebApi.ApiModel
{
	public class OrderItemCreateRequestApiModel
	{
		public long Quantity { get; set; }
		public decimal Rate { get; set; }
		public long MenuItemId { get; set; }
		public string? Remarks { get; set; }
	}
}
