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
    public class FireMonster : Classes.Monster
    {
        public FireMonster(int id)
        {
            this.id = Guid.NewGuid();
            this.name = "FireMonster";
            this.playerId = id;
            this.img = "";
            this.imgBytes = ImageFactory.GetImage("Assets/CardImages/vorse_raider.jpg");
            this.attacked = false;
            this.type = CardTypes.Monster;
        }
        public override void OnPlayerAttack(Game game, Player player, Player enemy)
        {
            enemy.playerHealth.healthCount -= 200;
        }
    }
}
