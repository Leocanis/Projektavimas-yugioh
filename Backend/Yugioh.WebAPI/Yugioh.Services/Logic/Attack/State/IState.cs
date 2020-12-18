using System;
using System.Collections.Generic;
using System.Text;

namespace Yugioh.Services.Logic.Attack.State
{
    public interface IState
    {
        void Handle(Guid gameId, Guid playerId, Guid cardId);
    }
}
