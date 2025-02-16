﻿using System;
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
        public string LogTrackId { get; set; }


        public SuccessBusinessResult(string logTrackId)
        {
            this.ResultCode = ResultCodes.Success;
            this.LogTrackId = logTrackId;
        }


        public SuccessBusinessResult(string message, string logTrackId):this(logTrackId)
        {
            this.ResultMessage = message;
        }


    }
}
