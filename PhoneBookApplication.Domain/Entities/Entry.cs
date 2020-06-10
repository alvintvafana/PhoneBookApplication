using PhoneBookApplication.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBookApplication.Domain.Entities
{
    public class Entry : BaseEntity<Guid>
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value ?? throw new ValidateException("name cannot be null");
            }
        }
        private string phoneNumber;
        public string PhoneNumber 
        {
            get { return phoneNumber; }
            set
            {
                if(!Regex.IsMatch(value, "^[0-9]+$"))
                    throw new ValidateException("that doesnot look like a valid phone number");
                phoneNumber = value;
            }
        }

        public Entry()
        {
        }
        public Entry(string name, string phoneNumber)
            : base(Guid.NewGuid())
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

    }
}
