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

            getDna(new List<DnaPeople>(), collection, collectionDt);

            //foreach(Person person in collection)
            //{
            //    dnasP = dnaPeopleService.getByPeople(person.Id);

            //    foreach (DnaPeople dp in dnasP)
            //    {
            //        collectionDt.Where(x => x.Id == person.Id).Single().
            //            Dna.Add(dnaService.getById(dp.IdDna).Description);
            //    }

            //    dnasP = null;
            //}           

            return collectionDt;
        }

        private void getDna(IList<DnaPeople> dnasP, IList<Person> people, IList<PersonDTO> personDTOs)
        {
            foreach (Person person in people)
            {
                dnasP = dnaPeopleService.getByPeople(person.Id);

                foreach (DnaPeople dp in dnasP)
                {
                    personDTOs.Where(x => x.Id == person.Id).Single().
                        Dna.Add(dnaService.getById(dp.IdDna).Description);
                }

                dnasP = null;
            }

        }

        public  Task<IList<PersonDTO>> GetByFilter(int key, string value)
        {
            if (value == null)
                return null;
            string value1, value2;

            var values = value.Split(',');

            value1 = values[0];
            value2 = values.Length > 1 ? values[1] : null;
              

            switch (key)
            {
                case Person.FILTER_TYPE_COUNTRY:
                    return filterCountry(value1, value2);
                case Person.FILTER_TYPE_RESULT:
                    return filterResul(value1, value2);
                default:
                    IList<PersonDTO> list = new List<PersonDTO>();
                    return (Task<IList<PersonDTO>>)list;
            }

         
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


        private async Task<IList<PersonDTO>> filterCountry(string value1, string value2)
        {
            int idValue = value2 != null ? countryService.getByDescription(value2).Id : 0;
            int idCountry = 0;
            
            Country country = countryService.getByDescription(value1);
            if (country != null)
                idCountry = country.Id;

            IList<Person> people = await peopleRepository.GetByCountry(idCountry, idValue);
            IList<PersonDTO> personDTOs = people != null && people.Count > 0? personAssembler.listDtoAssembler(people): new List<PersonDTO>();

            if(personDTOs.Count() > 0 )
                getDna(new List<DnaPeople>(), people, personDTOs);

            return personDTOs;
        }


        private async Task<IList<PersonDTO>> filterResul(string value1, string value2)
        {
            int idValue = value2 != null ? resultService.getResultByDescription(value2).Id : 0;

            IList<Person> people = await peopleRepository.GetByResult(resultService.getResultByDescription(value1).Id, idValue);
            IList<PersonDTO> personDTOs = personAssembler.listDtoAssembler(people);

            getDna(new List<DnaPeople>(), people, personDTOs);

            return personDTOs;

        }


    }
}
