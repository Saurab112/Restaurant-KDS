using Kds.Application.DTO;
using Kds.Application.Interface;
using Kds.Application.UnitOfWork;
using Kds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Services
{
	public class MenuItemService : MenuItemServiceInterface
	{
		private readonly MenuItemRepositoryInterface _menuItemRepository;
		private readonly UnitOfWorkInterface _unitOfWork;
		public MenuItemService(MenuItemRepositoryInterface menuItemRepository, UnitOfWorkInterface unitOfWork)
		{
			_menuItemRepository = menuItemRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task CreateMenuItem(MenuItemDto menuItemDto)
		{
			var menuItem = new MenuItem(menuItemDto.Name, menuItemDto.Category, menuItemDto.Price);
			await _menuItemRepository.InsertAsync(menuItem);
			await _unitOfWork.SaveChangesAsync(CancellationToken.None);
		}
	}
}
