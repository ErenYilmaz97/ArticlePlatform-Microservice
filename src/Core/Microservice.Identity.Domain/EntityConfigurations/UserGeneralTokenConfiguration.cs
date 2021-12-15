using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microservice.Identity.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Identity.Domain.EntityConfigurations
{
    public class UserGeneralTokenConfiguration : IEntityTypeConfiguration<UserGeneralToken>
    {
        public void Configure(EntityTypeBuilder<UserGeneralToken> builder)
        {
            throw new NotImplementedException();
        }
    }
}
