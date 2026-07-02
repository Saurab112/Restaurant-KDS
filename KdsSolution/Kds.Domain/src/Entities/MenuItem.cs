using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Entities
{
	public class MenuItem
	{
		protected MenuItem() { }

		public MenuItem(long id, string name, string category, decimal price)
		{
			Id = id;
			Name = name;
			Category = category;
			Price = price;
		}

		public long Id { get; protected set; }
		public string Name { get; protected set; } = null!;
		public string Category { get; protected set; } = null!;
		public decimal Price { get; protected set; }
	}
}
