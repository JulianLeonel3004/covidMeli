using AutoMapper;
using Model.MasterModel;
using Model.People;
using Services.Assembler.CountryAssembler;
using Services.Assembler.DnaAssmbler;
using Services.Assembler.GenericAssembler;
using Services.Assembler.ResultAssembler;
using Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Assembler.People
{
    public class PersonAssembler : IPersonAssembler // : GenericAssembler<Person, PersonDTO>, IPersonAssembler 
    {

        private ICountryAssembler countryAssembler { get; set; }
        private IDnaAssembler dnaAssembler { get; set; }
        private IResultAssembler resultAssembler { get; set; }

        public PersonAssembler(ICountryAssembler countryAssembler, IDnaAssembler dnaAssembler, IResultAssembler resultAssembler)
        {
            this.countryAssembler = countryAssembler;
            this.dnaAssembler = dnaAssembler;
            this.resultAssembler = resultAssembler;
        }

        public PersonDTO dtoAssembler(Person entity)
        {
            PersonDTO personDTO = new PersonDTO();

            //personDTO.id = entity.Id;
            //personDTO.name = entity.Description;
            //person

        //     public int? id { get; set; }
        //public string name { get; set; }
        //public string country { get; set; }
        //public List<string> dna { get; set; }
        //public string result { get; set; }

            return personDTO;
        }

        public  IList<PersonDTO> listDtoAssembler(IList<Person> people)
        {
            IList<PersonDTO> dtos = new List<PersonDTO>();

            foreach (Person entity in people)
            {
                dtos.Add(dtoAssembler(entity));
            }

            return dtos;
        }

        public Person entityAssembler(PersonDTO dto)
        {
            Person person = new Person();
            person.Id = dto.Id.Value;
            person.Description = dto.Name;



            return person;

        }

        public IList<Person> listEntityAssembler(IList<PersonDTO> peopleDto)
        {
            throw new NotImplementedException();
        }
    }
}
