using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;

namespace Yugioh.Services.Logic
{
    public interface IGameLogic
    {
        Game GetGame(Guid gameId);
    }
}
