using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame4
{
    public class GameManager
    {
        Ball4 m_pBall = null;
        Bar4 m_pBar = null;

        public void Initialize()
        {
            m_pBall = new Ball4();
            m_pBar = new Bar4();

            m_pBall.Initialize();
            m_pBar.Initialize();
        }

        public void Progress()
        {
            m_pBall.Progress();
            m_pBar.Progress(ref m_pBall);
        }

        public void Render()
        {
            m_pBall.Render();
            m_pBar.Render();
        }

        public void Release()
        {
            m_pBall = null;
            m_pBar = null;
        }
    }
}
