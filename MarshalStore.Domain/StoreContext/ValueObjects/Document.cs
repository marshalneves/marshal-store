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

            AddNotifications(new ValidationContract()
                .Requires()
                .IsTrue(Validate(Number), "Document", "Invalid Document")
            );


        }

        public string Number { get; private set; }

        public bool Validate(string number)
        {
            return !(number.Length < 10);

        }

        public override string ToString()
        {
            return Number;
        }
    }
}
