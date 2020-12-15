using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yugioh.Core.Entities;
using Yugioh.Services.Hubs;
using Yugioh.Services.Singleton;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/playcard")]
    public class PlayCardController : Controller
    {
        private GameHub _gameHub;
        public PlayCardController(GameHub gameHub) 
        {
            _gameHub = gameHub;
        }

        [HttpGet]
        public IActionResult Playcard(string player, int index, int playerindex)
        {
            try
            {
                //var player = StaticClass.players.Where(p => p.Id != playerId).FirstOrDefault();
                //player.PlayerHealth.HealthCount -= damage;
                //_healthHubContext.Clients.All.SendAsync("SendHealth",
                //    new
                //    {
                //        playerId = player.Id,
                //        health = player.PlayerHealth
                //    });
                if (playerindex == 1)
                {
                    var game = GamesSingleton.GetInstance().games.Where(g => g.player1.id.ToString() == player).FirstOrDefault();
                    game.PlayCardFromHand(player, index);
                    _gameHub.SendGame(game);
                }
                if (playerindex == 2)
                {
                    var game = GamesSingleton.GetInstance().games.Where(g => g.player2.id.ToString() == player).FirstOrDefault();
                    game.PlayCardFromHand(player, index);
                    _gameHub.SendGame(game);
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
