using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._30_RPG_TEST
{
    public class Field
    {
        public Player A_player = null;
        public BeginnerHunting B_pHunting = null;
        public IntermediateHunting I_pHunting = null;
        public ExpertHunting E_pHunting = null;

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
                Map();
                input = int.Parse(Console.ReadLine());

                if (input == 4)
                {
                    break;
                }
                else if (input <= 3)
                {
                    if (input == 1)
                    {
                        if (B_pHunting == null)
                        {
                            B_pHunting = new BeginnerHunting();
                            B_pHunting.SetPlayer(ref A_player);
                        }
                        B_pHunting.Progress();
                    }

                    else if (input == 2)
                    {
                        if (I_pHunting == null)
                        {
                            I_pHunting = new IntermediateHunting();
                            I_pHunting.SetPlayer(ref A_player);
                        }
                        I_pHunting.Progress();
                    }

                    else if (input == 3)
                    {
                        if (E_pHunting == null)
                        {
                            E_pHunting = new ExpertHunting();
                            E_pHunting.SetPlayer(ref A_player);
                        }
                        E_pHunting.Progress();
                    }
                }

            }

        }

        public void Map()
        {
            Console.WriteLine("맵을 선택");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. 초보자 사냥터");
            Console.WriteLine("2. 중급자 사냥터");
            Console.WriteLine("3. 전문가 사냥터");
            Console.WriteLine("4. 돌아가기");
            Console.WriteLine("==========================================");
        }

        public Field()
        {

        }
        ~Field()
        {

        }
    }
}
