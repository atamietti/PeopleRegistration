using PeopleRegistration.Domain.Services;
using PeopleRegistration.Infrastructure;
using PeopleRegistration.Shared.Domain;
using PeopleRegistration.Shared.Domain.Interfaces;

namespace PeopleRegistration;

public static class Bootstrapper
{
    public static IServiceCollection UsePersonInject(this IServiceCollection services, PeopleRegistrationConfiguration config)
    {
        services.AddSingleton(config);
        services.AddScoped<IPersonService, PersonService>();
        services.AddDbContext<IPeopleRegistrationDb, PeopoleRegistrationDb>(ServiceLifetime.Scoped);

        return services;
    }
}
