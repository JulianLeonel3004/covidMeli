using Model.People;
using Persistence.Repositories.Interfaces;
using Services.Assembler.People;
using Services.DTO_s;
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
        private IPersonAssembler personAssembler;
        public PeopleService(IPeopleRepository peopleRepository, IPersonAssembler personAssembler)
        {
            this.peopleRepository = peopleRepository;
            this.personAssembler = personAssembler; 
        }

        public async Task<IList<PersonDTO>> GetAllAsync()
        {
            var collection =  await peopleRepository.GetAllAsync();
            var collectionDt = personAssembler.listDtoAssembler(collection);

            return collectionDt;
        }
    }
}
