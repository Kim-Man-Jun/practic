using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpgGame;

namespace TextRpgGame
{
    public class Field
    {
        Player m_pPlayer = null;
        
        public void SetPlayer(ref Player pPlayer)
        {
            m_pPlayer = pPlayer;
        }

        public void Progress()
        {
            int iInput = 0;

            while (true)
            {
                Console.Clear();

                m_pPlayer.Render();
                DrawMap();
                iInput = int.Parse(Console.ReadLine());

                if (iInput == 4)
                {
                    break;
                }

                if (iInput <= 3)
                {
                    //몬스터를 만들고
                    //전투까지
                }

            }
        }

        public void DrawMap()
        {
            Console.WriteLine("1. 초보맵");
            Console.WriteLine("2. 중수맵");
            Console.WriteLine("3. 고수맵");
            Console.WriteLine("4. 전단계");
            Console.WriteLine("=====================================");
            Console.WriteLine("맵을 선택하세요");
        }

        public Field()
        {

        }
        ~Field()
        {

        }
    }
}
