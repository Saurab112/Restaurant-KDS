namespace Kds.WebApi.ApiModel.Kot
{
	public class KotResponseApiModel
	{
		public long KotId { get; set; }
		public long OrderId { get; set; }
		public long KotNo { get; set; }
		public string Status { get; set; } = null!;
		public DateTime CreatedOn { get; set; }
		public DateTime? KotPreparationStartedOn { get; set; }
		public DateTime? KotReadyOn { get; set; }
		public DateTime? KotCancelledOn { get; set; }
		public DateTime? KotCompletedOn { get; set; }
		public List<KotItemResponseApiModel> OrderItems { get; set; } = new();
	}
}
