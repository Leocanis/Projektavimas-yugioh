using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.Core.Spells
{
    public class ConsistentSpell:Classes.Spell
    {
        public ConsistentSpell(int playerid)
        {
            this.name = "ConsistentSpell";
            this.playerId = playerid;
            this.img = "";
            this.attack = -1;
            this.defense = 100;
            this.attacking = false;
        }
    }
}
