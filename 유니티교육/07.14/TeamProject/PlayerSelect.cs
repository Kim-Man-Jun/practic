using _07._14_TeamProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TeamProject
{
    public class PlayerSelect
    {
        Item Item = null;
        PlayerInfo m_player;
        PowerUp powerUp = new PowerUp();
        Potion potion = new Potion();
        KuemGangBul kGB = new KuemGangBul();
        public void SelectJob()
        {
            m_player = new PlayerInfo();

            Console.WriteLine("※주인공을 선택해주세요.※");
            Console.WriteLine("────────────────────────────────────────────┐");
            Console.WriteLine("1번\t\t\t\t\t    │");
            Console.WriteLine("이름 : 속사의 잭\t\t\t    │");
            Console.WriteLine("체력 : 3 \t 공격력 : 3\t\t    │");
            Console.WriteLine("────────────────────────────────────────────┤");
            Console.WriteLine("2번\t\t\t\t\t    │");
            Console.WriteLine("이름 : 정밀의 딘\t\t\t    │");
            Console.WriteLine("체력 : 2 \t 공격력 : 5\t\t    │");
            Console.WriteLine("────────────────────────────────────────────┤");
            Console.WriteLine("3번\t\t\t\t\t    │");
            Console.WriteLine("이름 : 보안관 슈나이더\t\t\t    │");
            Console.WriteLine("체력 : 5 \t 공격력 : 1\t\t    │");
            Console.WriteLine("────────────────────────────────────────────┘");

            int input = 0;
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    {
                        m_player.PlayerName = "속사의 잭";
                        m_player.PlayerHP = 3;
                        m_player.PlayerATK = 3;
                        m_player.PotionCT = 0;
                        m_player.CurPlayerHP = 3;
                        break;
                    }
                case 2:
                    {
                        m_player.PlayerName = "정밀의 딘";
                        m_player.PlayerHP = 2;
                        m_player.PlayerATK = 5;
                        m_player.PotionCT = 0;
                        m_player.CurPlayerHP = 2;
                        break;
                    }
                case 3:
                    {
                        m_player.PlayerName = "보안관 슈나이더";
                        m_player.PlayerHP = 5;
                        m_player.PlayerATK = 1;
                        m_player.PotionCT = 0;
                        m_player.CurPlayerHP = 5;

                        break;
                    }
            }
        }

        

        public void Render()
        {
            Console.WriteLine("─────────────────────────────────────────────────┐");
            Console.WriteLine("직업 이름 : " + m_player.PlayerName+"\t\t\t\t │" );
       
            Console.WriteLine("체력 : " + m_player.CurPlayerHP + "  공격력 : " + m_player.PlayerATK + "  소지금 : " + Money.Instance().GetMoney() + "  포션 :" + m_player.PotionCT);
        

            GameManager.Instance().SetPlayer(m_player);
        }
         
        public PlayerSelect()
        {

        }

        ~PlayerSelect()
        {

        }

    }
}
