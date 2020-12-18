using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;

namespace Yugioh.Core.Monsters
{
    public class WindMonster : Classes.Monster
    {
        public WindMonster(int id)
        {
            this.id = Guid.NewGuid();
            this.name = "WindMonster";
            this.playerId = id;
            this.img = "";
            this.attacked = false;
            this.type = CardTypes.Monster;
        }
        public override void OnAttack(Game game, Player player, Player enemy)
        {
            enemy.playerHealth.healthCount -= 50;
        }
    }
}
