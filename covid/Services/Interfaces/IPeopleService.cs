using Model.People;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPeopleService
    {
        Task<IList<Person>> GetAllAsync();
    }
}
