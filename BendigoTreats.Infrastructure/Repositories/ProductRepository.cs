using BendigoTreats.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BendigoTreats.Infrastructure.Repositories
{
	public class ProductRepository : GenericRepository<Product>
	{
		public ProductRepository(ShoppingContext context):base(context)
		{

		}


	}
}
