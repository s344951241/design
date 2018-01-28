using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.AbstractFatory
{

    public class PartA
    {
        public string Name { private set; get; }
        public PartA(string name)
        {
            Name = name;
        }
    }

    public class PartB
    {
        public string Name { private set; get; }
        public PartB(string name)
        {
            Name = name;
        }
    }
    public class Product
    {
        public PartA A { private set; get; }
        public PartB B { private set; get; }
        public Product(PartA a, PartB b)
        {
            A = a;
            B = b;
        }
        public override string ToString()
        {
            return "由" + A.Name + "和" + B.Name + "构成的产品";
        }
    }
    public abstract class Factory
    {
        public abstract PartA createPartA();
        public abstract PartB createPartB();
    }
    public class OneA : PartA
    {
        public OneA(string name) : base(name)
        {
        }
    }
    public class OneB : PartB
    {
        public OneB(string name) : base(name)
        {
        }
    }

    public class FactoryOne : Factory
    {
        public override PartA createPartA()
        {
            return new OneA("One工厂生产的partA");
        }

        public override PartB createPartB()
        {
            return new OneB("one工厂生产的partB");
        }
    }
    class AbstractFactory
    {
        public static void invoke()
        {
            FactoryOne one = new FactoryOne();
            Product product = new Product(one.createPartA(), one.createPartB());
            Console.WriteLine(product);
        }
    }
}
