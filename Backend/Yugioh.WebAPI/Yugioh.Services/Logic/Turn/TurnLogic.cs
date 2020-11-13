using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;
using Yugioh.Services.Hubs;

namespace Yugioh.Services.Logic
{
    public class TurnLogic
    {
        private GameHub _gameHub;

        public TurnLogic(GameHub gameHub)
        {
            _gameHub = gameHub;
        }
        public void Attack(Game game, Guid playerId)
        {
            game.turn.phase = TurnPhases.AttackPhase;
            _gameHub.SendGame(game);
        }

        public void Second(Game game, Guid playerId)
        {
            game.turn.phase = TurnPhases.SecondPhase;
            _gameHub.SendGame(game);
        }

        public void EndTurn(Game game, Guid playerId)
        {
            if(game.player1.id == playerId)
            {
                game.turn.playerId = game.player2.id;
            }
            else
            {
                game.turn.playerId = game.player1.id;
            }
            game.turn.phase = TurnPhases.MainPhase;
            _gameHub.SendGame(game);
        }
    }
}
