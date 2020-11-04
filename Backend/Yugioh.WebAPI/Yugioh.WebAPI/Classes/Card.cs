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
        private int playerId { get; set; }
        private string name { get; set; }
        private int attack { get; set; }
        private int defense { get; set; }
        private string img { get; set; }
        private bool attacking { get; set; }
    }
}
