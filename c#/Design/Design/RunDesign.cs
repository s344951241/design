using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
    class RunDesign
    {
        public static void Main(string[] args)
        {
            writec("simpleFactory:");
            SimpleFactory.SimpleFactory.invoke();
            writec("factory:");
            Factory.Factory.invoke();
            writec("abstractFatory:");
            AbstractFatory.AbstractFactory.invoke();
            writec("builder:");
            Builder.BuilderModel.invoke();
            writec("prototype:");
            Prototype.PrototypeModel.invoke();
            writec("adapter:");
            Adapter.Adapter.invoke();
            writec("bridge:");
            Bridge.Bridge.invoke();
            writec("composite:");
            Composite.CompositeModel.invoke();
            writec("decorator:");
            Decorator.DecoratorModel.invoke();
            writec("facade:");
            Facade.FacadeModel.invoke();
            writec("flyweight:");
            Flyweight.FlyweightModel.invoke();
            writec("proxy");
            Proxy.ProxyModel.invoke();
            Console.ReadKey();
        }
        private static void writec(string str)
        {
            Console.WriteLine(str + "------------------------------------------>");
        }
    }
}
