using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame5
{
    public class Ball
    {
        BallData m_tBall = new BallData();

        int[,] g_WallCollision = new int[4, 6]
        {
            { 3, 2, -1, -1, -1, 4},
            { -1 ,-1, -1, -1, 2, 1},
            { -1, 5, 4, -1, -1, -1},
            { -1, -1, 1, 0, 5, -1},
        };

        public void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public void Screen()
        {
            gotoxy(0, 0);
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            gotoxy(0, 1);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 2);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 3);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 4);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 5);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 6);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 7);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 8);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 9);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 10);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 11);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 12);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 13);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 14);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 15);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 16);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 17);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 18);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 19);
            Console.WriteLine("┃                                                                 ┃");
            gotoxy(0, 20);
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");

        }

        public void KeyInput()
        {
            int input;

            if (Console.KeyAvailable)
            {
                input = Active._getch();

                switch (input)
                {
                    case '0':
                        {
                            m_tBall.nDirect = 0;
                            m_tBall.nX = 30;
                            m_tBall.nY = 10;
                            break;
                        }
                    case '1':
                        {
                            m_tBall.nDirect = 1;
                            m_tBall.nX = 30;
                            m_tBall.nY = 10;
                            break;
                        }
                    case '2':
                        {
                            m_tBall.nDirect = 2;
                            m_tBall.nX = 30;
                            m_tBall.nY = 10;
                            break;
                        }
                    case '3':
                        {
                            m_tBall.nDirect = 3;
                            m_tBall.nX = 30;
                            m_tBall.nY = 10;
                            break;
                        }
                    case '4':
                        {
                            m_tBall.nDirect = 4;
                            m_tBall.nX = 30;
                            m_tBall.nY = 10;
                            break;
                        }
                    case '5':
                        {
                            m_tBall.nDirect = 5;
                            m_tBall.nX = 30;
                            m_tBall.nY = 10;
                            break;
                        }
                    case 'f':
                        {
                            m_tBall.nReady = 0;
                            break;
                        }
                    case 'r':
                        {
                            m_tBall.nReady = 1;
                            m_tBall.nX = 30;
                            m_tBall.nY = 10;
                            break;
                        }

                }
            }
        }

        public int Collision(int x, int y)      //벽과 충돌시 상태 변환 
        {
            if (y == 0)
            {
                m_tBall.nDirect = g_WallCollision[0, m_tBall.nDirect];
                return 1;
            }

            if (x == 1)
            {
                m_tBall.nDirect = g_WallCollision[1, m_tBall.nDirect];
                return 1;
            }

            if (y == 23)
            {
                m_tBall.nDirect = g_WallCollision[3, m_tBall.nDirect];
                return 1;
            }

            if (x == 77)
            {
                m_tBall.nDirect = g_WallCollision[2, m_tBall.nDirect];
                return 1;
            }

            return 0;
        }

        public void Initialize()
        {
            m_tBall.nReady = 1;
            m_tBall.nDirect = 0;
            m_tBall.nX = 30;
            m_tBall.nY = 10;
        }

        public void Progress()
        {
            KeyInput();

            if (m_tBall.nReady == 0)
            {
                switch (m_tBall.nDirect)
                {
                    case 0:
                        {
                            if (Collision(m_tBall.nX, m_tBall.nY - 1) == 0)
                            {
                                m_tBall.nY--;
                            }
                        }
                        break;

                    case 1:     //오른쪽 위
                        {
                            if (Collision(m_tBall.nX + 1, m_tBall.nY - 1) == 0)
                            {
                                m_tBall.nX++;
                                m_tBall.nY--;
                            }
                        }
                        break;

                    case 2:     //오른쪽 아래
                        {
                            if (Collision(m_tBall.nX + 1, m_tBall.nY + 1) == 0)
                            {
                                m_tBall.nX++;
                                m_tBall.nY++;
                            }
                        }
                        break;

                    case 3:     //아래
                        {
                            if (Collision(m_tBall.nX, m_tBall.nY + 1) == 0)
                            {
                                m_tBall.nY++;
                            }
                        }
                        break;

                    case 4:     //왼쪽 아래
                        {
                            if (Collision(m_tBall.nX - 1, m_tBall.nY + 1) == 0)
                            {
                                m_tBall.nX--;
                                m_tBall.nY++;
                            }
                        }
                        break;

                    case 5:     //왼쪽 위
                        {
                            if (Collision(m_tBall.nX - 1, m_tBall.nY - 1) == 0)
                            {
                                m_tBall.nX--;
                                m_tBall.nY--;
                            }
                        }
                        break;
                }
            }
        }

        public void Render()
        {
            Screen();
            gotoxy(m_tBall.nX, m_tBall.nY);
            Console.Write("○");
        }

        public void Release()
        {

        }


    }
}
