using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yugioh.Services.Hubs;
using Yugioh.Services.Singleton;

namespace Yugioh.Services.Logic.Attack
{
    public class AttackLogic
    {
        private GameHub _gameHub;

        public AttackLogic(GameHub gameHub)
        {
            _gameHub = gameHub;
        }

        public void Attack(Guid gameId, Guid playerId, Guid cardId)
        {
            var game = GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault();

            _gameHub.SendGame(game);
        }

        public void Target(Guid gameId, Guid playerId, Guid cardId)
        {
            var game = GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault();
            _gameHub.SendGame(game);
        }

        public void Cancel(Guid gameId, Guid playerId, Guid cardId)
        {
            var game = GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault();

            _gameHub.SendGame(game);
        }
    }
}
