using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yugioh.Services.Singleton;

namespace Yugioh.WebAPI.Controllers
{
    public class DrawCardController : Controller
    {
        public DrawCardController() { }

        public IActionResult DrawCard(Guid gameId, Guid playerId, int amount)
        {
            try
            {
                var game = GamesSingleton.GetInstance().games.Where(g => g.id == gameId).FirstOrDefault();
                game.PlayerDrawCardsIntoHand(playerId, amount);
                    return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
