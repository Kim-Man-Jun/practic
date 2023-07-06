using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _07._06
{
    class Calc
    {
        int z;
        public void printDivide(int x, int y)
        {
            try
            {
                z = x / y;      //y를 0으로 나누었을때
                Console.WriteLine(z);
            }
            catch (Exception e)     //예외가 발생되면 catch가 실행
            {
                Console.WriteLine("printDivide()에서 예외 발생");
                Console.WriteLine(e.Message);
            }
        }
    }
    internal class Base
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc();
            calc.printDivide(5, 0);
            Console.WriteLine("종료");
        }
    }
}
