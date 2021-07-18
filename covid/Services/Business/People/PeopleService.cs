using Model;
using Model.MasterModel;
using Model.People;
using Persistence.Repositories.CountryRepository;
using Persistence.Repositories.DnaPeopleRepository;
using Persistence.Repositories.DNARepository;
using Persistence.Repositories.Interfaces;
using Persistence.Repositories.ResultRepository;
using Services.Assembler.CountryAssembler;
using Services.Assembler.DnaAssmbler;
using Services.Assembler.People;
using Services.DTO_s;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class PeopleService : IPeopleService
    {
        
        private IPeopleRepository peopleRepository;
        private ICountryRepository countryRepository;
        private IResultRepository resultRepository;
        private IDnaRepository dnaRepository;
        private IDnaPeopleRepository dnaPeopleRepository;

        private IPersonAssembler personAssembler;
        private ICountryAssembler countryAssembler;

        public PeopleService(IPeopleRepository peopleRepository, 
            IPersonAssembler personAssembler,
             ICountryRepository countryRepository,
             IResultRepository resultRepository,
             IDnaRepository dnaRepository,
             IDnaPeopleRepository dnaPeopleRepository,
             ICountryAssembler countryAssembler)
        {
            this.peopleRepository = peopleRepository;
            this.personAssembler = personAssembler;
            this.countryRepository = countryRepository;
            this.resultRepository = resultRepository;
            this.dnaRepository = dnaRepository;
            this.dnaPeopleRepository = dnaPeopleRepository;
            this.countryAssembler = countryAssembler;
        }

        public async Task<IList<PersonDTO>> GetAllAsync()
        {
            var collection =  await peopleRepository.GetAllAsync();
            var collectionDt = personAssembler.listDtoAssembler(collection);

            return collectionDt;
        }

        public void insertPerson(PersonDTO personDTO)
        {
            Person person = getInfoPerson(personDTO);
            person.Description = personDTO.Name;
            person.IdCountry = person.IdCountry;
            person.IdResult = evaluateResult(person.Dna);

            if (person.IdCountry == 0)
            {
                Country country = new Country(personDTO.Country);
                countryRepository.insert(country);
                person.IdCountry = country.Id;

            }

            peopleRepository.insert(person);

            insertDna(person.Dna);
            insertDnaPeople(person);
            


        }

        private Person getInfoPerson(PersonDTO personDTO)
        {
            Person person = new Person();

            person.Country = countryRepository.getByDescription(personDTO.Country);
            person.Result = resultRepository.getByID(1);
            person.Dna = getDna(personDTO.Dna);

            return person;
        }
        
        private List<Dna> getDna(IList<string> dnaDescriptions)
        {
            if (dnaDescriptions == null || dnaDescriptions.Count == 0)
                return null;

            List<Dna> dnas = new List<Dna>();

            foreach (string description in dnaDescriptions)
            {
                var dna = dnaRepository.getByDescription(description);
                if (dna != null)
                    dnas.Add(dna);
                else
                    dnas.Add(new Dna(description));
            }

            return dnas;
        }


        private void insertDnaPeople(Person person)
        {
            List<DnaPeople> dnaPeople = new List<DnaPeople>();

            foreach(Dna dna in person.Dna)
            {
                dnaPeople.Add(new DnaPeople(dna.Id, person.Id));
            }

            dnaPeopleRepository.insertList(dnaPeople);
        }

        private void insertDna(List<Dna> dnas)
        {
            List<Dna> dnaAux = dnas.Where(x => x.Id == 0).ToList();

            dnaRepository.insertList(dnaAux);


        }

        private int evaluateResult(List<Dna> dnas)
        {
            Result res = new Result("infected");
            resultRepository.insert(res);

            return res.Id;
        }


    }
}
