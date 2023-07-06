using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _07._06
{
    internal class Base
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int a = rnd.Next(1, 31);

            Console.WriteLine("1부터 30까지의 값을 입력해 주세요");

            while (true)
            {
                string s = Console.ReadLine();
                if (s == "")
                {
                    Console.WriteLine("종료합니다");
                    break;
                }

                int n = 0;

                try
                {
                    n = int.Parse(s);
                }

                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("1부터 30까지의 값을 입력해 주세요");
                    continue;
                }

                if (n == a)
                {
                    Console.WriteLine("정답");
                    break;
                }
                else if (n > a)
                {
                    Console.WriteLine("다운");
                }
                else if (n < a)
                {
                    Console.WriteLine("업");
                }
            }
        }
    }
}
