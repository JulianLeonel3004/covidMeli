using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace covid.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Running...";
        }
    }
}