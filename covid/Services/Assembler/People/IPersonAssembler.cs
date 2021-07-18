using Model.People;
using Services.Assembler.GenericAssembler;
using Services.DTO_s;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Assembler.People
{
    public interface IPersonAssembler
    {
        PersonDTO dtoAssembler(Person entity);
        IList<PersonDTO> listDtoAssembler(IList<Person> people);
        Person entityAssembler(PersonDTO dto);
        IList<Person> listEntityAssembler(IList<PersonDTO> peopleDto);
    }
}
