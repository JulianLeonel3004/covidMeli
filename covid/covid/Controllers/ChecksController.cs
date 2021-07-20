using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.People;
using Services.DTO_s;
using Services.Interfaces;

namespace covid.Controllers
{
    [ApiController]
    [Route("covid/[controller]")]
    public class ChecksController : ControllerBase
    {
        private IPeopleService peopleService { get; set; }

        public ChecksController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        public async Task<IList<PersonDTO>> Get(int key, string value, string value2)
        {
            try
            {
                return await peopleService.GetAllAsync();
            }
            catch(Exception e)
            {
                return new List<PersonDTO>();
            }

        }

        [HttpGet("{id:int}")]
        public async Task<PersonDTO> Get(int id)
        {
            try
            {
                return await peopleService.GetbyId(id);

            }catch(Exception e)
            {
                return new PersonDTO();
            }
        }

        [HttpPost]
        public PersonDTO Post([FromBody] PersonDTO personDTO)
        {
            try
            {
                return peopleService.insertPerson(personDTO);

            }catch(Exception e)
            {
                return new PersonDTO();
            }
        }


      
        [HttpGet("{search}")]
        public async Task<IList<PersonDTO>> search(int key, string value)
        {
            try
            {
                return await peopleService.GetByFilter(key, value);
            }catch(Exception e)
            {
                return new List<PersonDTO>();
            }
        }
    }
}