using System;
using System.Collections.Generic;
using System.Text;

namespace Yugioh.Services.Logic.Attack.State
{
    public class AttackState : IState
    {
        private AttackLogic _attackLogic;
        public AttackState(AttackLogic attackLogic)
        {
            _attackLogic = attackLogic;
        }
        public void Handle(Guid gameId, Guid playerId, Guid cardId)
        {
            _attackLogic.Attack(gameId, playerId, cardId);
        }
    }
}
