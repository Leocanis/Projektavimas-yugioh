using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.Core.Monsters
{
    public class LightMonster : Classes.Monster
    {
        public LightMonster(int id)
        {
            this.name = "LightMonster";
            this.playerId = id;
            this.img = "";
            this.attack = 100;
            this.defense = 100;
            this.attacking = false;
        }
    }
}
