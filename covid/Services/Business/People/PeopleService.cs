using Model;
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
using System.Linq;
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

            IList<PersonDTO> collectionDt = personAssembler.listDtoAssembler(collection);

            IList<DnaPeople> dnasP;

            foreach(Person person in collection)
            {
                dnasP = dnaPeopleService.getByPeople(person.Id);

                foreach (DnaPeople dp in dnasP)
                {
                    collectionDt.Where(x => x.Id == person.Id).Single().
                        Dna.Add(dnaService.getById(dp.IdDna).Description);
                }

                dnasP = null;
            }           

            return collectionDt;
        }

        public async Task<PersonDTO> GetbyId(int id)
        {
            Person person = await peopleRepository.GetById(id);

            PersonDTO personDTO = personAssembler.dtoAssembler(person);

            IList<DnaPeople> dnasP = dnaPeopleService.getByPeople(person.Id);

            foreach (DnaPeople dp in dnasP)
            {
                personDTO.Dna.Add(dnaService.getById(dp.IdDna).Description);
            }

            return personDTO;

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
