using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.ValueObjects;

namespace MarshalStore.Tests
{
    [TestClass]
    public class DocumentTests
    {

        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests()
        {
            validDocument = new Document("12345678900000");
            invalidDocument = new Document("1234567890");
            
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            var document = invalidDocument;
            Assert.AreEqual(false,document.IsValid);

        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {
            var document = validDocument;
            Assert.AreEqual(true,document.IsValid);

        }

    }
}
