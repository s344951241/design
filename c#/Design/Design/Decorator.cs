using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Decorator
{

    public abstract class Component
    {
        public abstract void operate();
    }

    public class ConcreteComponent : Component {
        public override void operate()
        {
            Console.WriteLine("执行方法");
        }
    }

    public abstract class Decorator:Component
    {
        private Component _com = null;

        public Decorator(Component com)
        {
            _com = com;
        }

        public override void operate()
        {
            _com.operate();
        }
    }

    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component com) : base(com)
        {
        }
        private void methodA()
        {
            Console.WriteLine("装饰A");
        }
        public override void operate()
        {
            methodA();
            base.operate();
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component com) : base(com)
        {
        }

        private void methodB()
        {
            Console.WriteLine("装饰B");
        }
        public override void operate()
        {
            base.operate();
            methodB();
        }
    }

    public class DecoratorModel
    {
        public static void invoke()
        {
            Component com = new ConcreteComponent();
            com = new ConcreteDecoratorA(com);
            com = new ConcreteDecoratorB(com);
            com.operate();
        }
    }
}
