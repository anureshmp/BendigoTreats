using BendigoTreats.Domain.Models;
using BendigoTreats.Infrastructure;
using BendigoTreats.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BendigoTreats.Web
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddControllersWithViews();

			CreateInitialDatabase();

			services.AddDbContext<ShoppingContext>(options => options.UseSqlite(Configuration.GetConnectionString("cs")));
			services.AddTransient<IRepository<Customer>, CustomerRepository>();
			services.AddTransient<IRepository<Order>, OrderRepository>();
			services.AddTransient<IRepository<Product>, ProductRepository>();
		}


		public void CreateInitialDatabase()
		{
			using (var context = new ShoppingContext(
			new DbContextOptionsBuilder<ShoppingContext>()
			.UseSqlite(Configuration.GetConnectionString("cs")).Options))
			{
				context.Database.EnsureDeleted();
				context.Database.EnsureCreated();

				var rolls = new Product { Name = "Chicko Rolls", Price = 9.99m };
				var wrap = new Product { Name = "Tikka Masala Wrap", Price = 8.99m };
				var burger = new Product { Name = "Nashville Burger", Price = 19.99m };
				var pizza = new Product { Name = "Biriyani Pizza", Price = 21.99m };
				var wagyu = new Product { Name = "Wagyu Porterhouse", Price = 31.99m };
				var tart = new Product { Name = "Tender Coconut Tart", Price = 15.99m };
				var beer = new Product { Name = "Ginger Beer", Price = 11.99m };
				var water = new Product { Name = "Sparkling Water", Price = 4.99m };

				var productRepository = new ProductRepository(context);

				productRepository.Add(rolls);
				productRepository.Add(wrap);
				productRepository.Add(burger);
				productRepository.Add(pizza);
				productRepository.Add(wagyu);
				productRepository.Add(tart);
				productRepository.Add(beer);
				productRepository.Add(water);

				productRepository.SaveChanges();
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseStaticFiles();
			app.UseEndpoints(endpoints => 
			{ endpoints.MapControllerRoute(
				name: "default", pattern: "{controller=Order}/{action=Index}/{id?}"); });
		}
	}
}
