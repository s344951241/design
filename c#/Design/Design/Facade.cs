using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Facade
{

    public class ClassA
    {
        public void doA()
        {
            Console.WriteLine("做事情A");
        }
    }

    public class ClassB
    {
        public void doB()
        {
            Console.WriteLine("做事情B");
        }
    }
    class Facade
    {
        ClassA A;
        ClassB B;
        public Facade()
        {
            A = new ClassA();
            B = new ClassB();
        }

        public void doA()
        {
            A.doA();
        }
        public void doB()
        {
            B.doB();
        }
    }

    public class FacadeModel
    {
        public static void invoke()
        {
            Facade f = new Facade();
            f.doA();
            f.doB();
        }
    }
}
