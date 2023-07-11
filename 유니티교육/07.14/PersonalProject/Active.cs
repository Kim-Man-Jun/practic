using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SnakeGame
{
    public class Active
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();

        static void Main(string[] args)
        {
            Player player = new Player();
            Field field = new Field();
            ConsoleBuffer buffer = new ConsoleBuffer(100, 40);

            int current = Environment.TickCount;

            player.Intitialize();
            field.Intitialize();


            while (true)
            {
                if (current + 200 < Environment.TickCount)
                {
                    current = Environment.TickCount;
                    Console.Clear();
                    field.Render();
                    Console.CursorVisible = false;
                    buffer.Show();
                    player.Progress();
                    player.Render();

                }
            }
        }
    }
}
