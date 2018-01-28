using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.SimpleFactory
{
    
    public class ProductBase
    {
        public string Name { get;  private set; }
        public ProductBase(string name)
        {
            Name = name;
        }
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
    public class Factory
    {
        public static ProductBase create(int type)
        {
            ProductBase product = null;
            switch (type)
            {
                case 1:
                    product = new ProductA("Product A");
                    break;
                case 2:
                    product = new ProductBase("Product B");
                    break;

            }
            return product;
        }
    }

    class SimpleFactory
    {
        public static void invoke()
        {
            ProductBase product = Factory.create(1);
            Console.WriteLine("生产了产品:" + product.Name);
            product = Factory.create(2);
            Console.WriteLine("生产了产品:" + product.Name);
        }
    }

}
