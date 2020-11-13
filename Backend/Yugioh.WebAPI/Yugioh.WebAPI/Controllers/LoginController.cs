using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yugioh.Core.Entities.Auth;
using Yugioh.Core.Entities.Game;
using Yugioh.Core.Entities.PlayerNs;
using Yugioh.Services.Hubs;

namespace Yugioh.WebAPI.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private GameHub _gameHub;

        public LoginController(GameHub gameHub)
        {
            _gameHub = gameHub;
        }
        public IActionResult Login(string loginName)
        {
            try
            {
                var response = new LoginResponse();
                if (StaticClass.games.Count == 0)
                {
                    var newGame = new Game();
                    newGame.id = response.gameId = Guid.NewGuid();
                    newGame.player1 = new Player();
                    newGame.player1.id = response.playerId = Guid.NewGuid();
                    newGame.player1.playerName = loginName;
                    StaticClass.games.Add(newGame);
                }
                else
                {
                    if(StaticClass.games.Last().player2 != null)
                    {
                        var newGame = new Game();
                        newGame.id = response.gameId = Guid.NewGuid();
                        newGame.player1 = new Player();
                        newGame.player1.id = response.playerId = Guid.NewGuid();
                        newGame.player1.playerName = loginName;
                        StaticClass.games.Add(newGame);
                    }
                    else
                    {
                        var game = StaticClass.games.Last();
                        game.player2 = new Player();
                        game.player2.id = response.playerId = Guid.NewGuid();
                        game.player2.playerName = loginName;
                        response.gameId = game.id;
                        _gameHub.SendGame(game);
                    }
                }

                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
