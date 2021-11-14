using BendigoTreats.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BendigoTreats.Infrastructure.Repositories
{
	public class OrderRepository : GenericRepository<Order>
	{
		public OrderRepository(ShoppingContext context): base(context)
		{

		}
	}
}
