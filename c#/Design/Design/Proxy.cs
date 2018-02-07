using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Proxy
{
    public interface Subject
    {
        void operation();
    }
    public class RealSubject : Subject
    {
        public void operation()
        {
            Console.WriteLine("执行realSubject的方法");
        }
    }
    public class Proxy : Subject
    {
        private Subject _subject = null;

        public Proxy(Subject sub)
        {
            _subject = sub;
        }
        public Proxy()
        {
            _subject = new Proxy();
        }
        public void operation()
        {
            before();
            _subject.operation();
            after();
        }
        private void before()
        {
            Console.WriteLine("代理before");
        }
        private void after()
        {
            Console.WriteLine("代理after");
        }
    }
    public class ProxyModel
    {
        public static void invoke()
        {
            Subject sub = new RealSubject();
            sub.operation();
            sub = new Proxy(sub);
            sub.operation();
        }
    }
}
