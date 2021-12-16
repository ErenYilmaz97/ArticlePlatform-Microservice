using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string exMessage):base(exMessage)
        {

        }
    }
}
