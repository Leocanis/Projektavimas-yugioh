using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;

namespace Yugioh.Core.Monsters
{
    public class HolyMonster : Classes.Monster
    {
        public HolyMonster(int id)
        {
            this.id = Guid.NewGuid();
            this.name = "HolyMonster";
            this.playerId = id;
            this.img = "";
            this.attacked = false;
            this.type = CardTypes.Monster;
        }
        public override void OnPlay(Game game, Player player, Player enemy)
        {
            player.playerHealth.healthCount += 50;
        }
    }
}
