using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;
using Yugioh.Services.Hubs;

namespace Yugioh.Services.Logic.Command
{
    public class EndTurnPhaseCommand : ICommand
    {
        private GameHub _gameHub;

        public EndTurnPhaseCommand(GameHub gameHub)
        {
            _gameHub = gameHub;
        }        

        public override void ChangeTurnState(Game game, Guid playerId)
        {
            if (game.player1.id == playerId)
            {
                game.turn.playerId = game.player2.id;
            }
            else
            {
                game.turn.playerId = game.player1.id;
            }
            game.turn.phase = TurnPhases.MainPhase;
            game.turn.attackPhase = AttackPhases.Other;
            if (game.player1.id == playerId)
            {
                game.field1.monsterfield.Where(p => p != null).ToList().ForEach(p => p.attackPhase = CardAttackPhase.Other);

            }
            else if (game.player2.id == playerId)
            {
                game.field2.monsterfield.Where(p => p != null).ToList().ForEach(p => p.attackPhase = CardAttackPhase.Other);
            }
            _gameHub.SendGame(game);
        }

        public override void Forward(Game game, Guid playerId)
        {
            throw new NotImplementedException();
        }

        public override void Back(Game game, Guid playerId)
        {
            throw new NotImplementedException();
        }
    }
}
