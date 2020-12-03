using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Classes;
using Yugioh.Core.Monsters;

namespace Yugioh.Core.Factories
{
    public class MonsterFactory : AbstractFactory
    {
        public MonsterFactory(int id) 
        {
            this.playerID = id;
        }

        public override Card createRandCard(int id)
        {
            Random rand = new Random(id);
            int nr = rand.Next(0, 7);
            switch(nr)
            {
                case 0:
                    return new DarkMonster(playerID);
                case 1:
                    return new EarthMonster(playerID);
                case 2:
                    return new FireMonster(playerID);
                case 3:
                    return new HolyMonster(playerID);
                case 4:
                    return new LightMonster(playerID);
                case 5:
                    return new WaterMonster(playerID);
                case 6:
                    return new WindMonster(playerID);
                default:
                    return new DarkMonster(playerID);
            }
        }

        public override Card createCard(string name)
        {
            switch (name)
            {
                case "Dark":
                    return new DarkMonster(playerID);
                case "Earth":
                    return new EarthMonster(playerID);
                case "Fire":
                    return new FireMonster(playerID);
                case "Holy":
                    return new HolyMonster(playerID);
                case "Light":
                    return new LightMonster(playerID);
                case "Water":
                    return new WaterMonster(playerID);
                case "Wind":
                    return new WindMonster(playerID);
                default:
                    return new DarkMonster(playerID);
            }
        }
    }
}
