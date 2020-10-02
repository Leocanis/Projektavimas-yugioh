using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yugioh.Core.Entities.HealthNs;
using Yugioh.Core.Entities.PlayerNs;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/health")]
    public class HealthController : Controller
    {
        [HttpGet]
        [Route("getHealth")]
        public IActionResult GetHealth(int playerId)
        {
            try
            {
                var player = StaticClass.players.Where(p => p.Id == playerId).FirstOrDefault();
                return Ok(player.PlayerHealth);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
