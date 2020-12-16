using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yugioh.Core.Enums;
using Yugioh.Services.Logic;
using Yugioh.Services.Logic.Auth;
using Yugioh.Services.Singleton;
using Yugioh.Core.Strategy;
namespace Yugioh.WebAPI.Controllers
{
    [Route("api/facade")]
    public class FacadeController : Controller
    {
        private AuthLogic _authLogic;
        private TurnLogic _turnLogic;
        private DrawCardController drawcardcontroller;
        private Strategy strategy;
        private AttackController attackcontroller;
        public FacadeController(AuthLogic authLogic, TurnLogic turnLogic)
        {
            _authLogic = authLogic;
            _turnLogic = turnLogic;
            drawcardcontroller = new DrawCardController();
            strategy = new Strategy();
            //attackcontroller = new AttackController();
        }

        [Route("login")]
        public IActionResult Login(string loginName, string selectedtype)
        {
            try
            {
                var response = _authLogic.Login(loginName, selectedtype);
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
                        var game = GamesSingleton.GetInstance().games.Where(g => g.id == gameId).FirstOrDefault();
                        //strategy.decideStrategy(game, playerId);
                        _turnLogic.Attack(gameId, playerId);
                        break;
                    case TurnPhases.SecondPhase:
                        _turnLogic.Second(gameId, playerId);
                        break;
                    case TurnPhases.EndTurn:
                        drawcardcontroller.DrawCard(gameId, playerId, 1);
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
