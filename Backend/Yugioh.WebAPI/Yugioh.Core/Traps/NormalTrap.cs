using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.Core.Traps
{
    public class NormalTrap : Classes.Trap
    {
        public NormalTrap(int playerid)
        {
            this.name = "NormalTrap";
            this.playerId = playerid;
            this.img = "";
            this.attack = -1;
            this.defense = 100;
            this.attacking = false;
        }
    }
}
