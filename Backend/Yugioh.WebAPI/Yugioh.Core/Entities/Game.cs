using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Core.Classes;
namespace Yugioh.Core.Entities
{
    public class Game
    {
        public Guid id { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Field field1 { get; set; }
        public Field field2 { get; set; }
        public Turn turn { get; set; }
        public string message { get; set; }

        public void PlayerDrawCardsIntoHand(int playerId, int amount)
        {
            if(playerId == 1)
            {
                Card[] cards = player1.drawCardsFromDeck(amount);
                field1.insertCardsIntoHandField(cards);
            }
            else if(playerId ==2)
            {
                Card[] cards = player2.drawCardsFromDeck(amount);
                field2.insertCardsIntoHandField(cards);
            }
        }
    }
}
