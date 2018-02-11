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
    class AbstractFactoryModel
    {
        public static void invoke()
        {
            //FactoryOne one = new FactoryOne();
            //Product product = new Product(one.createPartA(), one.createPartB());
            //Console.WriteLine(product);
            AbstractFactory factory1 = new Factory1();
            AbstractFactory factory2 = new Factory2();

            ProductBaseA A1 = factory1.createProductA();
            ProductBaseA A2 = factory2.createProductA();
            ProductBaseB B1 = factory1.createProductB();
            ProductBaseB B2 = factory2.createProductB();
            A1.operation();
            A2.operation();
            B1.operation();
            B2.operation();
        }
    }

    public abstract class ProductBaseA
    {
        public void shareMethod() { }
        public abstract void operation();
    }
    public class ProductA1 : ProductBaseA
    {
        public override void operation()
        {
            Console.WriteLine("执行productA1的方法");
        }
    }
    public class ProductA2 : ProductBaseA
    {
        public override void operation()
        {
            Console.WriteLine("执行productA2的方法");
        }
    }

    public abstract class ProductBaseB
    {
        public void shareMethod() { }
        public abstract void operation();
    }
    public class ProductB1 : ProductBaseB
    {
        public override void operation()
        {
            Console.WriteLine("执行productB1的方法");
        }
    }
    public class ProductB2 : ProductBaseB
    {
        public override void operation()
        {
            Console.WriteLine("执行productB2的方法");
        }
    }

    public abstract class AbstractFactory {
        public abstract ProductBaseA createProductA();
        public abstract ProductBaseB createProductB();
    }

    public class Factory1 : AbstractFactory
    {
        public override ProductBaseA createProductA()
        {
            return new ProductA1();
        }

        public override ProductBaseB createProductB()
        {
            return new ProductB1();
        }
    }
    public class Factory2 : AbstractFactory
    {
        public override ProductBaseA createProductA()
        {
            return new ProductA2();
        }

        public override ProductBaseB createProductB()
        {
            return new ProductB2();
        }
    }

}
