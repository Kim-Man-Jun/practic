using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._27_C_
{
    class Player
    {
        public string Name;
        public int iAtt;
        public int iDef;

        public void PrintPlayer()
        {
            Console.WriteLine("이름 : " + Name);
            Console.WriteLine("공격력 : " + iAtt);
            Console.WriteLine("방어력 : " + iDef);
        }

    }
    internal class _06
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Name = "르블랑";
            player.iAtt = 5;
            player.iDef = 1;

            player.PrintPlayer();
        }
    }
}
