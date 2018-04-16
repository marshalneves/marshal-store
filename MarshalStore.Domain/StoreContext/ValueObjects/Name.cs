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

            new ValidationContract()
                .Requires()
                .HasMinLen(firstName, 3, "FirstName", "First name must be at least 3 characters")
                .HasMaxLen(firstName, 40, "FirstName", "First name must be less than 40 characters")
                .HasMinLen(lastName, 3, "LastName", "Last name must be less than 3 characters")
                .HasMaxLen(lastName, 40, "LastName", "Last name must be less than 40 characters");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
