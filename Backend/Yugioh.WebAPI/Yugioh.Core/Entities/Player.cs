using System;
using System.Collections.Generic;
using System.Text;

namespace Yugioh.Core.Entities
{
    public class Player
    {
        public Guid id { get; set; }
        public string playerName { get; set; }
        public string decktype { get; set; }
        
        public Health playerHealth { get; set; }

        public Player()
        {
            this.playerHealth = new Health(8000);
        }
    }
}
