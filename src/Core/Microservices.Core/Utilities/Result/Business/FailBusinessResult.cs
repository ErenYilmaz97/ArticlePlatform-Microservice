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
        public string LogTrackId { get; set; }


        public FailBusinessResult(string logTrackId)
        {
            this.ResultCode = ResultCodes.Failed;
            this.LogTrackId = logTrackId;
        }


        public FailBusinessResult(string message, string logTrackId) : this(logTrackId)
        {
            this.ResultMessage = message;
        }
    }
}
