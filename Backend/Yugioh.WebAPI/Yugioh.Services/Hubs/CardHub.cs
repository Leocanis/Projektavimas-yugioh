using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using Yugioh.Core.Entities;
using Yugioh.Core.Classes;

namespace Yugioh.Services.Hubs
{
    public class CardHub : Hub
    {
        public void SendCard(Card card, int playerId)
        {
            //Clients.All.SendAsync(game.id.ToString(), game);
            //var player = StaticClass.players.Where(p => p.Id != playerId).FirstOrDefault();
            //player.PlayerHealth.HealthCount -= damage;
            //_healthHubContext.Clients.All.SendAsync("SendHealth",
            //    new
            //    {
            //        playerId = player.Id,
            //        health = player.PlayerHealth
            //    });
            Clients.All.SendAsync(card.ToString(), new { playerId = playerId});
        }
    }
}
