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
    public class PersonAssembler : GenericAssembler<Person, PersonDTO>, IPersonAssembler 
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

        public override PersonDTO dtoAssembler(Person entity)
        {
            PersonDTO personDTO = new PersonDTO();

            personDTO.Id = entity.Id;
            personDTO.Description = entity.Description;
            
            personDTO.Country = countryAssembler.dtoAssembler(entity.Country);
            personDTO.Result = resultAssembler.dtoAssembler(entity.Result);
            

            return personDTO;
        }
        

        public override IList<PersonDTO> listDtoAssembler(IList<Person> people)
        {
            IList<PersonDTO> dtos = new List<PersonDTO>();

            foreach (Person entity in people)
            {
                dtos.Add(dtoAssembler(entity));
            }

            return dtos;
        }

    }
}
