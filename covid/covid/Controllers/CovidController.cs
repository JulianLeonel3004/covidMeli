using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.People;
using Services.Interfaces;

namespace covid.Controllers
{
    [ApiController]
    [Route("covid")]
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

        //public string Get()
        //{
        //    return "corre";
        //}
        public async Task<string> Get()
        {
             var collection =  peopleService.GetAllAsync();

            return "terminó";
        }
    }
}