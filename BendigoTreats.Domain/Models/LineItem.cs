using System;
using System.Collections.Generic;
using System.Text;

namespace BendigoTreats.Domain.Models
{
	public class LineItem
	{
		public Guid LineItemId { get; set; }
		public int Quantity { get; set; }
		public Product Product { get; set; }
		public Guid ProductId { get; set; }
		public Order Order { get; set; }
		public Guid OrderId { get; set; }


		public LineItem()
		{
			LineItemId = Guid.NewGuid();

		}
	}
}
