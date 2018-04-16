using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarshalStore.Domain.StoreContext.ValueObjects;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.Enums;

namespace MarshalStore.Tests
{
    [TestClass]
    public class OrderTests
    {

        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;

        public OrderTests()
        {
            var name = new Name("Kyrk","Douglas");
            var document = new Document("12345678900000");
            var email = new Email("hello@email.com.br");
            _customer = new Customer (name, document, email, "551998978456");
            _order = new Order(_customer);

            //Products
            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Keyboard Gamer", "Keyboard Gamer", "mouse.jpg", 100M, 10);
            _chair = new Product("Chair Gamer", "Chair Gamer", "mouse.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "mouse.jpg", 100M, 10);

        }

        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated() {
            
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        
        }

        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems() {
            
            _order.AddItem(_mouse, 5);
            _order.AddItem(_monitor,5);

            Assert.AreEqual(2, _order.Items.Count);
        }
        
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem() {
            
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced() {
            
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid() {

            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoShippingsWhenPurchasedTenProducts() {
            
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled() {
            
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void ShouldCancShippingWhenOrderCanceled() {

            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            _order.Cancel();
            foreach (var delivery in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, delivery.Status);
            }

        }
        

    }
}
