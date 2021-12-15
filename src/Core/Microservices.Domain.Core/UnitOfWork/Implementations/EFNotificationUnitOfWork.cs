using Microservice.Notification.Domain;
using Microservices.Domain.Core.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Domain.Core.UnitOfWork.Implementations
{
    public class EFNotificationUnitOfWork : EfUnitOfWork<NotificationDbContext>, INotificationUnitOfWork
    {
        private readonly NotificationDbContext _context;

        public EFNotificationUnitOfWork(NotificationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
