using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.CrossCuttingConcerns.Logging
{
    public interface ILog
    {
        void Info(object logMessage);
        void Debug(object logMessage);
        void Warning(object logMessage);
        void Error(object logMessage);
        void Fatal(object logMessage);
    }
}
