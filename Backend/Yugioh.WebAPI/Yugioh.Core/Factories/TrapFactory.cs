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
        public TrapFactory(int id)
        {
            this.playerID = id;
        }
        public override Card createRandCard(int id)
        {
            Random rand = new Random(0);
            int nr = rand.Next(0, 5);
            switch (nr)
            {
                default:
                    return new NormalTrap(playerID);
                case 0:
                    return new ConsistentTrap(playerID);
                case 1:
                    return new CounterTrap(playerID);
                case 2:
                    return new EnchantingTrap(playerID);
                case 3:
                    return new FieldTrap(playerID);
                case 4:
                    return new NormalTrap(playerID);
            }
        }
        public override Card createCard(string name)
        {
            switch (name)
            {
                default:
                    return new NormalTrap(playerID);
                case "Consistent":
                    return new ConsistentTrap(playerID);
                case "Counter":
                    return new CounterTrap(playerID);
                case "Enchanting":
                    return new EnchantingTrap(playerID);
                case "Field":
                    return new FieldTrap(playerID);
                case "Normal":
                    return new NormalTrap(playerID);
            }
        }
    }
}
