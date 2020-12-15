using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Enums;

namespace Yugioh.Core.Monsters
{
    public class WindMonster : Classes.Monster
    {
        public WindMonster(int id)
        {
            this.id = Guid.NewGuid();
            this.name = "WindMonster";
            this.playerId = id;
            this.img = "";
            this.attack = 100;
            this.defense = 100;
            this.attacked = false;
            this.type = CardTypes.Monster;
        }
    }
}
