using Model.MasterModel;
using Model.People;
using Persistence.Repositories.Interfaces;
using Services.Assembler.People;
using Services.Business.CountryService;
using Services.Business.DnaPeopleService;
using Services.Business.DnaService;
using Services.Business.ResultService;
using Services.DTO_s;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class PeopleService : IPeopleService
    {
        private IPeopleRepository peopleRepository;
        private IPersonAssembler personAssembler;
        private ICountryService countryService;
        private IDnaService dnaService;
        private IDnaPeopleService dnaPeopleService;
        private IResultService resultService;

        public PeopleService(IPeopleRepository peopleRepository,
            IPersonAssembler personAssembler,
             ICountryService countryService,
             IDnaService dnaService,
             IDnaPeopleService dnaPeopleService,
             IResultService resultService)
        {
            this.peopleRepository = peopleRepository;
            this.personAssembler = personAssembler;
            this.dnaPeopleService = dnaPeopleService;
            this.countryService = countryService;
            this.dnaService = dnaService;
            this.resultService = resultService;
        }

        public async Task<IList<PersonDTO>> GetAllAsync()
        {
            IList<Person> collection = await peopleRepository.GetAllAsync();

            var collectionDt = personAssembler.listDtoAssembler(collection);

            return collectionDt;
        }

        public PersonDTO insertPerson(PersonDTO personDTO)
        {
            Person person = getInfoPerson(personDTO); //country y dna

            person.Description = personDTO.Name;
            person.Result = resultService.generateResult(person.Dna);
            person.IdResult = person.Result.Id;

            if (person.Country != null)
                person.IdCountry = person.Country.Id;
            else
            {
                Country country = new Country(personDTO.Country);
                countryService.insert(country);
                person.IdCountry = country.Id;

            }

            peopleRepository.insert(person);

            dnaService.insertDnas(person.Dna);
            dnaPeopleService.insertDnaPeople(person);

            return personAssembler.dtoAssembler(person);


        }

        private Person getInfoPerson(PersonDTO personDTO)
        {
            Person person = new Person();

            person.Country = countryService.getByDescription(personDTO.Country);
            person.Dna = dnaService.getDnaByDescriptions(personDTO.Dna);

            return person;
        }


    }
}
