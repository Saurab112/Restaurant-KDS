namespace Kds.WebApi.ApiModel
{
	public class OrderItemResponseApiModel
	{
		public long OrderItemId { get; set; }
		public long KotId { get; set; }
		public long KotNo { get; set; }
		public long MenuItemId { get; set; }
		public string MenuItemName { get; set; } = null!;
		public decimal Rate { get; set; }
		public decimal Amount { get; set; }
		public long Quantity { get; set; }
		public string? Remarks { get; set; }
		public string Status { get; set; } = null!;
		public DateTime CreatedOn { get; set; }
		public DateTime? CancelledOn { get; set; }
	}
}
