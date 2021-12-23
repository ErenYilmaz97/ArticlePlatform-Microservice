using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.Repository.Paging
{
    public class PagedList<T>
    {
        public int TotalCount { get; init; }
        public List<T> Result { get; init; }
        public bool HasNext { get; init; }
        public bool HasPrevious { get; init; }
    }
}
