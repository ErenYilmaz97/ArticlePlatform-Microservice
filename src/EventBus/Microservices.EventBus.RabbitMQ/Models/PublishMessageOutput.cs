using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.EventBus.RabbitMQ.Models
{
    public class PublishMessageOutput
    {
        public bool IsSuccess { get; set; }
        public string ResultMessage { get; set; }
    }
}
