using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._30_RPG_TEST
{
    public class ExpertHunting
    {
        public Player A_player = null;
        int EM_HP = 50;
        int EM_ATK = 20;

        public void SetPlayer(ref Player player)
        {
            A_player = player;
        }
        public void Progress()
        {
            int input = 0;

            while (true)
            {
                Console.Clear();
                A_player.Render();
                ExpertMap();
                input = int.Parse(Console.ReadLine());

                if (input <= 3)
                {
                    break;
                }

            }

        }
        public void ExpertMap()
        {
            Console.WriteLine("고급 몬스터가 나타났다!");
            Console.WriteLine("어떻게 할까?\n");
            Console.WriteLine("==========================================");
            Console.WriteLine("고급 몬스터");
            Console.WriteLine($"체력 : {EM_HP}\t 공격력 : {EM_ATK}");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. 공격한다\t 2. 아이템을 쓴다");
            Console.WriteLine("3. 도망친다");
        }

        public ExpertHunting()
        {

        }
        ~ExpertHunting()
        {

        }
    }
}
