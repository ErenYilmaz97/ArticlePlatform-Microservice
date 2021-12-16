using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core
{
    public class AuthorizeException : Exception
    {
        public AuthorizeException(string exMessage) : base(exMessage)
        {

        }
    }
}
