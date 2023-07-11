using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BrickGame4
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

            int cur = Environment.TickCount;

            while (true)
            {
                if (cur + 100 < Environment.TickCount)
                {
                    cur = Environment.TickCount;
                    gm.Progress();
                    gm.Render();
                }
            }
            gm.Release();
        }
    }
}
