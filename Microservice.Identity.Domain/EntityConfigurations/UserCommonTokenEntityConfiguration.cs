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
    public class UserCommonTokenEntityConfiguration : IEntityTypeConfiguration<UserCommonToken>
    {
        public void Configure(EntityTypeBuilder<UserCommonToken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Created).IsRequired();


            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.TokenType).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.ExpireDate).IsRequired();
            builder.Property(x => x.IsValid).IsRequired();

            builder.HasOne(x=>x.User).WithMany(x=>x.CommonTokens).HasForeignKey(x=>x.UserId);


        }
    }
}
