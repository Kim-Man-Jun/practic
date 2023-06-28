using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._27_C_
{
    /*
    class Calc
    {
        public int add(int a, int b)
        {
            return a + b;
        }
    }

    internal class _06
    {
        static void disp()
        {
            int c;
            Calc calc = new Calc();

            c = calc.add(8, 9);
            Console.WriteLine(c);
        }

        static void Main(string[] args)
        {
            disp();
        }
        */
    internal class _06
    {
        public class Myutillity
        {
            public static int ver;

        }

        static void Main(string[] args)
        {
            Myutillity.ver = 110;
            Console.WriteLine(Myutillity.ver);
        }
    }
}
