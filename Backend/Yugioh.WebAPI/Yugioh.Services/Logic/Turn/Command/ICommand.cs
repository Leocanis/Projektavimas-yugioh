using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;

namespace Yugioh.Services.Logic.Turn.Command
{
    public abstract class ICommand
    {
        public abstract void ChangeTurnState(Game game, Guid playerId);
        public abstract void Forward(Game game, Guid playerId);
        public abstract void Back(Game game, Guid playerId);
    }
}
