using PhoneBookApplication.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

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
        public int PhoneNumber { get; set; }

        public Entry()
        {
        }
        public Entry(string name, int phoneNumber)
            : base(Guid.NewGuid())
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

    }
}
