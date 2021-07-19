using Model.MasterModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business.CountryService
{
    public interface ICountryService
    {
        Country getByDescription(string description);
        void insert(Country country);
    }
}
