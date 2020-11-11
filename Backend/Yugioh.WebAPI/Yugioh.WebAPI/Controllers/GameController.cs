using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpGet]
        [Route("getgame")]
        public IActionResult GetGame(Guid gameId)
        {
            try
            {
                var game = StaticClass.games.Where(p => p.id == gameId).FirstOrDefault();
                return Ok(game);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
