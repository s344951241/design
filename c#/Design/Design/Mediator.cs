using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Mediator
{
    public abstract class Colleague {
        protected Mediator _mediator;
        public Colleague(Mediator me)
        {
            _mediator = me;
        }
    }
    public class ConcreteColleagueA : Colleague
    {
        public ConcreteColleagueA(Mediator me) : base(me)
        {

        }
        public void selfMethod()
        {
            Console.WriteLine("ConcreteColleagueA self method");
        }
        public void depMethod()
        {
            _mediator.operation1();
        }
    }

    public class ConcreteColleagueB : Colleague
    {
        public ConcreteColleagueB(Mediator me) : base(me)
        {
        }
        public void selfMethod()
        {
            Console.WriteLine("ConcreteColleagueB self method");
        }
        public void depMethod()
        {
            _mediator.operation2();
        }
    }
    public abstract class Mediator
    {
        public ConcreteColleagueA CA;
        public ConcreteColleagueB CB;

        

        public abstract void operation1();
        public abstract void operation2();
    }
    public class ConcreteMediator : Mediator
    {
        public override void operation1()
        {
            CA.selfMethod();
            CB.selfMethod();
        }

        public override void operation2()
        {
            CA.selfMethod();
            CB.selfMethod();
        }
    }
    public class MediatorModel
    {
        public static void invoke()
        {
            ConcreteMediator me = new ConcreteMediator();
            ConcreteColleagueA ca = new ConcreteColleagueA(me);
            ConcreteColleagueB cb = new ConcreteColleagueB(me);
            me.CA = ca;
            me.CB = cb;
            ca.depMethod();
            cb.depMethod();
        }
    }
}
