using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.CountryRepository;
using Persistence.Repositories.DnaPeopleRepository;
using Persistence.Repositories.DNARepository;
using Persistence.Repositories.Implementations;
using Persistence.Repositories.Interfaces;
using Persistence.Repositories.ResultRepository;

namespace Persistence
{
    public class ConfigPeristence
    {
        public static void injectionRepositoty(IServiceCollection services)
        { 
            services.AddTransient<IPeopleRepository, PeopleRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IDnaRepository, DnaRepository>();
            services.AddTransient<IResultRepository, ResultRepository>();
            services.AddTransient<IDnaPeopleRepository, DnaPeopleRepository>();

        }
    }
}
