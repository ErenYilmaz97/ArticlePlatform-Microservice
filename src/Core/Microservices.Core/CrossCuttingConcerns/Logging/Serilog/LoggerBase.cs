using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.CrossCuttingConcerns.Logging.Serilog
{
    public abstract class SerilogLoggerBase : ILog
    {
        private readonly ILogger _logger;

        public SerilogLoggerBase(LoggerConfiguration loggerConfig)
        {
            this._logger = loggerConfig.CreateLogger();
        }



        public void Debug(object logMessage)
        {
            _logger.Debug("{@logMessage}", logMessage);
        }


        public void Error(object logMessage)
        {
            _logger.Error("{@logMessage}", logMessage);
        }


        public void Fatal(object logMessage)
        {
            _logger.Fatal("{@logMessage}", logMessage);
        }


        public void Info(object logMessage)
        {
            _logger.Information("{@logMessage}", logMessage);
        }


        public void Warning(object logMessage)
        {
            _logger.Warning("{@logMessage}", logMessage);
        }
    }
}
