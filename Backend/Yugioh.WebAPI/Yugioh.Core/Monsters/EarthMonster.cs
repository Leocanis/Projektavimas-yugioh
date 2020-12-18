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
    public class EarthMonster : Classes.Monster
    {
        public EarthMonster(int id)
        {
            this.id = Guid.NewGuid();
            this.name = "EarthMonster";
            this.playerId = id;
            this.img = "";
            this.imgBytes = ImageFactory.GetImage("Assets/CardImages/celtic_guardian.jpg");
            this.attacked = false;
            this.type = CardTypes.Monster;
        }
        public override void OnHold(Game game, Player player, Player enemy)
        {
            player.playerHealth.healthCount += 100;
        }
    }
}
