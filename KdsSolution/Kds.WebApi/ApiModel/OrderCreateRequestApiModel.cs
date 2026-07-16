using System.ComponentModel.DataAnnotations;

namespace Kds.WebApi.ApiModel
{
	public class OrderCreateRequestApiModel
	{
		public string? TableNumber { get; set; }
		public List<OrderItemCreateRequestApiModel> OrderItems { get; set; } = new List<OrderItemCreateRequestApiModel>();
	}
}
