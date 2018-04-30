using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using MarshalStore.Domain.StoreContext.Enums;
using MarshalStore.Shared.Entities;


//te mostrar aqui um domínio rico de um curso que eu fiz
namespace MarshalStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
            {
                AddNotification("OrderItem", $"Produto {product.Title} n�o tem {quantity} itens em estoque");
            }

            var item = new OrderItem(product, quantity);
            _items.Add(item);

        }

        //To Place An Order
        //comportamentos todos no domínio
        public void Place()
        {
            //Gera o n�mero do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            if (_items.Count == 0)
                AddNotification("Order","Produto fora de estoque");
        }

        //Pagar um pedido
        public void Pay()
        {
            Status = EOrderStatus.Paid;

        }

        //Enviar um pedido
        public void Ship()
        {
            //A cada 5 produtos, gera uma entrega separada
            var deliveries = new List<Delivery>();

            //Inclui uma entrega
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));

            //Quebra as entregas
            var count = 1;
            foreach (var item in _items)    
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //Envia todas as entregas
            deliveries.ForEach(x => x.Ship());

            //Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));

        }

        //Cancelar um pedido
        public void Cancel()
        {
            //Cancela o pedido
            Status = EOrderStatus.Canceled;

            //Cancela todas as entregas
            _deliveries.ToList().ForEach(x => x.Cancel());
        }

    }
}
