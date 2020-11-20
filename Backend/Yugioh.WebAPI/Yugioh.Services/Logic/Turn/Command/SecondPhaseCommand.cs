using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;
using Yugioh.Services.Hubs;

namespace Yugioh.Services.Logic.Command
{
    public class SecondPhaseCommand : ICommand
    {
        private GameHub _gameHub;

        public SecondPhaseCommand(GameHub gameHub)
        {
            _gameHub = gameHub;
        }        

        public override void Forward(Game game, Guid playerId)
        {
            throw new NotImplementedException();
        }

        public override void Back(Game game, Guid playerId)
        {
            throw new NotImplementedException();
        }
        public override void ChangeTurnState(Game game, Guid playerId)
        {
            game.turn.phase = TurnPhases.SecondPhase;
            _gameHub.SendGame(game);
        }
    }
}
