using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _07._14_TeamProject
{
    //합친부분
    internal class Enemy
    {
        EnemyInfo enemyInfo = new EnemyInfo();
        public bool shopCheck = false;
        public int enemyX;
        public int enemyY;

        //Enemy Info 시작
        public EnemyInfo GetInfo() { return enemyInfo; }
        private readonly int[] spawnPositions = { 20 };
        private readonly Random rand = new Random();
        //Enemy Info 끝

        public Enemy()
        {
            enemyX = 20;
            enemyY = 3;
            enemyInfo.enemyHP = 30;
            enemyInfo.enemyATK = 1;
            GameManager.Instance().SetEnmey(enemyInfo);
        }

        public void EnemyDraw()
        {
            if (GameManager.Instance().GetInfoEnemy().enemyHP >= 0)
            {
                string enemy = "◎";
                Console.SetCursorPosition(enemyX, enemyY);
                Console.WriteLine(enemy);

            }
        }

        public void EnemyMove()
        {
            enemyY++;

            if( enemyY > 42)
            {
                enemyY = 3;
                enemyX = spawnPositions[rand.Next(spawnPositions.Length)];
            }
        }

        public void TakeDamage()
        {
            GameManager.Instance().GetInfoEnemy().enemyHP -=
                GameManager.Instance().GetInfoPlayer().PlayerATK; 

            if (GameManager.Instance().GetInfoEnemy().enemyHP <= 0)
            {
                Console.SetCursorPosition(enemyX, enemyY);
                Console.WriteLine("X"); // 사망 시 X 표시
            }
        }

        public void HitPlayer()
        {
            GameManager.Instance().GetInfoPlayer().CurPlayerHP -=
                   GameManager.Instance().GetInfoEnemy().enemyATK;

          
        }
        //

    }
}
