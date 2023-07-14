using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject;

namespace _07._14_TeamProject
{
    internal class Field
    {
        //얘 끄면 오류남. 왜지 ?
        //Enemy enemy = new Enemy();
        Potion potion = new Potion();
        //합친부분
        public void Render()
        {
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■              ■■              ■■              ■■              ■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

            ScoreRender();
        }

        public void ScoreRender()
        {
            //플레이어 출력
      
            Console.WriteLine("\n플레이어 : " + GameManager.Instance().GetInfoPlayer().PlayerName + "\t체력 : " 
                + GameManager.Instance().GetInfoPlayer().CurPlayerHP +  "\t공격력 : " + GameManager.Instance().GetInfoPlayer().PlayerATK +
                "\t소지금: " + Money.Instance().GetMoney() + "\t 포션:" + GameManager.Instance().GetInfoPlayer().PotionCT);

            //적 출력
            Console.WriteLine("\n" + GameManager.Instance().GetInfoEnemy().enemyName +"단계" + "\t체력 : "
                + GameManager.Instance().GetInfoEnemy().enemyHP + "\t공격력 : " + GameManager.Instance().GetInfoEnemy().enemyATK );

            //게임 이동을 위한
            Console.WriteLine("\nq : 나가기");
        }
    }
}
