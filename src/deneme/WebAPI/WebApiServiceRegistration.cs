using Application.Services.ImageGeneratorService;
using Application.Services.ImageService;
using Infrastructure.Adapters.ImageGeneratorService;
using Infrastructure.Adapters.ImageService;
using Infrastructure.Adapters.PrintfulService;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class WebApiServiceRegistration
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services)
    {
        services.AddScoped<PrintfulServiceAdapter,PrintfulServiceAdapter>();
        return services;
    }
}
