using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Visitor
{
    public interface Part
    {
        void operation(Visitor visitor);
    }

    public class PartA : Part
    {
        public void operation(Visitor visitor)
        {
            visitor.visit(this);
        }
    }
    public class PartB : Part
    {
        public void operation(Visitor visitor)
        {
            visitor.visit(this);
        }
    }


    public interface Visitor
    {
        void visit(PartA a);
        void visit(PartB b);
    }

    public class ConcreteVisitorA : Visitor
    {
        public void visit(PartB b)
        {
            Console.WriteLine("ConcreteVisitorA visit PartB");
        }

        public void visit(PartA a)
        {
            Console.WriteLine("ConcreteVisitorA visit PartA");
        }
    }

    public class VisitorModel
    {
        public static void Invoke()
        {
            Visitor v = new ConcreteVisitorA();
            Part a = new PartA();
            Part b = new PartB();

            a.operation(v);
        }
    }
}
