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
        Task<IList<Person>> GetByCountry(int id, int? id2);
        Task<IList<Person>> GetByResult(int id, int?id2);
        void insert(Person person);
       
    }
}
