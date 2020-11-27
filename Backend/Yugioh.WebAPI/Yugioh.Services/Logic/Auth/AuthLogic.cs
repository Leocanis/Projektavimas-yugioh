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

        public LoginResponse Login(string loginName, string decktype)
        {
            var response = new LoginResponse();
            if (GamesSingleton.GetInstance().games.Count == 0)
            {
                var newGame = new Game();
                newGame.id = response.gameId = Guid.NewGuid();
                newGame.player1 = new Player();
                newGame.field1 = new Field();
                newGame.player1.id = response.playerId = Guid.NewGuid();
                newGame.player1.playerName = loginName;
                newGame.player1.decktype = decktype;
                newGame.player1.createDeck(decktype, 1);
                //newGame.player1.drawCardsFromDeck(3);
                newGame.PlayerDrawCardsIntoHand(newGame.player1.id, 3);
                GamesSingleton.GetInstance().games.Add(newGame);
            }
            else
            {
                if (GamesSingleton.GetInstance().games.Last().player2 != null)
                {
                    var newGame = new Game();
                    newGame.id = response.gameId = Guid.NewGuid();
                    newGame.player1 = new Player();
                    newGame.field1 = new Field();
                    newGame.player1.id = response.playerId = Guid.NewGuid();
                    newGame.player1.playerName = loginName;
                    newGame.player1.decktype = decktype;
                    newGame.player1.createDeck(decktype, 1);
                    //var cards = newGame.player1.drawCardsFromDeck(3);
                    newGame.PlayerDrawCardsIntoHand(newGame.player1.id, 3);
                    GamesSingleton.GetInstance().games.Add(newGame);
                }
                else
                {
                    var game = GamesSingleton.GetInstance().games.Last();
                    game.player2 = new Player();
                    game.field2 = new Field();
                    game.player2.id = response.playerId = Guid.NewGuid();
                    game.player2.playerName = loginName;
                    game.player2.decktype = decktype;
                    game.player2.createDeck(decktype, 2);
                    response.gameId = game.id;
                    game.PlayerDrawCardsIntoHand(game.player2.id, 3);
                    _gameLogic.StartGame(game);
                    _gameHub.SendGame(game);
                }
            }
            return response;
        }
    }
}
