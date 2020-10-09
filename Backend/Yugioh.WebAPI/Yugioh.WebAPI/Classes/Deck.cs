using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.WebAPI.Factories;

namespace Yugioh.WebAPI.Classes
{
    public class Deck
    {
        private AbstractFactory abfact;
        public ArrayList carddeck;

        public Deck()
        {
            for (int i = 0; i < 20; i++)
            {
                abfact = new MonsterFactory();
                Card c1 = abfact.createRandCard();
                abfact = new SpellFactory();
                Card c2 = abfact.createRandCard();
                abfact = new TrapFactory();
                Card c3 = abfact.createRandCard();

                carddeck.Add(c1);
                carddeck.Add(c2);
                carddeck.Add(c3);
            }
        }
        
    }
}
