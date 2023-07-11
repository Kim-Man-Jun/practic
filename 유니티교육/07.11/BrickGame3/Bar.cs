using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BrickGame3
{
    public class Bar
    {
        BarData bardata = new BarData();

        public void Initialize()
        {
            bardata.nX[0] = 12;
            bardata.nX[1] = 14;
            bardata.nX[2] = 16;
            bardata.nY = 16;
        }

        public void Progress()
        {
            int nKey = 0;

            if (Console.KeyAvailable)
            {
                nKey = Active._getch();

                switch (nKey)
                {
                    case 75:
                        {
                            bardata.nX[0] -= 10;
                            bardata.nX[1] -= 10;
                            bardata.nX[2] -= 10;
                            break;
                        }
                    case 77:
                        {
                            bardata.nX[0] += 10;
                            bardata.nX[1] += 10;
                            bardata.nX[2] += 10;
                            break;
                        }
                }
            }
        }

        public void Render()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                gotoxy(bardata.nX[i], bardata.nY);
                Console.Write("▒");
            }
        }

        public void Release()
        {

        }

        public void gotoxy(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}
