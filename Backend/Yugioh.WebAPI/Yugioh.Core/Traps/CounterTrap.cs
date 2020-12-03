using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.Core.Traps
{
    public class CounterTrap : Classes.Trap
    {
        public CounterTrap(int playerid)
        {
            this.name = "CounterTrap";
            this.playerId = playerid;
            this.img = "";
            this.attack = -1;
            this.defense = 100;
            this.attacking = false;
        }
    }
}
