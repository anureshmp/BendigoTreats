using BendigoTreats.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BendigoTreats.Infrastructure.Repositories
{
	public class CustomerRepository : GenericRepository<Customer>
	{
		public CustomerRepository(ShoppingContext context):base(context)
		{

		}
	}
}
