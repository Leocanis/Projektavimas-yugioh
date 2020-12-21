using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;
using Yugioh.Core.Classes;
using Yugioh.Core.Enums;
using Yugioh.Core.Visitor;

namespace Yugioh.Core.Entities
{
    public class Game
    {
        public Game()
        {

        }
        public Game(Game game)
        {
            this.id = game.id;
            this.player1 = game.player1;
            this.gameType = game.gameType;
        }

        public Guid id { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Field field1 { get; set; }
        public Field field2 { get; set; }
        public Turn turn { get; set; }
        public string message { get; set; }
        public GameTypes gameType { get; set; }

        public void DestroyMonster(Game game, Guid playerId, Guid enemyid, int index)
        {
            if (player1.id == playerId)
            {
                //field1.removeCardFromMonsterField(index, game, player1, player2);
                FieldVisitor.removeCardFromField(index, game, player1, player2, field1.monsterfield, ref field1.monsterfieldCount);
            }
            if (player2.id == playerId)
            {
                //field2.removeCardFromMonsterField(index, game, player2, player1);
                FieldVisitor.removeCardFromField(index, game, player2, player1, field2.monsterfield, ref field2.monsterfieldCount);
            }
        }
        public void PlayCardFromHand(string playerId, int index)
        {
            if (player1.id.ToString() == playerId)
            {
                //Card c = field1.removeCardFromHandField(index);
                Card c = FieldVisitor.removeCardFromField(index, null, null, null, field1.handfield, ref field1.handfieldCount);
                if (c.type == Enums.CardTypes.Monster)
                {
                    Monster monster = (Monster)c;
                    Monster[] cs = { monster };
                    //field1.insertCardsIntoMonsterField(cs, this, player1, player2);
                    FieldVisitor.insertCardsIntoField(cs, this, player1, player2, field1.monsterfield, ref field1.monsterfieldCount);
                }
                    
                else if (c.type == Enums.CardTypes.Spell)
                {
                    Spell spell = (Spell)c;
                    Spell[] cs = { spell };
                    //field1.insertCardsIntoSpellField(cs);
                    FieldVisitor.insertCardsIntoField(cs, null, null, null, field1.trapfield, ref field1.trapfieldCount);
                }
                else if (c.type == Enums.CardTypes.Trap)
                {
                    Trap trap = (Trap)c;
                    Trap[] cs = { trap };
                    //field1.insertCardsIntoSpellField(cs);
                    FieldVisitor.insertCardsIntoField(cs, null, null, null, field1.trapfield, ref field1.trapfieldCount);
                }
            }
            if (player2.id.ToString() == playerId)
            {
                //Card c = field2.removeCardFromHandField(index);
                Card c = FieldVisitor.removeCardFromField(index, null, null, null, field2.handfield, ref field2.handfieldCount);
                if (c.type == Enums.CardTypes.Monster)
                {
                    Monster monster = (Monster)c;
                    Monster[] cs = { monster };
                    //field2.insertCardsIntoMonsterField(cs, this, player2, player1);
                    FieldVisitor.insertCardsIntoField(cs, this, player2, player1, field2.monsterfield, ref field2.monsterfieldCount);
                }

                else if (c.type == Enums.CardTypes.Spell)
                {
                    Spell spell = (Spell)c;
                    Spell[] cs = { spell };
                    //field2.insertCardsIntoSpellField(cs);
                    FieldVisitor.insertCardsIntoField(cs, null, null, null, field2.trapfield, ref field2.trapfieldCount);
                }
                else if (c.type == Enums.CardTypes.Trap)
                {
                    Trap trap = (Trap)c;
                    Trap[] cs = { trap };
                    //field2.insertCardsIntoSpellField(cs);
                    FieldVisitor.insertCardsIntoField(cs, null, null, null, field2.trapfield, ref field2.trapfieldCount);
                }
            }
        }
        public void PlayerDrawCardsIntoHand(Guid playerId, int amount)
        {
            if (playerId == player1.id)
            {
                Card[] cards = player1.drawCardsFromDeck(amount);
                //field1.insertCardsIntoHandField(cards);
                FieldVisitor.insertCardsIntoField(cards, null, null, null, field1.handfield, ref field1.handfieldCount);
            }
            else if (playerId == player2.id)
            {
                Card[] cards = player2.drawCardsFromDeck(amount);
                //field2.insertCardsIntoHandField(cards);
                FieldVisitor.insertCardsIntoField(cards, null, null, null, field2.handfield, ref field2.handfieldCount);
            }
        }
    }
}
