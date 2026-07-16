using Kds.Application.DTO;
using Kds.Application.Interface;
using Kds.Application.UnitOfWork;
using Kds.Domain.Entities;
using Kds.Domain.Exceptions.Order;
using Kds.Domain.Exceptions.OrderItem;

namespace Kds.Application.Services
{
	public class OrderService : OrderServiceInterface
	{
		private readonly OrderRepositoryInterface _orderRepository;
		private readonly MenuItemRepositoryInterface _menuItemRepository;
		private readonly UnitOfWorkInterface _unitOfWork;

		public OrderService(OrderRepositoryInterface orderRepository, MenuItemRepositoryInterface menuItemRepository, UnitOfWorkInterface unitOfWork)
		{
			_orderRepository = orderRepository;
			_menuItemRepository = menuItemRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Order> CreateTableOrder(OrderCreateDto orderCreateDto)
		{
			if (orderCreateDto.OrderItems is null || orderCreateDto.OrderItems.Count == 0)
				throw new ArgumentException("Order must contain at least one item.");

			var order = new Order(orderCreateDto.TableNumber);

			//var kotNo = await _kotSequenceProvider.GetNextKotNoAsync();
			var kotNo = 1; // For demonstration purposes, using a static value. Replace with actual sequence provider.
			var kot = new Kot(order, kotNo);

			foreach (var itemDto in orderCreateDto.OrderItems)
			{
				var menuItem = await _menuItemRepository.GetByIdAsync(itemDto.MenuItemId)
					?? throw new KeyNotFoundException($"MenuItem {itemDto.MenuItemId} not found.");

				order.AddOrderItem(menuItem, itemDto.Quantity, itemDto.Remarks, kot);
			}

			await _orderRepository.InsertAsync(order);
			await _unitOfWork.SaveChangesAsync(CancellationToken.None);

			return order;
		}

		public async Task MarkOrderItemAsPreparationStarted(long orderItemId)
		{
			var order = await _orderRepository.GetOrderByOrderItemId(orderItemId).ConfigureAwait(false) ?? throw new OrderNotFoundException();
			OrderItem orderItem = order.OrderItems.SingleOrDefault(a => a.Id == orderItemId) ?? throw new OrderItemNotFoundException(orderItemId);
			var kotId = orderItem.KotId;
			order.MarkOrderItemAsPreparationStarted(orderItemId);
			await _unitOfWork.SaveChangesAsync(CancellationToken.None);
		}

		public async Task MarkOrderItemAsReady(long orderItemId)
		{
			var order = await _orderRepository.GetOrderByOrderItemId(orderItemId).ConfigureAwait(false) ?? throw new OrderNotFoundException();
			OrderItem orderItem = order.OrderItems.SingleOrDefault(a => a.Id == orderItemId) ?? throw new OrderItemNotFoundException(orderItemId);
			var kotId = orderItem.KotId;
			order.MarkOrderItemAsReady(orderItemId);
			await _unitOfWork.SaveChangesAsync(CancellationToken.None);
		}
	}
}
