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
            SimpleFactory.SimpleFactory.invoke();
            Factory.Factory.invoke();
            AbstractFatory.AbstractFactory.invoke();
            Builder.BuilderModel.invoke();
            Console.ReadKey();
        }
    }
}
