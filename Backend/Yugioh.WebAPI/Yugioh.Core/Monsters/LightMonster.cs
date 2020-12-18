using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;
using Yugioh.Core.Logic.Flyweight;

namespace Yugioh.Core.Monsters
{
    public class LightMonster : Classes.Monster
    {
        public LightMonster(int id)
        {
            this.id = Guid.NewGuid();
            this.name = "LightMonster";
            this.playerId = id;
            this.img = "";
            this.imgBytes = ImageFactory.GetImage("Assets/CardImages/blue_eyes_white_dragon.jpg");
            this.attacked = false;
            this.type = CardTypes.Monster;
        }
        public override void OnDeath(Game game, Player player, Player enemy)
        {
            player.playerHealth.healthCount += 50;
        }
    }
}
