using Model.People;
using Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPeopleService
    {
        Task<IList<PersonDTO>> GetAllAsync();
        void insertPerson(PersonDTO personDTO);
    }
}
