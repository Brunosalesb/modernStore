using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        //private readonly User user = new User("bruno@gmail.com", "brunosenha");

        //[TestMethod]
        //[TestCategory("Order - new order")]
        //public void GivenAnOutOfStockProductShouldReturnAnError()
        //{
        //    var customer = new Customer("Bruno", "Sales", "bruno@gmail.com", user);
        //    var mouse = new Product("mouse", 180, "mouse.jpg", 5);
            
        //    var order = new Order(customer, 10, 5);
        //    order.AddItem(new OrderItem(mouse, 7));

        //    Assert.IsFalse(order.IsValid());
        //}

        //[TestMethod]
        //[TestCategory("Order - new order")]
        //public void GivenAnInStockProductShouldUpdateQuantityOnHand()
        //{
        //    var customer = new Customer("Bruno", "Sales", "bruno@gmail.com", user);
        //    var mouse = new Product("mouse", 180, "mouse.jpg", 20);

        //    var order = new Order(customer, 10, 5);
        //    order.AddItem(new OrderItem(mouse, 5));

        //    Assert.IsTrue(mouse.QuantityOnHand == 15);
        //}

        //[TestMethod]
        //[TestCategory("Order - new order")]
        //public void GivenAValidOrderItShouldReturn()
        //{
        //    var customer = new Customer("Bruno", "Sales", "bruno@gmail.com", user);
        //    var mouse = new Product("mouse", 300, "mouse.jpg", 20);

        //    var order = new Order(customer, 12, 2);
        //    order.AddItem(new OrderItem(mouse, 1));

        //    Assert.IsTrue(order.Total() == 310);
        //}
    }
}
