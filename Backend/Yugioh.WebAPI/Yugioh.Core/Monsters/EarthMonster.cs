using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Entities;
using Yugioh.Core.Enums;

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
            //this.attack = 100;
            //this.defense = 100;
            this.attacked = false;
            this.type = CardTypes.Monster;
        }
        public override void OnHold(Game game, Player player, Player enemy)
        {
            player.playerHealth.healthCount += 100;
        }
    }
}
