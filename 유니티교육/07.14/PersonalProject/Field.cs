using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class ConsoleBuffer
    {
        private readonly int fieldx;
        private readonly int fieldy;
        private char[,] backBuffer = null;
        private char[,] frontBuffer = null;

        public ConsoleBuffer(int infieldx, int infieldy)
        {
            fieldx = infieldx;
            fieldy = infieldy;
            backBuffer = new char[fieldy, fieldx];
            frontBuffer = new char[fieldy, fieldx];
            Console.SetWindowSize(fieldx, fieldy + 1);
        }

        public char[,] Buffer => backBuffer;

        private bool IsRangeOut(int inX, int inY)
        {
            if ((inX >= fieldx || inY >= fieldy) || (inX < 0 || inY < 0))
            {
                return true;
            }

            return false;
        }

        public void Draw(char inChar, int inX, int inY)
        {
            if (!IsRangeOut(inX, inY))
            {
                backBuffer[inY, inX] = inChar;
            }
        }

        public void Draw(string inStr, int inX, int inY)
        {
            char[] temp = inStr.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                if (!IsRangeOut(inX, inY))
                {
                    backBuffer[inY, inX + 1] = temp[i];
                }
            }
        }

        private void BufferExtraction()
        {
            Array.Copy(backBuffer, frontBuffer, fieldx * fieldy);
        }

        public void ClearBuffer()
        {
            Array.Clear(backBuffer, 0, fieldx * fieldy);
        }

        private void Print()
        {
            for (int y = 0; y < fieldy; y++)
            {
                for (int x = 0; x < fieldx; x++)
                {
                    Console.Write(frontBuffer[y, x]);
                }
                Console.WriteLine();
            }
        }

        public void Show()
        {
            BufferExtraction();
            Console.SetCursorPosition(0, 0);
            Print();
        }
    }


    public class Field
    {


        public FieldInfo fieldinfo = new FieldInfo();

        public void Intitialize()
        {
            fieldinfo.FieldX = 0;
            fieldinfo.FieldY = 0;
        }

        public void Render()
        {
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■                                    ■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■");
        }
    }
}
