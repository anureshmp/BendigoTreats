using BendigoTreats.Domain.Models;
using BendigoTreats.Infrastructure.Repositories;
using BendigoTreats.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BendigoTreats.Web.Controllers
{
	public class OrderController:Controller
	{
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Product> productRepository;
        private ILogger<OrderController> logger;

        public OrderController(IRepository<Order> orderRepository,
             IRepository<Product> productRepository, ILogger<OrderController> logger)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            var orders = orderRepository.Find(order => order.OrderDate > DateTime.UtcNow.AddDays(-1));

            return View(orders);
        }

        public IActionResult Create()
        {
            var products = productRepository.All();

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderModel model)
        {
            if (!model.LineItems.Any()) return BadRequest("Please submit line items");

            if (string.IsNullOrWhiteSpace(model.Customer.Name)) return BadRequest("Customer needs a name");

            var customer = new Customer
            {
                Name = model.Customer.Name,
                ShippingAddress = model.Customer.ShippingAddress,
                City = model.Customer.City,
                PostalCode = model.Customer.PostalCode,
                Country = model.Customer.Country
            };

            var order = new Order
            {
                LineItems = model.LineItems
                    .Select(line => new LineItem { ProductId = line.ProductId, Quantity = line.Quantity })
                    .ToList(),

                Customer = customer
            };

            orderRepository.Add(order);

            orderRepository.SaveChanges();
            logger.LogInformation("Order has been created");

            return Ok("Order Created");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
