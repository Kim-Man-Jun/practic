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
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            int x = 10, y = 10;

            while (true)
            {
                Console.Clear();

                Console.SetCursorPosition(x, y);        //커서를 x,y 좌표로 이동
                Console.Write("o");

                cki = Console.ReadKey(true);        //누르는 키를 입력 받아 true 값이면 넣어줌

                switch (cki.Key)
                {
                    case System.ConsoleKey.LeftArrow:
                        {
                            x--;
                            break;
                        }

                    case System.ConsoleKey.RightArrow:
                        {
                            x++;
                            break;
                        }
                    case System.ConsoleKey.UpArrow:
                        {
                            y--;
                            break;
                        }
                    case System.ConsoleKey.DownArrow:
                        {
                            y++;
                            break;
                        }
                    case System.ConsoleKey.Q:
                        {
                            return;     //리턴을 통해서 함수 종료
                        }
                }

            }
        }
    }
}
