using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Command
{
    public abstract class Receiver {
        public abstract void operater();
    }
    public class ReceiverA : Receiver
    {
        public override void operater()
        {
            Console.WriteLine("ReceiverA执行命令");
        }
    }

    public class ReceiverB : Receiver
    {
        public override void operater()
        {
            Console.WriteLine("ReceiverB执行命令");
        }
    }

    public abstract class Command 
    {
        protected Receiver _receiver;
        public Command()
        {

        }
        public Command(Receiver re)
        {
            _receiver = re;
        }
        public abstract void execute();
    }
    public class ConcreteCommandA : Command
    {
        public ConcreteCommandA():base()
        {
            _receiver = new ReceiverA();
        }
        public ConcreteCommandA(Receiver re):base(re)
        {
           
        }
        public override void execute()
        {
            _receiver.operater();
            Console.WriteLine("命令A");
        }
    }

    public class ConcreteCommandB : Command
    {
        public ConcreteCommandB():base()
        {
            _receiver = new ReceiverB();
        }
        public ConcreteCommandB(Receiver re):base(re)
        {

        }
        public override void execute()
        {
            _receiver.operater();
            Console.WriteLine("命令B");
        }
    }

    public class Invoker
    {
        private Command _command;
        public void setCommand(Command com)
        {
            _command = com;
        }
        public void action()
        {
            _command.execute();
        }
    }

    public class CommandModel {
        public static void  invoke()
        {
            Invoker invoker = new Invoker();
            Command com = new ConcreteCommandA();
            invoker.setCommand(com);
            invoker.action();
        }
    }
}
