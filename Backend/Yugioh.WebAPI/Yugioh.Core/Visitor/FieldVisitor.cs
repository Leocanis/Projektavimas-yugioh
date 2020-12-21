using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Classes;
using Yugioh.Core.Entities;
namespace Yugioh.Core.Visitor
{
    public class FieldVisitor
    {
        public static void insertCardsIntoField(Card[] cards, Game game, Player player, Player enemy,  Card[] field, ref int fieldCount)
        {
            int n = fieldCount;
            int m = cards.Length;
            if (n + m > field.Length)
            {
                m = field.Length - n;
            }

            for (int i = 0; i < m; i++)
            {
                try
                {
                    //deck.carddeck.Add(cards[i]);
                    field[fieldCount++] = cards[i];
                    if(player != null)
                    {
                        cards[i].OnPlay(game, player, enemy);
                    }
                }
                catch
                {

                }
            }
        }

        public static Card removeCardFromField(int index, Game game, Player player, Player enemy, Card[] field, ref int fieldCount)
        {
            Card c = field[index];
            if (c == null)
            {
                return c;
            }
            if(game != null && player != null && enemy != null)
            {
                c.OnDeath(game, player, enemy);
            }
            for (int i = index; i < field.Length - 1; i++)
            {
                field[i] = field[i + 1];
            }
            if (fieldCount > 0)
            {
                field[fieldCount--] = null;
            }
            // cleanup for accidental overspill
            for (int i = fieldCount; i < field.Length; i++)
            {
                field[i] = null;
            }
            return c;
        }
    }
}
