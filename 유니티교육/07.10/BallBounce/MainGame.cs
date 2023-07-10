using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BrickGame
{
    public class MainGame
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();         //객체 생성
            int Current = Environment.TickCount;        //현재 시간

            gm.Initialize();

            while (true)
            {
                if (Current + 100 < Environment.TickCount)
                {
                    Current = Environment.TickCount;
                    gm.Progress();
                    gm.Render();
                }
            }
            gm.Release();
        }
    }
}
