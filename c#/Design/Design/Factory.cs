using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Factory
{
    public class ProductBase
    {
        public ProductBase(string name)
        {
            Name = name;
        }
        public string Name { private set; get; }
    }

    public class ProductA : ProductBase
    {
        public ProductA(string name) : base(name)
        {
        }
    }
    public class ProductB : ProductBase
    {
        public ProductB(string name) : base(name)
        {
        }
    }

    public abstract class FactoryBase
    {
        public abstract ProductBase create();
    }
    public class FactoryA : FactoryBase
    {
        public override ProductBase create()
        {
            return new ProductA("product A");
        }
    }
    public class FactoryB : FactoryBase
    {
        public override ProductBase create()
        {
            return new ProductB("product B");
        }
    }
    class Factory
    {
        public static void invoke()
        {
            ProductBase product = new FactoryA().create();
            Console.WriteLine("生产了产品：" + product.Name);
            product = new FactoryB().create();
            Console.WriteLine("生产了产品：" + product.Name);
        }
    }
}
