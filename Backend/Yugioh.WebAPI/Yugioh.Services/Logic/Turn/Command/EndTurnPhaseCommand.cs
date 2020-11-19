﻿using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Services.Hubs;

namespace Yugioh.Services.Logic.Turn.Command
{
    public class EndTurnPhaseCommand : ICommand
    {
        private GameHub _gameHub;

        public EndTurnPhaseCommand(GameHub gameHub)
        {
            _gameHub = gameHub;
        }
        public void ChangeTurnState(Game game, Guid playerId)
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
    }
}
