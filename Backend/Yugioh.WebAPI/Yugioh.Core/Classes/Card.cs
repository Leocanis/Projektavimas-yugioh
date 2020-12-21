using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Yugioh.Core.Enums;
using Yugioh.Core.Entities;

namespace Yugioh.Core.Classes
{
    public abstract class Card 
    {
        public Guid id { get; set; }
        public int playerId { get; set; }
        public string name { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public string img { get; set; }
        public string imgBytes { get; set; }
        public bool attacked { get; set; }
        public CardTypes type { get; set; }
        public CardAttackPhase attackPhase { get; set; }
        public Card()
        {
            playerId = 0;
            name = "";
            attack = -1;
            defense = 1;
            img = "";
            attacked = false;

        }
        public int GetAtk()
        {
            return attack;
        }

        public int GetDef()
        {
            return defense;
        }
        public virtual void OnPlay(Entities.Game game, Player player, Player enemy) { }
        public virtual void OnDeath(Entities.Game game, Player player, Player enemy) { }
    }
}
