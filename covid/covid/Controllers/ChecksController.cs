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
            var collection = await peopleService.GetAllAsync();

            return collection;

        }

        [HttpGet("{id:int}")]
        public async Task<PersonDTO> Get(int id)
        {
            return await peopleService.GetbyId(id);
        }

        [HttpPost]
        public PersonDTO Post([FromBody] PersonDTO personDTO)
        {
            return peopleService.insertPerson(personDTO);

        }


      
        [HttpGet("{search}")]
        public async Task<IList<PersonDTO>> search(int key, string value, string value2)
        {
            //TODO: Adaptar servicio a las comas
            return await peopleService.GetByFilter(key, value, value2);
        }
    }
}