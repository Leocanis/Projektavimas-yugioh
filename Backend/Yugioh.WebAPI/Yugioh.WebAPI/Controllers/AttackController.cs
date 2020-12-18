using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Yugioh.Core.Entities;
using Yugioh.Services.Hubs;
using Yugioh.Services.Logic.Attack;
using Yugioh.Services.Logic.Attack.State;
using Yugioh.Services.Singleton;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/attack")]
    public class AttackController : Controller
    {
        private AttackLogic _attackLogic;
        public AttackController(AttackLogic attackLogic) 
        {
            _attackLogic = attackLogic;
        }

        [HttpGet]
        [Route("action")]
        public IActionResult Attack(Guid gameId, Guid playerId, Guid cardId, int state)
        {
            try
            {
                switch(state)
                {
                    case 1:
                        {
                            IState logic = new AttackState(_attackLogic);
                            logic.Handle(gameId, playerId, cardId);
                            break;
                        }
                    case 2:
                        {
                            IState logic = new TargetState(_attackLogic);
                            logic.Handle(gameId, playerId, cardId);
                            break;
                        }
                    case 3:
                        {
                            IState logic = new CancelState(_attackLogic);
                            logic.Handle(gameId, playerId, cardId);
                            break;
                        }
                }

                
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("attack")]
        public IActionResult Attack(Guid gameId, Guid playerId, Guid cardId)
        {
            try
            {
                _attackLogic.Attack(gameId, playerId, cardId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("target")]
        public IActionResult Target(Guid gameId, Guid playerId, Guid cardId)
        {
            try
            {
                _attackLogic.Target(gameId, playerId, cardId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("cancel")]
        public IActionResult Cancel(Guid gameId, Guid playerId, Guid cardId)
        {
            try
            {
                _attackLogic.Cancel(gameId, playerId, cardId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
