using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microservice.Identity.Application.Caching;
using Microservice.Identity.Domain.Context;
using Microservice.Identity.Domain.IoC;
using Microservice.Identity.Infrastructure.Caching;
using Microservices.Core.CrossCuttingConcerns.Caching;
using Microservices.Core.CrossCuttingConcerns.Caching.Redis;
using Microservices.Core.CrossCuttingConcerns.Logging;
using Microsoft.EntityFrameworkCore;
using Mircoservice.Identity.API;
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

// Add services to the container.
builder.Services.AddDbContext<IdentityDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDbConnectionString")));
builder.Services.AddSingleton<IIdentityCache, IdentityCache>();
builder.Services.AddSingleton<ICache, RedisCache>();

//TODO : Start Redis Connection While Starting Up The Proejct.
//TODO : Write Serilog Configuration Extension, For Clean Code.

#region Serilog Configuration
Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Enviroment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                .MinimumLevel.Debug()
                .Filter.ByExcluding(Matching.FromSource("Microsoft"))
                .Filter.ByExcluding(Matching.FromSource("System"))
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(builder.Configuration.GetValue<string>("ElasticSearch:Uri")))
                {
                    AutoRegisterTemplate = true,
                    DetectElasticsearchVersion = true,
                    RegisterTemplateFailure = RegisterTemplateRecovery.IndexAnyway,
                    TemplateName = "serilog-identityservice-template",
                    IndexFormat = $"identityservicelogs-{DateTime.UtcNow:yyyy.MM.dd}",
                    MinimumLogEventLevel = LogEventLevel.Information,
                    BufferBaseFilename = builder.Configuration.GetValue<string>("ElasticSearch:BufferFilePath"),
                    BatchPostingLimit = 10000,
                    BufferFileSizeLimitBytes = 10 * 1024 * 1024,  //10mb
                    ConnectionTimeout = TimeSpan.FromSeconds(15000)
                })
    .CreateLogger();

builder.Host.UseSerilog();

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
