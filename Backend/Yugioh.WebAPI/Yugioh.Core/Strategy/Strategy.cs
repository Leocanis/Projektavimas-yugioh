using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Classes;
using Yugioh.Core.Entities;

namespace Yugioh.Core.Strategy
{
    public class Strategy
    {
        public void decideStrategy(Game game, Player player, Player enemy)
        {
            if (game.player1.id == player.id)
            {
                var playermonsterfield = game.field1;
                var enemymonsterfield = game.field2;
                for (int i = playermonsterfield.monsterfieldCount - 1; i >= 0; i--)
                {
                    Monster monster = playermonsterfield.monsterfield[i];
                    if (enemymonsterfield.monsterfieldCount > 0)
                    {
                        MonsterAttack(game, player, enemy, monster);
                    }
                    else if (enemymonsterfield.monsterfieldCount == 0)
                    {
                        PlayerAttack(game, player, enemy, playermonsterfield.monsterfield[i].attack, monster);
                    }
                    else
                    {
                        HoldAttack();
                    }
                }
            }
            if (game.player2.id == player.id)
            {
                var playermonsterfield = game.field2;
                var enemymonsterfield = game.field1;
                for (int i = playermonsterfield.monsterfieldCount - 1; i >= 0; i--)
                {
                    Monster monster = playermonsterfield.monsterfield[i];
                    if (enemymonsterfield.monsterfieldCount > 0)
                    {
                        MonsterAttack(game, player, enemy, monster);
                    }
                    else if (enemymonsterfield.monsterfieldCount == 0)
                    {
                        PlayerAttack(game, player, enemy, playermonsterfield.monsterfield[i].attack, monster);
                    }
                    else
                    {
                        HoldAttack();
                    }
                }
            }
        }
        /*public void decideStrategy(Game game, Guid playerid)
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
        }*/
        public void PlayerAttack(Game game, Player player, Player target, int damage, Monster monster)
        {
            /*if(game.player1.id == targetPlayer)
            {
                game.player1.playerHealth.healthCount -= damage;
            }
            else if (game.player2.id == targetPlayer)
            {
                game.player2.playerHealth.healthCount -= damage;
            }*/
            monster.OnPlayerAttack(game, player, target);
            target.playerHealth.healthCount -= damage;
        }
        public void MonsterAttack(Game game, Player player, Player enemy, Monster monster)
        {
            monster.OnAttack(game, player, enemy);
            game.field1.removeCardFromMonsterField(game.field1.monsterfieldCount - 1, game, player, enemy);
            game.field2.removeCardFromMonsterField(game.field2.monsterfieldCount - 1, game, player, enemy);
        }
        public void HoldAttack()
        {

        }
    }
}
