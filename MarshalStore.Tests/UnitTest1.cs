using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.ValueObjects;

namespace MarshalStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Marshal", "Neves");
            var document = new Document("12345678911");
            var email = new Email("marshalneves@email.com.br");
            var c = new Customer(name, document, email, "99999999");

            var mouse = new Product("Mouse", "Rato", "image.png", 159.90M, 10);
            var printer = new Product("Printer", "Printer", "printer.png", 359.90M, 10);
            var chair = new Product("Chair", "Chair", "printer.png", 559.90M, 10);

            var order = new Order(c);
            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(chair, 5));
            //order.AddItem(new OrderItem(printer, 5));

            // Realizei o pedido
            order.Place();

            //Verificar se o pedido é válido
            var valid = order.IsValid;

            //Simular o pagamento
            order.Pay();

            //Simular o envio
            order.Ship();

            //Simular o cancelamento
            order.Cancel();
            
        }
    }
}
