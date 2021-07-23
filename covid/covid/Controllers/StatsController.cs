using Microsoft.AspNetCore.Mvc;
using Services.Business.StatService;
using Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid.Controllers
{
    [ApiController]
    [Route("covid/stats")]
    public class StatsController : Controller
    {
        private IStatService statService;
        
        public StatsController(IStatService statService)
        {
            this.statService = statService;
        } 

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await statService.getStats());
            }catch(Exception e)
            {
                return NotFound(e.Message);
            }
           

        }
    }
}
