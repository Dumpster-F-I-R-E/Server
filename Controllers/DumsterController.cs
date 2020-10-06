using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("dumpster")]
    public class DumsterController : ControllerBase
    {
        private readonly ILogger<DumsterController> _logger;
       
        public DumsterController(ILogger<DumsterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Dumpster> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Dumpster
            {
                Fullness = rng.Next(0, 100),
                Battery = rng.Next(0, 100),
                Location = new Location(rng.Next(0,65000),rng.Next(-232323,2343424))
            })

            .ToArray();
        }
    }
}
