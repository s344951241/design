using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Bridge
{

    public interface Implementor {
        void operation();
    }

    public class ConcreteImplementorA : Implementor
    {
        public void operation()
        {
            Console.WriteLine("ConcreteImplementorA 实现 Implementor的operation方法");
        }
    }

    public class ConcreteImplementorB : Implementor
    {
        public void operation()
        {
            Console.WriteLine("ConcreteImplementorB 实现 Implementor的operation方法");
        }
    }

    public abstract class Abstraction
    {
        private Implementor Imp;

        public void SetImp(Implementor imp)
        {
            this.Imp = imp;
        }

        public Implementor GetImp()
        {
            return Imp;
        }

        public abstract void operation();
    }

    public class BrigeClass : Abstraction
    {
        public override void operation()
        {
            GetImp().operation();
        }
    }

    class Bridge
    {
        public static void invoke()
        {
            BrigeClass brige = new BrigeClass();
            brige.SetImp(new ConcreteImplementorA());
            brige.operation();
            brige.SetImp(new ConcreteImplementorB());
            brige.operation();
        }
       
    }
}
