using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Utilities.Result.Business
{
    public class FailBusinessResult : IBusinessResult
    {
        public ResultCodes ResultCode { get; set; }
        public string ResultMessage { get; set; }


        public FailBusinessResult()
        {
            this.ResultCode = ResultCodes.Failed;
        }


        public FailBusinessResult(string message) : this()
        {
            this.ResultMessage = message;
        }
    }
}
