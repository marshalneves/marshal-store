using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshalStore.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            Number = number;

            //Custom validation example
            AddNotifications(new ValidationContract()
                .Requires()
                .IsTrue(Validate(Number), "Document", "Invalid Document")
            );

        }

        public string Number { get; private set; }

        public bool Validate(string number)
        {
            //A simple custom validation
            if (number.Length != 14) return false;
            return true;

        }

        public override string ToString()
        {
            return Number;
        }
    }
}
