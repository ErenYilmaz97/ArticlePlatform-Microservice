using Microservice.Chat.Domain.Context;
using Microservices.Domain.Core.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Domain.Core.UnitOfWork.Implementations
{
    public class EFChatUnitOfWork : EfUnitOfWork<ChatDbContext> , IChatUnitOfWork
    {
        private readonly ChatDbContext _context;

        public EFChatUnitOfWork(ChatDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
