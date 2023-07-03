using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._30_RPG_TEST
{
    public class IntermediateHunting
    {
        public Player A_player = null;
        int IM_HP = 35;
        int IM_ATK = 12;

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
                IntermediateMap();
                input = int.Parse(Console.ReadLine());

                if (input <= 4)
                {
                    break;
                }

            }

        }
        public void IntermediateMap()
        {
            Console.WriteLine("고급 몬스터가 나타났다!");
            Console.WriteLine("어떻게 할까?\n");
            Console.WriteLine("==========================================");
            Console.WriteLine("고급 몬스터");
            Console.WriteLine($"체력 : {IM_HP}\t 공격력 : {IM_ATK}");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. 공격한다\t 2. 아이템을 쓴다");
            Console.WriteLine("3. 도망친다");
        }

        public IntermediateHunting()
        {

        }
        ~IntermediateHunting()
        {

        }
    }
}
