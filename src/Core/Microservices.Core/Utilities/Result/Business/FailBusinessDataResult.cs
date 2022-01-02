using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Utilities.Result.Business
{
    public class FailBusinessDataResult<TData> : IBusinessDataResult<TData>
    {
        public ResultCodes ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public TData Data { get; set; }



        public FailBusinessDataResult()
        {
            this.ResultCode = ResultCodes.Success;
        }



        public FailBusinessDataResult(TData data) : this()
        {
            this.Data = data;
        }


        public FailBusinessDataResult(string message) : this()
        {
            this.ResultMessage = message;
        }


        public FailBusinessDataResult(string message, TData data) : this(message)
        {
            this.Data = data;
        }
    }
}
