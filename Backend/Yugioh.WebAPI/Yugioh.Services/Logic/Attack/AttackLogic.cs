using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yugioh.Core.Enums;
using Yugioh.Services.Hubs;
using Yugioh.Services.Singleton;

namespace Yugioh.Services.Logic.Attack
{
    public class AttackLogic
    {
        private GameHub _gameHub;

        public AttackLogic(GameHub gameHub)
        {
            _gameHub = gameHub;
        }

        public void Attack(Guid gameId, Guid playerId, Guid cardId)
        {
            var game = GamesSingleton.GetInstance().games.Where(p =>p.id == gameId).FirstOrDefault();
            if (game.player1.id == playerId)
            {
                var card = game.field1.monsterfield.Where(p => p != null && p.id == cardId).FirstOrDefault();
                card.attackPhase = CardAttackPhase.Attacking;
                
            }
            else if (game.player2.id == playerId)
            {
                var card = game.field2.monsterfield.Where(p => p != null && p.id == cardId).FirstOrDefault();
                card.attackPhase = CardAttackPhase.Attacking;
            }
            game.turn.attackPhase = AttackPhases.Targeting;
            _gameHub.SendGame(game);
        }

        public void Target(Guid gameId, Guid playerId, Guid cardId)
        {
            var game = GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault();
            if (game.player1.id == playerId)
            {
                var attackingCard = game.field1.monsterfield.Where(p => p != null && p.attackPhase == CardAttackPhase.Attacking).FirstOrDefault();
                var targetCard = game.field2.monsterfield.Where(p => p != null && p.id == cardId).FirstOrDefault();

                if(attackingCard.attack > targetCard.defense)
                {
                    for(int i = 0; i< game.field2.monsterfield.Length; i++)
                    {
                        if(game.field2.monsterfield[i] != null && targetCard.id == game.field2.monsterfield[i].id)
                        {
                            game.field2.monsterfield[i] = null;
                        }
                    }
                    attackingCard.attackPhase = CardAttackPhase.Attacked;
                    attackingCard.attacked = true;
                }
                else if(attackingCard.attack < targetCard.defense)
                {
                    for (int i = 0; i < game.field1.monsterfield.Length; i++)
                    {
                        if (game.field1.monsterfield[i] != null && attackingCard.id == game.field1.monsterfield[i].id)
                        {
                            game.field1.monsterfield[i] = null;
                        }
                    }
                }
                else if(attackingCard.attack == targetCard.defense)
                {
                    for (int i = 0; i < game.field2.monsterfield.Length; i++)
                    {
                        if (game.field2.monsterfield[i] != null && targetCard.id == game.field2.monsterfield[i].id)
                        {
                            game.field2.monsterfield[i] = null;
                        }
                    }
                    for (int i = 0; i < game.field1.monsterfield.Length; i++)
                    {
                        if (game.field1.monsterfield[i] != null && attackingCard.id == game.field1.monsterfield[i].id)
                        {
                            game.field1.monsterfield[i] = null;
                        }
                    }
                }

            }
            else if (game.player2.id == playerId)
            {
                var attackingCard = game.field2.monsterfield.Where(p => p != null && p.attackPhase == CardAttackPhase.Attacking).FirstOrDefault();
                var targetCard = game.field1.monsterfield.Where(p => p != null && p.id == cardId).FirstOrDefault();

                if (attackingCard.attack > targetCard.defense)
                {
                    for (int i = 0; i < game.field1.monsterfield.Length; i++)
                    {
                        if (game.field1.monsterfield[i] != null && targetCard.id == game.field1.monsterfield[i].id)
                        {
                            game.field1.monsterfield[i] = null;
                        }
                    }
                    attackingCard.attackPhase = CardAttackPhase.Attacked;
                    attackingCard.attacked = true;
                }
                else if (attackingCard.attack < targetCard.defense)
                {
                    for (int i = 0; i < game.field2.monsterfield.Length; i++)
                    {
                        if (game.field2.monsterfield[i] != null && attackingCard.id == game.field2.monsterfield[i].id)
                        {
                            game.field2.monsterfield[i] = null;
                        }
                    }
                }
                else if (attackingCard.attack == targetCard.defense)
                {
                    for (int i = 0; i < game.field2.monsterfield.Length; i++)
                    {
                        if (game.field2.monsterfield[i] != null && targetCard.id == game.field2.monsterfield[i].id)
                        {
                            game.field2.monsterfield[i] = null;
                        }
                    }
                    for (int i = 0; i < game.field1.monsterfield.Length; i++)
                    {
                        if (game.field1.monsterfield[i] != null && attackingCard.id == game.field1.monsterfield[i].id)
                        {
                            game.field1.monsterfield[i] = null;
                        }
                    }
                }
            }
            game.turn.attackPhase = AttackPhases.Attacking;
            _gameHub.SendGame(game);
        }

        public void Cancel(Guid gameId, Guid playerId, Guid cardId)
        {
            var game = GamesSingleton.GetInstance().games.Where(p => p.id == gameId).FirstOrDefault();
            if (game.player1.id == playerId)
            {
                var card = game.field1.monsterfield.Where(p => p != null && p.id == cardId).FirstOrDefault();
                card.attackPhase = CardAttackPhase.Waiting;

            }
            else if (game.player2.id == playerId)
            {
                var card = game.field2.monsterfield.Where(p => p != null && p.id == cardId).FirstOrDefault();
                card.attackPhase = CardAttackPhase.Waiting;
            }
            game.turn.attackPhase = AttackPhases.Attacking;
            _gameHub.SendGame(game);
        }
    }
}
