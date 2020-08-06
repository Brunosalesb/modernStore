using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User user = new User("bruno@gmail.com", "brunosenha");

        [TestMethod]
        [TestCategory("Customer - new customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            var customer = new Customer("","Sales", "bruno@gmail.com", user);
            Assert.IsFalse(customer.IsValid());
        }
        [TestMethod]
        [TestCategory("Customer - new customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            var customer = new Customer("Bruno", "", "bruno@gmail.com", user);
            // can be like this - Assert.AreEqual("", customer.LastName);
            Assert.IsFalse(customer.IsValid());
        }
        [TestMethod]
        [TestCategory("Customer - new customer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            var customer = new Customer("Bruno", "Sales", "a", user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}
