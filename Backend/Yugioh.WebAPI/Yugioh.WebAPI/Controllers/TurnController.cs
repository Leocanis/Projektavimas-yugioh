using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/turnchange")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        public IActionResult TurnChange(int PlayerId)
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
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        // GET: api/<TurnController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TurnController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TurnController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TurnController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TurnController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
