using Kds.WebApi.ApiModel.Kot;

namespace Kds.WebApi.ApiModel
{
	public class OrderResponseApiModel
	{
		public long OrderId { get; set; }
		public string? TableNumber { get; set; }
		public string OrderStatus { get; set; } = null!;
		public DateTime CreatedOn { get; set; }
		public List<KotResponseApiModel> Kots { get; set; } = new();
		public List<OrderItemResponseApiModel> OrderItems { get; set; } = new();
	}
}
