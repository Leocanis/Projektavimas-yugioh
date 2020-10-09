using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.WebAPI.Classes;

namespace Yugioh.WebAPI.Factories
{
    public abstract class AbstractFactory
    {
        //public abstract Monster createRandMonster();
        //public abstract Spell createRandSpell();
        //public abstract Trap createRandTrap();
        public abstract Card createRandCard();
    }
}
