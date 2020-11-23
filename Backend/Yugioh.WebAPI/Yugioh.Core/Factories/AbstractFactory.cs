using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Classes;

namespace Yugioh.Core.Factories
{
    public abstract class AbstractFactory
    {
        protected int playerID { get; set; }
        public void SetPlayerID(int playerid)
        {
            playerID = playerid;
        }
        //public abstract Monster createRandMonster();
        //public abstract Spell createRandSpell();
        //public abstract Trap createRandTrap();
        public abstract Card createRandCard(int id);
        public abstract Card createCard(string name);
    }
}
