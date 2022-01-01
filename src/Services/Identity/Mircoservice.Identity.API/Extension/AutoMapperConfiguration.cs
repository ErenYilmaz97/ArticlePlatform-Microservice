using Microservice.Identity.Infrastructure.Mapper.AutoMapper;
using Microsoft.AspNetCore.Builder;

namespace Mircoservice.Identity.API.Extension
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this WebApplicationBuilder appBuilder)
        {
            appBuilder.Services.AddAutoMapper(typeof(IdentityMapperProfile));
        }
    }
}
