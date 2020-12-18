using System;
using System.Collections.Generic;
using System.Text;

namespace Yugioh.Services.Logic.Attack.State
{
    public class CancelState : IState
    {
        private AttackLogic _attackLogic;
        public CancelState(AttackLogic attackLogic)
        {
            _attackLogic = attackLogic;
        }
        public void Handle(Guid gameId, Guid playerId, Guid cardId)
        {
            _attackLogic.Target(gameId, playerId, cardId);
        }
    }
}
