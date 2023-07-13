using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace BrickGameFinal
{
    public class Active
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();

        public static void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.Initialize();

            int Curr = Environment.TickCount;

            while (true)
            {
                if (Curr + 150 < Environment.TickCount)
                {
                    Curr = Environment.TickCount;

                    gm.Progress();
                    gm.Render();

                }

            }

            gm.Release();
        }
    }
}
