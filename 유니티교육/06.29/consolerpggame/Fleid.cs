using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpgGame;

namespace TextRpgGame
{
    public class Field
    {
        Player m_pPlayer = null;
        Monster m_pMonster = null;

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
                    CreateMonster(iInput);
                    Fight();
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

        //생성을 도와주는 함수
        //공장처럼 찍어냄
        //팩토리 메서드 패턴

        public void Create(string _strName, int _iHp, int _iAttack, out Monster pMonster)
        {
            pMonster = new Monster();
            INFO tMonster = new INFO();

            tMonster.strName = _strName;
            tMonster.iHP = _iHp;
            tMonster.iAttack = _iAttack;

            pMonster.SetMonster(tMonster);

        }

        public void CreateMonster(int input)
        {
            switch (input)
            {
                case 1:
                    {
                        Create("초보몹", 30, 3, out m_pMonster);
                        break;
                    }
                case 2:
                    {
                        Create("중수몹", 60, 6, out m_pMonster);
                        break;
                    }
                case 3:
                    {
                        Create("고수몹", 90, 9, out m_pMonster);
                        break;
                    }
            }
        }


        public void Fight()
        {
            int iInput = 0;
            while (true)
            {
                Console.Clear();
                m_pPlayer.Render();
                m_pMonster.Render();

                Console.WriteLine("1. 공격 2. 도망 : ");
                iInput = int.Parse(Console.ReadLine());

                if (iInput == 1)
                {
                    m_pPlayer.SetDamage(m_pMonster.GetMonster().iAttack);       //플레이어 데미지 주기, 몬스터 공격력 넣어서 데미지
                    m_pMonster.SetDamage(m_pPlayer.GetInfo().iAttack);          //몬스터 데미지 추가, 플레이어 공격력 넣기

                    if (m_pPlayer.GetInfo().iHP <= 0)
                    {
                        m_pPlayer.SetHp(100);
                        break;
                    }
                }

                if (iInput == 2 || m_pMonster.GetMonster().iHP <= 0)
                {
                    m_pMonster = null;
                    break;
                }
            }
        }

        public Field()
        {

        }
        ~Field()
        {

        }
    }
}
