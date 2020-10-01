using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yugioh.Core.Entities.HealthNs;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/health")]
    public class HealthController : Controller
    {
        public static Health _health = new Health { HealthCount = 8000 };

        [HttpGet]
        [Route("getHealth")]
        public IActionResult GetHealth()
        {
            try
            {
                return Ok(_health);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
