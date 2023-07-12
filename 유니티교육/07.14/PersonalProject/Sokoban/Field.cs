using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Field2
    {
        public List<int[,]> stages = new List<int[,]>();

        private readonly char wall = '■';
        private readonly char box = '○';
        private readonly char goal = '◎';
        private readonly char road = '▤';
        private readonly char goalbox = '●';

        public Field2()
        {
            AddStage();
        }

        public char Wall => wall;
        public char Box => box;
        public char Goal => goal;
        public char Road => road;
        public char Goalbox => goalbox;

        public int[,] stage1 = new int[8, 8]
        {
            { 0,0,1,1,1,0,0,0 },
            { 0,0,1,3,1,0,0,0 },
            { 0,0,1,0,1,1,1,1 },
            { 1,1,1,2,0,2,3,1 },
            { 1,3,0,2,0,1,1,1 },
            { 1,1,1,1,2,1,0,0 },
            { 0,0,0,1,3,1,0,0 },
            { 0,0,0,1,1,1,0,0,},
        };

        public int[,] stage2 = new int[7, 10]
        {
            {0,1,1,1,1,1,1,1,0,0},
            {0,1,0,0,0,0,0,1,1,1},
            {1,1,2,1,1,1,0,0,0,1},
            {1,0,0,0,2,0,0,2,0,1},
            {1,0,3,3,1,0,2,0,1,1},
            {1,1,3,3,1,0,0,0,1,0},
            {0,1,1,1,1,1,1,1,1,0},
        };

        public void SetMap(int[,] inMap, char[,] inBuf)
        {
            for (int y = 0; y < inMap.GetLength(0); y++)
            {
                for (int x = 0; x < inMap.GetLength(1); x++)
                {
                    if (inMap[y, x] == 0)
                    {
                        inBuf[y, x] = road;
                    }
                    else if (inMap[y, x] == 1)
                    {
                        inBuf[y, x] = wall;
                    }
                    else if (inMap[y, x] == 2)
                    {
                        inBuf[y, x] = box;
                    }
                    else if (inMap[y, x] == 3)
                    {
                        inBuf[y, x] = goal;
                    }
                }
            }
        }

        public void AddStage()
        {
            stages.Add(stage1);
            stages.Add(stage2);
        }

        public int GetGoalCount(int[,] inMap)
        {
            int goalCount = 0;

            for (int y = 0; y < inMap.GetLength(0); y++)
            {
                for (int x = 0; x < inMap.GetLength(1); x++)
                {
                    if (inMap[y, x] == 3)
                    {
                        goalCount++;
                    }
                }
            }
            return goalCount;
        }

        public bool IsWall(char[,] inMap, int inX, int inY)
        {
            return GetPoint(inMap, inX, inY) == wall ? true : false;
        }
        public bool IsBox(char[,] inMap, int inX, int inY)
        {
            return GetPoint(inMap, inX, inY) == box ? true : false;
        }
        public bool IsGoalBox(char[,] inMap, int inX, int inY)
        {
            return GetPoint(inMap, inX, inY) == goalbox ? true : false;
        }
        public bool IsGoal(char[,] inMap, int inX, int inY)
        {
            return GetPoint(inMap, inX, inY) == goal ? true : false;
        }
        private char GetPoint(char[,] inMap, int inX, int inY)
        {
            return inMap[inY, inX];
        }
    }
}
