using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Entities.Game;
using Yugioh.Core.Entities.HealthNs;
using Yugioh.Core.Entities.PlayerNs;

namespace Yugioh.WebAPI
{
    public static class StaticClass
    {
        public static List<Game> games = new List<Game>();
    }
}