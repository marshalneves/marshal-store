using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace MarshalStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid(){

            var command = new CreateCustomerCommand();
            command.FirstName = "Marshal";
            command.LastName = "Neves";
            command.Document = "12345678900000";
            command.Email = "marshalneves@email.com";
            command.Phone = "558499999999";

            Assert.AreEqual(true,command.Valid());


        }
    }
}
