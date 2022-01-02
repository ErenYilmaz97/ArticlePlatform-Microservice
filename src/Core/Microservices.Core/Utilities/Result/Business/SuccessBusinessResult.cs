using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Utilities.Result.Business
{
    public class SuccessBusinessResult : IBusinessResult
    {
        public ResultCodes ResultCode { get; set; }
        public string ResultMessage { get; set; }


        public SuccessBusinessResult()
        {
            this.ResultCode = ResultCodes.Success;
        }


        public SuccessBusinessResult(string message):this()
        {
            this.ResultMessage = message;
        }


    }
}
