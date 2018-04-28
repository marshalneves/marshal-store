using System;
using MarshalStore.Share.Commands;

namespace MarshalStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
   
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult()
        {    
        }

        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}




