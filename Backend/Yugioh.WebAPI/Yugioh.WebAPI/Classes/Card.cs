using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Yugioh.Core.Entities.HealthNs;
using Yugioh.Services.Hubs;

namespace Yugioh.WebAPI.Classes
{
    public abstract class Card 
    {
        protected int playerId { get; set; }
        protected string name { get; set; }
        protected int attack { get; set; }
        protected int defense { get; set; }
        protected string img { get; set; }
        protected bool attacking { get; set; }

        public Card()
        {
            playerId = 0;
            name = "";
            attack = -1;
            defense = 1;
            img = "";
            attacking = false;
        }
        public int GetAtk()
        {
            return attack;
        }

        public int GetDef()
        {
            return defense;
        }

    }
}
