using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    public class GameManager
    {
        Ball pBall = null;

        public void Initialize()
        {
            pBall = new Ball();
            pBall.Intitialize();
        }

        public void Progress()
        {
            pBall.Progress();
        }

        public void Render()
        {
            pBall.Render();
        }

        public void Release()
        {
            pBall.Release();
        }
    }
}
