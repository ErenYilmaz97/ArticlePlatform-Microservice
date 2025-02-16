﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void CommitChanges();
        Task CommitChangesAsync();
    }
}
