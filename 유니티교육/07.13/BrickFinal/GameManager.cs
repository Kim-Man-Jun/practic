using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BrickGameFinal
{
    public class GameManager
    {
        Ball m_pBall = null;
        Block m_pBlock = null;
        Bar m_pBar = null;

        public void Initialize()
        {
            if (m_pBall == null)
            {
                m_pBall = new Ball();
                m_pBall.Initialize();
            }
            if (m_pBlock == null)
            {
                m_pBlock = new Block();
                m_pBlock.Initialize();
            }
            if (m_pBar == null)
            {
                m_pBar = new Bar();
                m_pBar.Initialize();
            }

            m_pBall.SetBar(m_pBar);
            m_pBall.SetBlock(ref m_pBlock);
        }

        public void Progress()
        {
            m_pBall.Progress();
            m_pBlock.Progress();
            m_pBar.Progress(ref m_pBall);
        }

        public void Render()
        {
            Console.Clear();
            m_pBall.Render();
            m_pBlock.Render();
            m_pBar.Render();
        }

        public void Release()
        {

        }

    }
}
