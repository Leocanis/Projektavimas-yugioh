using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Yugioh.WebAPI.Achievements
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject  //attaches observers to subjects and notifies them
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class Subject : ISubject
    {
        public int State { get; set; } = -0;
        private List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }

    class FirstVictory : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State == 1)
            {
                Console.WriteLine("Congratulations on winning your first game!");
            }
        }
    }

    class FinishedTutorial : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State == 1)
            {
                Console.WriteLine("Congratulations on finishing the tutorial!");
            }
        }
    }

}
/* client implementation example
var subject = new Subject();
var observerA = new FirstVictory();
subject.Attach(observerA);
var observerB = new FinishedTutorial();
subject.Attach(observerB);
...
subject.Detach(observerB);
*/


