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
    [Route("covid/checks")]
    public class CovidController : ControllerBase
    {
        private readonly ILogger<CovidController> _logger;
        private IPeopleService peopleService { get; set; }

        public CovidController(ILogger<CovidController> logger, IPeopleService peopleService)
        {
            _logger = logger;
            this.peopleService = peopleService;
        }

        [HttpGet]

        public async Task<IList<PersonDTO>> Get()
        {
            var collection = await peopleService.GetAllAsync();

            return collection;

        }
        [HttpGet("{id}")]
        public async Task<PersonDTO> Get(int id)
        {
            return await peopleService.GetbyId(id);
        }

        [HttpPost]
        public PersonDTO Post([FromBody] PersonDTO personDTO)
        {
           return peopleService.insertPerson(personDTO);
           
        }
    }
}