using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Services.Singleton;

namespace Yugioh.Services.Logic
{
    public class GameReal : IGame
    {
        public Game GetGame(Guid gameId)
        {
            return GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault();
        }
    }
}
