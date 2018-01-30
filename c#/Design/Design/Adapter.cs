using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Adapter
{
    public interface InterfaceA
    {
         void InterfaceAFun();
    }
    public class ClassA : InterfaceA
    {
        public void InterfaceAFun()
        {
            Console.WriteLine("this is classA's function InterfaceAFun from InterfaceA");
        }

    }

    public interface InterfaceB
    {
        void InterfaceBFun();
    }

    public class ClassAdapter : ClassA, InterfaceB
    {
        public void InterfaceBFun()
        {
            Console.WriteLine("classAdapter:");
            this.InterfaceAFun();
        }
    }
    public class TargetAdapter : InterfaceB
    {
        private ClassA a = new ClassA();
        public void InterfaceBFun()
        {
            Console.WriteLine("targetAdapter:");
            a.InterfaceAFun();
        }
    }
    public class Adapter
    {
        public static void invoke()
        {
            ClassAdapter adapter = new ClassAdapter();
            adapter.InterfaceBFun();

            TargetAdapter adapter1 = new TargetAdapter();
            adapter1.InterfaceBFun();
        }
    }
}
