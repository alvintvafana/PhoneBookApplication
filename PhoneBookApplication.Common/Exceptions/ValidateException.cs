using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookApplication.Common.Exceptions
{
  public class ValidateException: Exception
    {
        public ValidateException(string message) : base(message)
        {
            
        }
    }
}
