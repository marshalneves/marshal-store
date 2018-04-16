using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.ValueObjects;

namespace MarshalStore.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            var document = new Document("1234567890000000000");
            Assert.AreEqual(false,document.IsValid);

        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {
            var document = new Document("1234567890");
            Assert.AreEqual(true,document.IsValid);

        }

    }
}
