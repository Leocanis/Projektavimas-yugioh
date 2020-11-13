using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yugioh.WebAPI.Spells
{
    abstract class EquipSpell : Classes.Spell //Decorator
    {
        Classes.Monster monster = null;
        protected int bonusAtk { get; set; }
        protected int bonusDef { get; set; }
        // gal CardDatabase ant Equip spell entry kur yra Atk ir Def null irasyti koki pokyti duoda apkaustytai kortai, kad butu is kur traukt values?
        // bet reiktu daugiau fieldu, nes pvz "Stim-Pack" vis mazina atk kas ejima, kitos kortos gali equip tik ant tam tikro atributo/tipo

        protected EquipSpell(Classes.Monster baseItem)
        {
            monster = baseItem;
        }

        public int GetAtk()
        {
            return (monster.GetAtk() + bonusAtk);
        }
        public int GetDef()
        {
            return (monster.GetDef() + bonusDef);
        }

    }

    class Armament : EquipSpell
    {
        public Armament(Classes.Monster baseComponent) : base(baseComponent)
        {
            this.bonusAtk = 500;
            this.bonusDef = 500;
            //Example: Sword of Deep-Seated
        }
    }
}
/* client implementation example
    Monster newMonster = new Monster();
    Console.WriteLine("Attack: " newMonster.GetAtk() + "; Defense: " + newMonster.GetDef());
 
    newMonster = new Armament(newMonster);
    Console.WriteLine("Attack: " newMonster.GetAtk() + "; Defense: " + newMonster.GetDef());
    
    Console.ReadLine();
*/
