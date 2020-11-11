using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Yugioh.Services.Hubs;
using Yugioh.WebAPI.Classes;
using Yugioh.WebAPI.Factories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/turnchange")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        private Deck deck;

        private readonly IHubContext<TurnHub> _turnHubContext;
        public TurnController(IHubContext<TurnHub> turnHubContext)
        {
            deck = new Deck();
            _turnHubContext = turnHubContext;
        }
        public IActionResult TurnChange(int playerId)
        {
            try
            {
                /*
                var player = StaticClass.players.Where(p => p.Id != playerId).FirstOrDefault();
                player.PlayerHealth.HealthCount -= damage;
                _healthHubContext.Clients.All.SendAsync("SendHealth",
                    new
                    {
                        playerId = player.Id,
                        health = player.PlayerHealth
                    });

                return Ok();*/
                //var player = StaticClass.players.Where(p => p.Id != playerId).FirstOrDefault();

                //var generatedCard = deck.generateRandMonster(player.Id + player.PlayerHealth.HealthCount);
                //_turnHubContext.Clients.All.SendAsync("SendCard", generatedCard);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
