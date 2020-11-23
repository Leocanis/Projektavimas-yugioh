using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Classes;
using Yugioh.Core.Traps;

namespace Yugioh.Core.Factories
{
    public class TrapFactory : AbstractFactory
    {
        public override Card createRandCard(int id)
        {
            Random rand = new Random(0);
            int nr = rand.Next(0, 5);
            switch (nr)
            {
                default:
                    return new NormalTrap();
                case 0:
                    return new ConsistentTrap();
                case 1:
                    return new CounterTrap();
                case 2:
                    return new EnchantingTrap();
                case 3:
                    return new FieldTrap();
                case 4:
                    return new NormalTrap();
            }
        }
        public override Card createCard(string name)
        {
            switch (name)
            {
                default:
                    return new NormalTrap();
                case "Consistent":
                    return new ConsistentTrap();
                case "Counter":
                    return new CounterTrap();
                case "Enchanting":
                    return new EnchantingTrap();
                case "Field":
                    return new FieldTrap();
                case "Normal":
                    return new NormalTrap();
            }
        }
    }
}
