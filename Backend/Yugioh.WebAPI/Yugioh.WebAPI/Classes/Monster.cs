using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.WebAPI.Classes
{
    public abstract class Monster:Card
    {
        public Monster()
        {
            this.attack = 100;
            this.defense = 100;
        }
    }
}
