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
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.PictureName).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.EmailConfirmed).IsRequired();
            builder.Property(x => x.EmailConfirmedDate).IsRequired(false);
            builder.Property(x => x.LastLoginDate).IsRequired();
            builder.Property(x => x.LastPasswordUpdatedDate).IsRequired(false);
            builder.Property(x => x.IsPasswordExpired).IsRequired();

            #region Relations
            builder.HasMany(x => x.Roles).WithMany(x => x.Users);
            #endregion

        }
    }
}
