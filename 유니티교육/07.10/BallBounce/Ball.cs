using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BrickGame
{
    public class Ball
    {
        //좌표
        private Info info = new Info();

        public int FieldX = 100;
        public int FieldY = 30;

        public int p_mX = 10;
        public int p_mY = 10;

        public int p_minusX = 1;
        public int p_minusY = 1;

        public void Intitialize()       //초기화 해주는 메서드
        {
            info.m_nX = 0;
            info.m_nY = 0;
        }

        public void Progress()      //움직임 관련 메서드
        {
            info.m_nX += p_mX * p_minusX;
            info.m_nY += p_mY * p_minusY;

            if (info.m_nX >= FieldX)    //공 X,Y축이 필드를 넘어갔을 때
            {
                if (p_minusX >= 0)
                {
                    p_minusX = -1;
                }
            }
            else if (info.m_nY >= FieldY)
            {
                if (p_minusY > 0)
                {
                    p_minusY = -1;
                }
            }
            else if (info.m_nX <= 0)
            {
                if (p_minusX < 0)
                {
                    p_minusX = 1;
                }
            }
            else if (info.m_nY <= 0)
            {
                if (p_minusY < 0)
                {
                    p_minusY = 1;
                }
            }
        }

        public void Render()        //화면에 그려주는 메서드
        {
            Console.Clear();
            gotoxy(info.m_nX, info.m_nY);       //공의 좌표 설정
            Console.Write("●");
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
