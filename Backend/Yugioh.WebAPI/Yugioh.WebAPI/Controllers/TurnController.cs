﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Yugioh.Services.Hubs;
using Yugioh.Services.Logic;
using Yugioh.WebAPI.Classes;
using Yugioh.WebAPI.Factories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/turn")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        private TurnLogic _turnLogic;


        public TurnController(TurnLogic turnLogic)
        {
            _turnLogic = turnLogic;
        }

        [Route("main")]
        public IActionResult MainPhase(Guid playerId, Guid gameId)
        {
            try
            {                
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("attack")]
        public IActionResult AttackPhase(Guid playerId, Guid gameId)
        {
            try
            {
                _turnLogic.Attack(StaticClass.games.Where(p => p.id == gameId).FirstOrDefault(), playerId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("second")]
        public IActionResult SecondPhase(Guid playerId, Guid gameId)
        {
            try
            {
                _turnLogic.Second(StaticClass.games.Where(p => p.id == gameId).FirstOrDefault(), playerId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("end")]
        public IActionResult EndTurn(Guid playerId, Guid gameId)
        {
            try
            {
                _turnLogic.EndTurn(StaticClass.games.Where(p => p.id == gameId).FirstOrDefault(), playerId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
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
