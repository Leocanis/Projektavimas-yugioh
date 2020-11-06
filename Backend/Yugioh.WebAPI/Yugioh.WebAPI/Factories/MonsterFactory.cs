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
        public override Card createRandCard(int id)
        {
            Random rand = new Random(id);
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

        public override Card createCard(string name)
        {
            switch (name)
            {
                case "Dark":
                    return new DarkMonster();
                case "Earth":
                    return new EarthMonster();
                case "Fire":
                    return new FireMonster();
                case "Holy":
                    return new HolyMonster();
                case "Light":
                    return new LightMonster();
                case "Water":
                    return new WaterMonster();
                case "Wind":
                    return new WindMonster();
                default:
                    return new DarkMonster();
            }
        }
    }
}
