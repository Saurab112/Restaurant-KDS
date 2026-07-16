using Asp.Versioning;
using Kds.Application.Interface;
using Kds.Domain.Exceptions.Kot;
using Kds.Infrastructure.Data;
using Kds.WebApi.ApiModel.Kot;
using Kds.WebApi.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Kds.WebApi.ApiControllers
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route(ApiEndPoint.KotBaseEndPoint)]
	public class KotApiController: ControllerBase
	{
		private readonly KotServiceInterface _KotService;
		private readonly AppDbContext _modelDbContext;
		private readonly IHubContext<SignalRHub> _signalRHub;

		public KotApiController(KotServiceInterface kotService, AppDbContext modelDbContext, IHubContext<SignalRHub> signalRHub)
		{
			_KotService = kotService;
			_modelDbContext = modelDbContext;
			_signalRHub = signalRHub;
		}
		[HttpPost(ApiEndPoint.MarkKotAsPreparationStarted)]
		public async Task<IActionResult> MarkKotAsPreparationStarted(long kotId)
		{
			await _KotService.MarkKotAsPreparationStarted(kotId);
			var kotResponse = await BuildKotResponse(kotId);
			await _signalRHub.Clients.All.SendAsync(SignalRMethods.KotChanged, kotResponse);
			return Ok();
		}
		[HttpPost(ApiEndPoint.MarkKotAsReady)]
		public async Task<IActionResult> MarkKotAsReady(long kotId)
		{
			await _KotService.MarkKotAsReady(kotId);
			var kotResponse = await BuildKotResponse(kotId);
			await _signalRHub.Clients.All.SendAsync(SignalRMethods.KotChanged, kotResponse);
			return Ok();
		}
		[HttpPost(ApiEndPoint.MarkKotAsCancelled)]
		public async Task<IActionResult> MarkKotAsCancelled(long kotId)
		{
			await _KotService.MarkKotAsCancelled(kotId);
			var kotResponse = await BuildKotResponse(kotId);
			await _signalRHub.Clients.All.SendAsync(SignalRMethods.KotChanged, kotResponse);
			return Ok();
		}

		private async Task<KotResponseApiModel> BuildKotResponse(long kotId)
		{
			var kot = await _modelDbContext.Kots
				.Where(k => k.Id == kotId)
				.Select(k => new KotResponseApiModel
				{
					KotId = k.Id,
					OrderId = k.OrderId,
					KotNo = k.KotNo,
					Status = k.Status.Name,
					CreatedOn = k.CreatedOn,
					KotPreparationStartedOn = k.KotPreparationStartedOn,
					KotReadyOn = k.KotReadyOn,
					KotCancelledOn = k.KotCancelledOn,
					KotCompletedOn = k.KotCompletedOn,
					OrderItems = k.OrderItems.Select(oi => new KotItemResponseApiModel
					{
						OrderItemId = oi.Id,
						MenuItemId = oi.MenuItemId,
						MenuItemName = oi.MenuItem.Name,
						Quantity = oi.Quantity,
						Remarks = oi.Remarks,
						Status = oi.Status.Name,
						CreatedOn = oi.CreatedOn,
						CancelledOn = oi.CancelledOn,
					}).ToList()
				})
				.FirstOrDefaultAsync() ?? throw new KotNotFoundException(kotId);

			return kot;
		}
	}
}
