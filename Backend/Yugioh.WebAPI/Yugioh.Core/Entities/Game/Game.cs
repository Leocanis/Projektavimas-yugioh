using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities.PlayerNs;

namespace Yugioh.Core.Entities.Game
{
    public class Game
    {
        public Guid id { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
    }
}
