using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.CrossCuttingConcerns.Logging
{
    public class LogObject
    {
        public string Message { get; set; }
        public string LogTrackId { get; set; }

        public LogObject(string message, string logTrackId)
        {
            Message = message;
            LogTrackId = logTrackId;
        }
    }
}
