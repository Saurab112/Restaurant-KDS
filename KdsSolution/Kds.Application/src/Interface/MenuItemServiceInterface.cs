using Kds.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Interface
{
	public interface MenuItemServiceInterface
	{
		Task CreateMenuItem(MenuItemDto menuItemDto);
	}
}
