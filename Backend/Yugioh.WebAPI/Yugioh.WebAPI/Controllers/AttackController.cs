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
        private static Health _health = new Health { HealthCount = 8000 };
        public AttackController(IHubContext<HealthHub> healthHubContext)
        {
            _healthHubContext = healthHubContext;
        }

        [HttpGet]
        public IActionResult Attack(int damage)
        {
            try
            {
                _health.HealthCount -= damage;
                _healthHubContext.Clients.All.SendAsync("SendHealth",
                    new
                    {
                        health = _health
                    });

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

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
