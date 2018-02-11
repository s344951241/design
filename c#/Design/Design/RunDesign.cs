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
            AbstractFatory.AbstractFactoryModel.invoke();
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
            writec("chian");
            Chain.Chain.invoke();
            writec("command");
            Command.CommandModel.invoke();
            writec("mediator");
            Mediator.MediatorModel.invoke();
            writec("observer");
            Observer.ObserverModel.invoke();
            writec("strategy");
            Strategy.StrategyModel.invoke();
            writec("template");
            Template.Templetemodel.invoke();
            writec("visitor");
            Visitor.VisitorModel.Invoke();
            writec("state");
            State.StateModel.invoke();
            Console.ReadKey();
        }
        private static void writec(string str)
        {
            Console.WriteLine(str + "------------------------------------------>");
        }
    }
}
