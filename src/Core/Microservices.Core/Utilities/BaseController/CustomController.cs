using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Utilities.BaseController
{
    public class CustomController : ControllerBase
    {
        protected string GetLogTrackIdFromHeader()
        {
            return this.HttpContext.Request.Headers["logTrackId"];
        }
    }
}
