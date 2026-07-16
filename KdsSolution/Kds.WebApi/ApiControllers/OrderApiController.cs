using Kds.Application.DTO;
using Kds.Application.Interface;
using Kds.Domain.Exceptions.Order;
using Kds.Infrastructure.Data;
using Kds.WebApi.ApiModel;
using Kds.WebApi.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Kds.WebApi.ApiControllers
{
	[ApiController]
	public class OrderApiController: ControllerBase
	{
		private readonly OrderServiceInterface _orderService;
		private readonly AppDbContext _modelDbContext;
		private readonly IHubContext<SignalRHub> _signalRHub;
		public OrderApiController(OrderServiceInterface orderService, AppDbContext dbContext, IHubContext<SignalRHub> signalRHub)
		{
			_orderService = orderService;
			_modelDbContext = dbContext;
			_signalRHub = signalRHub;
		}
		[HttpPost]
		public async Task<IActionResult> CreateOrder([FromBody] OrderCreateRequestApiModel apiModel)
		{
			var orderItemDtoList = apiModel.OrderItems.Select(item => new OrderItemDto
			{
				Quantity = item.Quantity,
				Rate = item.Rate,
				MenuItemId = item.MenuItemId,
				Remarks = item.Remarks,
			}).ToList();

			var tableOrderDto = new OrderCreateDto
			{
				OrderItems = orderItemDtoList.ToList(),
				TableNumber = apiModel.TableNumber,
			};

			var order = await _orderService.CreateTableOrder(tableOrderDto);
			var response = await BuildOrderResponse(order.OrderId);

			await _signalRHub.Clients.All.SendAsync(SignalRMethods.OrderCreated, response);

			return Ok(order);
		}

		[HttpPost(ApiEndPoint.OrderItemMarkAsPreparationStarted)]
		public async Task<IActionResult> MarkOrderItemAsPreparationStarted(long orderItemId)
		{
			await _orderService.MarkOrderItemAsPreparationStarted(orderItemId);
			long orderId = await _modelDbContext.OrderItems.Where(a => a.Id == orderItemId).Select(a => a.OrderId).SingleOrDefaultAsync();
			var orderResponse = await BuildOrderResponse(orderId);
			await _signalRHub.Clients.All.SendAsync(SignalRMethods.OrderChanged, orderResponse);
			return Ok();
		}

		[HttpPost(ApiEndPoint.OrderItemMarkAsReady)]
		public async Task<IActionResult> MarkOrderItemAsReady(long orderItemId)
		{
			await _orderService.MarkOrderItemAsReady(orderItemId);

			long orderId = await _modelDbContext.OrderItems.Where(a => a.Id == orderItemId).Select(a => a.OrderId).SingleOrDefaultAsync();
			var orderResponse = await BuildOrderResponse(orderId);
			await _signalRHub.Clients.All.SendAsync(SignalRMethods.OrderChanged, orderResponse);
			return Ok();
		}


		private async Task<OrderResponseApiModel> BuildOrderResponse(long orderId)
		{
			var order = await _modelDbContext.Orders
				.Where(o => o.OrderId == orderId)
				.Select(o => new OrderResponseApiModel
				{
					OrderId = o.OrderId,
					TableNumber = o.TableNumber,
					OrderStatus = o.Status.Name,
					CreatedOn = o.CreatedOn,
					Kots = o.Kots.Select(k => new KotResponseApiModel
					{
						KotId = k.Id,
						KotNo = k.KotNo,
						Status = k.Status.Name,
						CreatedOn = k.CreatedOn,
						KotPreparationStartedOn = k.KotPreparationStartedOn,
						KotReadyOn = k.KotReadyOn,
						KotCancelledOn = k.KotCancelledOn,
						KotCompletedOn = k.KotCompletedOn,
					}).OrderBy(k => k.KotNo).ToList(),
					OrderItems = o.OrderItems.Select(oi => new OrderItemResponseApiModel
					{
						OrderItemId = oi.Id,
						KotId = oi.KotId,
						KotNo = oi.Kot.KotNo,
						MenuItemId = oi.MenuItemId,
						MenuItemName = oi.MenuItem.Name,
						Rate = oi.MenuItem.Price,
						Amount = oi.MenuItem.Price * oi.Quantity,
						Quantity = oi.Quantity,
						Remarks = oi.Remarks,
						Status = oi.Status.Name,
						CreatedOn = oi.CreatedOn,
						CancelledOn = oi.CancelledOn,
					}).ToList(),
				})
				.SingleOrDefaultAsync() ?? throw new OrderNotFoundException();

			return order;
		}
	}
}
