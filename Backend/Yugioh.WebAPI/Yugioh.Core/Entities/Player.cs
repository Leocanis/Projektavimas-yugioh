using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Classes;
namespace Yugioh.Core.Entities
{
    public class Player
    {
        public Guid id { get; set; }
        public string playerName { get; set; }
        public string decktype { get; set; }
        public Deck deck { get; set; }
        public Hand hand { get; set; }
        public Health playerHealth { get; set; }

        public Player()
        {
            this.playerHealth = new Health(8000);
        }
        public void createDeck(string decktype, int playerid)
        {
            deck = new Deck(playerid);
            deck.decktype = decktype;
            deck.generateDeck(decktype);
        }
        public void getHand(int playerid)
        {
            hand.Draw(deck, 5);
        }
    }
}
