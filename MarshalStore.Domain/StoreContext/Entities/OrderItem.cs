using FluentValidator;
using MarshalStore.Shared.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MarshalStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if(product.QuantityOnHand < quantity)
                AddNotification(new Notification("Quantity", "Produto fora de estoque"));

            product.DecreaseQuantity(quantity);

        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        
    }
}
