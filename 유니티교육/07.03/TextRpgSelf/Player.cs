using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _06._30_RPG_TEST
{
    public class Player
    {
        public Infomation p_player;

        public void SelectJob()
        {
            p_player = new Infomation();

            Console.WriteLine("직업 선택 창");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 법사");
            Console.WriteLine("3. 도적");
            int input = 0;
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    {
                        p_player.Job = "기사";
                        p_player.HP = 100;
                        p_player.ATK = 10;
                        break;
                    }
                case 2:
                    {
                        p_player.Job = "법사";
                        p_player.HP = 80;
                        p_player.ATK = 15;
                        break;
                    }
                case 3:
                    {
                        p_player.Job = "도적";
                        p_player.HP = 85;
                        p_player.ATK = 13;
                        break;
                    }
            }
        }
        public void Render()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("직업 : " + p_player.Job);
            Console.WriteLine("체력 : " + p_player.HP + "\t공격력 : " + p_player.ATK);
            Console.WriteLine("==========================================\n");
        }

        public Player()
        {

        }

        ~Player()
        {

        }
    }
}
