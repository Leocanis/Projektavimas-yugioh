using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities.HealthNs;

namespace Yugioh.Core.Entities.PlayerNs
{
    public class Player
    {
        public Guid id { get; set; }
        public string playerName { get; set; }
        public Health playerHealth { get; set; }

        public Player()
        {
            this.playerHealth = new Health(8000);
        }
    }
}
