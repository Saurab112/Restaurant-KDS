using System;
using System.Collections.Generic;
using System.Text;

namespace Kds.Domain.Exceptions.Order
{
	public class OrderNotFoundException : Exception
	{
		public OrderNotFoundException(string message = "Order Not Found.") : base(message)
		{
		}
	}
}
