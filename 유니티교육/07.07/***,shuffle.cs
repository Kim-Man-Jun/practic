using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _07._07
{
    internal class Base
    {
        static void Main(string[] args)
        {
            /*
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{i}{j} ");
                }
                Console.WriteLine(); 
            }
            

            int g = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 5; j > g; j--)
                {
                    Console.Write("*");
                }
                g++;
                Console.WriteLine();
            }

            

            int g = 1;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < g; j++)
                {
                    Console.Write("*");
                }
                g++;
                Console.WriteLine();
            }

             실제 풀이

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i + j <= 4)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("");
                    }
                }
                Console.WriteLine();
            }



            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i + j >= 4)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("");
                    }
                }
                Console.WriteLine();
            }

            */

            int a = 10;
            int b = 5;
            int t;

            t = a;
            a = b;
            b = t;

            Console.WriteLine(a + "," + b);
        }
    }
}
