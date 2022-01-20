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
        public string LogTrackId { get; set; }



        public SuccessBusinessDataResult(string logTrackId)
        {
            this.ResultCode = ResultCodes.Success;
            this.LogTrackId = logTrackId;
        }



        public SuccessBusinessDataResult(TData data, string logTrackId):this(logTrackId)
        {
            this.Data = data;
        }


        public SuccessBusinessDataResult(string message, string logTrackId):this(logTrackId)
        {
            this.ResultMessage = message;
        }


        public SuccessBusinessDataResult(string message, TData data, string logTrackId):this(message, logTrackId)
        {
            this.Data = data;
        }

    }
}
