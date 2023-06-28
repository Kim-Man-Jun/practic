using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _06._28_C_
{
    class Cat
    {
        private string a = "shiro";
        string b = "Tama";
        public string c = "Tora";

        public void SetA(string _a)
        {
            a = _a;
        }

        public void SetB(string _b)
        {
            b = _b;
        }

        public string GetA()
        {
            return a;
        }

        public string GetB()
        {
            return b;
        }
    }

    internal class _06
    {
        static void Main(string[] args)
        {
            Cat name = new Cat();
            name.SetA("shiro");
            name.SetB("Tama");

            Console.WriteLine(name.GetA());
            Console.WriteLine(name.GetB());
            Console.WriteLine(name.c);
        }
    }
}
