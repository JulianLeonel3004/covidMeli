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
        public async Task<ActionResult> Get() 
        {
            try
            {
                return Ok(await peopleService.GetAllAsync());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                return Ok(await peopleService.GetbyId(id));

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] PersonDTO personDTO)
        {
            try
            {
                return Ok(peopleService.insertPerson(personDTO));

            }catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }


      
        [HttpGet("{search}")]
        public async Task<ActionResult> search(int key, string value)
        {
            try
            {
                return Ok(await peopleService.GetByFilter(key, value));

            }catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}