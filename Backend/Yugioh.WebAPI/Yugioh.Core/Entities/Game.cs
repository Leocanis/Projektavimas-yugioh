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

        public void DestroyMonster(Game game, Guid playerId, Guid enemyid, int index)
        {
            if (player1.id == playerId)
            {
                field1.removeCardFromMonsterField(index, game, player1, player2);
            }
            if (player2.id == playerId)
            {
                field2.removeCardFromMonsterField(index, game, player2, player1);
            }
        }
        public void PlayCardFromHand(string playerId, int index)
        {
            if (player1.id.ToString() == playerId)
            {
                Card c = field1.removeCardFromHandField(index);
                if (c.type == Enums.CardTypes.Monster)
                {
                    Monster monster = (Monster)c;
                    Monster[] cs = { monster };
                    field1.insertCardsIntoMonsterField(cs, this, player1, player2);
                }
                    
                else if (c.type == Enums.CardTypes.Spell)
                {
                    Spell spell = (Spell)c;
                    Spell[] cs = { spell };
                    field1.insertCardsIntoSpellField(cs);
                }
                else if (c.type == Enums.CardTypes.Trap)
                {
                    Trap trap = (Trap)c;
                    Trap[] cs = { trap };
                    field1.insertCardsIntoSpellField(cs);
                }
            }
            if (player2.id.ToString() == playerId)
            {
                Card c = field2.removeCardFromHandField(index);
                if (c.type == Enums.CardTypes.Monster)
                {
                    Monster monster = (Monster)c;
                    Monster[] cs = { monster };
                    field2.insertCardsIntoMonsterField(cs, this, player2, player1);
                }

                else if (c.type == Enums.CardTypes.Spell)
                {
                    Spell spell = (Spell)c;
                    Spell[] cs = { spell };
                    field2.insertCardsIntoSpellField(cs);
                }
                else if (c.type == Enums.CardTypes.Trap)
                {
                    Trap trap = (Trap)c;
                    Trap[] cs = { trap };
                    field2.insertCardsIntoSpellField(cs);
                }
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
