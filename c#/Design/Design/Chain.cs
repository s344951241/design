using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Chain
{
    public abstract class Handle
    {
        private Handle _nextHandler;

        public abstract Response operation(Request req);
        public abstract Level getHandleLevel();

        public Response handle(Request req)
        {
            Response res = null;
            if (this.getHandleLevel().Equals(req.getRequestLevel()))
            {
                res = this.operation(req);
            }
            else {
                if (_nextHandler != null)
                {
                    Console.WriteLine("传给下一个链");
                    _nextHandler.operation(req);
                }
                else {
                    Console.WriteLine("没有下一个链了");
                }
            }
            return res;
        }
        public void setNext(Handle handle)
        {
            _nextHandler = handle;
        }
    }

    public class ConcreteHandler1 : Handle
    {
        private Level _lv;
        public ConcreteHandler1(Level lv)
        {
            _lv = lv;
        }
        public override Level getHandleLevel()
        {
            return _lv;
        }

        public override Response operation(Request req)
        {
            Console.WriteLine("ConcreteHandler1执行责任");
            return null;
        }
    }

    public class ConcreteHandler2 : Handle
    {
        private Level _lv;
        public ConcreteHandler2(Level lv)
        {
            _lv = lv;
        }
        public override Level getHandleLevel()
        {
            return _lv;
        }

        public override Response operation(Request req)
        {
            Console.WriteLine("ConcreteHandler2执行责任");
            return null;
        }
    }
    class Chain
    {
        public static void invoke()
        {
            Level lv1 = new Level { Lv = 1 };
            Level lv2 = new Level { Lv = 2 };
            Handle handle1 = new ConcreteHandler1(lv1);
            Handle handle2 = new ConcreteHandler2(lv2);

            handle1.setNext(handle2);

            Response res = handle1.handle(new Request(lv2));
        }
      
    }


    public class Response { }
    public class Request {
        private Level _lv;
        public Request(Level lv) {
            _lv = lv;
        }
        public Level getRequestLevel() {
            return _lv;
        }
    }
    public class Level {
        public int Lv;
    }
}
