using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Classes;
using Yugioh.Core.Spells;

namespace Yugioh.Core.Factories
{
    public class SpellFactory : AbstractFactory
    {
        public override Card createRandCard(int id)
        {
            Random rand = new Random(0);
            int nr = rand.Next(0, 6);
            switch (nr)
            {
                default:
                    return new NormalSpell(playerID);
                case 0:
                    return new ConsistentSpell(playerID);
                case 1:
                    return new CounterSpell(playerID);
                case 2:
                    return new NormalSpell(playerID);
                //return new EquipSpell();
                case 3:
                    return new FieldSpell();
                case 4:
                    return new NormalSpell(playerID);
                case 5:
                    return new RitualSpell(playerID);
            }
            
        }
        public override Card createCard(string name)
        {
            switch (name)
            {
                default:
                    return new NormalSpell(playerID);
                case "Consistent":
                    return new ConsistentSpell(playerID);
                case " Counter":
                    return new CounterSpell(playerID);
                case "Field":
                    return new FieldSpell();
                case "Normal":
                    return new NormalSpell(playerID);
                case "Ritual":
                    return new RitualSpell(playerID);
            }
        }
    }
}
