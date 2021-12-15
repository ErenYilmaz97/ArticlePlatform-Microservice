using Microservice.Identity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Identity.Domain.EntityConfigurations
{
    public class UserActionHistoryConfiguration : IEntityTypeConfiguration<UserActionHistory>
    {
        public void Configure(EntityTypeBuilder<UserActionHistory> builder)
        {
            throw new NotImplementedException();
        }
    }
}
