using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayTest2
{
    internal class Program
    {
        enum Animal { mouse, cat, bird, dog = 100, koala, pig, lion };

        static void Main(string[] args)
        {
            /*int[][] a = new int[][]
            {
                new int[] { 10, 20, 30 },
                new int[] { 40, 50 },
                new int[] { 60 }
            };

            Console.WriteLine(a[0][0]);
            Console.WriteLine(a[0][1]);
            Console.WriteLine(a[0][2]);

            Console.WriteLine(a[1][0]);
            Console.WriteLine(a[1][1]);

            Console.WriteLine(a[2][0]);
            

            int[] a = new int[4];
            int b = a.Length;
            Console.WriteLine(b);

            int[,] c = new int[3, 2];
            int d = c.Length;
            Console.WriteLine(d);
           

            int[][] a = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5 },
            };

            int b = a.Length;               //a 행 갯수
            int c = a[1].Length;            //a1에 속한 갯수
            int d = a[0].Length;            //a0에 속한 갯수

            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            

            int[] a = new int[10];
            Console.WriteLine(a.Length);
            

            int[][] a = new int[][]
{
                new int[] { 1, 2, 3 },
                new int[] { 4, 5 },
};

            Console.WriteLine(a.Length);
            

            List<string> inventory = new List<string>();
            inventory.Add("Potion");
            inventory.Add("rock");
            inventory.Add("bread");
            inventory.Add("sword");
            Console.WriteLine(inventory.Count);
            inventory.RemoveAt(1);
            Console.WriteLine("1번 항목 : " + inventory[0]);
            Console.WriteLine("2번 항목 : " + inventory[1]);
            Console.WriteLine("3번 항목 : " + inventory[2]);
            

            Animal a;
            a = Animal.dog;
            Console.WriteLine((int)a);
            

            Console.WriteLine("5 + 5는?" + " " + (5 + 5) + "입니다.");
            Console.WriteLine("5 - 5는?" + " " + (5 - 5) + "입니다.");
            Console.WriteLine("5 * 5는?" + " " + (5 * 5) + "입니다.");
            Console.WriteLine("5 / 5는?" + " " + (5 / 5) + "입니다.");
            Console.WriteLine("5 % 5는?" + " " + (5 % 5) + "입니다.");
            

            int a = 10;
            int b = 2;

            Console.WriteLine("a + b = " + (a + b));
            Console.WriteLine("a - b = " + (a - b));
            Console.WriteLine("a * b = " + (a * b));
            Console.WriteLine("a / b = " + (a / b));
            Console.WriteLine("a % b = " + (a % b));

            int a = 90;
            a += 10;
            a++;
            Console.WriteLine(a);

            int b = 1;
            int c = 2;
            int d = b + c;
            Console.WriteLine("b + c = " + ++d);
            Console.WriteLine(b++ + c);
            Console.WriteLine(b);
            */

            int att = 50;
            int def = 10;

            att += 10;

            Console.WriteLine("공격력 : " + att);
            Console.WriteLine("방어력 : " + ++def);
        }
    }
}
