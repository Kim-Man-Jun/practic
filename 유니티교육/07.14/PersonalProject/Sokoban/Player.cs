using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Player2
    {
        int x;
        int y;
        readonly char images;

        public Player2(char inImages, int inX, int inY)
        {
            x = inX;
            y = inY;
            images = inImages;
        }

        //각 값들을 읽기 전용으로 제공하기
        public char Images => images;
        public int X => x;
        public int Y => y;

        public void SetLocation(int inX, int inY)
        {
            x = inX;
            y = inY;
        }
        public void Move(ConsoleKeyInfo inKey)
        {
            switch (inKey.Key)
            {
                case ConsoleKey.RightArrow:
                    ++x;
                    break;

                case ConsoleKey.LeftArrow:
                    --x;
                    break;

                case ConsoleKey.UpArrow:
                    --y;
                    break;

                case ConsoleKey.DownArrow:
                    ++y;
                    break;

                default:
                    return;
            }
        }
    }
}
