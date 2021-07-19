using Microsoft.Extensions.DependencyInjection;
using Services.Assembler.CountryAssembler;
using Services.Assembler.DnaAssmbler;
using Services.Assembler.People;
using Services.Assembler.ResultAssembler;
using Services.Business.CountryService;
using Services.Business.DnaPeopleService;
using Services.Business.DnaService;
using Services.Business.ResultService;
using Services.Implementations;
using Services.Interfaces;


namespace Services.ConfigService
{
    public static class ConfigService
    {
        public static void injectionService(IServiceCollection services)
        {
            services.AddTransient<ICountryService,CountryService>();
            services.AddTransient<IDnaPeopleService, DnaPeopleService>();
            services.AddTransient<IDnaService, DnaService>();
            services.AddTransient<IPeopleService, PeopleService>();
            services.AddTransient<IResultService, ResultService>();

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
