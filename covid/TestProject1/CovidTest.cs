using Microsoft.EntityFrameworkCore;
using Model.MasterModel;
using Model.People;
using NUnit.Framework;
using Persistence.Repositories.CountryRepository;
using Persistence.Repositories.DnaPeopleRepository;
using Persistence.Repositories.DNARepository;
using Persistence.Repositories.Implementations;
using Persistence.Repositories.ResultRepository;
using Repository;
using Services.Assembler.People;
using Services.Business.CountryService;
using Services.Business.DnaPeopleService;
using Services.Business.DnaService;
using Services.Business.ResultService;
using Services.Business.StatService;
using Services.DTO_s;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject1
{
    public class CovidTest
    {
        private IPeopleService peopleService;
        private AplicationDbContext context;
        private IStatService statService;
        private IResultRepository resultRepository;
        private bool stop = false;
        string[] DNAS = new string[] { "ATGCGA", "CGGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

        Person person;
     


        [SetUp]
        public void Setup()
        {
            if (stop)
                return;

            stop = true;

            var options = new DbContextOptionsBuilder<AplicationDbContext>().UseInMemoryDatabase(databaseName: $"covid.Db");//"Data Source=.;Initial Catalog=covid;Integrated Security=True"


            context = new AplicationDbContext(options.Options);


            List<Result> results = new List<Result>();


            results.Add(new Result(Result.INFECTED, "infected"));
            results.Add(new Result(Result.HELTHY, "helthy"));
            results.Add(new Result(Result.INMUNE, "inmune"));

            foreach (Result res in results)
            {
                context.Results.Add(res);
            }


            Person person = new Person();
            insertTestPerson(person);
            context.People.Add(person);
            this.person = person;


            context.SaveChanges();



            var peoplerepository = new PeopleRepository(context);

            var personAssembler = new PersonAssembler();

            var countryService = new CountryService(new CountryRepository(context));

            var dnaService = new DnaService(new DnaRepository(context));

            var dnaPeopleService = new DnaPeopleService(new DnaPeopleRepository(context));

            resultRepository = new ResultRepository(context);
           var resultService = new ResultService(resultRepository);

            statService = new StatService(peoplerepository);

            peopleService = new PeopleService(peoplerepository, personAssembler, countryService, dnaService, dnaPeopleService, resultService);


        }

        [Test]
        public void Get()
        {

            PersonDTO personDTO = new PersonDTO();
            mappingTestPersonDTO(personDTO, person);
            

            Task<IList<PersonDTO>> persons = peopleService.GetAllAsync();

            PersonDTO pd = persons.Result[0];

            Assert.IsTrue(EqualPersonDto(pd, personDTO));
        }

     


        [Test]
        public void GetByIdTest()
        {

            PersonDTO personDTO = new PersonDTO();
            mappingTestPersonDTO(personDTO, person);

            Task<PersonDTO> listPersonDto = peopleService.GetbyId(person.Id);

            PersonDTO pd = listPersonDto.Result;

            Assert.IsTrue(EqualPersonDto(pd, personDTO));

        }


    

        [Test]
        public void PostTest()
        {
            PersonDTO personDTO = new PersonDTO();

            string[] dnas = new string[] { "ATGCGA", "CGGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            personDTO.Country = "España";
            personDTO.Dna = createListString(dnas);
            personDTO.Name = "Julian";

            var p = peopleService.insertPerson(personDTO);

            personDTO.Result = "infected";

            personDTO.Id = p.Id;

            Assert.IsTrue(EqualPersonDto(p, personDTO));

        }

        [Test]
        public void PostTestCountryExist()
        {
            PersonDTO personDTO = new PersonDTO();

            string[] dnas = new string[] { "ATGCGA", "CGGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            personDTO.Country = "Argentina";
            personDTO.Dna = createListString(dnas);
            personDTO.Name = "Julian";

            var p = peopleService.insertPerson(personDTO);

            personDTO.Result = "infected";

            personDTO.Id = p.Id;

            Assert.IsTrue(EqualPersonDto(p, personDTO));

        }

        [Test]
        public void GetBySearchCountry()
        {
            PersonDTO personDTO = new PersonDTO();



            mappingTestPersonDTO(personDTO, person);

            Task<IList<PersonDTO>> listPersonDto = peopleService.GetByFilter(1, "Argentina");


            PersonDTO pd = listPersonDto.Result[0];


            Assert.IsTrue(EqualPersonDto(pd, personDTO));

        }

        [Test]
        public void GetBySearchResult()
        {
            PersonDTO personDTO = new PersonDTO();



            mappingTestPersonDTO(personDTO, person);

            Task<IList<PersonDTO>> listPersonDto = peopleService.GetByFilter(2, "infected");


            PersonDTO pd = listPersonDto.Result[0];


            Assert.IsTrue(EqualPersonDto(pd, personDTO));

        }

        [Test]
        public void GetBySearchNothing()
        {
            Task<IList<PersonDTO>> listPersonDto = peopleService.GetByFilter(4, "nothing");
            Assert.IsTrue(listPersonDto == null);

        }

        [Test]
        public void stats()
        {

           var dto = statService.getStats();

            Assert.IsTrue(dto.Result.Healthy == 0 && dto.Result.Infected == 3 && dto.Result.Inmune == 0);
        }

 
        private bool EqualPersonDto(PersonDTO p1, PersonDTO p2)
        {
            return p1.Name.Equals(p2.Name) && p1.Result.Equals(p2.Result) &&
                p1.Country.Equals(p2.Country) && EqualsListString(p1.Dna, p2.Dna);
        }

        private bool EqualsListString(List<string> value1, List<string> value2)
        {
            if (value1 == null)
                return value1 == value2;

            for(int i=0; i < value1.Count(); i++)
            {
                if (!value1[i].Equals(value2[i]))
                    return false;
            }

            return true;
        }



        private async void TestGetById(int id, Person person)
        {
            try
            {
              var p = await peopleService.GetbyId(id);

                Assert.AreEqual(person, p);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }



        private List<Dna> createListDna(string[] values)
        {
            List<Dna> listDna = new List<Dna>();

            foreach(string val in values)
            {
                listDna.Add(new Dna(val));
            }

            return listDna;
        }


        private List<string> createListString(string[] values)
        {
            List<string> list = new List<string>();

            foreach(string val in values)
            {
                list.Add(val);
            }

            return list;
        }


        private void mappingTestPersonDTO(PersonDTO personDTO, Person pers)
        {
            personDTO.Name = pers.Description;
            personDTO.Country = pers.Country.Description;
            personDTO.Result = "infected";
            personDTO.Dna = createListString(DNAS);
        }

        private void insertTestPerson(Person pers)
        {
            pers.Country = new Country("Argentina");
            pers.Description = "Julian";

            pers.Dna = new List<Dna>();

            pers.Dna.Add(new Dna(71, "ATGCGA"));
            pers.Dna.Add(new Dna(72, "CGGTGC"));
            pers.Dna.Add(new Dna(73, "TTATGT"));
            pers.Dna.Add(new Dna(74, "AGAAGG"));
            pers.Dna.Add(new Dna(75, "CCCCTA"));
            pers.Dna.Add(new Dna(76, "TCACTG"));

            pers.IdCountry = 27;
            pers.IdResult = 1;

        }


    }
}