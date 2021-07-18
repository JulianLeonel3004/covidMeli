using Model.People;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        Task<IList<Person>> GetAllAsync();
        Task<Person> GetById(int id);
        void insert(Person person);
       
    }
}
