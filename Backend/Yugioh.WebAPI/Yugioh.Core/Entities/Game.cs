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

        public void DestroyMonster(Guid playerId, int index)
        {
            if (player1.id == playerId)
            {
                field1.removeCardFromMonsterField(index);
            }
            if (player2.id == playerId)
            {
                field2.removeCardFromMonsterField(index);
            }
        }
        public void PlayCardFromHand(string playerId, int index)
        {
            if (player1.id.ToString() == playerId)
            {
                Card c = field1.removeCardFromHandField(index);
                Card[] cs = { c };
                if (c.type == Enums.CardTypes.Monster)
                    field1.insertCardsIntoMonsterField(cs);
                else if (c.type == Enums.CardTypes.Spell)
                    field1.insertCardsIntoSpellField(cs);
                else if (c.type == Enums.CardTypes.Trap)
                    field1.insertCardsIntoSpellField(cs);
            }
            else if (player2.id.ToString() == playerId)
            {
                Card c = field2.removeCardFromHandField(index);
                Card[] cs = { c };
                if (c.type == Enums.CardTypes.Monster)
                    field2.insertCardsIntoMonsterField(cs);
                else if (c.type == Enums.CardTypes.Spell)
                    field2.insertCardsIntoSpellField(cs);
                else if (c.type == Enums.CardTypes.Trap)
                    field2.insertCardsIntoSpellField(cs);
            }
        }
        public void PlayerDrawCardsIntoHand(Guid playerId, int amount)
        {
            if (playerId == player1.id)
            {
                Card[] cards = player1.drawCardsFromDeck(amount);
                field1.insertCardsIntoHandField(cards);
            }
            else if (playerId == player2.id)
            {
                Card[] cards = player2.drawCardsFromDeck(amount);
                field2.insertCardsIntoHandField(cards);
            }
        }
    }
}
