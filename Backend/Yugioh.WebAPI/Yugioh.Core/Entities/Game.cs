using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;

namespace Yugioh.Core.Entities
{
    public class Game
    {
        public Guid id { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }

        public Turn turn { get; set; }
    }
}
