using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Classes;

namespace Yugioh.Core.Entities
{
    public class Field
    {
        public Card[] handfield;
        private int handfieldCount;
        public Card[] trapfield;
        private int trapfieldCount;
        public Card[] monsterfield;
        private int monsterfieldCount;

        public Field()
        {
            handfield = new Card[6];
            trapfield = new Card[6];
            monsterfield = new Card[6];
            handfieldCount = 0;
            trapfieldCount = 0;
            monsterfieldCount = 0;
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
            for (int i = index; i < handfield.Length-1; i++)
            {
                handfield[i] = handfield[i + 1];
            }
            handfield[handfieldCount--] = null;
            return c;
        }
    }
}
