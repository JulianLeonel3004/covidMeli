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

            personDTO.Id = entity.Id;
            personDTO.Name = entity.Description;
            personDTO.Country = entity.Country.Description;
            personDTO.Dna = assemblerListDna(entity.Dna);
            personDTO.Result = entity.Result.Description;
            
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

        private List<string> assemblerListDna(List<Dna> dnas)
        {
            List<string> newDnas = new List<string>();

            if (dnas == null)
                return newDnas;

            foreach(Dna dna in dnas)
            {
                newDnas.Add(dna.Description);
            }

            return newDnas;
        }
    }
}
