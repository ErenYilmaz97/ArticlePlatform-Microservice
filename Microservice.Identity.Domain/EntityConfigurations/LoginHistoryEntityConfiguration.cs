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
    public class LoginHistoryEntityConfiguration : IEntityTypeConfiguration<LoginHistory>
    {
        public void Configure(EntityTypeBuilder<LoginHistory> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.HasQueryFilter(x => x.IsDeleted == false);


            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Succeed).IsRequired();
            builder.Property(x => x.LoginType).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.LoginHistories).HasForeignKey(x => x.UserId);

        }
    }
}
