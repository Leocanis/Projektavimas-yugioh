using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Yugioh.Core.Entities.HealthNs;
using Yugioh.Services.Hubs;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/attack")]
    public class AttackController : Controller
    {
        private readonly IHubContext<HealthHub> _healthHubContext;        
        public AttackController(IHubContext<HealthHub> healthHubContext)
        {
            _healthHubContext = healthHubContext;
        }

        [HttpGet]        
        public IActionResult Attack(int playerId, int damage)
        {
            try
            {
                var player = StaticClass.players.Where(p => p.Id != playerId).FirstOrDefault();
                player.PlayerHealth.HealthCount -= damage;
                _healthHubContext.Clients.All.SendAsync("SendHealth",
                    new
                    {
                        playerId = player.Id,
                        health = player.PlayerHealth
                    });

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }        
    }
}
