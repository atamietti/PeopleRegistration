using PeopleRegistration.Shared.Domain.Interfaces;
using PeopleRegistration.Shared.Infrastructure;
using System.Text.Json.Serialization;

namespace PeopleRegistration.Shared
{

    public static class Bootstrapper
    {
        public static IServiceCollection UseSharedInject(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }

}
