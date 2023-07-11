using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BrickGame3
{
    public class Active
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();

        static void Main(string[] args)
        {
            Bar bar = new Bar();

            bar.Initialize();

            int cur = Environment.TickCount;

            while (true)
            {
                if (cur + 100 < Environment.TickCount)
                {
                    cur = Environment.TickCount;
                    bar.Progress();
                    bar.Render();
                }
            }

            bar.Release();

        }
    }
}
