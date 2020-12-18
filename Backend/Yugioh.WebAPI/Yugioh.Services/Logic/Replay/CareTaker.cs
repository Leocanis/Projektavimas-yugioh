using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Yugioh.Services.Logic.Replay
{
    public class CareTaker {
        private List<Memento> mementoList = new List<Memento>();
        public void add(Memento state) {
            mementoList.Add(state);
        }
        public Memento get(int index) {
            return mementoList[index];
        }
    }
}
