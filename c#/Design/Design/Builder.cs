using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Builder
{
    public class Product
    {
        public string Name { set; get; }
        public string Id { set; get; }
        public string Info { set; get; }
    }
    public abstract class Builder
    {
        public abstract void BuildName();
        public abstract void BuildId();
        public abstract void BuildInfo();

        public abstract Product buildProduct();
    }

    public class ConcreteBuilder : Builder
    {
        private Product _product = new Product();
        public override void BuildId()
        {
            _product.Id = "00001";
        }

        public override void BuildInfo()
        {
            _product.Info = "这是一个product";
        }

        public override void BuildName()
        {
            _product.Name = "Product";
        }

        public override Product buildProduct()
        {
            return _product;
        }
    }
    public class Director
    {
        private Builder _builder;
        public Director(Builder builder)
        {
            _builder = builder;
        }
        public Product build()
        {
            _builder.BuildId();
            _builder.BuildName();
            _builder.BuildInfo();
            return _builder.buildProduct();
        } 
    }
    class BuilderModel
    {
        public static void invoke()
        {
            Director director = new Director(new ConcreteBuilder());
            Product product = director.build();
            Console.WriteLine(product.Id + product.Name + product.Info);
        }
    }
}
