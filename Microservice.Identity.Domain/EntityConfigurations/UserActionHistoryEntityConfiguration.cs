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
    public class UserActionHistoryEntityConfiguration : IEntityTypeConfiguration<UserActionHistory>
    {
        public void Configure(EntityTypeBuilder<UserActionHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.ActionType).IsRequired();

            builder.HasOne(x=>x.User).WithMany(x=>x.ActionHistories).HasForeignKey(x=>x.UserId);

        }
    }
}
