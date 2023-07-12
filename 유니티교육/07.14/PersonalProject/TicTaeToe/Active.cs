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
            Field field = new Field();
            Play play = new Play();

            Console.Clear();
            field.Render();
        }
    }
}
