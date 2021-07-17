using Microsoft.Extensions.DependencyInjection;
using Services.Assembler.CountryAssembler;
using Services.Assembler.DnaAssmbler;
using Services.Assembler.People;
using Services.Assembler.ResultAssembler;
using Services.Implementations;
using Services.Interfaces;


namespace Services.ConfigService
{
    public static class ConfigService
    {
        public static void injectionService(IServiceCollection services)
        {
            services.AddTransient<IPeopleService, PeopleService>();
        }

        public static void injectionAssembler(IServiceCollection services)
        {

            services.AddTransient<IPersonAssembler, PersonAssembler>();
            services.AddTransient<ICountryAssembler, CountryAssembler>();
            services.AddTransient<IDnaAssembler, DnaAssembler>();
            services.AddTransient<IResultAssembler, ResultAssembler>();
        }
    }
}
