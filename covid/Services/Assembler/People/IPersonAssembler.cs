using Model.People;
using Services.Assembler.GenericAssembler;
using Services.DTO_s;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Assembler.People
{
    public interface IPersonAssembler:IGenericAssembler<Person, PersonDTO>
    {
    }
}
