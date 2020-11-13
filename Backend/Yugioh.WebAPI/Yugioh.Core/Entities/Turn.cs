using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Enums;

namespace Yugioh.Core.Entities
{
    public class Turn
    {
        public Guid playerId { get; set; }
        public TurnPhases phase { get; set; }
    }
}
