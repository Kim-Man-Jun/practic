using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BrickGame
{
    public class MainGame2
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();

        static void Main(string[] args)
        {
            Ball2 ball2 = new Ball2();

            int Current = Environment.TickCount;
            ball2.Intitialize();

            while (true)
            {
                if (Current + 100 < Environment.TickCount)
                {
                    Current = Environment.TickCount;
                    ball2.Progress();
                    ball2.Render();
                }
            }
            ball2.Release();
        }
    }
}
