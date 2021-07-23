using Model.MasterModel;
using Model.People;
using Services.DTO_s;
using System;
using System.Collections.Generic;

namespace Services.Assembler.People
{
    public class PersonAssembler : IPersonAssembler
    {


        public PersonAssembler()
        {
           
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
