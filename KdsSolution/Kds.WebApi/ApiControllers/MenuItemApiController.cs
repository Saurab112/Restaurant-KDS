using Asp.Versioning;
using Kds.Application.DTO;
using Kds.Application.Interface;
using Kds.WebApi.ApiModel.MenuItem;
using Microsoft.AspNetCore.Mvc;

namespace Kds.WebApi.ApiControllers
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route(ApiEndPoint.MenuItemBaseEndPoint)]
	public class MenuItemApiController: ControllerBase
	{
		private readonly MenuItemServiceInterface _menuItemService;

		public MenuItemApiController(MenuItemServiceInterface menuItemService)
		{
			_menuItemService = menuItemService;
		}
		[HttpPost]
		public async Task<IActionResult> CreateMenuItem([FromBody] MenuItemCreateRequestApiModel apiModel)
		{
			var menuItemDto = new MenuItemDto
			{
				Name = apiModel.Name,
				Category = apiModel.Category,
				Price = apiModel.Price
			};
			await _menuItemService.CreateMenuItem(menuItemDto);
			return Ok();
		}
	}
}
