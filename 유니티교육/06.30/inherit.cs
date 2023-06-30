using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _06._30_RPG_TEST
{
    class Terran
    {
        public string terran = "Terran";
    }

    class Marine : Terran
    {
        public void marine()
        {
            string M = "Marine";
            Console.WriteLine(terran + "의 " + M);

        }
    }
    class Tank : Terran
    {
        public void tank()
        {
            string T = "Tank";
            Console.WriteLine(terran + "의 " + T);

        }
    }
    class BattleCruser : Terran
    {
        public void battleCruser()
        {
            string B = "BattleCruser";
            Console.WriteLine(terran + "의 " + B);

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Marine m = new Marine();
            Tank t = new Tank();
            BattleCruser b = new BattleCruser();

            m.marine();
            b.battleCruser();
            t.tank();
        }
    }
}
