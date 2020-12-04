using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;

namespace Yugioh.Core.Strategy
{
    public class Strategy
    {
        public void decideStrategy(Game game, Guid playerid, int monsterindex)
        {

        }
        public void decideStrategy(Game game, Guid playerid)
        {
            if (game.player1.id == playerid)
            {

                for (int i = game.field1.monsterfieldCount - 1; i >= 0; i--)
                {
                    if (game.field2.monsterfieldCount > 0)
                    {
                        MonsterAttack(game, playerid);
                    }
                    else if (game.field2.monsterfieldCount == 0)
                    {
                        PlayerAttack(game, game.player2.id, game.field1.monsterfield[i].attack);
                    }
                    else
                    {
                        HoldAttack();
                    }
                }

            }

            if (game.player2.id == playerid)
            {

                for (int i = game.field2.monsterfieldCount - 1; i >= 0; i--)
                {
                    if (game.field1.monsterfieldCount > 0)
                    {
                        MonsterAttack(game, playerid);
                    }
                    else if (game.field1.monsterfieldCount == 0)
                    {
                        PlayerAttack(game, game.player1.id, game.field2.monsterfield[i].attack);
                    }
                    else
                    {
                        HoldAttack();
                    }


                }
            }
        }
        public void PlayerAttack(Game game, Guid targetPlayer, int damage)
        {
            if(game.player1.id == targetPlayer)
            {
                game.player1.playerHealth.healthCount -= damage;
            }
            else if (game.player2.id == targetPlayer)
            {
                game.player2.playerHealth.healthCount -= damage;
            }
        }
        public void MonsterAttack(Game game, Guid playerId)
        {
            game.field1.removeCardFromMonsterField(game.field1.monsterfieldCount - 1);
            game.field2.removeCardFromMonsterField(game.field2.monsterfieldCount - 1);
        }
        public void HoldAttack()
        {

        }
    }
}
