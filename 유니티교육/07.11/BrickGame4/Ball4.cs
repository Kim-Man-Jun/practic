using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame4
{
    public class Ball4
    {
        BallData4 balldata = new BallData4();

        public BallData4 GetBall() { return balldata; }     //볼데이터를 가져오는 함수

        public void SetX(int x) { balldata.nX += x; }       //공의 X값을 더해주는 함수
        public void SetY(int y) { balldata.nY += y; }       //공의 Y값을 더해주는 함수

        public void SetBall(BallData4 tBall)                //볼데이터를 전달 해주는 함수
        {
            balldata = tBall;
        }

        public void SetReady(int Ready) { balldata.nReady = Ready; }

        public void Initialize()
        {
            balldata.nReady = 1;
            balldata.nDirect = 0;
            balldata.nX = 20;
            balldata.nY = 1;
        }

        public void Progress()
        {
            if (balldata.nReady == 0)
            {
                balldata.nY++;

                if (balldata.nY > 24)
                {
                    balldata.nReady = 1;
                    balldata.nX = 20;
                    balldata.nY = 1;
                }
            }
        }

        public void Render()
        {
            Console.Clear();
            Active.gotoxy(balldata.nX, balldata.nY);
            Console.Write("▲");
        }

        public void Release()
        {

        }
    }
}
