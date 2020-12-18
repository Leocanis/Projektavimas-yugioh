using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;

namespace Yugioh.Services.Logic
{
    public class GameLogic
    {
        public void StartGame(Game game)
        {
            game.turn = new Turn();
            game.turn.phase = TurnPhases.MainPhase;
            game.turn.attackPhase = AttackPhases.Other;
            game.turn.playerId = game.player1.id;
            game.gameType = GameTypes.AutoAttack;
        }
    }
}
