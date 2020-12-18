using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Services.Logic.Replay;

namespace Yugioh.Services.Hubs
{
    public class GameHub : Hub
    {
        Originator originator = new Originator();
        public void SendGame(Game game)
        {
            Clients.All.SendAsync(game.id.ToString(), game);
            originator.setState(game);      //saves gamestate
        }
    }
}
