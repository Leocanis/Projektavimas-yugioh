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
        public IActionResult Attack(int damage)
        {
            try
            {
                HealthController._health.HealthCount -= damage;
                _healthHubContext.Clients.All.SendAsync("SendHealth",
                    new
                    {
                        health = HealthController._health
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
