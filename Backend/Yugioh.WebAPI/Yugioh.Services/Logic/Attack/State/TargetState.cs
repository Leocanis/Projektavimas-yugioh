using System;
using System.Collections.Generic;
using System.Text;

namespace Yugioh.Services.Logic.Attack.State
{
    public class TargetState : IState
    {
        private AttackLogic _attackLogic;
        public TargetState(AttackLogic attackLogic)
        {
            _attackLogic = attackLogic;
        }
        public void Handle(Guid gameId, Guid playerId, Guid cardId)
        {
            _attackLogic.Target(gameId, playerId, cardId);
        }
    }
}
