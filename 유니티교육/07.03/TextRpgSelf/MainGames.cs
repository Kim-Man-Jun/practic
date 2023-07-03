using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06._30_RPG_TEST
{
    public class MainGame
    {
        public Player A_player = null;
        public Field A_pField = null;

        public void Initialize()
        {
            A_player = new Player();
            A_player.SelectJob();
        }
        public void Progress()
        {
            int input = 0;
            while (true)
            {
                Console.Clear();
                A_player.Render();
                Console.WriteLine("할일 정하기");
                Console.WriteLine("\n1. 사냥터 \t2. 동료");
                input = int.Parse(Console.ReadLine());

                if (input == 2)
                {
                    break;
                }
                else if (input == 1)
                {
                    Console.Clear();

                    if (A_pField == null)
                    {
                        A_pField = new Field();
                        A_pField.SetPlayer(ref A_player);
                    }
                    A_pField.Progress();
                }
            }
        }

        public MainGame()
        {

        }

        ~MainGame()
        {

        }
    }

}
