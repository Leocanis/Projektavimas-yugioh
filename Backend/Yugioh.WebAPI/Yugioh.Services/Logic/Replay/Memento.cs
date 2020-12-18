using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;

namespace Yugioh.Services.Logic.Replay
{
    public class Memento
    {
        private Game state;
        public Memento(Game state)
        {
            this.state = state;
        }
        public Game getState()
        {
            return state;
        }
    }
}
