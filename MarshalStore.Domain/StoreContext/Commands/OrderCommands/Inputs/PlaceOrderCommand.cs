using System;
using System.Collections;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using MarshalStore.Share.Commands;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; private set; }

        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                    .HasLen(Customer.ToString(), 36, "Customer", "Invalid customer identifier.")
                    .IsGreaterThan(OrderItems.Count,0,"Items","Items list has empty.")
            );

            return IsValid;
            
        }
    }

    public class OrderItemCommand 
    {
        public Guid Product { get; private set; }
        public decimal Quantity { get; private set; }
    }

}