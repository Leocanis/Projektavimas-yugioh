﻿using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Classes;

namespace Yugioh.Core.Entities
{
    public class Field
    {
        public Card[] handfield { get; set; }
        public int handfieldCount;
        public Card[] trapfield { get; set; }
        public int trapfieldCount;
        public Monster[] monsterfield { get; set; }
        public int monsterfieldCount;

        public Field()
        {
            handfield = new Card[6];
            trapfield = new Card[6];
            monsterfield = new Monster[6];
            handfieldCount = 0;
            trapfieldCount = 0;
            monsterfieldCount = 0;
        }

        public void insertCardsIntoMonsterField(Monster[] cards, Game game, Player player, Player enemy)
        {
            int n = monsterfieldCount;
            int m = cards.Length;
            if (n + m > 6)
            {
                m = 6 - n;
            }

            for (int i = 0; i < m; i++)
            {
                try
                {
                    //deck.carddeck.Add(cards[i]);
                    monsterfield[monsterfieldCount++] = cards[i];
                    cards[i].OnPlay(game, player, enemy);
                }
                catch
                {

                }
            }
        }

        public void insertCardsIntoSpellField(Card[] cards)
        {
            int n = trapfieldCount;
            int m = cards.Length;
            if (n + m > 6)
            {
                m = 6 - n;
            }

            for (int i = 0; i < m; i++)
            {
                try
                {
                    //deck.carddeck.Add(cards[i]);
                    trapfield[trapfieldCount++] = cards[i];
                }
                catch
                {

                }
            }
        }

        public void insertCardsIntoHandField(Card[] cards)
        {
            int n = handfieldCount;
            int m = cards.Length;
            if (n + m > 6)
            {
                m = 6 - n;
            }

            for (int i = 0; i < m; i++)
            {
                try
                {
                    //deck.carddeck.Add(cards[i]);
                    handfield[handfieldCount++] = cards[i];
                }
                catch
                {

                }
            }
        }

        public Card removeCardFromHandField(int index)
        {
            Card c = handfield[index];
            if(c==null)
            {
                return c;
            }
            for (int i = index; i < handfield.Length-1; i++)
            {
                handfield[i] = handfield[i + 1];
            }
            if (handfieldCount > 0)
            {
                handfield[handfieldCount--] = null;
            }
            return c;
        }

        public Card removeCardFromMonsterField(int index, Game game, Player player, Player enemy)
        {
            Monster c = monsterfield[index];
            if (c == null)
            {
                return c;
            }
            if( player!=null)
            {
                c.OnDeath(game, player, enemy);
            }
            for (int i = index; i < monsterfield.Length - 1; i++)
            {
                monsterfield[i] = monsterfield[i + 1];
            }
            if (monsterfieldCount > 0)
            {
                monsterfield[monsterfieldCount--] = null;
            }
            return c;
        }
    }
}
