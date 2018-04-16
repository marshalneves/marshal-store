using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarshalStore.Domain.StoreContext.ValueObjects;

namespace MarshalStore.Tests
{
    [TestClass]
    public class NameTests
    {

        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("","Kirky");
            Assert.AreEqual(false,name.IsValid);
            Assert.AreEqual(1,name.Notifications.Count);

        }

    }
}
