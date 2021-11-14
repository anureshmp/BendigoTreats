using System;
using System.Collections.Generic;
using System.Text;
using BendigoTreats.Domain;
using BendigoTreats.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace BendigoTreats.Infrastructure
{
	public class ShoppingContext:DbContext
	{

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }

		public ShoppingContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{

		}


	}
}
