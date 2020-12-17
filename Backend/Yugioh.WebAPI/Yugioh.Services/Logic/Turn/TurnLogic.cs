using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;
using Yugioh.Services.Hubs;
using Yugioh.Services.Logic.Command;
using Yugioh.Services.Singleton;

namespace Yugioh.Services.Logic
{
    public class TurnLogic
    {
        private GameHub _gameHub;

        public TurnLogic(GameHub gameHub)
        {
            _gameHub = gameHub;
        }
        public void UpdateView(Game game)
        {
            _gameHub.SendGame(game);
        }
        public void Attack(Guid gameId, Guid playerId)
        {
            ICommand command = new AttackPhaseCommand(_gameHub);
            command.ChangeTurnState(GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault(), playerId);
        }

        public void Second(Guid gameId, Guid playerId)
        {
            ICommand command = new SecondPhaseCommand(_gameHub);
            command.ChangeTurnState(GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault(), playerId);
        }

        public void EndTurn(Guid gameId, Guid playerId)
        {
            ICommand command = new EndTurnPhaseCommand(_gameHub);
            command.ChangeTurnState(GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault(), playerId);
        }
    }
}
