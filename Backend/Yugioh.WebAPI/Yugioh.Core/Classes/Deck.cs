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
        public ArrayList carddeck;
        public string decktype { get; set; }

        public Deck(int playerid)
        {
            carddeck = new ArrayList();
            abfact = new MonsterFactory();
            abfact.SetPlayerID(playerid);
        }
        public void generateDeck(string decktype)
        {
            
            abfact = new SpellFactory();
            Card c = abfact.createCard(decktype);
            carddeck.Add(c);

            abfact = new TrapFactory();
            c = abfact.createCard(decktype);
            carddeck.Add(c);

            for (int i = 0; i < 50; i++)
            {
                abfact = new MonsterFactory();
                c = abfact.createCard(decktype);
                carddeck.Add(c);
            }
        }

        public Card generateRandMonster(int seed)
        {
            abfact = new MonsterFactory();
            return abfact.createRandCard(seed);
        }

        public void Shuffle(ref ArrayList list)
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
