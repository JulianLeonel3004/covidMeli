using Model.People;
using Persistence.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class PeopleService : IPeopleService
    {
        private IPeopleRepository peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            this.peopleRepository = peopleRepository;
        }

        public async Task<IList<Person>> GetAllAsync()
        {
            return peopleRepository.GetAllAsync();
        }
    }
}
