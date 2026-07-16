namespace Kds.WebApi
{
	public static class ApiEndPoint
	{
		public const string Module = "/" + "Restaurant" + "/api/";

		//order api
		public const string OrderBaseEndPoint = Module + "order";
		public const string OrderId = "{orderId}";
		public const string OrderItemId = "{orderItemId}";

		public const string OrderItemMarkAsPreparationStarted =	OrderBaseEndPoint + "/" + OrderId + "/order-item/" + OrderItemId + "/preparation-started";

		public const string OrderItemMarkAsReady =
		OrderBaseEndPoint + "/" + OrderId + "/order-item/" + OrderItemId + "/ready";

		public const string OrderItemMarkAsCancelled =
		OrderBaseEndPoint + "/" + OrderId + "/order-item/" + OrderItemId + "/cancelled";

		//kot api
		public const string KotBaseEndPoint = Module + "kot";
		public const string KotId = "{kotId}";
		public const string MarkKotAsPreparationStarted = KotBaseEndPoint + "/" + KotId + "/mark-kot-as-preparation-started";
		public const string MarkKotAsReady = KotBaseEndPoint + "/" + KotId + "/mark-kot-as-ready";
		public const string MarkKotAsCancelled = KotBaseEndPoint + "/" + KotId + "/mark-kot-as-cancelled";
	}
}
