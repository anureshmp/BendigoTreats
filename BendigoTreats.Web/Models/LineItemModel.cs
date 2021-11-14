using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BendigoTreats.Web.Models
{
	public class LineItemModel
	{
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
