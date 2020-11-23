using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Yugioh.Core.Monsters
{
    public class WaterMonster : Classes.Monster
    {
        public WaterMonster(int id)
        {
            this.name = "WaterMonster";
            this.playerId = id;
            this.img = "";
            this.attack = 100;
            this.defense = 100;
            this.attacking = false;
        }
    }
}
