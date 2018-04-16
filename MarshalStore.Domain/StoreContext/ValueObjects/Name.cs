using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshalStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(
                
                new ValidationContract()
                    .Requires()
                    .HasMinLen(FirstName, 3, "FirstName", "First name must be at least 3 characters")
                    .HasMaxLen(FirstName, 40, "FirstName", "First name must be less than 40 characters")
                    .HasMinLen(LastName, 3, "LastName", "Last name must be less than 3 characters")
                    .HasMaxLen(LastName, 40, "LastName", "Last name must be less than 40 characters")
            
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
