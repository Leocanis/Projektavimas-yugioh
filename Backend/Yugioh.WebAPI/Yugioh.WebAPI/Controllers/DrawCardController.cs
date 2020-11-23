using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yugioh.WebAPI.Controllers
{
    public class DrawCardController : Controller
    {
        public DrawCardController() { }

        public IActionResult DrawCard(int playerId, int amount)
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

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
