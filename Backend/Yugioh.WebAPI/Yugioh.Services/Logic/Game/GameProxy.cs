using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Services.Singleton;

namespace Yugioh.Services.Logic
{
    public class GameProxy : IGame
    {
        IGame _realSubject;
        public GameProxy() {
            _realSubject = new GameReal();
        }
        public Game GetGame(Guid gameId)
        {
            Game game = null;

            if(GamesSingleton.GetInstance().games.Where(p=>p.id == gameId).FirstOrDefault().player2 != null)
            {
                game = _realSubject.GetGame(gameId);
            }
            else
            {
                game = new Game(GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault());
            }

            return game;
        }
    }
}
