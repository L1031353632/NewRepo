using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AopAlliance.Intercept;
using Spring.Aop;
using Spring.Aop.Framework;

namespace AOPTest
{
    class Program
    {
        static void Main(string[] args)
        {
          //Person p=new Person();
          //  p.Pen=new Pen();
          //  p.Write();

            ProxyFactory proxy = new ProxyFactory(new Pen());
            //proxy.AddAdvice(new BeforeAdvice());
            proxy.AddAdvice(new AroundAdvice());
            IWrite p = proxy.GetProxy() as IWrite;
            p.Write();

            Console.ReadKey();
        }
    }

    public interface IWrite
    {
        void Write();
    }

    public class Pen : IWrite
    {
        public void Write()
        {
            Console.WriteLine("写字");
        }
    }

    public class BeforeAdvice : IMethodBeforeAdvice
    {

        public void Before(System.Reflection.MethodInfo method, object[] args, object target)
        {
            Console.WriteLine("判断墨水");
        }
    }

    public class AroundAdvice : IMethodInterceptor
    {

        public object Invoke(IMethodInvocation invocation)
        {
            Console.WriteLine("------1------");
            //invocation.Proceed();
            Console.WriteLine("-----2-------");
            return "";
        }
    }

}
