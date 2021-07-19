using Model.MasterModel;
using Persistence.Repositories.CountryRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business.CountryService
{
    public class CountryService : ICountryService
    {
        private ICountryRepository countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public Country getByDescription(string description)
        {
             return countryRepository.getByDescription(description);
        }

        public void insert(Country country)
        {
            countryRepository.insert(country);
        }
    }
}
