using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.Core.Monsters
{
    public class FireMonster : Classes.Monster
    {
        public FireMonster()
        {
            this.name = "FireMonster";
            this.playerId = 1;
            this.img = "";
            this.attack = 100;
            this.defense = 100;
            this.attacking = false;
        }
    }
}
