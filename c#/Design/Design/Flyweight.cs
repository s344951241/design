using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Design.Flyweight
{

    public interface Flyweight
    {
        void operation();
    }

    public class ConcreteFlyweight : Flyweight
    {
        private string _name;
        public int Index { get; set; }
        public ConcreteFlyweight(string name)
        {
            _name = name;
        }
        public void operation()
        {
            Console.WriteLine("执行元的方法" + _name+Index);
        }
    }

    public class FlyweightFactory {
        private Dictionary<string, ConcreteFlyweight> _dict = new Dictionary<string, ConcreteFlyweight>();

        public ConcreteFlyweight factory(string name)
        {
            ConcreteFlyweight fly = null;
            _dict.TryGetValue(name, out fly);
            if (fly == null)
            {
                fly = new ConcreteFlyweight(name);
                _dict.Add(name, fly);
            }
            return fly;
        }
    }
    public class FlyweightModel {
        public static void invoke()
        {
            FlyweightFactory factory = new FlyweightFactory();
            ConcreteFlyweight fly = factory.factory("vv");
            fly.Index = 1;
            fly.operation();

            ConcreteFlyweight fly2 = factory.factory("xx");
            fly2.Index = 2;
            fly2.operation();
           

            ConcreteFlyweight fly3 = factory.factory("vv");
            fly3.Index = 3;
            fly3.operation();
            fly.operation();
            Console.WriteLine(object.ReferenceEquals(fly, fly3));
        }
    }
}
