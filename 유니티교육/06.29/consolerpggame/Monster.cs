using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRpgGame;

namespace TextRpgGame
{
    public class Monster
    {
        public INFO m_tMonster;     //몬스터 데이터 생성
        public void SetDamage(int iAttack) { m_tMonster.iHP -= iAttack; }      //돌아오는 인자값으로 HP감소
        public void SetMonster(INFO tMonster) { m_tMonster = tMonster; }        //INFO클래스 타입 인자로 몬스터데이터를 넣어줌
        public INFO GetMonster() { return m_tMonster; }

        public void Render()        //몬스터의 내용 출력
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("몬스터 이름 : " + m_tMonster.strName);
            Console.WriteLine("체력 : " + m_tMonster.iHP + "\t 공격력" + m_tMonster.iAttack);
        }

        public Monster() { }        //기본생성자
        ~Monster() { }              //소멸자
    }
}
