using Model.People;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
      IList<Person> GetAllAsync();
     // Task<Person> GetAsync(string id);
       
    }
}
