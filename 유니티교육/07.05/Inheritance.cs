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
    interface Greet             //최초 1번
    {
        void greet();
    }

    interface Bye : Greet       //bye는 greet를 상속
    {
        void bye();
    }

    class Greeting : Bye
    {
        public void greet()     //최초 1번에서 상속 받은 것
        {
            Console.WriteLine("Hello");
        }

        public void bye()       //기존에 있던 bye 
        {
            Console.WriteLine("Bye");
        }
    }

    internal class Base
    {
        static void Main(string[] args)
        {
            Greeting greeting = new Greeting();
            greeting.greet();
            greeting.bye();
        }
    }
}
