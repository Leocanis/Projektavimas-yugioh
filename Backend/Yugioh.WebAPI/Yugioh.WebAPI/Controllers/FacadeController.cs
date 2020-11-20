using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yugioh.Core.Enums;
using Yugioh.Services.Logic;
using Yugioh.Services.Logic.Auth;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/facade")]
    public class FacadeController : Controller
    {
        private AuthLogic _authLogic;
        private TurnLogic _turnLogic;

        public FacadeController(AuthLogic authLogic, TurnLogic turnLogic)
        {
            _authLogic = authLogic;
            _turnLogic = turnLogic;
        }

        [Route("login")]
        public IActionResult Login(string loginName)
        {
            try
            {
                var response = _authLogic.Login(loginName);
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("turnPhase")]
        public IActionResult TurnPhase(TurnPhases phase, Guid playerId, Guid gameId)
        {
            try
            {
                switch(phase)
                {
                    case TurnPhases.AttackPhase:
                        _turnLogic.Attack(gameId, playerId);
                        break;
                    case TurnPhases.SecondPhase:
                        _turnLogic.Second(gameId, playerId);
                        break;
                    case TurnPhases.EndTurn:
                        _turnLogic.EndTurn(gameId, playerId);
                        break;
                    default:
                        throw new NotImplementedException();
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
