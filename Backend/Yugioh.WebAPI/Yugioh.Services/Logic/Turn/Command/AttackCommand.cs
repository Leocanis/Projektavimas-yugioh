﻿using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;
using Yugioh.Services.Hubs;

namespace Yugioh.Services.Logic.Command
{
    public class AttackCommand : ICommand
    {
        private GameHub _gameHub;
        public AttackCommand(GameHub gameHub)
        {
            _gameHub = gameHub;
        }        

        public override void ChangeTurnState(Game game, Guid playerId)
        {
            game.turn.phase = TurnPhases.AttackPhase;
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