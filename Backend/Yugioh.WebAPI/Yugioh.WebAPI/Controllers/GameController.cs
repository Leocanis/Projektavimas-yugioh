using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yugioh.Services.Logic;
using Yugioh.Services.Singleton;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        IGame _gameProxy;

        public GameController ()
        {
            _gameProxy = new GameProxy();
        }

        [HttpGet]
        [Route("getgame")]
        public IActionResult GetGame(Guid gameId)
        {
            try
            {
                var game = _gameProxy.GetGame(gameId);
                return Ok(game);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
