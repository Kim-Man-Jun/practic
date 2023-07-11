using SnakeGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Player
    {
        public PlayerInfo player = new PlayerInfo();

        public int StageX = 35;
        public int StageY = 24;

        public void KeyInput()
        {
            int inputkey;

            if (Console.KeyAvailable)
            {
                inputkey = Active._getch();

                switch (inputkey)
                {
                    case 72:            //위쪽 방향키
                        {
                            player.PlayerDirect = 1;
                            break;
                        }
                    case 75:            //왼쪽 방향키
                        {
                            player.PlayerDirect = 3;
                            break;
                        }
                    case 77:            //오른쪽 방향키
                        {
                            player.PlayerDirect = 4;
                            break;
                        }
                    case 80:            //아래쪽 방향키
                        {
                            player.PlayerDirect = 2;
                            break;
                        }

                }
            }
        }

        public void Intitialize()
        {
            player.PlayerX = 10;
            player.PlayerY = 10;
            player.PlayerSpeed = 2;
            player.PlayerDirect = 0;
        }

        public void Progress()
        {
            KeyInput();

            if (player.PlayerDirect == 1)
            {
                player.PlayerY -= player.PlayerSpeed;
            }
            else if (player.PlayerDirect == 2)
            {
                player.PlayerY += player.PlayerSpeed;
            }
            else if (player.PlayerDirect == 3)
            {
                player.PlayerX -= player.PlayerSpeed;
            }
            else if (player.PlayerDirect == 4)
            {
                player.PlayerX += player.PlayerSpeed;
            }

            if (player.PlayerX > StageX)
            {
                player.PlayerX = StageX;
                Environment.Exit(0);
            }
            if (player.PlayerY > StageY - 1)
            {
                player.PlayerY = StageY - 1;
                Environment.Exit(0);
            }
            if (player.PlayerX < 1)
            {
                player.PlayerX = 1;
                Environment.Exit(0);
            }
            if (player.PlayerY < 1)
            {
                player.PlayerY = 1;
                Environment.Exit(0);
            }
        }

        public void Render()
        {
            KeyInput();
            Console.Clear();
            gotoxy(player.PlayerX, player.PlayerY);
            Console.Write("●");

            /*
            if (player.PlayerDirect == 1)
            {
                gotoxy(player.PlayerX, player.PlayerY + 1);
                Console.Write("■");
            }
            else if (player.PlayerDirect == 2)
            {
                gotoxy(player.PlayerX, player.PlayerY - 1);
                Console.Write("■");
            }
            else if (player.PlayerDirect == 3)
            {
                gotoxy(player.PlayerX + 1, player.PlayerY);
                Console.Write("■");
            }
            else if (player.PlayerDirect == 4)
            {
                gotoxy(player.PlayerX - 1, player.PlayerY);
                Console.Write("■");
            }
            */
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



