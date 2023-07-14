using _07._14_TeamProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace TeamProject
{
    public class MainGame
    {
        public PlayerSelect Player = null;
        public Shop shop = new Shop();

        Player player = new Player();
        Field field = new Field();
        Enemy enemy = new Enemy();

        public void Initialize()
        {
            Player = new PlayerSelect();
            Player.SelectJob();
        }

        public void Progress()
        {
            int Input = 0;
            
            while (true)
            {
                Console.Clear();
                Player.Render();
                Console.WriteLine("─────────────────────────────────────────────────┘");
                Console.WriteLine("1. 상점 \t2. 사냥터");
                Input = int.Parse(Console.ReadLine());

                if (Input == 1)
                {

                    if (shop == null)
                    {
                        shop = new Shop();
                        shop.SetPlayer(ref Player);

                    }
                    shop.Progress();
                }

                if (Input == 2)
                {
                    //사냥터가면 단계 체크 후 싸우러 가기
                    FightSetting();
                }
            }
        }

        //적 필드 (단계 넣어주기)
        public void Fight(int num)
        {
            //플레이어 생성 -> 위에 선언
            /*Player player = new Player();
            Field field = new Field();
            Enemy enemy = new Enemy();*/

            int cur = Environment.TickCount;

            while (true)
            {
                if (cur + 200 < Environment.TickCount)
                {
                    cur = Environment.TickCount;
                    Console.Clear();

                    //필드 그려주고
                    field.Render();

                    //플레이어 나오고
                    player.BulletDraw(enemy);
                    player.GameMain();
                    player.CheckCollision(enemy);
                    //적 생성
                    enemy.EnemyDraw();
                    //enemy.EnemyCreate();
                    enemy.EnemyMove();

                    if(GameManager.Instance().GetInfoEnemy().enemyHP <= 0)
                    {
                        Money.Instance().AddMoney(1000);
                        break;
                    }
                    if (GameManager.Instance().GetInfoPlayer().CurPlayerHP <= 0)
                    {
                        GameManager.Instance().GetInfoPlayer().CurPlayerHP = GameManager.Instance().GetInfoPlayer().PlayerHP;
                        break;
                    }
                    //키입력받아서 다른데서 가져올 수 있도록 해보기
                    if(player.shopCheck == true)
                    {
                        break;
                    }
                }
            }
        }

        // 싸우기
        public void FightSetting()
        {

            while (true)
            {
                //초기화
                /*if(player.endCheck == true)
                {
                    player.endCheck = false;
                }*/

                if(player.shopCheck == true)

                {
                    player.shopCheck = false;
                    //shpp으로 가기 위해
                    break;
                }

                Console.Clear();
                Player.Render();
                Console.WriteLine("─────────────────────────────────────────────────┘");
                Console.WriteLine("[1] 1단계  [2] 뒤로가기" );

                int  num = int.Parse(Console.ReadLine());

                if(num == 1)
                {
                    if(GameManager.Instance().GetInfoEnemy().enemyHP <= 0)
                    {
                        GameManager.Instance().GetInfoEnemy().enemyHP = 30;

                    }
                    Console.Clear();
                    Fight(num);
                }
                else
                {
                    break;
                }
            }
        }



    }
}
