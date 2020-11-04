using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.WebAPI.Classes;
using Yugioh.WebAPI.Spells;

namespace Yugioh.WebAPI.Factories
{
    public class SpellFactory : AbstractFactory
    {
        public override Card createRandCard(int id)
        {
            Random rand = new Random(0);
            int nr = rand.Next(0, 6);
            switch(nr)
            {
                default:
                    return new NormalSpell();
                case 0:
                    return new ConsistentSpell();
                case 1:
                    return new CounterSpell();
                case 2:
                    return new EnchantingSpell();
                case 3:
                    return new FieldSpell();
                case 4:
                    return new NormalSpell();
                case 5:
                    return new RitualSpell();
            }
        }
    }
}
