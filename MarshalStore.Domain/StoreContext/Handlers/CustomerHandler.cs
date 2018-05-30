using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using MarshalStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MarshalStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using MarshalStore.Domain.StoreContext.Entities;
using MarshalStore.Domain.StoreContext.Repositories;
using MarshalStore.Domain.StoreContext.Services;
using MarshalStore.Domain.StoreContext.ValueObjects;
using MarshalStore.Share.Commands;

namespace MarshalStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable,
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Check Document
            if (_repository.CheckDocument(command.Document)) {
                AddNotification("Document","Document already in use");
            }

            //Check Email
            if (_repository.CheckEmail(command.Email)) {
                AddNotification("Email","Email already in use");
            }
            
            //Create Value Objects
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Create Customer
            var customer = new Customer(name, document, email, command.Phone);

            //Validate
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(false, 
                    "Por favor, corrija os campos abaixo", 
                    Notifications);

            // Persist Customer
            _repository.Save(customer);

            // Send Welcome Email
            _emailService.Send(email.Address, "hello@marshalstore.io", "Welcome", "Welcome to MarshalStore");
            
            //Return results in screen
            return new CommandResult(true, 
                    "Bem vindo ao Marshal Store", 
                    new {
                        Id = customer.Id, 
                        Name = name.ToString(), 
                        Email = email.Address
                    }
            );
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
