using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Entities.HealthNs;
using Yugioh.Core.Entities.PlayerNs;

namespace Yugioh.WebAPI
{
    public static class StaticClass
    {
        private static bool _init = false;
        public static Player[] players = new Player[2];

        public static void Init()
        {
            if (!_init)
            {
                players = new Player[2] {
                new Player() {
                    Id = 1,
                    PlayerHealth = new Health{ HealthCount = 8000}
                },
                new Player(){
                    Id = 2,
                    PlayerHealth = new Health{ HealthCount = 8000}
                }};
            }
        }
    }
}