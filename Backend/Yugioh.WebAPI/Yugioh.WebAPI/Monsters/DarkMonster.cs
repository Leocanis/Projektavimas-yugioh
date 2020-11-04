using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.WebAPI.Classes;

namespace Yugioh.WebAPI.Monsters
{
    public class DarkMonster: Classes.Monster
    {
        public DarkMonster()
        {
            this.name = "DarkMonster";
            this.playerId = 1;
            this.img = "";
            this.attack = 100;
            this.defense = 100;
            this.attacking = false;
        }
    }
}
