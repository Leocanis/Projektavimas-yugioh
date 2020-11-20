﻿using System;
using System.Collections.Generic;
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