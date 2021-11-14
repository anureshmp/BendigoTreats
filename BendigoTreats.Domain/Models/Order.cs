using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BendigoTreats.Domain.Models
{
	public class Order
	{
		public Guid OrderId { get; set; }
		public ICollection<LineItem> LineItems { get; set; }
		public Customer Customer { get; set; }
		public Guid CustomerId { get; set; }
		public DateTime OrderDate { get; set; }
		public decimal OrderTotal => LineItems.Sum(item => item.Product.Price * item.Quantity);

		public Order()
		{
			OrderId = Guid.NewGuid();
			OrderDate = DateTime.UtcNow;
		}


	}
}
