using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Template
{
    public abstract class Template
    {
        protected abstract void method1();
        protected abstract void method2();

        public void operation()
        {
            method1();
            method2();
        }
    }

    public class ConcreteA : Template
    {
        protected override void method1()
        {
            Console.WriteLine("实现类A的method1");
        }

        protected override void method2()
        {
            Console.WriteLine("实现类A的method2");
        }
    }

    public class ConcreteB : Template
    {
        protected override void method1()
        {
            Console.WriteLine("实现类B的method1");
        }

        protected override void method2()
        {
            Console.WriteLine("实现类B的method2");
        }
    }

    public class Templetemodel
    {
        public static void invoke()
        {
            Template A = new ConcreteA();
            A.operation();
            A = new ConcreteB();
            A.operation();
        }
    }
}
