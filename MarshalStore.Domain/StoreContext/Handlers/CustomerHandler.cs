using System;
using System.Collections.Generic;
using System.Text;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using FluentValidator;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.ValueObjects;
using MarshalStore.Share.Commands;

namespace MarshalStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable,
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAddressCommand>
    {
        protected CustomerHandler()
        {
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Create Value Objects
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Create entity
            var customer = new Customer(name, document, email, command.Phone);

            //Validate
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);
            
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
