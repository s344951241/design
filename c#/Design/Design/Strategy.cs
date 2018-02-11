using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Strategy
{

    public interface Strategy
    {
        void operation();
    }

    public class ConcreteStrategyA : Strategy
    {
        public void operation()
        {
            Console.WriteLine("执行策略A");
        }
    }

    public class ConcreteStrategeB : Strategy
    {
        public void operation()
        {
            Console.WriteLine("执行策略B");
        }
    }

    public class Context
    {
        private Strategy _strategy;

        public Context(Strategy strategy)
        {
            _strategy = strategy;
        }
        public void operation()
        {
            _strategy.operation();
        }
    }

    public class StrategyModel
    {
        public static void invoke()
        {
            Context context = new Context(new ConcreteStrategyA());
            context.operation();
        }
    }
}
