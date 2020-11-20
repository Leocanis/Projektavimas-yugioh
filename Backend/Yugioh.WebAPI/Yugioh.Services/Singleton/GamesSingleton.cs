using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;

namespace Yugioh.Services.Singleton
{
    public class GamesSingleton
    {
        private static GamesSingleton instance = new GamesSingleton();

        private GamesSingleton()
        {
            games = new List<Game>();
        }

        public static GamesSingleton GetInstance()
        {
            return instance;
        }

        public List<Game> games;
    }
}
