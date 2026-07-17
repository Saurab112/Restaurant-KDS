namespace Kds.WebApi.Models
{
	public class ExceptionResponseApiModel
	{
		public ExceptionResponseApiModel()
		{
		}

		public ExceptionResponseApiModel(Exception response)
		{
			ExceptionName = response.GetType().Name;
			Description = response.Message;
		}

		public string ExceptionName { get; set; }
		public string Description { get; set; }
	}
}
