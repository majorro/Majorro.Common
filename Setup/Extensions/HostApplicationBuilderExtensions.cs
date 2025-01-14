using Majorro.Common.Setup.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Majorro.Common.Setup.Extensions;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder Configure<T>(this IHostApplicationBuilder builder)
        where T : class, IConfig
    {
        builder.Services
            .AddOptions<T>()
            .BindConfiguration(T.SectionName)
            .ValidateDataAnnotations();
        return builder;
    }
}