using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Presentation.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IApplicantRepository, ApplicantRepository>();
        services.AddScoped<IEmployerRepository, EmployerRepository>();

        services.AddControllers();

        return services;
    }
}
