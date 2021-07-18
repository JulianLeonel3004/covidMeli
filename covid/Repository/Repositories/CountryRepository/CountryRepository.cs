using Model.MasterModel;
using Persistence.Repositories.GenericRepository;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Repositories.CountryRepository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(AplicationDbContext context) : base(context)
        {
        }

      
    }
}
