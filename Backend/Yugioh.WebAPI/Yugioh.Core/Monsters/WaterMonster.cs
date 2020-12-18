using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;

namespace Yugioh.Core.Monsters
{
    public class WaterMonster : Classes.Monster
    {
        public WaterMonster(int id)
        {
            this.id = Guid.NewGuid();
            this.name = "WaterMonster";
            this.playerId = id;
            this.img = "";
            this.attacked = false;
            this.type = CardTypes.Monster;
        }
        public override void OnAttack(Game game, Player player, Player enemy)
        {
            player.playerHealth.healthCount += 50;
        }
    }
}
