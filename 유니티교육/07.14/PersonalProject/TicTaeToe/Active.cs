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

namespace TicTaeToe
{
    public class Active
    {
        static void Main(string[] args)
        {
            Play play = new Play();

            int Cur = Environment.TickCount;

            while (true)
            {
                if (Cur + 150 < Environment.TickCount)
                {
                    Console.Clear();
                    play.SetField();
                }
            }
        }
    }
}
