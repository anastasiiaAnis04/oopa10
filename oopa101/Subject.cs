using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopa101
{
    abstract class Subject
    {
        List<Observer> observers;

        public Subject()
        {
            observers = new List<Observer>();
        }

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
    }
}
