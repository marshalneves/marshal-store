﻿using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarshalStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "Email is invalid.");

        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }

    }
}
