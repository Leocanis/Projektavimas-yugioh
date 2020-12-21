using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Classes;
using Yugioh.Core.Entities;
using Yugioh.Core.Iterator;
using Yugioh.Core.Visitor;
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
                MonsterFieldIterator piter = new MonsterFieldIterator();
                MonsterFieldIterator eiter = new MonsterFieldIterator();
                piter.DictBySWeakest(playermonsterfield.monsterfield, playermonsterfield.monsterfieldCount);
                eiter.DictByStrongest(enemymonsterfield.monsterfield, enemymonsterfield.monsterfieldCount);

                for (int i = 0; i < piter.Count; i++)
                {
                    Monster monster = piter.GetKey(i);
                    if (eiter.Count > 0)
                    {
                        MonsterAttack(game, player, enemy, monster, piter.GetValue(i), eiter.GetValue(0));
                        piter.Remove(piter.Pair(i).Key);
                        eiter.Remove(eiter.Pair(0).Key);
                        i--;
                    }
                    else if (eiter.Count == 0)
                    {
                        PlayerAttack(game, player, enemy, piter.GetKey(i).attack, monster);
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
                MonsterFieldIterator piter = new MonsterFieldIterator();
                MonsterFieldIterator eiter = new MonsterFieldIterator();
                piter.DictBySWeakest(playermonsterfield.monsterfield, playermonsterfield.monsterfieldCount);
                eiter.DictByStrongest(enemymonsterfield.monsterfield, enemymonsterfield.monsterfieldCount);

                for (int i = 0; i < piter.Count; i++)
                {
                    Monster monster = piter.GetKey(i);
                    if (eiter.Count > 0)
                    {
                        MonsterAttack(game, player, enemy, monster, piter.GetValue(i), eiter.GetValue(0));
                        piter.Remove(piter.Pair(i).Key);
                        eiter.Remove(eiter.Pair(0).Key);
                        i--;
                    }
                    else if (eiter.Count == 0)
                    {
                        PlayerAttack(game, player, enemy, piter.GetKey(i).attack, monster);
                    }
                    else
                    {
                        HoldAttack();
                    }
                }
            }
        }

        public void PlayerAttack(Game game, Player player, Player target, int damage, Monster monster)
        {
            monster.OnPlayerAttack(game, player, target);
            target.playerHealth.healthCount -= damage;
        }
        public void MonsterAttack(Game game, Player player, Player enemy, Monster monster, int monsterindex1, int monsterindex2)
        {
            monster.OnAttack(game, player, enemy);
            FieldVisitor.removeCardFromField(monsterindex1, game, player, enemy, game.field1.monsterfield, ref game.field1.monsterfieldCount);
            FieldVisitor.removeCardFromField(monsterindex2, game, enemy, player, game.field2.monsterfield, ref game.field2.monsterfieldCount);
            //game.field1.removeCardFromMonsterField(monsterindex1, game, player, enemy);
            //game.field2.removeCardFromMonsterField(monsterindex2, game, player, enemy);
        }
        /*public void MonsterAttack(Game game, Player player, Player enemy, Monster monster)
        {
            monster.OnAttack(game, player, enemy);
            game.field1.removeCardFromMonsterField(game.field1.monsterfieldCount - 1, game, player, enemy);
            game.field2.removeCardFromMonsterField(game.field2.monsterfieldCount - 1, game, player, enemy);
        }*/
        public void HoldAttack()
        {

        }
    }
}
