using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Enums;

namespace Yugioh.Core.Spells
{
    public class NormalSpell : Classes.Spell
    {
        public NormalSpell(int playerid)
        {
            this.id = Guid.NewGuid();
            this.name = "ConsistentSpell";
            this.playerId = playerid;
            this.img = "";
            this.attack = -1;
            this.defense = 100;
            this.attacked = false;
            this.type = CardTypes.Spell;
        }
    }
}
