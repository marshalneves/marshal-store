using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.ValueObjects;
using MarshalStore.Domain.StoreContext.Handlers;
using MarshalStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MarshalStore.Tests.Fakes;

namespace MarshalStore.Tests
{
    [TestClass]
    public class CustomerHandlerTests
    {

        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid(){

            var command = new CreateCustomerCommand();
            command.FirstName = "Marshal";
            command.LastName = "Neves";
            command.Document = "12345678900000";
            command.Email = "marshalneves@email.com";
            command.Phone = "558499999999";

            Assert.AreEqual(true,command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);

        }
    }
}
