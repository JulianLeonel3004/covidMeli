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
using System.Globalization;
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
            IList<Person> collection = await peopleRepository.GetAllAsync();

            var collectionDt = personAssembler.listDtoAssembler(collection);

            return collectionDt;
        }

        public PersonDTO insertPerson(PersonDTO personDTO)
        {
            Person person = getInfoPerson(personDTO); //country y dna

            person.Description = personDTO.Name;
            person.Result = generateResult(person.Dna);
            person.IdResult = person.Result.Id;

            if (person.Country != null)
                person.IdCountry = person.Country.Id;
            else
            {
                Country country = new Country(personDTO.Country);
                countryRepository.insert(country);
                person.IdCountry = country.Id;

            }

            peopleRepository.insert(person);

            insertDna(person.Dna);
            insertDnaPeople(person);

            return personAssembler.dtoAssembler(person);


        }

        private Person getInfoPerson(PersonDTO personDTO)
        {
            Person person = new Person();

            person.Country = countryRepository.getByDescription(personDTO.Country);
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

            if (person.Dna == null)
                return;

            List<DnaPeople> dnaPeople = new List<DnaPeople>();

            foreach (Dna dna in person.Dna)
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

        private Result generateResult(List<Dna> dnas)
        {
            int sequence = 0, idDna = 0;

            sequence = sequenceRow(dnas) + sequenceColumn(dnas);
            
            if (sequence >= 4)
                idDna = Result.INMUNE;
            else if (sequence < 2)
                idDna = Result.HELTHY;
            else
                idDna = Result.INFECTED;

            return resultRepository.getByID(idDna);
        }

        private int sequenceRow(List<Dna> dnas)
        {
            int sequence = 0;

            foreach (Dna dna in dnas)
            {
         
                if (countCounsecutive(dna.Description) == 4)
                    sequence++;

                if (sequence == 4)
                   break;

            }

            return sequence;
        }

        private int sequenceColumn(List<Dna> dnas)
        {
            int totalDnas = dnas.Count;
            int j = 0;
            string concatenate = "";
            List<Dna> newDnas = new List<Dna>();

            for (int i = 0; i < totalDnas; i++)
            {
                    concatenate += dnas[i].Description.Substring(j,1);

                if (i == totalDnas - 1)
                {
                    newDnas.Add(new Dna(concatenate));
                    concatenate = "";
                    if (j == totalDnas - 1)
                        break;

                    i = -1;
                    j++;
                }

            }

            return sequenceRow(newDnas);
        }


        private int countCounsecutive(string description)
        {
            char[] des = description.ToArray();
            char? prev = null;

            int auxRepeat = 0;
            int repeat = 0;

            foreach (char act in des)
            {
                if (prev != null && prev == act)
                    auxRepeat++;
                else
                {
                    if (auxRepeat > repeat)
                        repeat = auxRepeat;

                    auxRepeat = 0;
                }

                prev = act;

            }


            if (auxRepeat > repeat)
                repeat = auxRepeat;

            return repeat+1;
        }

    }
}
