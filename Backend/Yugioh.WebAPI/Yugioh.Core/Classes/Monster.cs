using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Entities;
namespace Yugioh.Core.Classes
{
    public class Monster:Card
    {
        public Monster()
        {
            Random r = new Random();
            this.attack = 50*r.Next(2,6);
            this.defense = 100;
        }
        public virtual void OnDeath(Entities.Game game, Player player, Player enemy) { }
        public virtual void OnPlay(Entities.Game game, Player player, Player enemy) { }
        public virtual void OnAttack(Entities.Game game, Player player, Player enemy) { }
        public virtual void OnHold(Entities.Game game, Player player, Player enemy) { }
        public virtual void OnPlayerAttack(Entities.Game game, Player player, Player enemy) { }
    }
}
