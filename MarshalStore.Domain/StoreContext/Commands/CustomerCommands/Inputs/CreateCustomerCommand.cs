using FluentValidator;
using FluentValidator.Validation;
using MarshalStore.Share.Commands;

namespace MarshalStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
   
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Fail Fast Validation
        public bool Valid() {

            AddNotifications(new ValidationContract()
                    .HasMinLen(FirstName, 3, "FirstName", "First name must be at least 3 characters")
                    .HasMaxLen(FirstName, 40, "FirstName", "First name must be less than 40 characters")
                    .HasMinLen(LastName, 3, "LastName", "Last name must be less than 3 characters")
                    .HasMaxLen(LastName, 40, "LastName", "Last name must be less than 40 characters")
                    .IsEmail(Email, "Email", "Email is invalid.")
                    .HasLen(Document,14,"Document","Document is invalid.")
            
            );

            return IsValid;
        }

    }
}




