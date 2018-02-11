using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    public class Originator {
        public string State { get; set; }

        public Memento createMemento()
        {
            Console.WriteLine("设置备忘录");
            return new Memento(this.State);
        }
        public void restoreMemento(Memento memento)
        {
            Console.WriteLine("恢复备忘录");
            State = memento.State;
        }
    }
    public class Memento
    {
        public string State { get; set; }

        public Memento(string state)
        {
            State = state;
        }

    }
    public class Caretaker {
        public Memento Memento { get; set; }

    }

    public class MementoModel
    {
        public static void invoke()
        {
            Originator origin = new Originator();
            Caretaker care = new Caretaker();
            care.Memento = origin.createMemento();
            origin.restoreMemento(care.Memento);
        }
    }
}
