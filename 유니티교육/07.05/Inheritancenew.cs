using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _07._05
{
    class A
    {
        public void m()
        {
            Console.WriteLine("A 클래스의 메소드");
        }
    }

    class B : A
    {
        public new void m()
        {
            Console.WriteLine("B 클래스의 메소드");
        }
    }
    internal class Base
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            A c = new A();

            a.m();
            b.m();
            c.m();
        }
    }
}
