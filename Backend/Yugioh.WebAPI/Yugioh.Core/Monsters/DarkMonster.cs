using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Classes;
using Yugioh.Core.Enums;

namespace Yugioh.Core.Monsters
{
    public class DarkMonster: Classes.Monster
    {
        public DarkMonster(int playerid)
        {
            this.id = Guid.NewGuid();
            this.name = "DarkMonster";
            this.playerId = playerid;
            this.img = "";
            this.attack = 100;
            this.defense = 100;
            this.attacked = false;
            this.type = CardTypes.Monster;
        }
    }
}
