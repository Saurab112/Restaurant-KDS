using Kds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Application.Interface
{
	public interface MenuItemRepositoryInterface
	{
		Task InsertAsync(MenuItem menuItem);
		Task<MenuItem?> GetByIdAsync(long id);
		Task<IList<MenuItem>> GetAllAsync();
		Task<MenuItem?> GetByName(string menuItemName);
	}
}
