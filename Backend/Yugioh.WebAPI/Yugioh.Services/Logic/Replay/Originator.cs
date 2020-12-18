using System;
using System.Collections.Generic;
using System.Text;
using Yugioh.Core.Entities;

namespace Yugioh.Services.Logic.Replay
{
    public class Originator
    {
        private Game state;
        public void setState(Game state) {
            this.state = state;
        }
        public Game getState() {
            return state;
        }
        public Memento saveStateToMemento() {
            return new Memento(state);
        }
        public void getStateFromMemento(Memento memento)
        {
            state = memento.getState();
        }

    }
}
