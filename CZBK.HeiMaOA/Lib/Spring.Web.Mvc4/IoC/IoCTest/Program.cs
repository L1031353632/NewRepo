using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;

namespace IoCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPerson p=new Person();

            //步骤1：创建容器对象
            IApplicationContext ctx = ContextRegistry.GetContext();
            IPerson p = ((IObjectFactory) ctx).GetObject("MyPerson") as IPerson;
            p.SayHello();

            Console.ReadKey();
        }
    }

    public interface IPerson
    {
        void SayHello();
    }

    public class Person : IPerson
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Car MyCar { get; set; }

        public Person()
        {
            Console.WriteLine("无参构造方法被调用");
        }

        public Person(string name)
        {
            Console.WriteLine("name构造方法被调用");
            Name = name;
        }

        public Person(int id)
        {
            Console.WriteLine("id构造方法被调用");
            Id = id;
        }

        public Person(int id,string name)
        {
            Console.WriteLine("两个参数构造方法被调用");
            Name = name;
            Id = id;
        }

        public void SayHello()
        {
            Console.WriteLine("{0} say {1}",Name,MyCar.Brand);
        }
    }

    public class Car
    {
        public string Brand { get; set; }
    }
}
