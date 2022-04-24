using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Controllers;
using OrderManagementSystem.Domain;
using System.Collections.Generic;
using Xunit;

namespace OrderManagementSystem.Tests
{
    public class OrderControllerTest
    {
        private readonly OrdersController _orderController;
        private readonly IOrderService _orderService;

        public OrderControllerTest(OrdersController orderController,IOrderService orderService)
        {
            _orderController = orderController;
            _orderService = orderService;
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _orderController.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>((IActionResult)okResult as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = (IActionResult)_orderController.GetAll() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Order>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
