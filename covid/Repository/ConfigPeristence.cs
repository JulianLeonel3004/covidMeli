using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.Implementations;
using Persistence.Repositories.Interfaces;

namespace Persistence
{
    public class ConfigPeristence
    {
        public static void injectionRepositoty(IServiceCollection services)
        { 
            services.AddTransient<IPeopleRepository, PeopleRepository>();
        }
    }
}
