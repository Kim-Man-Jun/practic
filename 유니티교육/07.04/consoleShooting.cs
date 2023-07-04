using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame
{
    //미사일 클래스
    public class BULLET
    {
        public int x;
        public int y;
        public bool fire;
    }
    //플레이어 클래스
    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();  //c언어 함수 가져옴

        public int playerX;  //플레이어 X좌표
        public int playerY;  //플레이어 Y좌표
        public BULLET[] playerBullet = new BULLET[20];

        public Player() //생성자
        {
            //플레이어 좌표위치 초기화
            playerX = 0;
            playerY = 12;

            for (int i = 0; i < 20; i++) //총알 초기화
            {
                playerBullet[i] = new BULLET();
                playerBullet[i].x = 0;
                playerBullet[i].y = 0;
                playerBullet[i].fire = false;
            }
        }

        public void GameMain()
        {
            //키를 입력하는 부분
            KeyControl();
            //플레이어를 그려준다.
            PlayerDraw();
        }

        void KeyControl()//키를 입력하는 부분
        {
            int pressKey; //정수형 변수선언 키값 받을거임


            if (Console.KeyAvailable) //키가 눌렸을때 true
            {
                pressKey = _getch(); //아스키값 왼쪽 오른쪽

                switch (pressKey)
                {
                    case 72:
                        //위쪽방향 아스키코드 
                        playerY--;
                        if (playerY < 1)
                            playerY = 1;
                        break;
                    case 75:
                        //왼쪽 화살표키
                        playerX--;
                        if (playerX < 0) //if문 한줄 {} 생략가능
                            playerX = 0;
                        break;
                    case 77:
                        //오른쪽
                        playerX++;
                        if (playerX > 75)
                            playerX = 75;
                        break;

                    case 80: //아래
                        playerY++;
                        if (playerY > 23)
                            playerY = 23;
                        break;

                    case 32:
                        //스페이스바 누르면 총알 발사
                        for (int i = 0; i < 20; i++)
                        {
                            //미사일이 false 발사가능
                            if (playerBullet[i].fire == false)
                            {
                                playerBullet[i].fire = true;
                                //플레이어 앞에서 미사일 쏘기 +5
                                playerBullet[i].x = playerX + 5;
                                playerBullet[i].y = playerY + 1;
                                //한발씩쏘겠다
                                break;
                            }
                        }

                        break;
                }
            }
        }

        //미사일 그리기
        public void BulletDraw()
        {
            string bullet = "->"; //미사일모습

            //20개
            for (int i = 0; i < 20; i++)
            {
                //미사일이 살아있는 상태
                if (playerBullet[i].fire == true)
                {
                    //좌표설정  -> 중간위치를위해 보정을위해 x -1
                    Console.SetCursorPosition(playerBullet[i].x - 1, playerBullet[i].y);
                    //총알 출력
                    Console.Write(bullet);

                    playerBullet[i].x++; //미사일 오른쪽으로 날라가기


                    if (playerBullet[i].x > 79) //오른쪽화면을 넘어가면
                    {
                        playerBullet[i].fire = false; //미사일 false 다시 준비상태
                    }
                }
            }



        }






        public void PlayerDraw() //플레이어 그리기
        {
            string[] player = new string[]
            {
                "->",
                ">>>",
                "->",
            }; //배열문자열로 그리기

            for (int i = 0; i < player.Length; i++)
            {
                //콘솔좌표 설정 플레이어X 플레이어Y
                Console.SetCursorPosition(playerX, playerY + i);
                //문자열배열 출력
                Console.WriteLine(player[i]);
            }


        }


        //충돌처리 
        public void ClashEnemyAndBullet(Enemy enemy)
        {
            //미사일 20개
            for (int i = 0; i < 20; i++)
            {
                //살아있는 미사일
                if (playerBullet[i].fire == true)
                {
                    //미사일과 적의 y값이 같을때 
                    if (playerBullet[i].y == enemy.enemyY)
                    {
                        if (playerBullet[i].x >= (enemy.enemyX - 1)
                            && playerBullet[i].x <= (enemy.enemyX + 1))  //충돌 
                        {
                            //충돌
                            Random rand = new Random(); //랜덤
                            enemy.enemyX = 75; //x 75
                            enemy.enemyY = rand.Next(2, 22); // 2~21
                            playerBullet[i].fire = false; // 미사일도 준비상태
                        }
                    }
                }
            }
        }


    }



    public class Enemy //적 클래스
    {
        public int enemyX;  //X좌표
        public int enemyY;  //Y좌표

        public Enemy()
        {
            //적 좌표 위치 초기화
            enemyX = 77;
            enemyY = 12;
        }

        public void EnemyDraw()//적그리기
        {
            string enemy = "<-0->"; //문자열로 표현
            Console.SetCursorPosition(enemyX, enemyY); //좌표설정
            Console.Write(enemy);//출력
        }

        public void EnemyMove()
        {
            Random rand = new Random(); //랜덤
            enemyX--; //왼쪽으로 움직임

            if (enemyX < 2) //화면 왼쪽넘어가면 새로 좌표잡아라
            {
                enemyX = 77; //좌표 77
                enemyY = rand.Next(2, 22); // 2~21
            }
        }

    }






    internal class Program
    {
        static void Main(string[] args)
        {
            //플레이어 생성
            Player player = new Player();
            Enemy enemy = new Enemy(); //적생성

            //유니티처럼 속도 프레임속도
            int dwTime = Environment.TickCount; //1/1000 초 계산값이 들어온다.

            while (true) //무한반복
            {
                //0.05 초 지연 
                if (dwTime + 50 < Environment.TickCount)
                {
                    //현재시간 세팅
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    player.BulletDraw();
                    //플레이어
                    player.GameMain();

                    enemy.EnemyDraw(); //적그리기
                    enemy.EnemyMove(); //적이동

                    //충돌처리 
                    player.ClashEnemyAndBullet(enemy);
                }
            }

        }
    }
}
