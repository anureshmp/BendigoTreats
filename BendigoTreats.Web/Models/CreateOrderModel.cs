using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BendigoTreats.Web.Models
{
	public class CreateOrderModel
	{
		public IEnumerable<LineItemModel> LineItems { get; set; }

		public CustomerModel Customer { get; set; }
	}
}
