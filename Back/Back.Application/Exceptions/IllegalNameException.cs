using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Exceptions
{
    public class IllegalNameException : Exception
    {
        public IllegalNameException(string message) : base(message) { }
        public IllegalNameException() : base(ExceptionMessage.NameAlreadyUsed) { }
    }
}
