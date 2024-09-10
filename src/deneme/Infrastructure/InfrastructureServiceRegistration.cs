using Application.Services.ImageGeneratorService;
using Application.Services.ImageService;
using Application.Services.PrintfulService;
using Infrastructure.Adapters.ImageGeneratorService;
using Infrastructure.Adapters.ImageService;
using Infrastructure.Adapters.PrintfulService;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ImageServiceBase, CloudinaryImageServiceAdapter>();
        services.AddScoped<ImageGeneratorServiceBase, DalleImageGeneratorServiceAdapter>();
        services.AddScoped<PrintfulServiceBase, PrintfulServiceAdapter>();

        return services;
    }
}
