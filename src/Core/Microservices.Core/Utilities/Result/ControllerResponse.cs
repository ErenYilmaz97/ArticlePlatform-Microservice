using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Utilities.Result
{
    public class ControllerResponse<TData>
    {
        public ResultCodes ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public TData Data { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
