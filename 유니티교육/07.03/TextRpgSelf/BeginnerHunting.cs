using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._30_RPG_TEST
{
    public class BeginnerHunting
    {
        public Player A_player = null;
        int BM_HP = 20;
        int BM_ATK = 5;
        public Infomation p_player;

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
                BeginnerMap();
                p_player = new Infomation();

                input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    p_player.HP -= BM_ATK;
                    BM_HP -= (int)p_player.ATK;
                    Console.WriteLine(p_player.HP);
                }


            }

        }
        public void BeginnerMap()
        {
            Console.WriteLine("초급 몬스터가 나타났다!");
            Console.WriteLine("어떻게 할까?\n");
            Console.WriteLine("==========================================");
            Console.WriteLine("초급 몬스터");
            Console.WriteLine($"체력 : {BM_HP}\t 공격력 : {BM_ATK}");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. 공격한다\t 2. 아이템을 쓴다");
            Console.WriteLine("3. 도망친다");
        }

        public BeginnerHunting()
        {

        }
        ~BeginnerHunting()
        {

        }
    }
}
