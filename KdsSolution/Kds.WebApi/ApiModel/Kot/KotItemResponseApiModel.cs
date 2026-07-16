namespace Kds.WebApi.ApiModel.Kot
{
	public class KotItemResponseApiModel
	{
		public long OrderItemId { get; set; }
		public long MenuItemId { get; set; }
		public string MenuItemName { get; set; } = null!;
		public long Quantity { get; set; }
		public string? Remarks { get; set; }
		public string Status { get; set; } = null!;
		public DateTime CreatedOn { get; set; }
		public DateTime? CancelledOn { get; set; }
	}
}
