using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yugioh.Core.Classes;

namespace Yugioh.Core.Factories
{
    public abstract class AbstractFactory
    {
        protected int playerID { get; set; }

        public abstract Card createRandCard(int id);
        public abstract Card createCard(string name);
    }
}
