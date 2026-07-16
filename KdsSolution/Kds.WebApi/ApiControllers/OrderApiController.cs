using Microsoft.AspNetCore.Mvc;

namespace Kds.WebApi.ApiControllers
{
	[ApiController]
	public class OrderApiController: ControllerBase
	{
		public async Task<IActionResult> CreateTableOrder()
		{
			return Ok();
		}
	}
}
