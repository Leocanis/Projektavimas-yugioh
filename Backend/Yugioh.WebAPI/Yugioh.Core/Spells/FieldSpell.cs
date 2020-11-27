using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.Core.Spells
{
    public class FieldSpell : Classes.Spell
    {
        protected int bonusAtk { get; set; }
        protected int bonusDef { get; set; }
        protected string Attribute { get; set; }
        protected string MonsterType { get; set; } //maybe make it a list/array since cards like "Forest" affect multiple types

        public void UpdateField()
        {
            //check all monsters on field and take their attribute, put them in an array
            //for i = 0, i < n, i++
            switch (Attribute)
            {
                case "Earth":
                    // Monsters.EarthMonster Object[i] atk = atk+bonusatk, def = def+bonusdef, etc.
                    break;
                    //repeat for all attributes
                default:
                    break;
            }
            //another switch for types

        }

}

}
