using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcsd
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            /*
            int a = 5;

            if (a % 2 == 0)
            {
                Console.WriteLine(a + "는 짝수입니다.");
            }
            else
            {
                Console.WriteLine(a + "는 홀수입니다.");
            }
            

            int s = 80;
            Console.WriteLine("당신의 점수는 " + s + "점 입니다.");

            if (s < 70)
            {
                Console.WriteLine("평균까지 앞으로 " + (70 - s) + "점");
                Console.WriteLine("분발하십쇼.");
            }
            else
            {
                Console.WriteLine("잘 했습니다.");
            }
            

            int num = 1000;

            Console.WriteLine(num + "는?");
            if (num >= 0 && num <= 9)
            {
                Console.WriteLine("1자리의 수입니다.");
            }
            else if (num >= 10 && num <= 99)
            {
                Console.WriteLine("2자리의 수입니다.");
            }
            else if (num >= 100 && num <= 999)
            {
                Console.WriteLine("3자리의 수입니다.");
            }
            else if (num >= 1000 && num <= 9999)
            {
                Console.WriteLine("4자리의 수입니다.");
            }
            else if (num >= 10000)
            {
                Console.WriteLine("5자리의 이상의 수입니다.");
            }
            

            int a = 90;

            if (a > 80)
            {
                if (a == 100)
                {
                    Console.WriteLine("만점입니다.");
                }
                else
                {
                    Console.WriteLine("조금만 더");
                }
            }
            else
            {
                Console.WriteLine("분발하세요");
            }

            

            int i;
            for (i = 1; i < 4; i++)
            {
                Console.WriteLine("안녕하세요" + i);
            }
            

            int i, j;

            for (j = 1; j <= 9; j++)
            {
                for (i = 1; i <= 9; i++)
                {
                    Console.WriteLine(j + " X " + i + " = " + j * i);
                }
            }
            

            int[] nums = { 1, 2, 3, 4 };
            foreach (int a in nums)
            {
                Console.WriteLine(a);
            }
            

            int cnt = 0;
            while (cnt < 10)
            {
                Console.WriteLine(cnt);
                cnt++;
                if (cnt == 5)
                {
                    break;
                }
            }
           

            int a = 0, i = 0;

            do

            {

                ++i;

                a += i;

            } while (i < 10);

            Console.WriteLine("1부터 " + i + "까지의 합은 " + a);

           

            Random rand = new Random();

            int a = rand.Next(1, 5);

            Console.WriteLine(a);

            for (int i = 0; i < 10; i++)
            {
                int b = rand.Next(1, 11);
                Console.WriteLine(b);
            }

            for (int j = 0; j < 10; j++)
            {
                int c = rand.Next(101);
                Console.WriteLine(c);
            }
           

            Random rnd = new Random();

            string[] str =
            {
                "S급 반지",
                "A급 반지",
                "B급 반지",
                "C급 반지",
                "D급 반지",
                "E급 반지",
            };

            for (int i = 0; i < 11; i++)
            {
                int a = rnd.Next(1, 101);
                if (a >= 1 && a < 6)
                {
                    Console.WriteLine(str[0]);
                }
                else
                {
                    Console.WriteLine(str[rnd.Next(1, 5)]);
                }
            }
            

            int a, b = 2;
            for (a = 0; a < 5; a++)
            {
                if (b - a <= 0)
                {
                    break;
                }

                Console.WriteLine(b + " - " + a + " = " + (b - a));
            }
            

            int a, b = 1;

            for (a = 0; a < 4; a++)
            {
                if (a + b == 2)
                {
                    continue;
                }
                Console.WriteLine(a + " + " + b + " = " + (a + b));
            }
            

            int a = 5;

            switch (a)
            {
                case 0:
                    {
                        Console.WriteLine("a = 0");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("a = 1");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("a = 2");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("a = 3");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("맞는게 없음");
                        break;
                    }
            }
            

            string str = "반지";

            switch (str)
            {
                case "반지":
                    Console.WriteLine(str + "를 얻었습니다");
                    break;

                case "도끼":
                    Console.WriteLine(str + "를 얻었습니다");
                    break;
            }
            

            int a;
            for (a = 5; a <= 8; a++)
            {
                Console.WriteLine(a + " / 3 = " + a / 3);
                switch (a % 3)
                {
                    case 1:
                        {
                            Console.WriteLine(" : 나머지는 1입니다.");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(" : 나머지는 2입니다.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(" : 나머지는 0입니다.");
                            break;
                        }

                }
            }
            

            int data;

            data = int.Parse(Console.ReadLine());

            if (data >= 90)
            {
                Console.WriteLine("수");
            }
            else if (data >= 80 && data < 90)
            {
                Console.WriteLine("우");
            }
            else if (data >= 70 && data < 80)
            {
                Console.WriteLine("미");
            }
            else if (data >= 60 && data < 70)
            {
                Console.WriteLine("양");
            }
            else
            {
                Console.WriteLine("가");
            }

            

            int data = 2;

            switch (data)
            {
                case 1:
                    {
                        Console.WriteLine("오늘의 운세는 좋은 편 입니다.");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("오늘의 운세는 운수대통 입니다.");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("오늘의 운세는 보통입니다.");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("잘못 입력하였습니다. 다시 입력하세요.");
                        break;
                    }
            }
            */

            Random rnd = new Random();
            int a = rnd.Next(0, 4);

            Console.WriteLine(a);

            if (a == 0)
            {
                Console.WriteLine("위 이동");
            }
            else if (a == 1)
            {
                Console.WriteLine("아래 이동");
            }
            else if (a == 2)
            {
                Console.WriteLine("왼쪽 이동");
            }
            else if (a == 3)
            {
                Console.WriteLine("오른쪽 이동");
            }
        }
    }
}
