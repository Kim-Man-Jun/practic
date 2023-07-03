using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _07._03
{
    class Greeting
    {
        public virtual void bye()
        {
            Console.WriteLine("Good Bye");
        }
    }

    class Aisatsu : Greeting
    {
        public override void bye()
        {
            Console.WriteLine("안녕히 가세요");
        }
        public void cheer()
        {
            Console.WriteLine("건강하세요");
        }
    }

    internal class Base
    {
        static void Main(string[] args)
        {
            /*Aisatsu aisatsu = new Aisatsu();
            aisatsu.bye();
            aisatsu.cheer();
            

            Greeting greeting = new Greeting();
            greeting.bye();     //부모메모리로 만듦
            */

            Greeting greeting = new Aisatsu();      //부모타입에 자식 타입의 new 할당 가능
            greeting.bye();

        }
    }
}
