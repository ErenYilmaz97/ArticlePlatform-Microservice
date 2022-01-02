using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Utilities.Result.Business
{
    public class SuccessBusinessDataResult<TData> : IBusinessDataResult<TData>
    {
        public ResultCodes ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public TData Data { get; set; }



        public SuccessBusinessDataResult()
        {
            this.ResultCode = ResultCodes.Success;
        }



        public SuccessBusinessDataResult(TData data):this()
        {
            this.Data = data;
        }


        public SuccessBusinessDataResult(string message):this()
        {
            this.ResultMessage = message;
        }


        public SuccessBusinessDataResult(string message, TData data):this(message)
        {
            this.Data = data;
        }

    }
}
