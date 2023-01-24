using System;

using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(p => p.UseNewtonsoftJson())
    .ConfigureServices(services =>
    {
        services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
                {
                    var options = new DefaultOpenApiConfigurationOptions()
                    {
                        OpenApiVersion = OpenApiVersionType.V3,
                    };

                    var codespace = bool.TryParse(Environment.GetEnvironmentVariable("OpenApi__RunOnCodespaces"), out var result) && result;
                    if (codespace)
                    {
                        options.IncludeRequestingHostName = false;
                    }

                    return options;
                });
    })
    .Build();

host.Run();