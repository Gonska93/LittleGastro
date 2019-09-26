using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Application.Exceptions
{
    public class DbEntityOperationException : Exception
    {
        public DbEntityOperationException(string message) : base(message) { }
    }
}
