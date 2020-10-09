using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.WebAPI.Classes;
using Yugioh.WebAPI.Monsters;

namespace Yugioh.WebAPI.Factories
{
    public class MonsterFactory : AbstractFactory
    {
        public override Card createRandCard()
        {
            Random rand = new Random(0);
            int nr = rand.Next(0, 7);
            switch(nr)
            {
                case 0:
                    return new DarkMonster();
                case 1:
                    return new EarthMonster();
                case 2:
                    return new FireMonster();
                case 3:
                    return new HolyMonster();
                case 4:
                    return new LightMonster();
                case 5:
                    return new WaterMonster();
                case 6:
                    return new WindMonster();
                default:
                    return new DarkMonster();
            }
        }
    }
}
