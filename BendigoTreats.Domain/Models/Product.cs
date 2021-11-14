using System;
using System.Collections.Generic;
using System.Text;

namespace BendigoTreats.Domain.Models
{
	public class Product
	{
		public Guid ProductId { get; set; }
		public string Name { get; set; }

		public decimal Price { get; set; }

		public Product()
		{
			ProductId = Guid.NewGuid();
		}


	}
}
