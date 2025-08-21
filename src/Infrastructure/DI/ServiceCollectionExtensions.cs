using Application;
using Application.Common.Behaviours;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastucture.DependancyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection Services, IConfiguration configuration)
        {
       

            Services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly("Infrastructure")
                );
            });
            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services.AddSingleton(configuration);
            

            return Services;
        }
        //add Mediator and fluent Validation
        public static IServiceCollection AddRepositories(this IServiceCollection Services)
        {
            Services.AddScoped<IApplicantRepository ,ApplicantRepository>();
            return Services;
        }

        public static IServiceCollection AddServices(this IServiceCollection Services)
        {

            Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
            });
            Services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
            
            Services.AddTransient(typeof(IRequestPreProcessor<>), typeof(LoggingBehaviour<>));
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            Services.AddHttpClient<ICountryValidatorService, CountryValidatorService>();

            return Services;
        }

        public static IServiceCollection AddConfigs(this IServiceCollection Services)
        {
            //Services
            //  .AddOptions<IntegratedServicesDto>()
            //  .BindConfiguration("IntegratedServices")
            //  .ValidateDataAnnotations()
            //  .ValidateOnStart();
   

            return Services;
        }

    }
}
