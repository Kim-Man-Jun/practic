using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TeamProject;

namespace _07._14_TeamProject
{
    //합친부분
    internal class Player
    {
        //현숙추가. 플레이어의 정보를 받아오기 위해서
        /*PlayerInfo m_player;
        public void SetPlayer(PlayerInfo setInfo) { m_player = setInfo; }
        public PlayerInfo GetInfo() { return m_player; }*/
        Potion potion = new Potion();
        public BulletInfo[] bulletInfo = new BulletInfo[10];
        public FieldInfo fieldInfo = new FieldInfo();

        public int playerX;     //플레이어 위치 초기화
        public int playerY;     //플레이어 위치 초기화

        //현숙추가. 종료를 위한 변수
        public bool endCheck = false;
        public bool shopCheck = false;

        public void GameMain()
        {
            //키를 입력하는 부분
            Keycontrol();
            //플레이어를 그려준다.
            PlayerDraw();
        }

        public Player()
        {
            playerX = 20;       //플레이어 초기 위치
            playerY = 39;       //플레이어 초기 위치

            for (int i = 0; i < 10; i++)
            {
                bulletInfo[i] = new BulletInfo();       //총알 객체 생성
                bulletInfo[i].x = 0;                    //총알 초기 위치
                bulletInfo[i].y = 0;                    //총알 초기 위치
                bulletInfo[i].fire = false;             //총알 발사 여부
            }
        }

        void Keycontrol()
        {
            int input = 0;

            if (Console.KeyAvailable)                   //방향키가 눌릴때
            {
                input = Active._getch();

                switch (input)
                {
                    case 75:        //왼쪽 방향키
                        {
                            playerX -= 2;              //플레이어 수치만큼 이동

                            if (playerX < 3)
                            {
                                playerX = 3;            //이동 제한
                            }
                            break;
                        }
                    case 77:        //오른쪽 방향키
                        {
                            playerX += 2;              //플레이어 수치만큼 이동

                            if (playerX > fieldInfo.fieldX)
                            {
                                playerX = 57;           //이동 제한
                            }
                            break;
                        }

                    case 32:        //스페이스바
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                if (bulletInfo[i].fire == false)
                                {
                                    bulletInfo[i].fire = true;
                                    bulletInfo[i].x = playerX  ;
                                    bulletInfo[i].y = playerY + 1;
                                    break;
                                }
                            }
                            break;
                        }
                    case 'q':
                        Console.WriteLine("나가자");
                        // 게임 나가고 싶음 -> 상점으로 나가고 싶음
                        //endCheck = true;
                        shopCheck = true;
                        break;
                    case 'f':
                        if (GameManager.Instance().GetInfoPlayer().PotionCT != 0 && GameManager.Instance().GetInfoPlayer().CurPlayerHP != GameManager.Instance().GetInfoPlayer().PlayerHP)
                        {
                            GameManager.Instance().GetInfoPlayer().PotionCT -= 1;
                            GameManager.Instance().GetInfoPlayer().CurPlayerHP += 1;
                        }

                        break;
                    case 'r':
                            GameManager.Instance().GetInfoPlayer().CurPlayerHP -= 1;
                            break;

                        /*case 's': //보류\
                         * 
                            shopCheck = true;
                            break;*/
                }
            }
        }

        //총알 모습 그리기
            public void BulletDraw(Enemy enemy)
            {

                string[] bullet = new string[]                  
                {
                    "▲"
                };
                for (int i = 0; i < 10; i++)
                {
                    if (bulletInfo[i].fire == true)
                    {
                        for (int j = 0; j < bullet.Length; j++)
                        {
                            Console.SetCursorPosition(bulletInfo[i].x, bulletInfo[i].y);
                            Console.WriteLine(bullet[j]);
                        }

                        bulletInfo[i].y --;
                   
                        if (bulletInfo[i].y < 1)
                        {
                            bulletInfo[i].fire = false;
                        }
                        
                        //Enemy 충돌처리
                    else
                    {
                        
                        if (bulletInfo[i].x == enemy.enemyX && bulletInfo[i].y
                            == enemy.enemyY)
                        {
                            bulletInfo[i].fire = false;
                            enemy.TakeDamage();
                        }
                        //충돌처리 끝
                    }
                }
                }
            }
        //총알 끝

        //플레이어 모습 그리기
        public void PlayerDraw()
        {
            string[] player = new string[]
            {
                "■",
                //"┏━━━━━━━┓",
                //"┃       ┃",
                //"┃       ┃",
                //"┗━━━━━━━┛"
            };

            for (int i = 0; i < player.Length; i++)
            {
                Console.SetCursorPosition(playerX, playerY + i);
                Console.WriteLine(player[i]);
            }
        }


        //불렛 시작

      

        //불렛 끝


        //플레이어 전투
        //플레이어가 적에 닿았을때
        public void CheckCollision(Enemy enemy)
        {
            if (enemy.enemyX == playerX && enemy.enemyY == playerY)
            {
       
                
                enemy.HitPlayer();
          
            }
        }


        //플레이어 전투 끝

        #region 전투 -> MainGame 클래스로 이동함
        /*internal class Program
        {
            static void Main(string[] args)
            {
                //플레이어 생성
                Player player = new Player();
                Field field = new Field();
                Enemy enemy = new Enemy();

                int cur = Environment.TickCount;

                while (true)
                {
                    if (cur + 200 < Environment.TickCount)
                    {
                        cur = Environment.TickCount;
                        Console.Clear();

                        field.Render();
                        player.BulletDraw();
                        player.GameMain();
                        enemy.EnemyDraw();
                        enemy.EnemyCreate();
                        enemy.EnemyMove();

                    }
                }
            }
        }*/
        #endregion
    }
}
