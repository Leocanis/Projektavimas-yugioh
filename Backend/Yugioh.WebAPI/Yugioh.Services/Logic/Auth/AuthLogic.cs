using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Services.Hubs;
using Yugioh.Services.Singleton;

namespace Yugioh.Services.Logic.Auth
{
    public class AuthLogic
    {
        private GameHub _gameHub;
        private GameLogic _gameLogic;

        public AuthLogic(GameHub gameHub, GameLogic gameLogic)
        {
            _gameHub = gameHub;
            _gameLogic = gameLogic;
        }

        public LoginResponse Login(string loginName)
        {
            var response = new LoginResponse();
            if (GamesSingleton.GetInstance().games.Count == 0)
            {
                var newGame = new Game();
                newGame.id = response.gameId = Guid.NewGuid();
                newGame.player1 = new Player();
                newGame.player1.id = response.playerId = Guid.NewGuid();
                newGame.player1.playerName = loginName;
                GamesSingleton.GetInstance().games.Add(newGame);
            }
            else
            {
                if (GamesSingleton.GetInstance().games.Last().player2 != null)
                {
                    var newGame = new Game();
                    newGame.id = response.gameId = Guid.NewGuid();
                    newGame.player1 = new Player();
                    newGame.player1.id = response.playerId = Guid.NewGuid();
                    newGame.player1.playerName = loginName;
                    GamesSingleton.GetInstance().games.Add(newGame);
                }
                else
                {
                    var game = GamesSingleton.GetInstance().games.Last();
                    game.player2 = new Player();
                    game.player2.id = response.playerId = Guid.NewGuid();
                    game.player2.playerName = loginName;
                    response.gameId = game.id;
                    _gameLogic.StartGame(game);
                    _gameHub.SendGame(game);
                }
            }
            return response;
        }
    }
}
