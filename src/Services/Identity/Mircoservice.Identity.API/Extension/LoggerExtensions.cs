using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Filters;
using Serilog.Sinks.Elasticsearch;

namespace Mircoservice.Identity.API.Extension
{
    public static class LoggerExtensions
    {
        public static void ConfigureSeriogLogger(this WebApplicationBuilder appBuilder)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("Enviroment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                .MinimumLevel.Debug()
                .Filter.ByExcluding(Matching.FromSource("Microsoft"))
                .Filter.ByExcluding(Matching.FromSource("System"))
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(appBuilder.Configuration.GetValue<string>("ElasticSearch:Uri")))
                {
                    AutoRegisterTemplate = true,
                    DetectElasticsearchVersion = true,
                    RegisterTemplateFailure = RegisterTemplateRecovery.IndexAnyway,
                    TemplateName = "serilog-identityservice-template",
                    IndexFormat = $"identityservicelogs-{DateTime.UtcNow:yyyy.MM.dd}",
                    MinimumLogEventLevel = LogEventLevel.Information,
                    BufferBaseFilename = appBuilder.Configuration.GetValue<string>("ElasticSearch:BufferFilePath"),
                    BatchPostingLimit = 10000,
                    BufferFileSizeLimitBytes = 10 * 1024 * 1024,  //10mb
                    ConnectionTimeout = TimeSpan.FromSeconds(15000)

                }).CreateLogger();


            appBuilder.Host.UseSerilog();

        }
    }
}
