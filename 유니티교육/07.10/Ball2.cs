using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BrickGame
{
    public class Ball2
    {
        //좌표
        private Info2 info = new Info2();

        private int BlockX= 15;
        private int BlockY;

        public void KeyInput()
        {
            int nKey;

            if (Console.KeyAvailable)
            {
                nKey = BlockGame2._getch();     //키가 눌리면 아스키코드 값을 가져온다.

                switch (nKey)
                {
                    case '0':
                        {
                            info.m_nDirect = 0;
                            info.m_nX = 30;
                            info.m_nY = 10;
                            break;
                        }
                    case '1':
                        {
                            info.m_nDirect = 1;
                            info.m_nX = 30;
                            info.m_nY = 10;
                            break;
                        }
                    case '2':
                        {
                            info.m_nDirect = 2;
                            info.m_nX = 30;
                            info.m_nY = 10;
                            break;
                        }
                    case '3':
                        {
                            info.m_nDirect = 3;
                            info.m_nX = 30;
                            info.m_nY = 10;
                            break;
                        }
                    case '4':
                        {
                            info.m_nDirect = 4;
                            info.m_nX = 30;
                            info.m_nY = 10;
                            break;
                        }
                    case '5':
                        {
                            info.m_nDirect = 5;
                            info.m_nX = 30;
                            info.m_nY = 10;
                            break;
                        }
                    case 'f':
                        {
                            info.m_nReady = 0;
                            break;
                        }
                }
            }
        }
        public void Intitialize()       //초기화 해주는 메서드
        {
            info.m_nReady = 1;          //1: 준비상태 0: 움직이는 상태
            info.m_nDirect = 0;
            info.m_nX = 30;
            info.m_nY = 10;
            info.m_nSpeed = 1;
        }

        public void Progress()      //움직임 관련 메서드
        {
            KeyInput();
            if (info.m_nReady == 0)      //움직이는 상태
            {
                switch (info.m_nDirect)
                {
                    case 0: //위
                        {
                            info.m_nY -= info.m_nSpeed;
                            break;
                        }
                    case 1: //오른쪽 위
                        {
                            info.m_nX += info.m_nSpeed;
                            info.m_nY -= info.m_nSpeed;
                            break;
                        }
                    case 2: //오른쪽 아래
                        {
                            info.m_nX += info.m_nSpeed;
                            info.m_nY += info.m_nSpeed;
                            break;
                        }
                    case 3: //아래
                        {
                            info.m_nY += info.m_nSpeed;
                            break;
                        }
                    case 4: //왼쪽 아래
                        {
                            info.m_nX -= info.m_nSpeed;
                            info.m_nY += info.m_nSpeed;
                            break;
                        }
                    case 5: //왼쪽 위
                        {
                            info.m_nX -= info.m_nSpeed;
                            info.m_nY -= info.m_nSpeed;
                            break;
                        }
                }
                if (info.m_nY < 1 || info.m_nX > 79 || info.m_nX < 1 || info.m_nY > 23)
                {
                    info.m_nReady = 1;
                    info.m_nX = 30;
                    info.m_nY = 10;
                    info.m_nDirect = 0;
                }

            }
        }

        public void Render()        //화면에 그려주는 메서드
        {
            Console.Clear();
            gotoxy(info.m_nX, info.m_nY);       //공의 좌표 설정
            Console.Write("●");

            gotoxy(BlockX, BlockY);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■");
            gotoxy(BlockX, BlockY+1);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■");
        }

        public void Release()       //시작이나 종료 후 처리해주는 메서드
        {

        }

        public void gotoxy(int x, int y)        //좌표 메서드
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
