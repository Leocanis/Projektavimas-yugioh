using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Factories;

namespace Yugioh.Core.Classes
{
    public class Deck
    {
        private AbstractFactory abfact;
        public List<Card> carddeck;
        public int playerId { get; set; }
        public string decktype { get; set; }

        public Deck(int playerid)
        {
            carddeck = new List<Card>();
            //abfact = new MonsterFactory(playerid);
            //abfact.SetPlayerID(playerid);
            playerId = playerid;
        }
        public void generateDeck(string decktype)
        {

            abfact = new SpellFactory(playerId);
            Card c = abfact.createCard(decktype);
            carddeck.Add(c);

            abfact = new TrapFactory(playerId);
            c = abfact.createCard(decktype);
            carddeck.Add(c);

            for (int i = 0; i < 50; i++)
            {
                abfact = new MonsterFactory(playerId);
                c = abfact.createCard(decktype);
                carddeck.Add(c);
            }
        }
        public Card returnTopCard()
        {
            if (carddeck != null && carddeck.Count > 0)
            {
                var currentFirst = carddeck[0];
                carddeck.RemoveAt(0);
                return currentFirst;
            }
            return null;
        }


        public Card generateRandMonster(int seed)
        {
            abfact = new MonsterFactory(playerId);
            return abfact.createRandCard(seed);
        }

        public void Shuffle(ref List<Card> list)
        {
            Random rng = new Random();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                int number = rng.Next(i);
                var temp = list[i];
                list[i] = list[number];
                list[number] = temp;
             }
        }

    }
}
