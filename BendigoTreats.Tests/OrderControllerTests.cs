using BendigoTreats.Domain.Models;
using BendigoTreats.Infrastructure.Repositories;
using BendigoTreats.Web.Controllers;
using BendigoTreats.Web.Models;
using Moq;
using NUnit.Framework;
using System;

namespace BendigoTreats.Tests
{
	public class OrderControllerTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
        public void CanCreateOrderWithCorrectModel()
        {
            // ARRANGE 
            var orderRepository = new Mock<IRepository<Order>>();
            var productRepository = new Mock<IRepository<Product>>();
            var customerRepository = new Mock<IRepository<Customer>>();

            var orderController = new OrderController(
                orderRepository.Object,
                productRepository.Object
            );

            var createOrderModel = new CreateOrderModel
            {
                Customer = new CustomerModel
                {
                    Name = "Anuresh Puthukudy",
                    ShippingAddress = "3456 Lockwood Avenue",
                    City = "Bendigo",
                    PostalCode = "3550",
                    Country = "Australia"
                },
                LineItems = new[]
                {
                    new LineItemModel { ProductId = Guid.NewGuid(), Quantity = 10 },
                    new LineItemModel { ProductId = Guid.NewGuid(), Quantity = 2 },
                }
            };

            // ACT

            orderController.Create(createOrderModel);

            // ASSERT

            orderRepository.Verify(r => r.Add(It.IsAny<Order>()),
                Times.AtLeastOnce());
        }
    }
}