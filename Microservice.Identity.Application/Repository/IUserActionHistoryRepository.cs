using Microservice.Identity.Domain.Entity;
using Microservices.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Application.Repository
{
    public interface IUserActionHistoryRepository : IRepository<UserActionHistory,long>
    {
    }
}
