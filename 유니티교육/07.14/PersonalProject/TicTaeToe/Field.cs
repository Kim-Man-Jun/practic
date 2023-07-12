using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTaeToe
{
    public class Field
    {
        public void Render()
        {
            gotoxy(0, 0);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            gotoxy(0, 1);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 2);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 3);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 4);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 5);
            Console.WriteLine("■        1         ■         2        ■         3        ■");
            gotoxy(0, 6);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 7);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 8);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 9);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 10);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            gotoxy(0, 11);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 12);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 13);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 14);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 15);
            Console.WriteLine("■        4         ■         5        ■         6        ■");
            gotoxy(0, 16);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 17);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 18);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 19);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 20);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            gotoxy(0, 21);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 22);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 23);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 24);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 25);
            Console.WriteLine("■        7         ■         8        ■         9        ■");
            gotoxy(0, 26);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 27);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 28);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 29);
            Console.WriteLine("■                  ■                  ■                  ■");
            gotoxy(0, 30);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

        }

        public void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
