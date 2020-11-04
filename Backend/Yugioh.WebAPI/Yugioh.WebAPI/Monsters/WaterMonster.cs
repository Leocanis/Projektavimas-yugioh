using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Yugioh.WebAPI.Monsters
{
    public class WaterMonster : Classes.Monster
    {
        public WaterMonster()
        {
            this.name = "WaterMonster";
            this.playerId = 1;
            this.img = "";
            this.attack = 100;
            this.defense = 100;
            this.attacking = false;
        }
    }
}
