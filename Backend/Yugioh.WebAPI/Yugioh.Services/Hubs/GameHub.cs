using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;

namespace Yugioh.Services.Hubs
{
    public class GameHub : Hub
    {
        public void SendGame(Game game)
        {
            Clients.All.SendAsync(game.id.ToString(), game);
        }
    }
}
