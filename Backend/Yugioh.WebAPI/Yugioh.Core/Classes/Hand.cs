using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.Core.Classes
{
    public class Hand
    {
        public ArrayList hand;
        protected int playerID { get; set; }

        public Hand(int playerid)
        {
            hand = new ArrayList();
            playerID = playerid;
        }
        public void Draw(Deck deck, int j)
        {
            for (int i = 0; i < j; i++)
            {
                var card = deck.carddeck[deck.carddeck.Count - 1];
                hand.Add(card);
                deck.carddeck.RemoveAt(deck.carddeck.Count - 1);
            }
        }

        public void Discard(int j)
        {
            hand.RemoveAt(j);
        }

    }
}
