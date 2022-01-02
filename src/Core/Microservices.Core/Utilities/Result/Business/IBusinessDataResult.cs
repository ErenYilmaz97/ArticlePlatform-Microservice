using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Utilities.Result.Business
{
    public interface IBusinessDataResult<TData> : IBusinessResult
    {
         TData Data { get; set; }
    }
}
