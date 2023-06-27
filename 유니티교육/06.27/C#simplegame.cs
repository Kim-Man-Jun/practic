using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace dcsd
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Console.WriteLine("대장장이 키우기");

            int pmoney = 100;
            int input;
            int rnd;

            while (true)        //무한루프(콘솔창이 꺼지지 않게하기 위해)
            {
                Console.Clear();
                Console.WriteLine("1. 나무키우기");
                Console.WriteLine("2. 장비뽑기");
                Console.WriteLine("3. 나가기");
                Console.Write("입력 : ");

                input = int.Parse(Console.ReadLine());      //input에 키로 눌린 숫자 담기
                if (input == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("나무캐기(엔터)");
                        Console.WriteLine("뒤로가기 x");

                        string str = Console.ReadLine();

                        pmoney += 100;
                        Console.WriteLine("소지금 : " + pmoney);

                        if (str == "x")
                        {
                            Console.WriteLine("뒤로가기");
                            break;
                        }
                    }
                }
                else if (input == 2)
                {
                    if (pmoney >= 1000)
                    {
                        pmoney -= 1000;

                        for (int i = 1; i < 10; i++)
                        {
                            rnd = rand.Next(1, 101);

                            if (rnd == 1)            //1퍼센트
                            {
                                Console.WriteLine("도끼등급 S급");
                            }
                            else if (rnd >= 2 && rnd < 7)
                            {
                                Console.WriteLine("도끼등급 A급");
                            }
                            else if (rnd >= 7 && rnd < 18)
                            {
                                Console.WriteLine("도끼등급 B급");
                            }
                            else if (rnd >= 18 && rnd < 38)
                            {
                                Console.WriteLine("도끼등급 C급");
                            }
                            else if (rnd >= 38 && rnd < 70)
                            {
                                Console.WriteLine("도끼등급 D급");
                            }
                            else
                            {
                                Console.WriteLine("도끼등급 E급");
                            }
                            Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        Console.WriteLine("소지금이 부족합니다. \n");
                        Thread.Sleep(1000);
                    }
                }
                else if (input == 3)
                {
                    Console.WriteLine("나가기");
                    Environment.Exit(0);            //콘솔 종료 메서드
                }
            }
        }

    }
}
