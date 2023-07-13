using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGameFinal
{
    public class Bar
    {
        public BarData bar = new BarData();
        int m_nCatch;

        public void Initialize()
        {
            m_nCatch = 0;

            bar.nY = 18;
            bar.nX[0] = 12;
            bar.nX[1] = 14;
            bar.nX[2] = 16;
        }

        public void Progress(ref Ball pBall)
        {
            int nKey = 0;

            if (Console.KeyAvailable)
            {
                nKey = Active._getch();

                switch (nKey)
                {
                    case 75:
                        {
                            bar.nX[0]--;
                            bar.nX[1]--;
                            bar.nX[2]--;

                            if (pBall.GetBall().nReady == 1 && m_nCatch == 1)
                            {
                                pBall.SetX(-1);
                            }

                            break;
                        }

                    case 77:
                        {
                            bar.nX[0]++;
                            bar.nX[1]++;
                            bar.nX[2]++;

                            if (pBall.GetBall().nReady == 1 && m_nCatch == 1)
                            {
                                pBall.SetX(1);
                            }
                            break;
                        }
                    case 'a':
                        {
                            BallData tBall = new BallData();
                            tBall.nReady = 0;
                            tBall.nX = 20;
                            tBall.nY = 1;
                            pBall.SetBall(tBall);
                            m_nCatch = 0;
                            break;
                        }
                    case 's':
                        {
                            if (pBall.GetBall().nX >= bar.nX[0] &&
                                pBall.GetBall().nX <= bar.nX[2] + 1 &&
                                pBall.GetBall().nY == (bar.nY - 1))
                            {
                                pBall.SetReady(1);
                                m_nCatch = 1;
                            }
                            break;
                        }
                }

            }
        }

        public void Render()
        {
            for (int i = 0; i < 3; i++)
            {
                Active.gotoxy(bar.nX[i], bar.nY);
                Console.Write("▤");
            }
        }

        public void Release()
        {

        }

    }
}
