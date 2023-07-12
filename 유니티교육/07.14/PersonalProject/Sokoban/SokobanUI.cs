using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sokoban
{
    class SokobanUI
    {
        public void DrawText(char[,] inCharArr, char inChar, int inX, int inY)
        {
            inCharArr[inY, inX] = inChar;
        }

        public void DrawText(char[,] inCharArr, string inStr, int inX, int inY)
        {
            char[] temp = inStr.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                inCharArr[inY, inX + 1] = temp[i];
            }
        }

        public void WriteUI(char[,] inCharArr)
        {
            DrawText(inCharArr, "Stage   : ", 1, 12);
            DrawText(inCharArr, "Move    : ", 1, 13);
            DrawText(inCharArr, "Player  : ", 1, 15);
            DrawText(inCharArr, "Wall    : ", 1, 16);
            DrawText(inCharArr, "Box     : ", 1, 17);
            DrawText(inCharArr, "Goal    : ", 1, 18);
            DrawText(inCharArr, "GoalBox : ", 1, 19);
            DrawText(inCharArr, "Reset : ", 20, 15);
            DrawText(inCharArr, "Quit  : ", 20, 16);
        }

    }
}
