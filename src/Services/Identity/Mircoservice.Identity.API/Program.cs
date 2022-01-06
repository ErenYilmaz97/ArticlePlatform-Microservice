using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microservice.Identity.Application.Caching;
using Microservice.Identity.Application.Repository;
using Microservice.Identity.Application.Service;
using Microservice.Identity.Application.UnitOfWork;
using Microservice.Identity.Domain.Context;
using Microservice.Identity.Domain.CustomMiddleware;
using Microservice.Identity.Infrastructure.Caching;
using Microservice.Identity.Infrastructure.Repository.Dapper;
using Microservice.Identity.Infrastructure.Repository.EntityFramework;
using Microservice.Identity.Infrastructure.Service;
using Microservice.Identity.Infrastructure.UnitOfWork;
using Microservices.Core.CrossCuttingConcerns.Caching;
using Microservices.Core.CrossCuttingConcerns.Caching.Redis;
using Microservices.Core.CrossCuttingConcerns.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Mircoservice.Identity.API;
using Mircoservice.Identity.API.Extension;
using Mircoservice.Identity.API.Filter;
using Mircoservice.Identity.API.Validator;
using Newtonsoft.Json;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;
using Serilog.Filters;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<RedisConfiguration>(builder.Configuration.GetSection("RedisOptions"));

#region IoC Container
builder.Services.AddDbContext<IdentityDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDbConnectionString")), ServiceLifetime.Transient);
builder.Services.AddTransient<IIdentityUnitOfWork, IdentityUnitOfWork>();
builder.Services.AddTransient<IIdentityCache, IdentityCache>();

builder.Services.AddSingleton<ICache>(serviceProvider =>  //Connect Once, and Use Permanently
{
    var redisConfig = serviceProvider.GetRequiredService<IOptions<RedisConfiguration>>().Value;
    var redisCache = new RedisCache(redisConfig);
    return redisCache;
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IPermissionService, PermissionService>();
builder.Services.AddTransient<IPermissionGroupService, PermissionGroupService>();
builder.Services.AddTransient<ILoginHistoryService, LoginHistoryService>();
builder.Services.AddTransient<IUserActionHistoryService, UserActionHistoryService>();
builder.Services.AddTransient<IUserCommonTokenService, UserCommonTokenService>();
builder.Services.AddTransient<ISubscribedClientService, SubscribedClientService>();

#endregion


#region Serilog Configuration
builder.ConfigureSeriogLogger();
#endregion

#region AutoMapper Configuration
builder.AddAutoMapperConfiguration();
#endregion


builder.Services.AddControllers(opts =>
                {
                    opts.Filters.Add(typeof(LogTrackFilter));
                    opts.Filters.Add(typeof(ValidationFilter));
                })

                .ConfigureApiBehaviorOptions(options =>
                {
                    //Auto Validation Disabled
                    options.SuppressModelStateInvalidFilter = true;
                })

                .AddNewtonsoftJson(o =>
                {
                    //ReferenceLoop
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssemblyContaining<TestValidator>();
                }); 


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var redisCache = app.Services.GetRequiredService<ICache>();



// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
