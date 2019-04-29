using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApplication.Domain.Commands
{
    public class CreatePhoneBookCommand:ICommand
    {
        public string Name { get; set; }
    }
}
