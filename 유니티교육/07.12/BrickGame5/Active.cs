using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace BrickGame5
{
    public class Active
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();


        Block block = new Block();

        static void Main(string[] args)
        {
            Ball ball = new Ball();

            int Cur = Environment.TickCount;

            ball.Initialize();

            while (true)
            {
                if (Cur + 250 < Environment.TickCount)
                {
                    Cur = Environment.TickCount;

                    Console.Clear();
                    ball.Progress();
                    ball.Render();
                }
            }

            ball.Release();
        }
    }
}
