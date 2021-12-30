using Microservice.Identity.Infrastructure.Mapper.AutoMapper;

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
