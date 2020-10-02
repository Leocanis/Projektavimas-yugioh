using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities.HealthNs;

namespace Yugioh.Core.Entities.PlayerNs
{
    public class Player
    {
        public int Id { get; set; }
        public Health PlayerHealth { get; set; }
    }
}
