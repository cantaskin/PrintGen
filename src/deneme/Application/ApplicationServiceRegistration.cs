using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using NArchitecture.Core.Security.JWT;
using Application.Services.Categories;
using Application.Services.Colors;
using Application.Services.ProductImages;
using Application.Services.PrintAreas;
using Application.Services.PrintAreaNames;
using Application.Services.CustomizedImages;
using Application.Services.CustomizedProducts;
using Application.Services.Addresses;
using Application.Services.OrderDetails;
using Application.Services.Orders;
using Application.Services.OrderTransports;
using Application.Services.Prompts;
using Application.Services.ImageGeneratorService;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig,
        TokenOptions tokenOptions
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int, Guid>(tokenOptions);

        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IColorService, ColorManager>();
        services.AddScoped<IProductImageService, ProductImageManager>();
        services.AddScoped<IProductImageService, ProductImageManager>();
        services.AddScoped<IPrintAreaService, PrintAreaManager>();
        services.AddScoped<IPrintAreaNameService, PrintAreaNameManager>();
        services.AddScoped<ICustomizedImageService, CustomizedImageManager>();
        services.AddScoped<ICustomizedProductService, CustomizedProductManager>();
        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IOrderDetailService, OrderDetailManager>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IOrderTransportService, OrderTransportManager>();
        services.AddScoped<IPromptService, PromptManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
